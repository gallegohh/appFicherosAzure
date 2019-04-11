using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.IO;

namespace WebJob1
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("WebJob1: Iniciado a las " + DateTime.Now.ToShortTimeString());
            

            var ficheros = Directory.GetFiles("D:\\home\\site\\wwwroot\\wwwroot\\upload");

            Console.WriteLine("WebJob1: " + ficheros.Length + " FICHEROS ENCONTRADOS");

            foreach (var item in ficheros)
            {
                FileInfo file = new FileInfo(item);
                
                file.MoveTo(@"D:\\home\\site\\wwwroot\\wwwroot\\images\\" + file.Name);

                Console.WriteLine("WebJob1: ficheros" + file.Name + @" MOVIDO a la carpeta \images"); 
            }

            Console.WriteLine("WebJob1: Finalizado a las " + DateTime.Now.ToShortTimeString());
        }
    }
}
