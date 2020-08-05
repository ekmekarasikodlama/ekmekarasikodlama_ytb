static void Main(string[] args)
        {
            //Bir tane sayı
            //6 karakterden uzun
            //1 büyük harf olmalı
            char[] karakterler;

            baslangic();

            void baslangic()
            {
                Console.Write("Şifre girin:");
                string girilenSifre = Console.ReadLine();
                karakterler = girilenSifre.ToArray();
                sayikontrol();
            }

            void sayikontrol()
            {
                foreach(char karakter in karakterler)
                {
                    if(char.IsNumber(karakter))
                    {
                        uzunlukKontrol();
                        return;
                    }
                }
                Console.WriteLine(Environment.NewLine + "En az bir sayı girilmeli." + Environment.NewLine);
                baslangic();
            }

            void uzunlukKontrol() 
            {
                if(karakterler.Length >= 6)
                {
                    buyukHarfKontrol();
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "En az 6 karakter uzunluğunda olmalı" + Environment.NewLine);
                    baslangic();
                }

            }

            void buyukHarfKontrol()
            {
                foreach(char karakter in karakterler)
                {
                    if(char.IsUpper(karakter))
                    {
                        sonlandir();
                        return;
                    }
                }
                Console.WriteLine(Environment.NewLine + "En az bir büyük harf olmalıdır" + Environment.NewLine);
                baslangic();
            }

            void sonlandir()
            {
                Console.WriteLine(Environment.NewLine + "Şifre uygun.");
                Console.ReadLine();
            }
        }
