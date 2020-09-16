
//İŞLEM SINIFI İÇİNDEKİ KISIMDIR. ANA YAZILIMA EKLEMENİZ DURUMUNDA HATALARLA KARŞILAŞABİLİRSİNİZ.

        public static List<string> asalÇarpanlaraAyır(int ayrilacak)
        {
            List<string> dondur = new List<string>();

            int sira = 0;

            int[] bolunecekler = { 2, 3, 5, 7, 11, 13, 17, 19 };

            List<string> frekanslar = new List<string>();

            foreach (int a in bolunecekler)
            {
                frekanslar.Add(a.ToString() + "-0");
            }
    
            foreach (int a in bolunecekler)
            {
               tekrarbol:
                if (ayrilacak % a < 1)
                {
                    ayrilacak /= a;
                    frekanslar[sira] = frekanslar[sira].Split('-')[0] + "-" + (int.Parse(frekanslar[sira].Split('-')[1]) + 1); // frekansın değeri arttı
                    if(ayrilacak <= 0) { break; }else if(ayrilacak % a < 1) { goto tekrarbol; } //Eğer bölüne bölüne sayı 0 olmuşsa döngüden çık ve sonuç ver. Eğer bu sayıya birden fazla kez bölünüyorsa tekrar böl ve frekansı arttır.
                }
                else if (ayrilacak % a != 0)
                {
                    //diğer frekansları kontrol etmeye devam et.
                }
                sira++;
            }

            sira = 0;

            dondur.Add("Asal Çarpanlar | Frekansları");
            foreach (string s in frekanslar)
            {
                if(s.Split('-').Length > 0)
                {
                    if (int.Parse(s.Split('-')[1]) > 0) //eğer o sayıya ait frekans var ise                      
                    {
                        string eklenecek =  s.Split('-')[0] + "              |     " + s.Split('-')[1];                    
                        dondur.Add(eklenecek);
                    }
                }              
            }

            return dondur;
        }
        
        
        //PROGRAM.CS KODUNA YAZILMALIDIR. (static void Main altına)
        
          basa_don:
            
            if(!int.TryParse(Console.ReadLine(), out int ayrilacakSayi))
            {
                Console.WriteLine("Lütfen bir sayı girin." + Environment.NewLine);
                goto basa_don;
            }
            else if(ayrilacakSayi <= 0)
            {
                Console.WriteLine("Lütfen sıfır dışında bir sayı girin." + Environment.NewLine);
                goto basa_don;

            }
            List<string> sonuc = İşlem.asalÇarpanlaraAyır(ayrilacakSayi);
            if(sonuc.Count > 1)
            {
                foreach (string b in sonuc)
                {
                    Console.WriteLine(b);
                }
            }else if(sonuc.Count <= 1)
            {
                Console.WriteLine("Sayı asal.");
            }
            Console.WriteLine(Environment.NewLine);
            goto basa_don;
    
