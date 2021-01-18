using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallStatusUpdate
{

    class Connection
    {
        static SqlCommand komut;
        static SqlDataReader reader;
        public void Conn()
        {
             var datasource = @"Server"; //Server İsmi

           
            var database = "VDB"; //Database İsmi

            var username = "sa"; //SQL Connection sa

           

            var password = "s"; // sa ya ait password
                                
            //connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            
            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

              

                Console.WriteLine("Connection successful!");
                StringBuilder strBuilder = new StringBuilder();

                int sayac = 0;
                Console.WriteLine("DialId :");
                string DialId = Console.ReadLine();

                komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandText = "SELECT InsertDate,DialId,phone1 FROM CallList  WHERE DialId like '%" + DialId + "%' ";
                conn.Open();
                reader = komut.ExecuteReader();
               

                while (reader.Read())
                {
                    sayac++;

                    double timestamp = Convert.ToDouble(reader[0]);
                    DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    start = start.AddSeconds(timestamp);

                    Console.WriteLine("InsertDate:" + start + "  -  " + "DialId :  " + reader[1] + "   -  " + "    Telefon No  : " + reader[2] + "\n");

                    
                    string fileName = @"F:\Logs.txt";



                    string writeText = "InsertDate:" + start + "  -  " + "DialId :  " + reader[1] + "   -  " + "    Telefon No  : " + reader[2] + "\n"+" Sorgu Tarihi : "+DateTime.Now+"\n";

                    FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Close();
                    File.AppendAllText(fileName, Environment.NewLine + writeText);


                }
                conn.Close();

                Console.WriteLine("Sonuç  :" + sayac + " Data ");
                

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

    }
}
