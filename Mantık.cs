//Program.cs için

Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("İşlem olarak mantıksal operatörler seçildi.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Örnek kullanım: p(') (ve/veya/yada/ise/ancakveancak) q(')  (I-inverse/C-converse/CP-contrapositive)" + Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;
                List<int> saklananlar = new List<int>();
                bool sakla = false;
            start:
                Console.Write(">");
                string cumle = Console.ReadLine();
                int sayi1 = 0;
                int sayi2 = 0;
                bool negate1 = false;
                bool negate2 = false;
                bool getInverse = false;
                bool getConverse = false;
                bool getContraPositive = false;
                bool negateOperator = false;

                string s_operator = "";
                string org_operator = "";

                string[] veriler = cumle.Split(' ');
                if (veriler.Length > 1 && cumle != "sakla" && cumle != "karsilastir" && cumle != "t" && cumle != "s" && cumle != "menu" && cumle != "S")
                {
                    if (veriler[0].Contains("'")) { negate1 = true; int.TryParse(veriler[0].Substring(0, veriler[0].Length - 1), out sayi1); } else { negate1 = false; int.TryParse(veriler[0], out sayi1); }
                    if (veriler[2].Contains("'")) { negate2 = true; int.TryParse(veriler[2].Substring(0, veriler[2].Length - 1), out sayi2); } else { negate2 = false; int.TryParse(veriler[2], out sayi2); }
                    if (veriler.Length > 3)
                    {                      
                        if (veriler[3] == "I") { getInverse = true; } else { getInverse = false; }
                        if (veriler[3] == "C") { getConverse = true; } else { getConverse = false; }
                        if (veriler[3] == "CP") { getContraPositive = true; } else { getContraPositive = false; }

                    }
                  
                    s_operator = veriler[1];
                    if (s_operator.Contains("'")) { s_operator = s_operator.Substring(0, s_operator.Length - 1); negateOperator = true; } else { negateOperator = false; }
                    if (negateOperator == true && s_operator == "ve") { org_operator = "ve"; s_operator = "veya"; } else if (negateOperator == true && s_operator == "veya") { org_operator = "veya"; s_operator = "ve"; }
                    if (sayi1 > 1 || sayi2 > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("1 veya 0 girmeniz gerekmektedir.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto start;
                    }
                    bool deger1 = Convert.ToBoolean(sayi1);
                    bool deger2 = Convert.ToBoolean(sayi2);
                    if (negate1) { if (deger1) { deger1 = false; } else { deger1 = true; } }
                    if (negate2) { if (deger2) { deger2 = false; } else { deger2 = true; } }
                    int sonuc = 0;
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (s_operator == "ve" || s_operator == "VE")
                    {                        
                            sonuc = Convert.ToInt16(hesaplamalar.VE(deger1, deger2));
                            Console.WriteLine("Sonuç: " + sonuc);                     

                    }
                    else if (s_operator == "veya" || s_operator == "VEYA")
                    {
                            sonuc = Convert.ToInt16(@hesaplamalar.VEYA(deger1, deger2));
                           Console.WriteLine("Sonuç: " + sonuc);                      
                    }
                    else if (s_operator == "yada" || s_operator == "YADA")
                    {
                            sonuc = Convert.ToInt16(hesaplamalar.YADA(deger1, deger2));
                            Console.WriteLine("Sonuç: " + sonuc);
                    }
                    else if (s_operator == "ise" || s_operator == "İSE")
                    {
                            sonuc = Convert.ToInt16(hesaplamalar.İSE(deger1, deger2));
                            Console.WriteLine("Sonuç: " + sonuc);
                    }
                    else if (s_operator == "ancakveancak" || s_operator == "ANCAKVEANCAK")
                    {
                            sonuc = Convert.ToInt16(hesaplamalar.ANCAKVEANCAK(deger1, deger2));
                            Console.WriteLine("Sonuç: " + sonuc);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Girdiğiniz operatör tanınamadı.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto start;
                    }
                    if (negateOperator) { Console.WriteLine("Operatör " + org_operator + " 'den " + s_operator + "'e çevirildi."); }
                    if (getInverse) { Console.WriteLine(hesaplamalar.inverse(cumle)); }
                    if (getConverse) { Console.WriteLine(hesaplamalar.converse(cumle)); }
                    if (getContraPositive) { Console.WriteLine(hesaplamalar.contrapositive(cumle)); }
                    if (sakla) { saklananlar.Add(sonuc); }
                    Console.ForegroundColor = ConsoleColor.White;

                    s_operator = "";
                    cumle = "";
                    org_operator = "";
                    negate1 = false;
                    negate2 = false;
                    sayi1 = 0;
                    sayi2 = 0;
                    getInverse = false;
                    getConverse = false;
                    getContraPositive = false;
                    negateOperator = false;
                    sonuc = 0;
                    sakla = false;

                }
                else if (cumle == "sakla" || cumle == "SAKLA" || cumle == "S" || cumle == "s")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Bu sonuç saklanacak.");
                    Console.ForegroundColor = ConsoleColor.White;
                    sakla = true;
                }
                else if (cumle == "karşılaştır" || cumle == "karsilastir" || cumle == "KARŞILAŞTIR" || cumle == "KŞ" || cumle == "kş")
                {
                    Console.WriteLine("Operatör seçiniz.");
                    Console.Write(">");
                    string istenenoperator = Console.ReadLine();

                    bool sonuc = Convert.ToBoolean(saklananlar[0]);
                    string islemler = Convert.ToInt16(sonuc).ToString();
                    for (int a = 1; a < saklananlar.Count; a++)
                    {
                        bool deger = Convert.ToBoolean(saklananlar[a]);
                        if (istenenoperator == "ve")
                        {
                            sonuc = hesaplamalar.VE(sonuc, deger);
                            islemler += " ve " + Convert.ToInt16(deger);
                        }
                        else if (istenenoperator == "veya")
                        {
                            sonuc = hesaplamalar.VEYA(sonuc, deger);
                            islemler += " veya " + Convert.ToInt16(deger);
                        }
                        else if (istenenoperator == "yada")
                        {
                            sonuc = hesaplamalar.YADA(sonuc, deger);
                            islemler += " yada " + Convert.ToInt16(deger);
                        }
                        else if (istenenoperator == "ise")
                        {
                            sonuc = hesaplamalar.İSE(sonuc, deger);
                            islemler += " ise " + Convert.ToInt16(deger);
                        }
                        else if (istenenoperator == "ancakveancak")
                        {
                            sonuc = hesaplamalar.ANCAKVEANCAK(sonuc, deger);
                            islemler += " ancakveancak " + Convert.ToInt16(deger);
                        }
                    }
                    Console.WriteLine("Ortaya çıkan sonuç: " + Convert.ToInt16(sonuc) + Environment.NewLine);
                    Console.WriteLine("İşlemler: " + islemler);

                }
                else if (cumle == "temizle" || cumle == "t" || cumle == "T")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Değer listesi temizlendi.");
                    saklananlar.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (cumle == "yazisil" || cumle == "yazısil" || cumle == "YAZISİL" || cumle == "YZ")
                {
                    Console.Clear();
                } else if (cumle == "menu")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ana menüye dönüldü.");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto anamenu;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Lütfen geçerli veriler girin.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                goto start;
                
                
                
                
 //HESAPLAMALAR SINIFI
 public class hesaplamalar
    {
        #region Mantık
        public static bool VE(bool a, bool b)
        {
            return a & b;
        }
        public static bool VEYA(bool a, bool b)
        {
            return a | b;
        }
        public static bool YADA(bool a, bool b)
        {
            return a ^ b; 
        }
        public static bool İSE(bool a, bool b)
        {
            bool sonuc = false;
            if (a == true && b == true) { sonuc = true; }
            if (a == true && b == false) { sonuc = false; }
            if (a == false && b == true) { sonuc = true; }
            if (a == false && b == false) { sonuc = true; }
            return sonuc;
        }
        public static bool ANCAKVEANCAK(bool a, bool b)
        {
            return a == b; 
        }
        public static string inverse(string sentence)
        {

            string[] veriler = sentence.Split(' ');
            int sayi1, sayi2;
            string operatör;
            bool negate1, negate2;
            if (veriler[0].Contains("'")) { negate1 = true; int.TryParse(veriler[0].Substring(0, veriler[0].Length - 1), out sayi1); } else { negate1 = false; int.TryParse(veriler[0], out sayi1); }
            if (veriler[2].Contains("'")) { negate2 = true; int.TryParse(veriler[2].Substring(0, veriler[2].Length - 1), out sayi2); } else { negate2 = false; int.TryParse(veriler[2], out sayi2); }

            bool deger1 = false, deger2 = false;
            if (negate1 == false) { deger1 = Convert.ToBoolean(sayi1); } else { deger1 = Convert.ToBoolean(sayi1); if (deger1) { deger1 = false; } else { deger1 = true; } }
            if (negate2 == false) { deger2 = Convert.ToBoolean(sayi2); } else { deger2 = Convert.ToBoolean(sayi2); if (deger2) { deger2 = false; } else { deger2 = true; } }
            operatör = veriler[1];
            if (operatör == "ise")
            {
                return "Inverse : " + Convert.ToInt16(!deger1).ToString() + " ise " + Convert.ToInt16(!deger2).ToString() + Environment.NewLine + "Yeni Değer: " + Convert.ToInt16(İSE(!deger1, !deger2));
            }
            else
            {
                return "Sadece => (ise) için bu değer alınabilmektedir.";
            }
        }
        public static string converse(string sentence)
        {
            string[] veriler = sentence.Split(' ');
            int sayi1, sayi2;
            string operatör;
            bool negate1, negate2;
            if (veriler[0].Contains("'")) { negate1 = true; int.TryParse(veriler[0].Substring(0, veriler[0].Length - 1), out sayi1); } else { negate1 = false; int.TryParse(veriler[0], out sayi1); }
            if (veriler[2].Contains("'")) { negate2 = true; int.TryParse(veriler[2].Substring(0, veriler[2].Length - 1), out sayi2); } else { negate2 = false; int.TryParse(veriler[2], out sayi2); }

            bool deger1 = false, deger2 = false;
            if (negate1 == false) { deger1 = Convert.ToBoolean(sayi1); } else { deger1 = Convert.ToBoolean(sayi1); if (deger1) { deger1 = false; } else { deger1 = true; } }
            if (negate2 == false) { deger2 = Convert.ToBoolean(sayi2); } else { deger2 = Convert.ToBoolean(sayi2); if (deger2) { deger2 = false; } else { deger2 = true; } }
            operatör = veriler[1];
            if (operatör == "ise")
            {
                return "Converse : " + Convert.ToInt16(deger2).ToString() + " ise " + Convert.ToInt16(deger1).ToString() + Environment.NewLine + "Yeni Değer: " + Convert.ToInt16(İSE(deger2, deger1));
            }
            else
            {
                return "Sadece => (ise) için bu değer alınabilmektedir.";
            }
        }
        public static string contrapositive(string sentence)
        {
            string[] veriler = sentence.Split(' ');
            int sayi1, sayi2;
            string operatör;
            bool negate1, negate2;
            if (veriler[0].Contains("'")) { negate1 = true; int.TryParse(veriler[0].Substring(0, veriler[0].Length - 1), out sayi1); } else { negate1 = false; int.TryParse(veriler[0], out sayi1); }
            if (veriler[2].Contains("'")) { negate2 = true; int.TryParse(veriler[2].Substring(0, veriler[2].Length - 1), out sayi2); } else { negate2 = false; int.TryParse(veriler[2], out sayi2); }

            bool deger1 = false, deger2 = false;
            if (negate1 == false) { deger1 = Convert.ToBoolean(sayi1); } else { deger1 = Convert.ToBoolean(sayi1); if (deger1) { deger1 = false; } else { deger1 = true; } }
            if (negate2 == false) { deger2 = Convert.ToBoolean(sayi2); } else { deger2 = Convert.ToBoolean(sayi2); if (deger2) { deger2 = false; } else { deger2 = true; } }
            operatör = veriler[1];
            if (operatör == "ise")
            {
                return "Contrapositive : " + Convert.ToInt16(!deger2).ToString() + " ise " + Convert.ToInt16(!deger1).ToString() + Environment.NewLine + "Yeni Değer: " + Convert.ToInt16(İSE(!deger2, !deger1));
            }
            else
            {
                return "Sadece => (ise) için bu değer alınabilmektedir.";
            }
        }
        #endregion
