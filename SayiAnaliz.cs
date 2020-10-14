//PROGRAM.CS KISMI

analizbasadon:
                List<float> veriGrubu = new List<float>();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Lütfen veri grubunu giriniz.<tamam> yazmanız durumunda liste oluşturulacak ve bir sonraki aşamaya geçeceksiniz.<menu> yazarak ana menüye dönebilirsiniz.");
                Console.ForegroundColor = ConsoleColor.White;
            tekraryaz:
                Console.Write(">");
                string veri = Console.ReadLine();
                if (veri != "menu")
                {
                    if (veri == "tamam")
                    {
                        if (veriGrubu.Count > 0)
                        {
                            goto analizdevam;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Lütfen en az bir veri girin.");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto tekraryaz;
                        }
                    }
                   
                    if (float.TryParse(veri, out float verisayi))
                    {
                        veriGrubu.Add(verisayi);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Girilen veri listeye eklendi.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto tekraryaz;
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Veri sayıya çevirilemiyor.Lütfen tekrar yazın.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto tekraryaz;
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ana menüye yönlendirildiniz.");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizbasadon;
                }

            analizdevam:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Lütfen uygulamak istediğiniz işlemi yazın. Eğer hepsini görmek istiyorsanız <hepsi> yazınız. Çıkış için <menu> yazabilirsiniz. Eğer sayıları tekrar girmek istiyorsanız <tekrar> yazın. İşlemler:");
                string[] islemler = { "Büyükten küçüğe sıralama.<bkucuk>", "Küçükten büyüğe sıralama.<kbuyuk>", "Bütün elemanların toplamını alma<toplam>", "Tek ve çift sayıları ayırma <tekcift>", "En küçük ve en büyük değerleri alma <enkucukbuyuk>", "Aritmetik ortalama alma <ortalama>", "Medyan değeri bulma <medyan>", "Değerler arası açıklık alma <aciklik>" };
                for(int a = 0; a < islemler.Length; a++)
                {
                    Console.WriteLine((a + 1).ToString() + ". " + islemler[a]);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(">");
                string istenenislem = Console.ReadLine();
                if(istenenislem == "menu")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ana menüye yönlendirildiniz.");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizbasadon;
                }else if(istenenislem  == "hepsi")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Küçükten büyüğe sıralama: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach(float f in hesaplamalar.kucuktenBuyugeSırala(veriGrubu))
                    {
                        Console.WriteLine(f);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Büyükten küçüğe sıralama: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (float f in hesaplamalar.buyuktenKucugeSirala(veriGrubu))
                    {
                        Console.WriteLine(f);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Bütün elemanların toplamı: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hesaplamalar.elemanlarinToplami(veriGrubu));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Tek ve çift sayılar: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (string f in hesaplamalar.tekCiftDondur(veriGrubu))
                    {
                        Console.WriteLine(f);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("En büyük ve en küçük elemanlar: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hesaplamalar.min_max(veriGrubu, 0));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Aritmetik ortalama: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hesaplamalar.ortalama(veriGrubu));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Medyan değeri: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hesaplamalar.medyan(veriGrubu));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Değerler arası açıklık: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hesaplamalar.aciklik(veriGrubu));
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizdevam;
                }else if(istenenislem == "bkucuk")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Büyükten küçüğe sıralama: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (float f in hesaplamalar.buyuktenKucugeSirala(veriGrubu))
                    {
                        Console.WriteLine(f);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizdevam;
                }
                else if(istenenislem == "kbuyuk")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Küçükten büyüğe sıralama: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (float f in hesaplamalar.kucuktenBuyugeSırala(veriGrubu))
                    {
                        Console.WriteLine(f);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizdevam;
                }
                else if(istenenislem == "toplam")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Bütün elemanların toplamı: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hesaplamalar.elemanlarinToplami(veriGrubu));
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizdevam;
                }else if(istenenislem == "tekcift")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Tek ve çift sayılar: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (string f in hesaplamalar.tekCiftDondur(veriGrubu))
                    {
                        Console.WriteLine(f);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizdevam;
                }else if(istenenislem == "enkucukbuyuk")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("En büyük ve en küçük elemanlar: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hesaplamalar.min_max(veriGrubu, 0));
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizdevam;
                }else if(istenenislem == "ortalama")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Aritmetik ortalama: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hesaplamalar.ortalama(veriGrubu));
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizdevam;
                }
                else if(istenenislem  == "medyan")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Medyan değeri: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hesaplamalar.medyan(veriGrubu));
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizdevam;
                }
                else if(istenenislem == "aciklik")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Değerler arası açıklık: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hesaplamalar.aciklik(veriGrubu));
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizdevam;
                }else if(istenenislem == "tekrar")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Analiz sayfasının başına gönderildiniz. Liste temizlendi.");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizbasadon;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Komut algılanmadı.Lütfen tekrar komut girin.");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto analizdevam;
                }
                
 //HESAPLAMALAR.CS KISMI
 
 public static List<float> kucuktenBuyugeSırala(List<float> verigrubu)
        {
            if (verigrubu.Count > 0)
            {
                verigrubu.Sort();
            }
            return verigrubu;
        }
        public static List<float> buyuktenKucugeSirala(List<float> verigrubu)
        {
            if (verigrubu.Count > 0)
            {
                verigrubu.Sort();
                verigrubu.Reverse();         
            }
            return verigrubu;
        }
         public static float elemanlarinToplami(List<float> verigrubu)
        {
            float dondur = 0f;
            if(verigrubu.Count > 0)
            {
                dondur = verigrubu.Sum();
            }
            else
            {
                dondur = 0f;
               
            }
            return dondur;
        }
        public static List<string> tekCiftDondur(List<float> verigrubu, int hangisi = 0)
        {
           
            List<string> dondur = new List<string>();
            foreach (float f in verigrubu)
            {
                if (f % 2 == 0)
                {
                    if (hangisi != 1)
                    {
                        dondur.Add(f + "-cift");
                    }
                    else
                    {
                        dondur.Add(f.ToString());
                    }
                }
                else
                {
                    if(hangisi != 2)
                    {
                        dondur.Add(f + "-tek");
                    }
                    else
                    {
                        dondur.Add(f.ToString());
                    }
                }
            }

            return dondur; // daha sonra kontrol edilir
        }
        public static string min_max(List<float> verigrubu, int hangisi = 0)
        {
            string dondur = "";
            if(hangisi == 0)
            {
                dondur = "MAX-" + verigrubu.Max() + "-MIN-" + verigrubu.Min() + "-"; // string'i daha sonra ayırıcam
            }else if(hangisi == 1)
            {
                dondur = verigrubu.Min().ToString();
            }else if(hangisi == 2)
            {
                dondur = verigrubu.Max().ToString();
            }


            return dondur;
        }
        public static float ortalama(List<float> veriGrubu)
        {
            float sonuc = 0f;
            if(veriGrubu.Count > 0)
            {
                sonuc = veriGrubu.Average();
            }
            else
            {
                sonuc = 0f;
            }
            return sonuc;
        }
        public static float medyan(List<float> verigrubu)
        {
            float dondur2 = 0f;
            try
            {
              
                if (verigrubu.Count > 0)
                {
                    verigrubu.Sort();
                    if (verigrubu.Count % 2 == 0) // eğer çift sayı kadar veri varsa
                    {
                        float sonuc;
                        sonuc = float.Parse(verigrubu[verigrubu.Count / 2].ToString()) + float.Parse(verigrubu[(verigrubu.Count - 1) / 2].ToString());
                        dondur2 = sonuc / 2;
                    }
                    else // eğer tek sayı kadar veri varsa
                    {
                        dondur2 = verigrubu[verigrubu.Count / 2];
                    }
                }
            }
            catch
            {
                return 0f;
            }
            return dondur2;
        }
        public static float aciklik(List<float> verigrubu)
        {
            float deger = 0f;
            if(verigrubu.Count > 0)
            {
                deger = verigrubu.Max() - verigrubu.Min();
            }
            else
            {
                deger = 0;
            }
            return deger;
        }
