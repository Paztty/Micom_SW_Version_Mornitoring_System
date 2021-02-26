using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text.Json;

namespace Micom_SW_Version_Mornitoring_System
{
    class MySQL
    {
        public string connectionStr;
        public string dbServer { get; set; } = "sql12.freesqldatabase.com";
        public string dbDatabase { get; set; } = "sql12395168";
        public string dbUser { get; set; } = "sql12395168";
        public string dbPassword { get; set; } = "MakU4RSCBC";
        public BaseTableCache tableCache = new BaseTableCache(1000);
        public MySqlConnection connection;

        private int dataColumnsCount = 17;


        public class DataTable {
            public string Name;
            public string[] Columns;
            public List<string[]> Value = new List<string[]>();
        }

        public class UpdateParam
        {
            public string ColumnName = "";
            public string Value = "";

            public UpdateParam(string ColumnName, string Value)
            {
                this.ColumnName = ColumnName;
                this.Value = Value;
            }
        }

        public List<DataTable> DataTables = new List<DataTable>();

        public MySQL() {
            this.connectionStr = "server=" + dbServer + ";user=" + dbUser + ";database=" + dbDatabase + ";password=" + dbPassword;
            this.connection = new MySqlConnection(this.connectionStr);
        }
        // check user login
        public string AccountCheck(string acc, string pass)
        {
            string CommandText = "SELECT* FROM `MicomVersionUser` WHERE `ID` LIKE '"+acc+"'";
            this.connection.Open();
            MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
            using (MySqlDataReader dataReader = strCmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.GetValue(0).ToString());
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
            }
            this.connection.Close();
            Console.WriteLine(Global.user.userName);
            Console.WriteLine(Global.user.userPermission);
            return Global.user.userName;
        }

        public string AccountChangePass(string acc, string newpass)
        {
            string returnStr = "success.";
            //UPDATE `MicomVersionUser` SET `Password` = '7163002' WHERE `MicomVersionUser`.`ID` = '7163001';
            string CommandText = "UPDATE `MicomVersionUser` SET `Password` = '"+ newpass +"' WHERE `MicomVersionUser`.`ID` = '" + acc + "';";
            this.connection.Open();
            MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
            try
            {
                strCmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                returnStr = "Have an error: " + err.Message;
            }
            this.connection.Close();
            return returnStr;
        }
        public MySQL(string Server, string User, string database, string password)
        {
            this.connectionStr = "server=" + Server + ";user=" + User + ";database=" + database + ";password=" + password;
            this.connection = new MySqlConnection(this.connectionStr);
        }
        public bool TestConnection()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //SELECT Table_name as TablesName from information_schema.tables where table_schema = 'yourDatabaseName';
        public void GetTables()
        {
            string CommandText = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'sql12390272'";
            MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
            this.connection.Open();
            using (MySqlDataReader dataReader = strCmd.ExecuteReader())
            {
                string[] tableList = new string[10];
                Console.WriteLine(dataReader.GetValues(tableList));
            }
            this.connection.Close();
        }
        public bool GetDataFromTable(string tableName)
        {
            try
            {
                this.connection.Open();
                bool tableIsExist = false;
                int tableIndex = 0;
                for (int tableCount = 0; tableCount < DataTables.Count; tableCount++)
                {
                    if (DataTables[tableCount].Name == tableName)
                    {
                        tableIsExist = true;
                        string CommandText = "SELECT * FROM `" + tableName + "`";
                        MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
                        using (MySqlDataReader dataReader = strCmd.ExecuteReader())
                        {
                            int rows = 0;
                            DataTables[tableCount].Value.Clear();
                            Console.WriteLine(DataTables[tableCount].Name);
                            while (dataReader.Read())
                            {
                                DataTables[tableCount].Value.Add(new string[dataColumnsCount]);
                                for (int i = 0; i < dataColumnsCount; i++)
                                {
                                    try
                                    {
                                        DataTables[tableCount].Value[rows][i] = dataReader.GetValue(i).ToString();
                                        //Console.Write(DataTables[0].Value[rows][i] + "  ");
                                    }
                                    catch {
                                        Console.WriteLine("Error 0");
                                    };
                                }
                                //Console.WriteLine();
                                rows++;
                            }
                        }
                        break;
                    }
                }

                if (!tableIsExist)
                {
                    tableIndex = DataTables.Count;
                    this.DataTables.Add(new DataTable
                    {
                        Name = tableName,
                        Columns = new string[dataColumnsCount]
                    });
                    string CommandText = "SELECT * FROM `" + tableName + "`";
                    MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
                    using (MySqlDataReader dataReader = strCmd.ExecuteReader())
                    {
                        int rows = 0;
                        Console.WriteLine(DataTables[tableIndex].Name);
                        while (dataReader.Read())
                        {
                            DataTables[tableIndex].Value.Add(new string[dataColumnsCount]);
                            for (int i = 0; i < dataColumnsCount; i++)
                            {
                                try
                                {
                                    DataTables[tableIndex].Value[rows][i] = dataReader.GetValue(i).ToString();
                                    //Console.Write(DataTables[0].Value[rows][i] + "  ");
                                }
                                catch {
                                };
                            }
                            //Console.WriteLine();
                            rows++;
                        }
                    }
                }
                this.connection.Close();
                return true;
            }
            catch (Exception e)
            {
                this.connection.Close();
                Console.WriteLine("Error when read data:" + e.Message);
                return false;
            }
        }
        public void LoadToDataGridView(System.Windows.Forms.DataGridView view, string TableName)
        {
            view.Rows.Clear();
            foreach (DataTable table in DataTables) {
                if (table.Name == TableName)
                {
                    for (int i = 0; i < table.Value.Count; i++)
                    {
                        view.Rows.Add(table.Value[i]);
                    }
                }
            }
        }
        public void LoadToDataTableBuffer(System.Data.DataTable view, string TableName)
        {
            view.Rows.Clear();
            foreach (DataTable table in DataTables)
            {
                if (table.Name == TableName)
                {
                    for (int i = 0; i < table.Value.Count; i++)
                    {
                        string[] rowValue = new string[view.Columns.Count];
                        for (int viewColumnCount = 0; viewColumnCount < view.Columns.Count; viewColumnCount++)
                        {
                            rowValue[viewColumnCount] = table.Value[i][viewColumnCount];
                        }
                        view.Rows.Add(rowValue);
                    }
                }
            }
        }

        public void LoadToDataTable(System.Data.DataTable view, string TableName)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("Master Data");
            dataTable.Columns.Add("Model");
            dataTable.Columns.Add("Writing Area");
            dataTable.Columns.Add("Assy Code");
            dataTable.Columns.Add("PBA Code");
            dataTable.Columns.Add("PCB Code");
            dataTable.Columns.Add("MainAssy Micom Code");
            dataTable.Columns.Add("MainMicom Name");
            dataTable.Columns.Add("MainChecksum");
            dataTable.Columns.Add("MainVersion");
            dataTable.Columns.Add("MainApply day");
            dataTable.Columns.Add("InvAssy Micom Code");
            dataTable.Columns.Add("InvMicom Name");
            dataTable.Columns.Add("InvChecksum");
            dataTable.Columns.Add("InvVersion");
            dataTable.Columns.Add("InvApply day");
            dataTable.Columns.Add("Last user");

            foreach (DataTable table in DataTables)
            {
                if (table.Name == TableName)
                {
                    dataTable.Rows.Clear();
                    for (int i = 0; i < table.Value.Count; i++)
                    {
                        dataTable.Rows.Add(table.Value[i]);
                    }
                }
            }
            bool differences = false;

            if (view.Rows.Count != dataTable.Rows.Count)
            {
                differences = true;
                Console.WriteLine("Rows count difference"
                    + view.Rows.Count + " vs " + dataTable.Rows.Count);
            }
            else
            {
                for (int ColumnsCount = 0; ColumnsCount < dataTable.Columns.Count; ColumnsCount++)
                {
                    for (int rowsCount = 0; rowsCount < dataTable.Rows.Count; rowsCount++)
                    {
                        if (view.Rows[rowsCount][ColumnsCount].ToString() != dataTable.Rows[rowsCount][ColumnsCount].ToString())
                        {
                            differences = true;
                            Console.WriteLine("Data difference, row " + rowsCount + " column" + ColumnsCount + " data: -" + view.Rows[rowsCount][ColumnsCount] + "--" + dataTable.Rows[rowsCount][ColumnsCount] + "-");
                            break;
                        }
                    }
                    //break;
                }
            }

            if (differences)
            {
                view.Rows.Clear();
                Console.WriteLine("Have Change");
                view.Merge(dataTable);
                Console.WriteLine(view.Rows.Count);
            }
            else
            {
                Console.WriteLine("Not Things change");
                Console.WriteLine(view.Rows.Count);
            }
        }
            //UPDATE `Micom SW Version`
            //SET `Master Data` = 'DC92-00004Y-B',
            //`Model` = 'Sub 279A1',
            //`Writing Area` = 'Micom room1',
            //`Assy Code` = 'DC92-00004Y-A1',
            //`PBA Code` = 'DC94-00004Y-A1',
            //`PCB Code` = 'DC41-00279A1',
            //`Assy Main Micom Code` = 'DC92-01854B 1',
            //`Main Micom Name` = 'R5F100FCAFP1',
            //`Main Checksum` = '15F31',
            //` Main Version` = '1F051',
            //`Main Apply day` = '22/11/2019',
            //`Assy Inv Micom Code` = '1',
            //`Inv Micom Name` = '1',
            //` Inv Checksum` = '1',
            //`Inv Version` = '1',
            //`Inv Apply day` = '22/11/2019',
            //`Last user` = '7183938'
            //WHERE `Micom SW Version`.`Master Data` = 'DC92-00004Y-A';
        public string EditDatabase(Model model, string Edit_masterdata)
        {
            string returnStr = "success.";
            if (string.IsNullOrWhiteSpace(Edit_masterdata))
            {
                throw new ArgumentException($"'{nameof(Edit_masterdata)}' cannot be null or whitespace", nameof(Edit_masterdata));
            }
            string CommandText =
            "UPDATE `Micom SW Version`"+
            "SET `Master Data` = '"+ model.MasterData +"',"+
            "`Model` = '"+model.Name + "',"+
            "`Writing Area` = '" + model.WritingArea + "',"+
            "`Assy Code` = '" + model.AssyCode + "',"+
            "`PBA Code` = '" +model.PBACode + "',"+
            "`PCB Code` = '" + model.PCBCode + "',"+
            "`Assy Main Micom Code` = '" + model.ROMs[0].AssyMicomCode + "',"+
            "`Main Micom Name` = '" + model.ROMs[0].MicomName + "',"+
            "`Main Checksum` = '" + model.ROMs[0].Checksum + "',"+
            "`Main Version` = '" + model.ROMs[0].Version + "',"+
            "`Main Apply day` = '" + model.ROMs[0].DateApply + "',"+
            "`Assy Inv Micom Code` = '" + model.ROMs[1].AssyMicomCode + "',"+
            "`Inv Micom Name` = '" + model.ROMs[1].MicomName+ "',"+
            "`Inv Checksum` = '" + model.ROMs[1].Checksum + "',"+
            "`Inv Version` = '" + model.ROMs[1].Version + "',"+
            "`Inv Apply day` = '" + model.ROMs[1].DateApply+ "',"+
            "`Last user` = '" + Global.user.userID + "'"+
            "WHERE `Micom SW Version`.`Master Data` = '" + Edit_masterdata+ "';";
            Console.WriteLine(CommandText);
            MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
            this.connection.Open();
            try
            {
                strCmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                returnStr = "have an error: " + err.Message;
            }
            this.connection.Close();
            return returnStr;
        }
        public string InsertDatabase(Model model)
        {
            string returnStr = "success.";
            if (model.MasterData.Length > 1)
            {
                string CommandText =
                    "INSERT INTO `Micom SW Version`" +
                    "(`Master Data`, `Model`, `Writing Area`, `Assy Code`, `PBA Code`, `PCB Code`, `Assy Main Micom Code`, `Main Micom Name`, `Main Checksum`, `Main Version`, `Main Apply day`, `Assy Inv Micom Code`, `Inv Micom Name`, `Inv Checksum`, `Inv Version`, `Inv Apply day`, `Last user`)" +
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
                    Global.user.userID +
                    "');";
                MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
                this.connection.Open();
                try
                {
                    strCmd.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    returnStr = "have an error: " + err.Message;
                }
                this.connection.Close();
            }
            return returnStr;
        }
        public string DeleteData(string masterData)
        {
            string returnStr = "success.";
            string CommandText = "DELETE FROM `Micom SW Version` WHERE `Micom SW Version`.`Master Data` = '" + masterData + "'";
            MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
            this.connection.Open();
            try
            {
                strCmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                returnStr = "have an error: " + err.Message;
            }
            this.connection.Close();
            return returnStr;
        }

        public void getLineList(List<string> lineList)
        {
            lineList.Clear();
            string CommandText = "SELECT * FROM `MicomVersionMornitor`";
            MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
            this.connection.Open();
            using (MySqlDataReader dataReader = strCmd.ExecuteReader())
            {
                int i = 0;
                while (dataReader.Read())
                {
                    lineList.Add("");
                    lineList[i] = dataReader.GetValue(0).ToString();
                    i++;
                }
            }
            this.connection.Close();

        }
        public string UpdateUsedModel(Model model, string line)
        {
            //UPDATE `MicomVersionMornitor` SET `PCBcode` = 'DC92-02505A0', `PBAcode` = 'DC92-02505A0', `MicomAssycode` = 'DC94-002150', `ChecksumCode` = '0xFF0', `VersionCode` = 'AD350', `InvMicomAssCode` = 'DC94-002160', `InvMicomChecksum` = 'FDFA0', `InvMicomVersion` = 'AFAD0', `TimeChange` = '2/10/2021 15:38' WHERE `MicomVersionMornitor`.`Line` = 'DISPLAY_1';

            string returnStr = "success.";
            string CommandText = "UPDATE `MicomVersionMornitor` SET `" +
                "PCBcode` = '"+ model.PCBCode + "', `" +
                "PBAcode` = '" + model.PBACode + "', `" +
                "MicomAssycode` = '" + model.ROMs[0].AssyMicomCode + "', `" +
                "ChecksumCode` = '"+ model.ROMs[0].Checksum + "', `" +
                "VersionCode` = '" + model.ROMs[0].Version + "', `" +
                "InvMicomAssCode` = '" + model.ROMs[1].AssyMicomCode + "', `" +
                "InvMicomChecksum` = '" + model.ROMs[1].Checksum + "', `" +
                "InvMicomVersion` = '" + model.ROMs[1].Version + "',  `" +
                "TimeChange` = '"+ DateTime.Now.ToString("dd/MM/yyyy HH:mm")+"'" +
                "WHERE `MicomVersionMornitor`.`Line` = '" + line+ "';";
            MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
            this.connection.Open();
            try
            {
                strCmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                returnStr = "have an error: " + err.Message;
                Console.WriteLine(err.Message);
            }
            this.connection.Close();
            return returnStr;
        }
        public void UpdateRunStopStatus(string status, string line)
        {
             string CommandText = "UPDATE `MicomVersionMornitor` SET `" +
             "STATUS` = '" + status + "'" +
             "WHERE `MicomVersionMornitor`.`Line` = '" + line + "';";
            MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
            this.connection.Open();
            try
            {
                strCmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            this.connection.Close();
        }
    }
}
