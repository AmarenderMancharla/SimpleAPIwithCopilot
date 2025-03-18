using System.Reflection.Emit;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Pratice
{
    public class MethodOverloadingandRidding
    {
        public int Add(int num1, int num2)
        {
            return (num1 + num2);
        }
        public int Add(int num1, int num2, int num3)
        {
            return (num1 + num2 + num3);
        }
        public float Add(float num1, float num2)
        {
            return (num1 + num2);
        }
        public string Add(string value1, string value2)
        {
            return (value1 + " " + value2);
        }

        public void ImportDataFromExcel(string excelFilePath)
        {
            //declare variables - edit these based on your particular situation
            string ssqltable = "Table1";
            // make sure your sheet name is correct, here sheet name is sheet1,
           // so you can change your sheet name if have    different
           string myexceldataquery = "select Sale_Document_Type_ID,State,Sale_Document_Type from [Sheet1$]";
            try
            {
                //create our connection strings
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + excelFilePath +
                ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                //string ssqlconnectionstring = "Data Source=SAYYED;Initial Catalog=SyncDB;Integrated Security=True";
                ////execute a query to erase any previous data from our destination table
                //string sclearsql = "delete from " + ssqltable;
                //SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
                //SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
                //sqlconn.Open();
                //sqlcmd.ExecuteNonQuery();
                //sqlconn.Close();
                //series of commands to bulk copy data from the excel file into our sql table
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                //SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
               // bulkcopy.DestinationTableName = ssqltable;
                while (dr.Read())
                {
                   // bulkcopy.WriteToServer(dr);
                }
                dr.Close();
                oledbconn.Close();
                //Label1.Text = "File imported into sql server successfully.";
            }
            catch (Exception ex)
            {
                //handle exception
            }
        }
        static void Main(string[] args)
        {

            MethodOverloadingandRidding objProgram = new MethodOverloadingandRidding();
            objProgram.ImportDataFromExcel("C:\\Users\\m.reddy\\Downloads\\Who Can Buy Rules Sept 4 2024 1.xlsx");
            //Console.WriteLine("Add with two int parameter :" + objProgram.Add(3, 2));
            //Console.WriteLine("Add with three int parameter :" + objProgram.Add(3, 2, 8));
            //Console.WriteLine("Add with two float parameter :" + objProgram.Add(3 f, 22 f));
            //Console.WriteLine("Add with two string parameter :" + objProgram.Add("hello", "world"));
            //Console.ReadLine();
        }
    }
}
