using System;
using System.Collections.Generic;
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
        public string dbDatabase = "sql12390272";
        public string dbUser = "sql12390272";
        public string dbPassword = "uvwb9ppkvs";
        public BaseTableCache tableCache = new BaseTableCache(1000);
        public MySqlConnection connection;

        public class DataTable {
            public string Name;
            public string[] Columns;
            public List<string[]> Value = new List<string[]>();
        }

        public List<DataTable> DataTables = new List<DataTable>();





        public MySQL() {
            Console.WriteLine("");
            this.connection = new MySqlConnection(this.connectionStr);
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
            MySqlCommand strCmd = new MySqlCommand(CommandText,this.connection);
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
                foreach (var dataTable in DataTables)
                {
                    if (dataTable.Name == tableName)
                    {
                        tableIsExist = true;
                        break;
                    }
                }
                if (!tableIsExist)
                {
                    tableIndex = DataTables.Count;
                    this.DataTables.Add(new DataTable
                    {
                        Name = tableName,
                        Columns = new string[14]
                    });
                }
                else
                {
                    
                }

                string CommandText = "SELECT * FROM `"+ tableName +"`";
                MySqlCommand strCmd = new MySqlCommand(CommandText, this.connection);
                using (MySqlDataReader dataReader = strCmd.ExecuteReader())
                {
                    int rows = 0;
                    Console.WriteLine(DataTables[0].Name);
                    while (dataReader.Read())
                    {
                        DataTables[0].Value.Add(new string[14]);
                        for (int i = 0; i < 14; i++)
                        {
                            try {
                                DataTables[0].Value[rows][i] = dataReader.GetValue(i).ToString();
                                Console.Write(DataTables[0].Value[rows][i] + "  ");
                            }
                            catch{ };

                        }
                        Console.WriteLine();
                        rows++;
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
            foreach(DataTable table in DataTables){
                if (table.Name == TableName)
                {
                    for (int i = 0; i < table.Value.Count; i++)
                    {
                        view.Rows.Add(table.Value[i]);
                    }
                }
            }
        }
    }
}
