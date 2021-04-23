using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace Micom_SW_Version_Mornitoring_System
{
    class MySQLDatabase
    {
        //Data Source=172.22.14.220;Initial Catalog=Tech;User ID=sa;Password=***********    125.234.128.228
        public static string connectionStr = @"Data Source=125.234.128.228;Initial Catalog=Tech;User ID=micom;Password=tech@12";
        //public static string connectionStr = @"Data Source=172.22.17.241;Initial Catalog=Tech;User ID=micom;Password=tech@12";
        public MySQLDatabase()
        {
            if (File.Exists("databaseConfig.txt"))
            {
                connectionStr = Protecter.Decode(File.ReadAllText("databaseConfig.txt"));
                Console.WriteLine(connectionStr);
            }
            else
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
                {
                    DataSource = "172.22.17.241",
                    InitialCatalog = "Tech",
                    UserID = "micom",
                    Password = "tech@12",
                };
                File.WriteAllText("databaseConfig.txt", Protecter.Encode(builder.ConnectionString));
                connectionStr = builder.ConnectionString;
                Console.WriteLine(connectionStr);
            }
        }

        public bool Connect()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(connectionStr))
                {
                    SqlCommand command = new SqlCommand("select 1", myConnection)
                    {
                        CommandTimeout = 5
                    };
                    myConnection.Open();
                    if (myConnection.State == ConnectionState.Open)
                    {
                        stopwatch.Stop();
                        return true;
                    }
                    else
                    {
                        stopwatch.Stop();
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                stopwatch.Stop();
                return false;
            }
        }

        public bool Connect(string IP)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                //@"Data Source=172.22.17.241;Initial Catalog=Tech;User ID=micom;Password=tech@12"
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
                {
                    DataSource = IP,
                    InitialCatalog = "Tech",
                    UserID = "micom",
                    Password = "tech@12",
                    ConnectTimeout = 5
                };

                Console.WriteLine(builder.ConnectionString);
                using (SqlConnection myConnection = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand command = new SqlCommand("select 1", myConnection)
                    {
                        CommandTimeout = 5
                    };
                    myConnection.Open();
                    if (myConnection.State == ConnectionState.Open)
                    {
                        stopwatch.Stop();
                        return true;
                    }
                    else
                    {
                        stopwatch.Stop();
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                stopwatch.Stop();
                return false;
            }
        }

        public string AccountCheck(string acc, string pass)
        {
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                string CmdString = "SELECT * FROM MicomVersionUser Where ID = '" + acc + "';";
                SqlCommand Cmd = new SqlCommand(CmdString, myConnection);
                myConnection.Open();
                using (SqlDataReader dataReader = Cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        if (pass == dataReader.GetValue(2).ToString())
                        {
                            Global.user.userID = acc;
                            Global.user.userName = dataReader.GetValue(1).ToString();
                            Global.user.userPermission = dataReader.GetValue(3).ToString();
                            break;
                        }
                        else
                        {
                            Global.user = new User();
                        }
                    }
                    myConnection.Close();
                }
            }
            Console.WriteLine(Global.user.userName);
            Console.WriteLine(Global.user.userPermission);
            return Global.user.userName;
        }

        public string AccountChangePass(string acc, string newpass)
        {
            string returnStr = "success.";
            string CommandText = "UPDATE MicomVersionUser SET \"Password\" = N'" + newpass + "' WHERE  \"ID\" = '" + acc + "'; ";

            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    returnStr = e.Message;
                }
                myConnection.Close();
            }
            return returnStr;
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
        public void CreatTableFromServer(string tableName, System.Data.DataTable outputTable)
        {
            string CommandText = "SELECT* FROM sys.columns WHERE object_id = OBJECT_ID('dbo." + tableName + "')";
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
                            outputTable.Columns.Add(dataReader.GetString(1));
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

        public void GetDataFromTable(string tableName, System.Data.DataTable outputTable)
        {
            string CommandText = "SELECT * FROM \"" + tableName + "\"";
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        outputTable.Clear();
                        adapter.SelectCommand = Cmd;
                        adapter.Fill(outputTable);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public string UpdateData(string tableName, DataTable table, string lastUpdateTime)
        {
            string lastUpdate = lastUpdateTime;
            bool haveNewUpdate = false;
            string CommandText = "SELECT * FROM \"TableUpdate\" WHERE \"Table\" = '" + tableName + "';";
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                try
                {
                    myConnection.Open();
                    using (SqlDataReader dataReader = Cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            if (dataReader.GetString(1) != lastUpdateTime)
                            {
                                haveNewUpdate = true;
                                Console.WriteLine(dataReader.GetString(1));
                                lastUpdate = dataReader.GetString(1);
                                break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (haveNewUpdate)
            {
                GetDataFromTable(tableName, table);
            }
            return lastUpdate;
        }

        public string InsertDatabase(Model model)
        {
            string returnStr = "success.";
            if (model.MasterData.Length > 1)
            {
                string CommandText =
                    "INSERT INTO \"Micom SW Version\"" +
                    "(\"Master Data\", \"Model\", \"Writing Area\", \"Assy Code\", \"PBA Code\", \"PCB Code\", \"Assy Main Micom Code\", \"Main Micom Name\", \"Main Checksum\", \"Main Version\", \"Main Apply date\", \"Assy Inv Micom Code\", \"Inv Micom Name\", \"Inv Micom Checksum\", \"Inv Micom Version\", \"Inv Apply date\", \"Last user\")" +
                    "VALUES ('" +
                    model.MasterData + "', '" +
                    model.Name + "', '" +
                    model.WritingArea + "', '" +
                    model.AssyCode + "', '" +
                    model.PBACode + "', '" +
                    model.PCBCode + "', '" +
                    model.ROMs[0].AssyMicomCode + "', '" +
                    model.ROMs[0].MicomName + "', '" +
                    model.ROMs[0].Checksum + "', '" +
                    model.ROMs[0].Version + "', '" +
                    model.ROMs[0].DateApply + "', '" +
                    model.ROMs[1].AssyMicomCode + "', '" +
                    model.ROMs[1].MicomName + "', '" +
                    model.ROMs[1].Checksum + "', '" +
                    model.ROMs[1].Version + "', '" +
                    model.ROMs[1].DateApply + "', '" +
                    Global.user.userName +
                    "');";
                using (SqlConnection myConnection = new SqlConnection(connectionStr))
                {
                    SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                    myConnection.Open();
                    try
                    {
                        Cmd.ExecuteNonQuery();
                        updateChange("Micom SW Version", myConnection);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        returnStr = e.Message;
                    }
                    myConnection.Close();
                }
            }
            return returnStr;
        }

        public string EditDatabase(Model model, string Edit_masterdata)
        {
            string returnStr = "success.";
            if (string.IsNullOrWhiteSpace(Edit_masterdata))
            {
                throw new ArgumentException($"'{nameof(Edit_masterdata)}' cannot be null or whitespace", nameof(Edit_masterdata));
            }
            string CommandText =
            "UPDATE \"Micom SW Version\"" +
            "SET \"Master Data\" = '" + model.MasterData + "'," +
            "\"Model\" = '" + model.Name + "'," +
            "\"Writing Area\" = '" + model.WritingArea + "'," +
            "\"Assy Code\" = '" + model.AssyCode + "'," +
            "\"PBA Code\" = '" + model.PBACode + "'," +
            "\"PCB Code\" = '" + model.PCBCode + "'," +
            "\"Assy Main Micom Code\" = '" + model.ROMs[0].AssyMicomCode + "'," +
            "\"Main Micom Name\" = '" + model.ROMs[0].MicomName + "'," +
            "\"Main Checksum\" = '" + model.ROMs[0].Checksum + "'," +
            "\"Main Version\" = '" + model.ROMs[0].Version + "'," +
            "\"Main Apply date\" = '" + model.ROMs[0].DateApply + "'," +
            "\"Assy Inv Micom Code\" = '" + model.ROMs[1].AssyMicomCode + "'," +
            "\"Inv Micom Name\" = '" + model.ROMs[1].MicomName + "'," +
            "\"Inv Micom Checksum\" = '" + model.ROMs[1].Checksum + "'," +
            "\"Inv Micom Version\" = '" + model.ROMs[1].Version + "'," +
            "\"Inv Apply date\" = '" + model.ROMs[1].DateApply + "'," +
            "\"Last user\" = '" + Global.user.userName + "'" +
            "WHERE \"Master Data\" = '" + Edit_masterdata + "';";
            Console.WriteLine(CommandText);
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    Cmd.ExecuteNonQuery();
                    updateChange("Micom SW Version", myConnection);
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

        public string DeleteData(string masterData)
        {
            string returnStr = "success.";
            string CommandText = "DELETE FROM \"Micom SW Version\" WHERE \"Master Data\" = '" + masterData + "'";
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    Cmd.ExecuteNonQuery();
                    updateChange("Micom SW Version", myConnection);
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

        public string UpdateUsedModel(Model model, string line)
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
                "Time Change\" = '" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "'" +
                "WHERE \"Line\" = '" + line + "';";
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    Cmd.ExecuteNonQuery();
                    updateChange("SystemProperties", myConnection);
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
        /// <summary>
        /// update define time stop to site at System properties table
        /// </summary>
        /// <param name="action"></param>
        /// action [update] [check]
        /// <param name="time"></param>
        /// time int [ 1 ~ 1000 ]s
        /// <returns></returns>
        public int checkUpdateStopTime(string action, int time)
        {
            string CommandText = "";
            if (action == "update")
            {
                CommandText = "UPDATE TOP(1) \"Tech\".\"dbo\".\"SystemProperties\" SET \"Value\"=N'" + time + "' WHERE  \"Properties\"='timeStop';";
                using (SqlConnection myConnection = new SqlConnection(connectionStr))
                {
                    SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                    myConnection.Open();
                    try
                    {
                        Cmd.ExecuteNonQuery();
                        updateChange("SystemProperties", myConnection);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    myConnection.Close();
                }
            }

            if (action == "check") CommandText = "SELECT TOP 1 \"Properties\", \"Value\" FROM \"Tech\".\"dbo\".\"SystemProperties\" WHERE  \"Properties\" = 'timeStop';";
            {
                using (SqlConnection myConnection = new SqlConnection(connectionStr))
                {
                    SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                    try
                    {
                        myConnection.Open();
                        using (SqlDataReader dataReader = Cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Console.WriteLine(dataReader.GetString(1));
                                time = Convert.ToInt32(dataReader.GetString(1));
                                return time;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }
            return time;
        }


        public void updateChange(string table, SqlConnection myConnection)
        {
            string CommandText = "UPDATE TOP(1) \"TableUpdate\" SET \"Time\"='" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "' WHERE  \"Table\"='" + table + "';";
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

        public void updateAction(string User, string Action)
        {
            string CommandText = "INSERT INTO \"Notificatons\"(\"Time\", \"Date time\", \"User\", \"Actions\")" +
                                 "VALUES('" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', '" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "', '" + User + "', '" + Action + "')";
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    Cmd.ExecuteNonQuery();
                    updateChange("Notificatons", myConnection);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                myConnection.Close();
            }
        }

        public long loadAction(long lastLoad, TextBox tbNotify)
        {
            long lastTime = lastLoad;
            string CommandText = "SELECT TOP 100 * FROM \"Tech\".\"dbo\".\"Notificatons\" WHERE \"Time\" > '" + lastLoad + "' ORDER BY \"Time\" ASC;";
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
                            if (Convert.ToInt64(dataReader.GetValue(0).ToString()) > lastTime)
                                lastTime = Convert.ToInt64(dataReader.GetValue(0).ToString());

                            tbNotify.Invoke(new MethodInvoker(delegate
                            {
                                tbNotify.Text = dataReader.GetString(1) + ": " + dataReader.GetString(2) + " " + dataReader.GetString(3) + Environment.NewLine + tbNotify.Text;
                            }));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                myConnection.Close();
            }
            return lastTime;
        }

        public string Eeprom_Insert(EEPROM eeprom)
        {
            string returnStr = "success.";
            string CommandText = "INSERT INTO \"Tech\".\"dbo\".\"EEPROM OPTION\" (\"KeyCode\", \"Company\", \"KitCode\", \"MainPCBAssyCode\", \"MainPCBCode\", \"SubPCBAssyCode\", \"SubPCBCode\", \"EEPROMOption\", \"EEPROMAssyCode\", \"EEPROMpacket\", \"Last user\")" +
                    "VALUES ('" +
                    eeprom.KeyCode + "', '" +
                    eeprom.Company + "', '" +
                    eeprom.KitCode + "', '" +
                    eeprom.MainPCBAssyCode + "', '" +
                    eeprom.MainPCBCode + "', '" +
                    eeprom.SubPCBAssyCode + "', '" +
                    eeprom.SubPCBCode + "', '" +
                    eeprom.EEPROMOption + "', '" +
                    eeprom.EEPROMAssyCode + "', '" +
                    eeprom.EEPROMPacket + "', '" +
                    Global.user.userName + "');";
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    Cmd.ExecuteNonQuery();
                    updateChange("EEPROM OPTION", myConnection);
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

        public string Eeprom_Edit(EEPROM eeprom, string Edit_masterdata)
        {
            string returnStr = "success.";
            if (string.IsNullOrWhiteSpace(Edit_masterdata))
            {
                throw new ArgumentException($"'{nameof(Edit_masterdata)}' cannot be null or whitespace", nameof(Edit_masterdata));
            }
            string CommandText = "UPDATE \"Tech\".\"dbo\".\"EEPROM OPTION\" SET " +
                                 "\"KeyCode\"='" + eeprom.KeyCode + "'," +
                                 "\"Company\"='" + eeprom.Company + "'," +
                                 "\"KitCode\"='" + eeprom.KitCode + "'," +
                                 "\"MainPCBAssyCode\"='" + eeprom.MainPCBAssyCode + "'," +
                                 "\"MainPCBCode\"='" + eeprom.MainPCBCode + "'," +
                                 "\"SubPCBAssyCode\"='" + eeprom.SubPCBAssyCode + "'," +
                                 "\"SubPCBCode\"='" + eeprom.SubPCBCode + "'," +
                                 "\"EEPROMOption\"='" + eeprom.EEPROMOption + "'," +
                                 "\"EEPROMAssyCode\"='" + eeprom.EEPROMAssyCode + "'," +
                                 "\"EEPROMpacket\"='" + eeprom.EEPROMPacket + "'," +
                                 "\"Last user\"='" + Global.user.userName + "'" +
                                 "WHERE  \"KeyCode\"='" + Edit_masterdata + "';";

            Console.WriteLine(CommandText);
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    Cmd.ExecuteNonQuery();
                    updateChange("EEPROM OPTION", myConnection);
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
        public string Eeprom_Clrear(string Edit_masterdata)
        {
            string returnStr = "success.";
            if (string.IsNullOrWhiteSpace(Edit_masterdata))
            {
                throw new ArgumentException($"'{nameof(Edit_masterdata)}' cannot be null or whitespace", nameof(Edit_masterdata));
            }
            string CommandText = "DELETE FROM \"Tech\".\"dbo\".\"EEPROM OPTION\" WHERE  \"KeyCode\" = '" + Edit_masterdata + "';";

            Console.WriteLine(CommandText);
            using (SqlConnection myConnection = new SqlConnection(connectionStr))
            {
                SqlCommand Cmd = new SqlCommand(CommandText, myConnection);
                myConnection.Open();
                try
                {
                    Cmd.ExecuteNonQuery();
                    updateChange("EEPROM OPTION", myConnection);
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
    }
}
