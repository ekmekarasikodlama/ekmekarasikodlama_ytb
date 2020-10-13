//PROGRAM.CS KISMI
                 menu:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Üs almak için <us>, karekök almak için <kok> yazın. Ana menüye dönmek için <menu> yazın.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(">");
                string secili_islem = Console.ReadLine();
                if (secili_islem == "menu") {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ana menüye yönlendirildiniz.");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto anamenu; }
                else if (secili_islem == "us")
                {
                tekrar_us:

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Taban sayısını yazın.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(">");
                    string sayi1 = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Kuvveti yazın.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(">");
                    string kuvvet = Console.ReadLine();
                    if (!float.TryParse(sayi1, out float degerTaban) || !int.TryParse(kuvvet, out int degerKuvvet))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Girdiğiniz veriler sayıya dönüştürülemiyor.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto tekrar_us;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Sonuç: " + hesaplamalar.us(degerTaban, degerKuvvet));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Eğer ana menüye dönmek istiyorsanız <menu> yazın. Eğer istemiyorsanız boş bırakabilir veya herhangi başka bir şey yazabilirsiniz.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(">");
                    string menudon = Console.ReadLine();
                    if (menudon == "menu")
                    {
                        goto anamenu;

                    }
                    else
                    {
                        goto tekrar_us;
                    }

                } else if (secili_islem == "kok")
                {
                tekrar_kok:

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Sayıyı yazın.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(">");
                    string sayi1 = Console.ReadLine();
                    if (!float.TryParse(sayi1, out float degerSayi))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Girdiğiniz veriler sayıya dönüştürülemiyor.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto tekrar_kok;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Sonuç: " + hesaplamalar.karekok(degerSayi));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Eğer ana menüye dönmek istiyorsanız <menu> yazın. Eğer istemiyorsanız boş bırakabilir veya herhangi başka bir şey yazabilirsiniz.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(">");
                    string menudon = Console.ReadLine();
                    if (menudon == "menu")
                    {
                        goto anamenu;

                    }
                    else
                    {
                        goto tekrar_kok;
                    }
                }

//HESAPLAMALAR.CS KISMI
 public static float us(float taban, int us)
        {

            float.TryParse(Math.Pow(double.Parse(taban.ToString()), double.Parse(us.ToString())).ToString(), out float a);

            return a;
        }
        public static float karekok(float sayi)
        {
            return float.Parse(Math.Sqrt(double.Parse(sayi.ToString())).ToString());
        }
