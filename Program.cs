using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saatuygulamasıkonsol
{
    class Program
    {
        static void Main(string[] args)
        {
            //tarih
            //-kısa tarih
            //-uzun tarih
            //saat
            //-kısa saat
            //-uzun saat
            //belirli yıl/ay/gün/saat/dakika sonraki tarih
            Console.WriteLine(DateTime.Now.ToLongDateString());
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine("----");
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            Console.WriteLine("----");
            Console.Write("Eklenecek yılı yazın:");
            string eklenecekyil = Console.ReadLine();
            Console.Write("Eklenecek ayı yazın:");
            string eklenecekay = Console.ReadLine();
            Console.Write("Eklenecek günü yazın:");
            string eklenecekgun = Console.ReadLine();
            Console.Write("Eklenecek saat yazın:");
            string ekleneceksaat = Console.ReadLine();
            Console.Write("Eklenecek dakika yazın:");
            string eklenecekdakika = Console.ReadLine();

            Console.WriteLine("Ortaya çıkan tarih: " + DateTime.Now.AddYears(int.Parse(eklenecekyil)).AddMonths(int.Parse(eklenecekay)).AddDays(int.Parse(eklenecekgun)).AddHours(int.Parse(ekleneceksaat)).AddMinutes(int.Parse(eklenecekdakika)));

            Console.ReadLine();
        }
    }
}
