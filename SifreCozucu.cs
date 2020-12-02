 char[] alfabe = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z' };

            Console.WriteLine("Şifreleme yazılımı stilindeki şifreleri çözmekte kullanılır.");
            ilkBas:
            Console.WriteLine("Lütfen sözcük sayısını giriniz.Her bir harfin karşılığı size verilen anahtarda bulunacaktır. Hepsini teker teker girmeniz gerekmektedir.");
            string sozcukSayiText = Console.ReadLine();
            if(int.TryParse(sozcukSayiText, out int sozcukSayi) == false)
            {
                Console.WriteLine("Girilen sözcük dönüştürülemiyor.");
                goto ilkBas;
            }
            string[,] anahtar = new string[sozcukSayi, alfabe.Count()];
            for(int i = 0; i < sozcukSayi;i++)
            {
                Console.WriteLine("Sözcük: " + (i + 1));
                List<string> doneBefore = new List<string>();
                for(int k = 0; k < alfabe.Count(); k++)
                {
                    tekrargir:
                    Console.Write("Lütfen " + alfabe[k] + " için olan değeri giriniz: ");
                    string deger = Console.ReadLine();
                    if(deger != string.Empty && string.IsNullOrWhiteSpace(deger) == false && doneBefore.Contains(deger) == false)
                    {
                        anahtar[i, k] = deger;
                        doneBefore.Add(deger);
                    }
                    else
                    {
                        Console.WriteLine("Girilen değer boş olamaz ,birden fazla karakter uzunluğunda olamaz veya daha önce yazılmış olamaz.");
                        goto tekrargir;
                    }
                }
            }
         
            Console.WriteLine("Size gönderilen şifrelenmiş metni giriniz. Boşluklara dikkat etmeniz önem taşımaktadır.");
            string cozulecek = Console.ReadLine();
            string[] cumleler = cozulecek.Split(' ');
            string desifre = "";
            for(int sozcuk = 0;sozcuk < cumleler.Count();sozcuk++)
            {
                char[] karakterler = cumleler[sozcuk].ToCharArray();
                for (int karakter = 0; karakter < karakterler.Count(); karakter++)
                {
                    for (int column = 0; column < alfabe.Count(); column++)
                    {
                        //row = sözcük
                        if(karakterler[karakter].ToString() == anahtar[sozcuk,column])
                        {
                            
                            desifre += alfabe[column];
                        }
                    }
                }
            }
            Console.WriteLine("Deşifre: " + desifre);
            Console.Read();
