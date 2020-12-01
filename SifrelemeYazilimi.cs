 char[] alfabe = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g','ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z' };
            tekrarsifre:
            Console.WriteLine("Şifrelenecek mesajı girin:");
            Console.Write(">");
            string sifre = Console.ReadLine();
            if(sifre == string.Empty||sifre.Count() > 32)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Şifre boş olmamalı veya 32 karakterden uzun olmamalıdır.");
                Console.ForegroundColor = ConsoleColor.White;
                goto tekrarsifre;
            }
            string[,] anahtar = new string[sifre.Split(' ').Count(), alfabe.Count()];
           
            Random rnd = new Random();
            for (int row = 0; row < sifre.Split(' ').Count();row++)
            {
                List<char> allReadymade = new List<char>(){ };
              
                for(int column = 0; column < alfabe.Count();column++)
                {
                reassign:
                    int randNum = rnd.Next(0, alfabe.Count());
                   
                    if(!allReadymade.Contains(alfabe[randNum]) && anahtar[row,column] != alfabe[randNum].ToString())
                    {
                        anahtar[row, column] = alfabe[randNum].ToString();
                        allReadymade.Add(alfabe[randNum]);
;                    }
                    else
                    {
                        goto reassign;
                    }
                }
           
            }

            for (int row = 0; row < sifre.Split(' ').Count(); row++)
            {
                Console.WriteLine("Sözcük: " + (row+1)+  " ");
                string eklenecek = "";
                for (int s = 0; s < alfabe.Count(); s++)
                {
                    if(s != alfabe.Count() -1)
                    {
                        Console.Write(alfabe[s] + " ");
                    }
                    else
                    {
                        Console.WriteLine(alfabe[s] + " ");
                    }

                    eklenecek += "| ";
                }
                Console.WriteLine(eklenecek) ;
                for (int column = 0; column < alfabe.Count(); column++)
                {
                    Console.Write(anahtar[row, column] + " ");
                }
                Console.WriteLine(Environment.NewLine); 
            }
           
           
            string sifrelenmis = "";
            for(int word = 0; word < sifre.Split(' ').Count();word++)
            {
                for(int letter = 0; letter < sifre.Split(' ')[word].ToArray().Count(); letter++)
                {
                    
                        for (int column = 0; column < alfabe.Count(); column++)
                        {
                        int letterInAlphabet = Array.IndexOf(alfabe, sifre.Split(' ')[word].ToArray()[letter]);
                       if(column == letterInAlphabet)
                        {
                            sifrelenmis += anahtar[word,column];
                        }

                        }
                    
                }
                sifrelenmis += " ";

            }
            Console.WriteLine(sifrelenmis);
            
            Console.Read();
