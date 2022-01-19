//asal çarpanlara ayırma kısmı:
public static Dictionary<int, int> asalÇarpanlaraAyır(int ayrilacak)
        {
            Dictionary<int, int> carpanlarVeFrekanslari = new Dictionary<int, int>();

            int islemsayisi = ayrilacak;

            if(islemsayisi == 1)
            {
                Dictionary<int, int> dic = new Dictionary<int, int>();
                dic.Add(1, 1);
                return dic;
            }

            while (islemsayisi != 1)
            {
                for (int carpan = 2; carpan <= islemsayisi; carpan++)
                {
                    if (islemsayisi % carpan == 0)
                    {
                        islemsayisi /= carpan;
                        if (carpanlarVeFrekanslari.Any(x => x.Key == carpan) == false)
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
        
  //forms kısmı 
  
   public List<TextBox> sayiKutulari = new List<TextBox>();
        public List<Label> bolenyazilari = new List<Label>();

        public anaform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sayiKutulari.Add(tbox_sayi1);
            sayiKutulari.Add(tbox_sayi2);
        }

        private void btn_sayiekle_Click(object sender, EventArgs e)
        {
            TextBox yeniKutu = new TextBox();
            yeniKutu.Size = new Size(56, 35);
            yeniKutu.Font = tbox_sayi1.Font;
            yeniKutu.Location = new Point(15 + (sayiKutulari.Count * 60), 12);

            btn_sayiekle.Location = new Point(yeniKutu.Location.X + 100, 12);
            pbox_ayirac.Location = new Point(btn_sayiekle.Location.X - 40, 12);
            btn_işle.Location = new Point(btn_sayiekle.Location.X + 35, 12);
            btn_minimize.Location = new Point(btn_işle.Location.X + 140, 12);
            btn_kapat.Location = new Point(btn_minimize.Location.X + 35, 12);


            Controls.Add(yeniKutu);
            sayiKutulari.Add(yeniKutu);
            arayüzüTemizle();
            Size = new Size(420 + (sayiKutulari.Count-2) * 60,Size.Height);
        }

        void arayüzüTemizle()
        {
            foreach (Label l in bolenyazilari)
            {
                Controls.Remove(l);
            }
            bolenyazilari.Clear();
        }

        private void btn_işle_Click(object sender, EventArgs e)
        {
            arayüzüTemizle();
            if (sayiKutulari.All(x => int.TryParse(x.Text, out int a) == true) && sayiKutulari.Any(x => (x.Text == "" || x.Text == "0")) == false)
            {
                List<int> sayılar = new List<int>();
                foreach (TextBox tb in sayiKutulari)
                {
                    sayılar.Add(int.Parse(tb.Text));
                }

                List<int> orijinalKopya = sayılar;

                List<(int, bool)> kullanılanCarpanlar = new List<(int, bool)>();

                int işlemSayısı = 0;
                while (sayılar.Any(x => x != 1)) //herhangi bir sayı 1 olmadığı sürece
                {
                    List<int> enKucukler = new List<int>();
                    for (int i = 0; i < sayılar.Count; i++)
                    {
                        if (sayılar[i] != 1)
                        {
                            Dictionary<int, int> carpanDictionary = İşlem.asalÇarpanlaraAyır(sayılar[i]);
                            enKucukler.Add(carpanDictionary.ElementAt(0).Key);
                        }
                    }
                    int enKucukCarpan = enKucukler.Min();
                    //en kucuk carpan, çizginin sağına yazılmalı.
                    Label enKucukCarpanLabel = new Label();
                    enKucukCarpanLabel.Font = lbl_EBOB.Font;
                    enKucukCarpanLabel.Text = enKucukCarpan.ToString();
                    enKucukCarpanLabel.Location = new Point(btn_sayiekle.Location.X - 30, (btn_sayiekle.Location.Y + 10) + (işlemSayısı * 25));

                    //32 24 54 sayılarının asal çarpanları aldı, hepsinin çarpanlarından en küçük olanı, bütün sayılara uygulanacak.
                    bool ortak = sayılar.All(x => x % enKucukCarpan == 0);
                    enKucukCarpanLabel.Text += (ortak ? "*" : "");
                    Controls.Add(enKucukCarpanLabel);
                    bolenyazilari.Add(enKucukCarpanLabel);

                    for (int i = 0; i < sayılar.Count; i++)
                    {
                        Label bolumlabel = new Label();
                        bolumlabel.Font = lbl_EBOB.Font;
                        bolumlabel.AutoSize = false;
                        bolumlabel.Size = new Size(60, 20);
                        bolumlabel.TextAlign = ContentAlignment.TopCenter;
                        bolumlabel.Location = new Point(5 + (i * 60), 25 + ((işlemSayısı + 1) * 25));
                        if (sayılar[i] % enKucukCarpan == 0)
                        {
                            sayılar[i] /= enKucukCarpan;
                        }
                        bolumlabel.Text = sayılar[i].ToString();
                    

                        Controls.Add(bolumlabel);
                        bolenyazilari.Add(bolumlabel);
                    }
                    kullanılanCarpanlar.Add((enKucukCarpan, ortak));
                    işlemSayısı++;
                }
                pbox_ayirac.Size = new Size(5, 20 + (işlemSayısı * 32));
                lbl_EBOB.Location = new Point(10, 20 + (işlemSayısı * 40));
                lbl_ekok.Location = new Point(10, lbl_EBOB.Location.Y + 20);
                Size = new Size(Size.Width, 75 + işlemSayısı * 50);
                //EBOB
                var ortaklar =
                    from carpan in kullanılanCarpanlar
                    where carpan.Item2 == true
                    select carpan;

                int ebob = 1;
                string işlem = "";
                for (int i = 0; i < ortaklar.Count(); i++)
                {
                    ebob *= ortaklar.ElementAt(i).Item1;
                    işlem += ortaklar.ElementAt(i).Item1.ToString();
                    işlem += (i != ortaklar.Count() - 1 ?  "*" : "");
                }
                if(işlem.Count() == 1)
                {
                    işlem += "*1";
                }
                lbl_EBOB.Text = "EBOB: " + (ebob != 1 ? ebob.ToString() + ", İşlemler: " + işlem : "Aralarında asal sayılar.");

                //EKOK
                int ekok = 1;
                string ekokişlem = "";
                for (int i = 0; i < kullanılanCarpanlar.Count(); i++)
                {
                    ekok *= kullanılanCarpanlar[i].Item1;
                    ekokişlem += kullanılanCarpanlar[i].Item1.ToString();
                    ekokişlem += (i != kullanılanCarpanlar.Count() - 1 ? "*" : "");
                }
                if(ekokişlem.Count() == 1)
                {
                    ekokişlem += "*1";
                }
                lbl_ekok.Text = "EKOK: " + ekok.ToString() + ", İşlemler: " + ekokişlem;
            }
            else
            {
                MessageBox.Show("Bütün metin kutularında geçerli değerler bulunmamaktadır.");
                foreach(TextBox tb in sayiKutulari)
                {
                    tb.Text = "";
                }
            }

        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        bool drag = false;
        private void anaform_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
        }

        private void anaform_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void anaform_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Location = new Point(Location.X + e.X, Location.Y + e.Y);
            }
        }
