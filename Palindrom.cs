            basadon:
            Console.WriteLine("Lütfen veri giriniz:");
            Console.Write(">");
            string veri = Console.ReadLine();
            if(string.IsNullOrEmpty(veri))
            {
                goto basadon;
            }
            char[] normal = veri.ToArray();
            char[] ters = veri.ToArray();
            Array.Reverse(ters);
           
            bool palindrom = true;
            for(int i = 0; i < veri.ToArray().Count();i++)
            {
                if(normal[i] != ters[i])
                {
                    palindrom = false;
                }
            }
            Console.WriteLine("Palindrom mu? " + palindrom);
            Console.WriteLine(" ");
            goto basadon;
