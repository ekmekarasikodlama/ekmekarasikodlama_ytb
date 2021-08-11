public struct sonuc
{
public string kokDisi;
public string kokİci;
}
public sonuc hesapla(int derece, int sayı)
{
sonuc sonuc = new sonuc();
  bolenHesapla();
            void bolenHesapla()
            {
                int sayiTutucu = sayi;
                List<int> bolenler = new List<int>();
                while (sayiTutucu > 1)
                {
                    for (int i = 2; i <= sayi; i++)
                    {
                        if (sayiTutucu % i == 0)
                        {
                            bolenler.Add(i);
                            sayiTutucu /= i;
                            break;
                        }
                    }
                }
                frekansHesapla(bolenler);
            }

            void frekansHesapla(List<int> bolenler)
            {

                List<int> temp = bolenler;
                Dictionary<int, int> frekansTablosu = new Dictionary<int, int>();
                List<int> yapilanlar = new List<int>();
                for (int num = 0; num < bolenler.Count; num++)
                {

                    int thisnumber = bolenler[num];
                    if (yapilanlar.Contains(thisnumber) == false)
                    {
                        yapilanlar.Add(thisnumber);
                        int freq = 1;
                        for (int num2 = 0; num2 < temp.Count; num2++)
                        {
                            if (num != num2)
                            {
                                if (thisnumber == temp[num2] && temp[num2] != 0)
                                {
                                    freq++;
                                    temp[num2] = 0;
                                }
                            }
                        }
                        if (bolenler[num] != 0)
                            frekansTablosu.Add(bolenler[num], freq);

                    }
                }
                kokHesapla(frekansTablosu);
            }

            void kokHesapla(Dictionary<int, int> frekansTablo)
            {
                int kokici = 1;
                int kokdisi = 1;
                foreach (KeyValuePair<int, int> pair in frekansTablo)
                {
                    int bolum = pair.Value / derece;
                    int kdis = 1;
                    if (bolum > 0)
                    {
                        kdis = usdondur(pair.Key, bolum);
                    }

                    int moddeger = pair.Value % derece;
                    int kic = 1;
                    if (moddeger > 0)
                    {
                        kic = usdondur(pair.Key, moddeger);
                    }


                    if (kdis <= 0) { kdis = 1; }

                    kokdisi *= kdis;
                    if (kic > 0)
                    {
                        kokici *= kic;
                    }
                }
                sonucVer(kokdisi, kokici);
            }
            void sonucVer(int kokdisi, int kokici)
            {
                lbl_derece.Text = derece.ToString();
                if (kokici == 1)
                {
                 sonuc.kokİci = "";
                 sonuc.kokDisi = kokdisi.ToString();
                }else
                {
                    if(kokdisi == 1)
                    {
                    sonuc.kokDisi = "";
                    sonuc.kokİci = kokici.ToString();

                    }else
                    {
                    sonuc.kokDisi = kokdisi.ToString();
                    sonuc.kokİci = kokici.ToString();
                    }
                }
            }
}

//kullanılan bir void:
int usdondur(int taban, int kuvvet)
        {
            int dondurulecek = taban;
            for(int i = 1; i < kuvvet; i++)
            {
                dondurulecek *= taban;
            }
            return dondurulecek;
        }
