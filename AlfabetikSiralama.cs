    static void Main(string[] args)
        {
        basadon:
            List<string> veriler = new List<string>();
        tekrarveri:
            Console.Write(">");
            string veri = Console.ReadLine();
            if (veri != "tamam")
            {
                if (string.IsNullOrEmpty(veri) == false)
                {
                    veriler.Add(veri);
                    goto tekrarveri;
                }

            }
            else
            {
                if (veriler.Count() > 0)
                {
                    goto devamet;
                }
                else
                {
                    goto tekrarveri;
                }
            }
        devamet:
            Console.WriteLine("\n");
            veriler.Sort((x, y) => string.Compare(x, y));
            foreach (string eleman in veriler)
            {
                Console.WriteLine(eleman);
            }
            goto basadon;

        }
