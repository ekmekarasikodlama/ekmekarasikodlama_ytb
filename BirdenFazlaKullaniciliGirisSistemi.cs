// Burası Program.cs dosyasında bulunacak kodlar. Settings'e kullanicibilgilistesi adlı bir List<String> olduğundan ve ilkbaslatma adlı bir bool olduğundan emin olun.
-Program.cs
if(Properties.Settings.Default.ilkbaslatma == true)
  {
    Properties.Settings.Default.kullanicibilgilistesi = new List<string>();
    Properties.Settings.Default.ilkbaslatma = false;
    Properties.Settings.Default.Save();
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new KayıtSayfası());
  }else
  {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new GirisEkranı());             
  }
  
  //Şimdi ise kayıt sayfası. txt_sifre ve txt_ad adlı TextBox'lara ihtiyacınız var. Aynı zamanda btn_kaydol adlı bir butona ihtiyacınız var.
   
   -KayıtSayfası.cs
     -btn_kaydol_Click
      if(string.IsNullOrEmpty(txt_ad.Text) == false && string.IsNullOrEmpty(txt_sifre.Text) == false)
         {
                string eklenecek = txt_ad.Text + "<" + txt_sifre.Text;
                if(Properties.Settings.Default.kullanicibilgilistesi.Count > 0)
                {
                    foreach(string s in Properties.Settings.Default.kullanicibilgilistesi)
                    {
                        string[] degerler = s.Split('<');
                        if(degerler[0] == eklenecek.Split('<')[0])
                        {
                            return;
                        }
                    }
                }
           Properties.Settings.Default.kullanicibilgilistesi.Add(eklenecek);
           Properties.Settings.Default.Save();
           GirisEkranı girisEkranı = new GirisEkranı();
           girisEkranı.Show();
           Hide();
          }
          else
          {
           txt_sifre.Text = "";
           txt_ad.Text = "";
           MessageBox.Show("Geçersiz Değerler", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          
          
   //Şimdi ise giriş sayfası.
    -GirisEkranı.cs
      -btn_kaydl_Click
        KayıtSayfası ks = new KayıtSayfası();
        ks.Show();
        Hide();
       -btn_kaydol(giris olması lazım ama videoda yanlışlıkla öyle yapmışım)_Click
         if(Properties.Settings.Default.kullanicibilgilistesi.Count > 0)
            {
                if (!string.IsNullOrEmpty(txt_ad.Text))
                {
                    foreach(string kullanicibilgisi in Properties.Settings.Default.kullanicibilgilistesi)
                    {
                        string[] kullanicibilgileri = kullanicibilgisi.Split('<');
                        if(txt_ad.Text == kullanicibilgileri[0] && txt_sifre.Text == kullanicibilgileri[1])
                        {
                            MessageBox.Show("Giriş başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            icerik _icerik = new icerik();
                            _icerik.suankihesapindeksi = Array.IndexOf(Properties.Settings.Default.kullanicibilgilistesi.ToArray(), kullanicibilgisi);
                            _icerik.Show();
                            Hide();
                            return;
                           
                        }
                        else
                        {

                        }
                    }
                    MessageBox.Show("Kullanıcı adı veya şifre geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_ad.Text = "";
                    txt_sifre.Text = "";
                }
                else
                {
                    MessageBox.Show("Geçerli bir kullanıcı adı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              }else if(Properties.Settings.Default.kullanicibilgilistesi.Count <= 0)
              {
                  MessageBox.Show("Sistemde herhangi bir kullanıcı yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                  KayıtSayfası ks = new KayıtSayfası();
                  Hide();
                  ks.Show();
               
              }
       -GirisEkranı_FormClosing()
          Application.Exit();
       -btn_gorunurluk_Click()
          txt_sifre.UseSystemPasswordChar = !txt_sifre.UseSystemPasswordChar;

   //Burası içerik sayfası. Burada kullanıcı hesabına girmiş oluyor.
    -icerik.cs
    //public int suankihesapindeksi;   bir int gerekiyor.
      -icerik_Load()
          if(Properties.Settings.Default.kullanicibilgilistesi.Count < 0) {  return; }
          string suankihesap = Properties.Settings.Default.kullanicibilgilistesi.ToArray()[suankihesapindeksi];
          lbl_mrb.Text = "Merhaba, " + suankihesap.Split('<')[0];
      -btn_hesapsil_Click()
          Properties.Settings.Default.kullanicibilgilistesi.RemoveAt(suankihesapindeksi);
          Properties.Settings.Default.Save();
          GirisEkranı gs = new GirisEkranı();
          gs.Show();
          Hide();
       -icerik_FormClosing()
         Application.Exit();
       -btn_oturumdancik (videoda yine yanlış yapmışım)
         Hide();
         GirisEkranı gs = new GirisEkranı();
         gs.Show();
         

            
