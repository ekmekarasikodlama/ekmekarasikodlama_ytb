//sadece çarpalara ayırma kısmı

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


//form kısmı
 public ana_form()
        {
            InitializeComponent();
        }

        private void tbox_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(int.TryParse(tbox_input.Text, out int sayi))
                {
                    işle(sayi);
                }
            }
        }
        List<Label> eklenenKontroller = new List<Label>();

        void labelTemizle()
        {
            for(int i = 0; i < eklenenKontroller.Count; i++)
            {
                Controls.Remove(eklenenKontroller[i]);
            }
            eklenenKontroller.Clear();
        }
        void işle(int sayı)
        {
            Dictionary<int, int> carpanlarVeFrekanslar = İşlemler.asalÇarpanlaraAyır(sayı);
            if(carpanlarVeFrekanslar.Count == 1 && carpanlarVeFrekanslar.Any(x => x.Key == sayı))
            {
                labelTemizle();

                //asal sayıdır.
                lbl_sonuc1.Text = "Sayı asaldır.";
                lbl_asama1.Text = "1";
            }
            else //sayı asal değilse
            {
                string usluGosterim = "";

                lbl_sonuc1.Text = "Sonuç.";
                int cizilen = 1;

                labelTemizle();

                int temp = sayı;
                for(int c = 0; c < carpanlarVeFrekanslar.Count; c++)
                {
                    KeyValuePair<int, int> carpan = carpanlarVeFrekanslar.ElementAt(c);
                    for(int f = 1; f <= carpan.Value; f++)
                    {
                        //2-2 ise 2-1 ve 2-2 olarak her bir çarpımı alıyoruz.
                        if (c == 0 && f== 1)
                        {
                            temp /= carpan.Key;
                            lbl_sonuc1.Text = carpan.Key.ToString();                          
                            lbl_asama1.Text = (temp).ToString();
                        }
                        else
                        {
                            Label lblCarpan = new Label();
                            Label lblAsama = new Label();

                            lblCarpan.Font = new Font("Segoe UI", 16, FontStyle.Regular);
                            lblCarpan.Size = new Size(73, 25);
                            lblAsama.Size = lblCarpan.Size;
                            lblAsama.Font = lblCarpan.Font;


                            //x = sabit olacak, y konumu değişecek.
                            temp /= carpan.Key;
                            lblCarpan.Location = new Point(98, 21 + (cizilen * 25));
                            lblCarpan.Text = carpan.Key.ToString();
                            lblAsama.Location = new Point(20, 22 + ((cizilen+1) * 25));
                            lblAsama.Text = (temp).ToString();
                        
                            pbox_ayirac.Size = new Size(5, 30 + (cizilen * 25));

                            Controls.Add(lblCarpan);
                            Controls.Add(lblAsama);
                            eklenenKontroller.Add(lblAsama);
                            eklenenKontroller.Add(lblCarpan);
                            cizilen++;
                        }
                        
                    }
                    
                    string usEklenti = carpan.Value == 1 ? "" : ("^" + carpan.Value);
                    usluGosterim += carpan.Key + usEklenti;
                    string eklenti = c == carpanlarVeFrekanslar.Count-1 ? "" : " * ";
                    usluGosterim += eklenti;
                }
                Size = new Size(Size.Width, 125 + 30 * cizilen);
                lbl_sonucUslu.Text = "Üslü Gösterim: " + usluGosterim;
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
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Location = new Point(Location.X + e.X, Location.Y + e.Y);
            }
        }

        private void btn_bilgi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sayıyı asal çarpanlarına ayırmak için 'Enter' tuşuna basınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
