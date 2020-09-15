// Kod sayfasındaki ortak alana yazılan değişkenler.
bool altikarakter;
bool birbuyuk;
bool birsayi;

//Form'un Load olayına yazılan kod:
btn_kaydol.Enabled = false;

//Şifre TextBox'unun TextChanged() olayındaki kod:
 birsayi = false;
 altikarakter = false;
 birbuyuk = false;
 btn_kaydol.Enabled = false;
 if (txt_sifre.Text.ToCharArray().Count() > 0)
    {
     char[] karakterler = txt_sifre.Text.ToCharArray();
     karaktersayisi();              
      void karaktersayisi()
      {
      if(karakterler.Length > 6)
      {
        altikarakter = true;
        lbl_6karakter.ForeColor = Color.Green;
       }
        else
        {
         altikarakter = false;
         lbl_6karakter.ForeColor = Color.Red;
          }
          sayikontrol();
         }
         void sayikontrol()
                {
                    foreach(char karakter in karakterler)
                    {
                        if(char.IsNumber(karakter))
                        {
                            birsayi = true;
                            break;
                        }
                    }
                    if(birsayi == true) { lbl_1sayı.ForeColor = Color.Green; } else { lbl_1sayı.ForeColor = Color.Red; }
                    buyukkontrol();
                }
                void buyukkontrol()
                {
                    foreach(char karakter in karakterler)
                    {
                        if(char.IsUpper(karakter))
                        {
                            birbuyuk = true;
                            break;
                        }

                    }
                    if(birbuyuk == true) { lbl_buyukharf.ForeColor = Color.Green; }else { lbl_buyukharf.ForeColor = Color.Red; }
                    sonlandir();
                }
                void sonlandir()
                {
                    if(birbuyuk && birsayi && altikarakter)
                    btn_kaydol.Enabled = true;
                  
                }
            }

           
