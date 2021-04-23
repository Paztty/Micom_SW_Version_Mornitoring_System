﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MSWS_watch
{
    public class MySQLDatabase
    {
        private static string connectionStr = @"Data Source=172.22.17.241;Initial Catalog=Tech;User ID=micom;Password=tech@12";
        SqlConnection connection = new SqlConnection(connectionStr);
        public MySQLDatabase(){
            if (File.Exists("databaseConfig.txt"))
            {
                connectionStr = File.ReadAllText("databaseConfig.txt") + ";Initial Catalog=Tech;User ID=micom;Password=tech@12";
            }
            else
            {
                File.WriteAllText("databaseConfig.txt", connectionStr.Substring(0, connectionStr.IndexOf(';')));
            }
        }
        public MySQLDatabase(string connectionStr)
        {
            this.connection = new SqlConnection(connectionStr);
        }
        public bool Connect()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public void UpdateRunStopStatus(string status, string line)
        {
            //UPDATE "Tech"."dbo"."MicomVersionMornitor" SET "PCB Code"='PCB1', "PBA Code"='1', "Main Micom Assy Code"='1', "Main Micom Checksum"='1', "Main Micom Version"='1', "Inv Micom Assy Code"='1', "Inv Micom Checksum"='1', "Inv Micom Version"='1', "Time Change"='2/10/2021 15:38' WHERE  "Line"='DISPLAY_1';
            string CommandText = "UPDATE MicomVersionMornitor SET " +
            "Status = '" + status + "'" +
            "WHERE Line = '" + line + "';";

            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    Cmd.ExecuteNonQuery();
                    updateChange("MicomVersionMornitor", myConnection);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                myConnection.Close();
            }
        }
        public void getLineList(List<string> lineList)
        { 
            lineList.Clear();
            string CommandText = "SELECT * FROM MicomVersionMornitor";
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    using (SqlDataReader dataReader = Cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (dataReader.Read())
                        {
                            lineList.Add("");
                            lineList[i] = dataReader.GetValue(0).ToString();
                            i++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                myConnection.Close();
            }
        }

        public string UpdateUsedModel(Model model, string line, string status)
        {
            //UPDATE `MicomVersionMornitor` SET `PCBcode` = 'DC92-02505A0', `PBAcode` = 'DC92-02505A0', `MicomAssycode` = 'DC94-002150', `ChecksumCode` = '0xFF0', `VersionCode` = 'AD350', `InvMicomAssCode` = 'DC94-002160', `InvMicomChecksum` = 'FDFA0', `InvMicomVersion` = 'AFAD0', `TimeChange` = '2/10/2021 15:38' WHERE `MicomVersionMornitor`.`Line` = 'DISPLAY_1';
            string returnStr = "success.";
            string CommandText = "UPDATE \"MicomVersionMornitor\" SET \"" +
                "PCB Code\" = '" + model.PCBCode + "', \"" +
                "PBA Code\" = '" + model.PBACode + "', \"" +
                "Main Micom Assy Code\" = '" + model.ROMs[0].AssyMicomCode + "', \"" +
                "Main Micom Checksum\" = '" + model.ROMs[0].Checksum + "', \"" +
                "Main Micom Version\" = '" + model.ROMs[0].Version + "', \"" +
                "Inv Micom Assy Code\" = '" + model.ROMs[1].AssyMicomCode + "', \"" +
                "Inv Micom Checksum\" = '" + model.ROMs[1].Checksum + "', \"" +
                "Inv Micom Version\" = '" + model.ROMs[1].Version + "',  \"" +
                "Change Model\" = '" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "',  \"" +
                "Status\"= '" + status + "'" +
                "WHERE \"Line\" = '" + line + "';";
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    Cmd.ExecuteNonQuery();
                    updateChange("MicomVersionMornitor", myConnection);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    returnStr = e.Message;
                }
                myConnection.Close();
            }
            return returnStr;
        }

        public void updateChange(string table, SqlConnection myConnection)
        {
            string CommandText = "UPDATE TOP(1) \"TableUpdate\" SET \"Time\"='"+ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") +"' WHERE  \"Table\"='"+ table +"';";
            SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int GetModelLikeThis(String PBACODE, String Checksum, Model model)
        {
            int haveOnServer = 00;
            string CommandText = "SELECT * FROM \"Micom SW Version\" WHERE \"PBA Code\" LIKE '%"+ PBACODE + "%' OR \"Assy Code\" LIKE '%" + PBACODE + "%';";
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    using (SqlDataReader dataReader = Cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            haveOnServer = 10;
                            string checksum = dataReader.GetString(8).ToUpper();
                            Console.WriteLine("Checksum = " + checksum);
                            if (Checksum.Contains(checksum))
                            {
                                model.MasterData = dataReader.GetString(0);
                                model.PCBCode = dataReader.GetString(5);
                                model.PBACode = dataReader.GetString(4);
                                model.ROMs[0].AssyMicomCode = dataReader.GetString(6);
                                model.ROMs[0].Checksum = dataReader.GetString(8);
                                model.ROMs[0].Version = dataReader.GetString(9);
                                model.ROMs[1].AssyMicomCode = dataReader.GetString(11);
                                model.ROMs[1].Checksum = dataReader.GetString(13);
                                model.ROMs[1].Version = dataReader.GetString(14);
                                haveOnServer = 11;
                                break;
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                myConnection.Close();
            }
            return haveOnServer;
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            //file is not locked
            return false;
        }
    }
}
