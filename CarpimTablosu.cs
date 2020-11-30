tekrargir:
            List<int> sayilar = new List<int>() { };
            Console.WriteLine("Çarpım tablosunu almak istediğiniz sayıyı giriniz. Eğer hepsini görmek isterseniz <h> yazınız.Eğer belirli sayıları görmek isterseniz <b> yazınız.");
            ConsoleKeyInfo sayiSecenek = Console.ReadKey(true);
            string tusDeger = sayiSecenek.KeyChar.ToString();
            if(tusDeger == "0") { goto tekrargir; }
            else if(tusDeger == "h") { sayilar = new List<int>() { 1, 2, 3, 4, 5, 6,7, 8, 9 }; }
            else if(tusDeger == "b")
            {
                Console.WriteLine("Uygulamak istediğiniz sayıları girin. Bitince <tamam> yazın.");
            tekraryaz:
                Console.Write(">");
                string ekleDeger = Console.ReadLine();
                if(int.TryParse(ekleDeger,out int ekleSayi))
                {
                    sayilar.Add(ekleSayi);
                    goto tekraryaz;
                }
                else
                {
                    if(ekleDeger == "tamam")
                    {
                        if(sayilar.Count > 0)
                        goto devam;
                    }
                    else
                    {
                        goto tekraryaz;
                    }
                   
                }
            }
            else if(int.TryParse(tusDeger,out int sayi)) { sayilar.Add(sayi); }
        devam:
            int maxCarpilan = 0;
            Console.WriteLine("Hangi sayıya kadar olan çarpımları görmek istiyorsunuz?");
            Console.Write(">");
            string mDeger = Console.ReadLine();
            if(int.TryParse(mDeger,out maxCarpilan))
            {
                if(maxCarpilan > 0)
                {
                    goto devam1;
                }
            }
            else
            {
                maxCarpilan = 10;
            }
            devam1:
            string ilkSatir = "\n";
            for(int a = 0; a < sayilar.Count; a++)
            {
                ilkSatir += "**" + sayilar[a] + "**   ";
                
            }
            Console.WriteLine(ilkSatir);
            if(sayilar.Count > 1)
            {
               
                for (int z = 1; z < maxCarpilan+1; z++)
                {
                    string satir = "";
                    for (int i = 0; i < sayilar.Count; i++)
                    {

                        string sonbosluk = "";
                       if(z<10)
                        {
                            sonbosluk = "  ";
                        }
                        else if( z>= 10)
                        {
                   
                            sonbosluk = " ";
                        }
                     
                        string num = "";
                        if (sayilar[i] * z >= 10) { num = (sayilar[i] * z).ToString(); }
                        else
                        {
                            num = " " + (sayilar[i] * z);
                        }
                        satir +=   z + "x" + sayilar[i] + "=" + num + sonbosluk;
                    }
                    Console.WriteLine(satir);
                }

            }else if(sayilar.Count == 1)
            {

                for (int z = 1; z < maxCarpilan+1; z++)
                {
                    string num = "";
                    if (sayilar[0] * z >= 10) { num = (sayilar[0] * z).ToString(); }
                    else
                    {
                        num = " " + (sayilar[0] * z);
                    }
                    Console.WriteLine(z + "x" + sayilar[0] + "=" + num + "  ");
                }
           
            }
            goto tekrargir;
