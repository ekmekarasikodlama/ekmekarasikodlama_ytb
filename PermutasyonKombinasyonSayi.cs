 class Program
    {
     
        static double faktoriyel(double sayi)
        {
            double dondur = sayi;
            for(int i = 1; i < sayi;i++)
            {
                dondur *= i;
            }
            return dondur;
        }
    
        static void Main(string[] args)
        {
            basadon:
            Console.WriteLine("Kümedeki eleman sayısını giriniz (n): ");
            string elemanVeri = Console.ReadLine();
            if(double.TryParse(elemanVeri, out double elemanSayisi) == false) { goto basadon; }
            tekraralt:
            Console.WriteLine("Alt küme büyüklüğünü giriniz (r): ");
            string altVeri = Console.ReadLine();
            if(double.TryParse(altVeri, out double altSayi) == false) { goto tekraralt; }

            double ustKisim = faktoriyel(elemanSayisi);
            double altKisim = faktoriyel(elemanSayisi - altSayi);
            double permutasyon = ustKisim / altKisim;
            Console.WriteLine("Permütasyon: " + permutasyon + "\n");
            double altKisimC = faktoriyel(altSayi) * faktoriyel(elemanSayisi - altSayi);
            double kombinasyon = ustKisim / altKisimC;
            Console.WriteLine("Kombinasyon: " + kombinasyon + "\n");
            goto basadon;
        }
    }
