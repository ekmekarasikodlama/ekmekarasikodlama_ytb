basadon:
            List<double> sayilar = new List<double>();
            Console.WriteLine("Sayıları giriniz:");
        tekrargir:
            Console.Write(">");
            string veri = Console.ReadLine();
            if (veri != "tamam")
            {
                if (double.TryParse(veri, out double sayi) == false)
                {
                    goto basadon;
                }
                sayilar.Add(sayi);
                goto tekrargir;
            }
            else
            {
                if (sayilar.Count == 0)
                {
                    goto basadon;
                }

            }

            double ortalama = sayilar.Average();
            int altKisim = sayilar.Count - 1;
            double ustKisim = 0;
            foreach(double sayi in sayilar)
            {
                double eklenecek = sayi - ortalama;
                eklenecek *= eklenecek;
                ustKisim += eklenecek;
            }
            double sonuc = ustKisim / altKisim;
            sonuc = Math.Sqrt(sonuc);
            Console.WriteLine("----------");
            Console.WriteLine("Sonuç: " + sonuc);
            Console.WriteLine("----------");
            goto basadon;
