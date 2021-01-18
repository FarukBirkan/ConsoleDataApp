using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallStatusUpdate
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");
            Connection cn = new Connection();
            Console.Write("DialId ' ye Göre Aramak için 1 Yazınız.");
            string a = Console.ReadLine();
            if (a=="1")
            {
                cn.Conn();
            }
            else
            {
                Console.WriteLine("test");
            }
            
          
            Console.Read();
        }
    }
}

