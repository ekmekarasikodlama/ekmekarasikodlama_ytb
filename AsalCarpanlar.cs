//sadece çarpalara ayırma kısmını içerir.

        public static Dictionary<int,int> asalÇarpanlaraAyır(int ayrilacak)
        {
            Dictionary<int, int> carpanlarVeFrekanslari = new Dictionary<int, int>();

            int islemsayisi = ayrilacak;
            while(islemsayisi != 1)
            {
                for (int carpan = 2; carpan <= islemsayisi; carpan++)
                {
                    if(islemsayisi % carpan == 0)
                    {
                        islemsayisi /= carpan;
                        if(carpanlarVeFrekanslari.Any(x => x.Key == carpan) == false)
                        {
                            carpanlarVeFrekanslari.Add(carpan, 1);
                        }
                        else
                        {
                            carpanlarVeFrekanslari[carpan]++;
                        }
                        break;
                    }
                }
            }

           
            return carpanlarVeFrekanslari;
        }
