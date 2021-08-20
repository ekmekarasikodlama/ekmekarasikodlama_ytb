string kaydetmeKonum = "";
        private void kaydet_Click(object sender, EventArgs e)
        {
            if (File.Exists(kaydetmeKonum))
            {
                DialogResult result = MessageBox.Show("Yeni kaydetme konumu seç?", "Kaydetme Konumu", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    yeniDosya();
                }
                else if (result == DialogResult.No)
                {
                    dosyaKaydet();
                }
            }
            else
            {
                yeniDosya();
            }
        }

        void yeniDosya()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = ".txt dosyaları|*.txt";
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                kaydetmeKonum = dialog.FileName;
                konum.Text = kaydetmeKonum;
                dosyaKaydet();
            }
        }

        void dosyaKaydet()
        {
            File.WriteAllText(kaydetmeKonum, icerik.Text);
        }

        private void ac_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ".txt dosyaları|*.txt";
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                kaydetmeKonum = dialog.FileName;
                icerik.Text = File.ReadAllText(kaydetmeKonum);
                konum.Text = kaydetmeKonum;
            }
        }
