
// PROGRAM.CS İÇİN KODLAR.
tekrardortislem:
                Console.ForegroundColor = ConsoleColor.Cyan;
               
                Console.WriteLine("İşlem olarak dört işlem seçildi.Hesaplamak istediğiniz sayıları yazınız. <tamam> yazınca yazma işlemi biter.");
                Console.ForegroundColor = ConsoleColor.White;
            basa_dond:
                List<float> degerler = new List<float>();
            tekrargir:
                Console.Write(">");
                string deger = Console.ReadLine();
                if (deger != "tamam")
                {
                    if (float.TryParse(deger, out float sayi) == true)
                    {
                        degerler.Add(sayi);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Listeye sayı başarıyla eklendi.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto tekrargir;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Girdiğiniz değer sayıya dönüştürülemiyor.Lütfen tekrar girin.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto tekrargir;
                    }
                }
                else
                {
                    if (degerler.Count > 0)
                    {
                        goto islemlerdevam;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Listeye herhangi bir değer girilmemiş.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            islemlerdevam:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Toplama için <toplama>, çıkarma için <cikarma veya çıkarma>, çarpma için <carpma veya çarpma> ve bölme için <bolme veya bölme> yazınız.Eğer sayıları tekrar girmek istiyorsanız <tekrargir> yazın.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(">");
                string islemtur = Console.ReadLine();
                float sonuc = 0f;
                if (islemtur == "toplama")
                {
                    sonuc = hesaplamalar.Toplama(degerler.ToArray());
                } else if (islemtur == "cikarma" || islemtur == "çıkarma")
                {
                    sonuc = hesaplamalar.Çıkarma(degerler.ToArray());
                }
                else if (islemtur == "carpma" || islemtur == "çarpma")
                {
                    sonuc = hesaplamalar.Çarpma(degerler.ToArray());
                }
                else if (islemtur == "bolme" || islemtur == "bölme")
                {
                    sonuc = hesaplamalar.Bölme(degerler.ToArray());
                } else if (islemtur == "tekrargir")
                {
                    goto basa_dond;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Girilen değer tanınamadı. Lütfen tekrar girin.");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto islemlerdevam;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sonuç: " + sonuc);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ana menüye dönmek için <menu>, dört işlem sayfasına dönmek için <dortislem> yazınız.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(">");
                string sonrakiislem = Console.ReadLine();
                if (sonrakiislem == "menu")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ana menüye yönlendirildiniz.");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto anamenu;
                }
                else if (sonrakiislem == "dortislem")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Dört İşlem menüsüne gönderildiniz.");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto tekrardortislem;
                }            
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Girilen veri anlaşılamadı.Ana menüye yönlendirildiniz.");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto anamenu;
                }
                
//hesaplamalar.cs SINIFI İÇİN KODLAR
 public static float Toplama(params float[] degerler)
        {
            return degerler.Sum();
        }
        public static float Çıkarma(params float[] degerler)
        {
            float ilkdeger = degerler[0];
            for(int a = 1; a < degerler.Length;a++ )
            {
                ilkdeger -= degerler[a];
             
            }
            return ilkdeger;
        }
        public static float Çarpma(params float[] degerler)
        {
            float ilkdeger = degerler[0];
            for (int a = 1; a < degerler.Length; a++)
            {
                ilkdeger *= degerler[a];
            }
            return ilkdeger;
        }
        public static float Bölme(params float[] degerler)
        {
            float ilkdeger = degerler[0];
      
            for (int a = 1; a < degerler.Length; a++)
            {            
                ilkdeger /= degerler[a];
            }
            return ilkdeger;
        }
