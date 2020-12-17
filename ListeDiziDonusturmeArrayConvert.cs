  static void Main(string[] args)
        {
            basadon:
            List<int> liste = new List<int>();
            tekrargir:
            Console.Write(">");
            string veri = Console.ReadLine();
            if(veri != "tamam")
            {
                if(int.TryParse(veri, out int sayi))
                {
                    liste.Add(sayi);
                    goto tekrargir;
                }
                else
                {
                    goto tekrargir;
                }
            }
            else
            {
                if(liste.Count > 0)
                {
                    goto devamet;
                }
                else
                {
                    goto tekrargir;
                }
            }
        devamet:
            string[] degerler;
            degerler = Array.ConvertAll(liste.ToArray(), Convert.ToString);
            for(int i = 0; i < degerler.Length;i++)
            {
                degerler[i] += "a";
                Console.WriteLine(degerler[i]);
            }
            Console.WriteLine("\n");
            goto basadon;
        }
