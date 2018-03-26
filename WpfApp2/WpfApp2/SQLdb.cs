using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace WpfApp2
{
    class SQLdb
    {
        public DataTable dataTable = new DataTable();
        public SqlConnection dbConnection;
        public SqlCommand cmd;
        public SqlDataReader myReader;

        public SQLdb()
        {
            SqlConnectionStringBuilder dbInfo = new SqlConnectionStringBuilder();
            dbInfo.DataSource = "RAFAL";
            dbInfo.InitialCatalog = "JTTTdb";
            dbInfo.IntegratedSecurity = true;
            dbConnection = new SqlConnection(dbInfo.ToString());
            cmd = new SqlCommand("Insert Into dbo.Table_1 (URL, KeyWord, Mail) VALUES (@URL, @KeyWord, @Mail)", dbConnection);
        }

        public void dbAdd(string URL, string KeyWord, string Mail)
        {
            cmd.Parameters.AddWithValue("@URL", URL);
            cmd.Parameters.AddWithValue("@KeyWord", KeyWord);
            cmd.Parameters.AddWithValue("@Mail", Mail);
            dbConnection.Open();
            myReader = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();
        }

        public BindingList<JTTT> getData()
        {
            //SqlDataAdapter tmp = new SqlDataAdapter(cmd);
            //tmp.Fill(dataTable);
            //tmp.Dispose();
            //return dataTable;
            dbConnection.Open();
            BindingList<JTTT> tmp = new BindingList<JTTT>();
            while (myReader.Read())
            {
                JTTT tmpObject = new JTTT();
                tmpObject.url = myReader.GetString(0);
                tmpObject.text = myReader.GetString(1);
                tmpObject.mail = myReader.GetString(2);
                tmp.Add(tmpObject);
            }
            return tmp;
        }


    }
}
