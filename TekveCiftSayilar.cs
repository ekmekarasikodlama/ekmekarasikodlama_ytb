 //long değişkenini kullandım. long değişken türüyle daha büyük sayıları işleyebilirsiniz.
 
 static void Main(string[] args)
        {
            tekrardon:
            string veri = Console.ReadLine();
            if(long.TryParse(veri,out long sayi) == false) { goto tekrardon; }
            long kalan = sayi % 2;
            if(kalan == 0) { Console.WriteLine("Sayı çift."); } else { Console.WriteLine("Sayı tek."); }
            Console.WriteLine("\n");
            goto tekrardon;
        }
