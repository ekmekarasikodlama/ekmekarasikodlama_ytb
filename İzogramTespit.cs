 basadon:
            Console.WriteLine("Veri giriniz:");
            Console.Write(">");
            string veri = Console.ReadLine();
            if(string.IsNullOrEmpty(veri) == true)
            {
                goto basadon;
            }
            
            string kullanılacak = veri.ToLower();
            List<char> karakterler = new List<char>();
            bool isogram = true;

            foreach(char karakter in kullanılacak.ToArray())
            {
                if(karakterler.Contains(karakter) == false)
                {
                    karakterler.Add(karakter);
                }
                else
                {
                    isogram = false;
                }
            }

            Console.WriteLine("İsogram mı? " + isogram);
            goto basadon;
