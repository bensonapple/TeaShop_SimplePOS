using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace test0118_自己寫class
{
    internal class DBconn
    {
        public string ConnString;

        public DBconn() {
            ConnString = @"Data Source=DESKTOP-8D7LR2I\SQLEXPRESS01;Initial Catalog=AdventureWorksDW2019;Integrated Security=True";
        }
        public DBconn(string myConn) { 
            ConnString = myConn;
        }

        public int getTable(string mysql, DataTable mydt) {
            using (SqlConnection road = new SqlConnection(ConnString))
            {
                using (SqlDataAdapter person = new SqlDataAdapter())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = road;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = mysql;
                        person.SelectCommand = cmd;
                        int temp = person.Fill(mydt);
                        return temp;

                    }
                }
            }
        }
        public int CallSp(string mysql, DataTable mydt,CommandType mytype) {
            using (SqlConnection road = new SqlConnection(ConnString))
            {
                using (SqlDataAdapter person = new SqlDataAdapter())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = road;
                        cmd.CommandType = mytype;
                        cmd.CommandText = mysql;
                        person.SelectCommand = cmd;
                        int temp = person.Fill(mydt);
                        return temp;

                    }
                }
            }

        }

        //--------------------以下是有parameter版本

        public int getTableWithP(string mysql, DataTable mydt,Dictionary<string,string> dc) {
            using (SqlConnection road = new SqlConnection(ConnString))
            {
                using (SqlDataAdapter person = new SqlDataAdapter())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = road;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = mysql;
                        person.SelectCommand = cmd;//select xxx from xxx where column = @p1 and...
                        foreach (KeyValuePair<string,string> item in dc)
                        {//加入字典當參數 只是要讓class自動幫我們parameter 對應
                             person.SelectCommand.Parameters.AddWithValue(item.Key, item.Value);
                        }
                        int temp = person.Fill(mydt);
                        return temp;

                    }
                }
            }
        }
        public int CallSPWithP(string mysql, DataTable mydt, CommandType mytype,Dictionary<string,string> dc) {
            using (SqlConnection road = new SqlConnection(ConnString))
            {
                using (SqlDataAdapter person = new SqlDataAdapter())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = road;
                        cmd.CommandType = mytype;
                        cmd.CommandText = mysql;//"spname @p1"
                        person.SelectCommand = cmd;
                        foreach (KeyValuePair<string,string > item in dc)
                        {
                            person.SelectCommand.Parameters.AddWithValue(item.Key,item.Value);
                        }
                        int temp = person.Fill(mydt);
                        
                        return temp;

                    }
                }
            }
        }



    }
}
