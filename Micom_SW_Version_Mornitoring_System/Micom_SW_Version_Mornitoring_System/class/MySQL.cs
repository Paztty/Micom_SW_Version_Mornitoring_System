using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Micom_SW_Version_Mornitoring_System
{
    class MySQL
    {
        public string connectionStr = "server=sql12.freesqldatabase.com;user=sql12390272;database=sql12390272;password=uvwb9ppkvs;";
        public string dbServer = "sql12.freesqldatabase.com";
        public string dbDatabase = "sql12393466";
        public string dbUser = "sql12393466";
        public string dbPassword = "nNaIbF84eY";
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
            Console.WriteLine("");
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


        public MySQL(string Server, string User, string database, string password)
        {
            this.connectionStr = "server=" + Server + ";user=" + User + ";database=" + database + ";password=" + password;
            this.connection = new MySqlConnection(this.connectionStr);
        }
        public bool TestConnection()
        {
            try
            {
                Console.WriteLine("Openning Connection ...");
                connection.Open();
                Console.WriteLine("Connection successful!");
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
                                    Console.WriteLine("Error 1");
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
        public void EditDatabase(Model model, string Edit_masterdata)
        {
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
            "` Main Version` = '" + model.ROMs[0].Version + "',"+
            "`Main Apply day` = '" + model.ROMs[0].DateApply + "',"+
            "`Assy Inv Micom Code` = '" + model.ROMs[1].AssyMicomCode + "',"+
            "`Inv Micom Name` = '" + model.ROMs[1].MicomName+ "',"+
            "` Inv Checksum` = '" + model.ROMs[1].Checksum + "',"+
            "`Inv Version` = '" + model.ROMs[1].Version + "',"+
            "`Inv Apply day` = '" + model.ROMs[1].DateApply+ "',"+
            "`Last user` = '" +Global.user.userID+ "'"+
            "WHERE `Micom SW Version`.`Master Data` = '" + Edit_masterdata+ "';";
            Console.WriteLine(CommandText);
            MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
            this.connection.Open();
            using (MySqlDataReader dataReader = strCmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                }
            }
            this.connection.Close();
        }
        public void InsertDatabase(Model model)
        {
            if (model.MasterData.Length < 5)
            {
                string CommandText =
                    "INSERT INTO `Micom SW Version`" +
                    "(`Master Data`, `Model`, `Writing Area`, `Assy Code`, `PBA Code`, `PCB Code`, `Assy Main Micom Code`, `Main Micom Name`, `Main Checksum`, ` Main Version`, `Main Apply day`, `Assy Inv Micom Code`, `Inv Micom Name`, ` Inv Checksum`, `Inv Version`, `Inv Apply day`, `Last user`)" +
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
                using (MySqlDataReader dataReader = strCmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                    }
                }
                this.connection.Close();
            }
        }
        public string DeleteData(string masterData)
        {
            string returnStr = "";
            string CommandText = "DELETE FROM `Micom SW Version` WHERE `Micom SW Version`.`Master Data` = '" + masterData + "'";
            MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
            this.connection.Open();
            using (MySqlDataReader dataReader = strCmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    returnStr += dataReader.GetValue(0).ToString();
                }
            }
            this.connection.Close();
            return returnStr;
        }
    }
}
