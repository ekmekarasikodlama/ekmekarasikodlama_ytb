//küme işlemleri

public static List<int> kesişim(List<List<int>> kümeler)
        {
            return kümeler.Aggregate((prev, next) => prev.Intersect(next).ToList());
        }
        public static List<int> birleşim(List<List<int>> kümeler)
        {
            List<int> sonuc = kümeler[0];
            for(int i = 1; i < kümeler.Count; i++)
            {
                for(int e = 0; e < kümeler[i].Count; e++)
                {
                    int eleman = kümeler[i][e];
                    if(sonuc.Contains(eleman) == false)
                    {
                        sonuc.Add(eleman);
                    }
                }
            }

            return sonuc;
        }

        public static bool icerir(int eleman, List<int> liste)
        {
            return liste.Contains(eleman);
        }
        
        
        //FORMS
        
 public List<KümeKontrol> kümeSayfaları = new List<KümeKontrol>();
        public List<KümeKontrol> seçilenKümeSayfaları = new List<KümeKontrol>();

        char[] harfler = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'Y', 'Z' };
        public AnaForm()
        {
            InitializeComponent();
        }
        int currentDif = 0;
        public void checkEnlargement()
        {
            List<int> diff = new List<int>();
            foreach (KümeKontrol kt in kümeSayfaları)
            {
                diff.Add(kt.elemanKutuları.Count - 6);
            }

            int max = diff.Max();

            if (max > 0)
            {
                currentDif = max;
                Size = new Size(815 + (currentDif * 60), 490);
                gbox_islemler.Location = new Point(550 + (currentDif * 60), gbox_islemler.Location.Y);
               
            }
        }

        void placeUIObjects()
        {
            for(int i = 0; i < kümeSayfaları.Count; i++)
            {
                KümeKontrol crnt = kümeSayfaları[i];
                crnt.setNewID(harfler[i]);

                crnt.Location = new Point(lbl_kumeler.Location.X, lbl_kumeler.Location.Y + (i+1) * 40);
                btn_ekle.Location = new Point(crnt.Location.X, crnt.Location.Y + 40);
            }

            int diff = kümeSayfaları.Count() - 9;

            if (diff > 0)
            {
                Size = new Size(Size.Width, 480 + (diff * 42));
                gbox_islemler.Size = new Size(gbox_islemler.Size.Width, 430 + (diff * 42));
            }
        }

        public void deleteSet(KümeKontrol silinecek)
        {
            kümeSayfaları.Remove(silinecek);
            if(seçilenKümeSayfaları.Contains(silinecek))
            {
                seçilenKümeSayfaları.Remove(silinecek);
            }

            Controls.Remove(silinecek);
            placeUIObjects();
        }


        public void changeCheckSituation()
        {
            seçilenKümeSayfaları.Clear();
            foreach (KümeKontrol kt in kümeSayfaları)
            {
                if (kt.seçildi)
                {
                    seçilenKümeSayfaları.Add(kt);
                }
            }
        }
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (kümeSayfaları.Count() < harfler.Count())
            {
                KümeKontrol kontrol = new KümeKontrol(harfler[kümeSayfaları.Count()], this);


                Controls.Add(kontrol);
                kümeSayfaları.Add(kontrol);

                placeUIObjects();

            }
        }

        private void btn_kesişim_Click(object sender, EventArgs e)
        {
            if (seçilenKümeSayfaları.Count > 1)
            {
                List<(bool, List<int>)> sonuclar = new List<(bool, List<int>)>();
                foreach (KümeKontrol kt in kümeSayfaları)
                {
                    sonuclar.Add(kt.degerVer());
                }
                if (sonuclar.All(x => x.Item1 == true))
                {
                    List<List<int>> kumeler = new List<List<int>>();
                    foreach (KümeKontrol kt in kümeSayfaları)
                    {
                        kumeler.Add(kt.degerVer().Item2);
                    }
                    List<int> sonuc = İşlemler.kesişim(kumeler);
                    lbox_sonuc.Items.Clear();
                    foreach (int s in sonuc)
                    {
                        lbox_sonuc.Items.Add(s);
                    }
                }
            }
        }

        private void btn_birlesim_Click(object sender, EventArgs e)
        {
            if (seçilenKümeSayfaları.Count > 1)
            {
                List<(bool, List<int>)> sonuclar = new List<(bool, List<int>)>();
                foreach (KümeKontrol kt in kümeSayfaları)
                {
                    sonuclar.Add(kt.degerVer());
                }
                if (sonuclar.All(x => x.Item1 == true))
                {
                    List<List<int>> kumeler = new List<List<int>>();
                    foreach (KümeKontrol kt in kümeSayfaları)
                    {
                        kumeler.Add(kt.degerVer().Item2);
                    }
                    List<int> sonuc = İşlemler.birleşim(kumeler);
                    lbox_sonuc.Items.Clear();
                    foreach (int s in sonuc)
                    {
                        lbox_sonuc.Items.Add(s);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (seçilenKümeSayfaları.Count > 1 && int.TryParse(tbox_icerik.Text, out int i))
            {
                List<(bool, List<int>)> sonuclar = new List<(bool, List<int>)>();
                foreach (KümeKontrol kt in kümeSayfaları)
                {
                    sonuclar.Add(kt.degerVer());
                }
                if (sonuclar.All(x => x.Item1 == true))
                {
                    List<List<int>> kumeler = new List<List<int>>();
                    foreach (KümeKontrol kt in kümeSayfaları)
                    {
                        kumeler.Add(kt.degerVer().Item2);
                    }
                    List<bool> icerir = new List<bool>();
                    foreach (List<int> kume in kumeler)
                    {
                        icerir.Add(kume.Contains(i));
                    }
                    bool sonuc = icerir.All(x => x == true);

                    if(sonuc)
                    {
                        pbox_elemancevap.BackColor = Color.Green;
                    }
                    else
                    {
                        pbox_elemancevap.BackColor = Color.Red;
                    }
                  
                }
            }
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_alt_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        bool drag = false;
        private void AnaForm_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
        }

        private void AnaForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            Location = new Point(Location.X + e.X, Location.Y + e.Y);
        }

        private void AnaForm_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
