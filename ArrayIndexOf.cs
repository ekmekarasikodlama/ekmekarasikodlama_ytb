 string[] dizi = { "ekmek", "arası", "kodlama" };
        basadon:
          
            string veri = Console.ReadLine();
            if(dizi.Contains(veri))
            {
                Console.WriteLine(Array.IndexOf(dizi, veri));
                List<string> yeniDizi = dizi.ToList();
                yeniDizi.RemoveAt(Array.IndexOf(dizi, veri));
                dizi = yeniDizi.ToArray();
                foreach(string s in dizi)
                {
                    Console.WriteLine("yeni liste: " + s);
                }
            }
            goto basadon;
