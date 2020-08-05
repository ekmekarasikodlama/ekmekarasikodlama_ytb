 static void Main(string[] args)
        {
            string veri_tarih = Console.ReadLine();
            string gun, ay, yil;
            gun = null;
            ay = null;
            yil = null;
            if (veri_tarih.Split('/').Length > -1)
            {
                string[] tarihVerileriYC = veri_tarih.Split('/');
                gun = tarihVerileriYC[0];
                ay = tarihVerileriYC[1];
                yil = tarihVerileriYC[2];
                
            }else if(veri_tarih.Split('.').Length > -1)
            {
                string[] tarihVerileriN = veri_tarih.Split('.');
                gun = tarihVerileriN[0];
                ay = tarihVerileriN[1];
                yil = tarihVerileriN[2];
            }

            if(gun != null && ay != null && yil != null)
            {
                Console.WriteLine("Gün: " + gun);
                Console.WriteLine("Ay: " + ay);
                Console.WriteLine("Yıl: " + yil);
            }
            Console.ReadLine();
        }
    }
