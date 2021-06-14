static void Main(string[] args)
        {
            tekrargir:
            double pay, payda;
            double istenenPayda, sonuc;
            Console.WriteLine("İlk kesiri giriniz: Formatınız (x/y) olmalıdır.");
            string veri = Console.ReadLine();
            string[] bolunmus = veri.Split('/');
            if (bolunmus.Length > 2) { goto tekrargir; }
            if(double.TryParse(bolunmus[0], out pay) == false) { goto tekrargir; }
            if(double.TryParse(bolunmus[1], out payda) == false) { goto tekrargir; }
            Console.WriteLine("İstenen paydayı giriniz:");
            string veri1 = Console.ReadLine();
            if(double.TryParse(veri1, out istenenPayda) == false) { goto tekrargir; }
            sonuc = (pay * istenenPayda) / payda;

            Console.WriteLine("--------");
            Console.WriteLine("Sonuç: " + sonuc);
            Console.WriteLine("--------");
            goto tekrargir;
        }
