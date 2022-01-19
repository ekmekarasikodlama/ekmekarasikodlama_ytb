 public AnaForm()
        {
            InitializeComponent();
        
        }

        private void btn_tamam_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbox_sayi.Text, out int sayi))
            {
                if (sayi != 0)
                {
                    işle(sayi);
                }
            }
        }
        //94
        int çiftTek(int s)
        {
            return s % 2 == 0 ? 1 : 0;
        }
        //94
        //"94"
        void işle(int sayı)
        {
            List<int> rakamlar = new List<int>();
            string yazisi = sayı.ToString();
            foreach (char c in yazisi)
            {
                rakamlar.Add(int.Parse(c.ToString()));
            }

            int sonRakam = rakamlar[rakamlar.Count - 1];
            int rakamlarToplami = rakamlar.Sum();


            //iki
            bool ikibolunur = çiftTek(sonRakam) == 1;
            string ikiString = "2 ile Bölünebilirlik: Sayının son rakamı " + sonRakam.ToString() + "'dır. Bu sayı " + (ikibolunur ? "çift" : "tek") + " olduğundan, iki ile tam " + (ikibolunur ? "bölünebilir." : "bölünemez.");
            lbl_ikibol.Text = ikiString;
            lbl_ikibol.ForeColor = ikibolunur ? Color.Green : Color.Red;

            //üç
            bool ucbolunur = rakamlarToplami % 3 == 0;
            string ucString = "3 ile Bölünebilirlik: Sayının rakamları toplamı " + rakamlarToplami.ToString() + " olduğundan ve bu sayı 3'e tam " + (ucbolunur ? "bölündüğünden" : "bölünmediğinden") + " sayı 3'e " + (ucbolunur ? "bölünür." : "bölünmez.");
            lbl_ucbol.Text = ucString;
            lbl_ucbol.ForeColor = ucbolunur ? Color.Green : Color.Red;

            //altı
            bool altibolunur = ikibolunur && ucbolunur;
            string altiString = "6 ile Bölünebilirlik: Sayı aynı anda iki ve üçe " + (altibolunur ? "bölünebildiğinden" : "bölünemediğinden") + " 6'ya da tam " + (altibolunur ? "bölünebilir." : "bölünemez.");
            lbl_altıbol.Text = altiString;
            lbl_altıbol.ForeColor = altibolunur ? Color.Green : Color.Red;

            //dört
            int soniki = 0;
            if (yazisi.Count() < 2)
            {
                soniki = sayı;
            }
            else
            {
                soniki = int.Parse(yazisi.Substring(yazisi.Count() - 2));
            }
            bool dortbolunur = (soniki % 4 == 0 || soniki == 0);
            string dortString = "4 ile Bölünebilirlik: Sayının son iki rakamı " + soniki.ToString() + " olduğundan" + (soniki == 0 ? "" : (dortbolunur ? " ve bu sayı 4'e tam bölündüğünden" : " ve bu sayı 4'e tam bölünmediğinden")) + " bu sayı 4'e tam " + (dortbolunur ? "bölünür." : "bölünmez.");
            lbl_dortbol.Text = dortString;
            lbl_dortbol.ForeColor = dortbolunur ? Color.Green : Color.Red;

            //beş
            bool besbolunur = sonRakam == 0 || sonRakam == 5;
            string besString = "5 ile Bölünebilirlik: Sayının son rakamı " + sonRakam.ToString() + " olduğundan ve bu rakam 5 ya da 0" + (besbolunur ? " olduğundan" : " olmadığından") + " 5'e tam " + (besbolunur ? "bölünür." : "bölünmez.");
            lbl_besbol.Text = besString;
            lbl_besbol.ForeColor = besbolunur ? Color.Green : Color.Red;

            //sekiz
            soniki = 0;
            if (yazisi.Count() < 3)
            {
                soniki = sayı;
            }
            else
            {
                soniki = int.Parse(yazisi.Substring(yazisi.Count() - 3));
            }
            bool sekizbolunur = (soniki % 8 == 0 || soniki == 0);
            string sekizString = "8 ile Bölünebilirlik: Sayının son üç rakamı " + soniki.ToString() + " olduğundan" + (soniki == 0 ? "" : (dortbolunur ? " ve bu sayı 8 ile tam bölündüğünden" : " ve bu sayı 8 ile tam bölünmediğinden")) + " bu sayı 8'e tam " + (sekizbolunur ? "bölünür." : "bölünmez.");
            lbl_sekizbol.Text = sekizString;
            lbl_sekizbol.ForeColor = sekizbolunur ? Color.Green : Color.Red;

            //dokuz
            bool dokuzBolunur = rakamlarToplami % 9 == 0;
            string dokuzString = "9 ile Bölünebilirlik: Sayının rakamları toplamı " + rakamlarToplami.ToString() + " olduğundan ve bu sayı 9'a tam " + (dokuzBolunur ? "bölündüğünden" : "bölünmediğinden") + " sayı 9'a tam " + (dokuzBolunur ? "bölünür." : "bölünmez.");
            lbl_dokuzbol.Text = dokuzString;
            lbl_dokuzbol.ForeColor = dokuzBolunur ? Color.Green : Color.Red;

            //on
            bool onBolunur = sonRakam == 0;
            string onString = "10 ile Bölünebilirlik: Sayının son rakamı " + (onBolunur ? "0 olduğundan" : "0 olmadığından") + " bu sayı 10'a tam " + (onBolunur ? "bölünür." : "bölünmez.");
            lbl_onbol.Text = onString;
            lbl_onbol.ForeColor = onBolunur ? Color.Green : Color.Red;

            //onbir
            int sayiToplamıAlternatif = 0;
            //2056 sayısı için +2, -0, +5, -6
            //                  0   1   2   3 (çift ise ekle, tek ise çıkar)
            for (int i = 0; i < yazisi.Count(); i++)
            {
                int sayi = int.Parse(yazisi[i].ToString());
                sayi = i % 2 == 0 ? sayi + 0 : -sayi;
                sayiToplamıAlternatif += sayi;
            }
            bool onbirbolunur = (sayiToplamıAlternatif % 11 == 0 || sayiToplamıAlternatif == 0);
            string onbirstr = "11 ile Bölünebilirlik: Sayının rakamlarının (+, -) olacak şekilde toplamı " + sayiToplamıAlternatif + " olduğundan" + (sayiToplamıAlternatif == 0 ? "" : (onbirbolunur ? " ve bu sayı 11'e tam bölündüğünden" : " ve bu sayı 11'e tam bölünmediğinden")) + " sayı 11'e tam " + (onbirbolunur ? "bölünür." : "bölünmez.");
            lbl_onbirbol.Text = onbirstr;
            lbl_onbirbol.ForeColor = onbirbolunur ? Color.Green : Color.Red;

            List<int> karakterSayilari = new List<int>();
            karakterSayilari.Add(ikiString.Count());
            karakterSayilari.Add(ucString.Count());
            karakterSayilari.Add(dortString.Count());
            karakterSayilari.Add(besString.Count());
            karakterSayilari.Add(altiString.Count());
            karakterSayilari.Add(sekizString.Count());
            karakterSayilari.Add(dokuzString.Count());
            karakterSayilari.Add(onString.Count());
            karakterSayilari.Add(onbirstr.Count());
            int azamiKarakterSayisi = karakterSayilari.Max();

            if(azamiKarakterSayisi > 94)
            {
                //genişletme lazım.
                int delta = azamiKarakterSayisi - 94;
                //her on karakter için 30 birim arttırılacak.
                int artis = delta / 10;
                Size = new Size(940 + (artis * 30), Size.Height);
            }

            tbox_sayi.Focus();
        }


        bool drag = false;
        private void AnaForm_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
        }

        private void AnaForm_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void AnaForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Location = new Point(Location.X + e.X, Location.Y + e.Y);
            }
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_state_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
