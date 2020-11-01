using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------WCF хост----------------------");
            using (var s = new ServiceHost(typeof(Service1)))
            {
                s.Open();
                Console.WriteLine("Сервис запущен");
                Console.WriteLine("Нажать Enter для остановки");
                Console.ReadKey();                
                s.Close();
            }
        }
    }
}
