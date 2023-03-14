using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelefonRehberi.Entities;

namespace WFUI
{
    public partial class AnaForm : Form
    {
        TelefonRehberi.BLL.BusinessLogicLayer BLL;
        public AnaForm()
        {
            InitializeComponent();
            BLL = new TelefonRehberi.BLL.BusinessLogicLayer();
        }

        private void btn_yeni_kayit_Click(object sender, EventArgs e)
        {
            int Sonuc = BLL.YeniKayit(Guid.NewGuid(), txt_isim.Text, txt_soyisim.Text, txt_telefonI.Text, txt_telefonII.Text,
                txt_telefonIII.Text, txt_adres.Text, txt_emailAdres.Text, txt_website.Text, txt_aciklama.Text);

            if (Sonuc > 0)
            {
                MessageBox.Show("Kaydınız başarılı bir şekilde eklendi.");
                Doldur();
            }
            else if (Sonuc == -100)
            {
                MessageBox.Show("Eksik parametre hatası. Lütfen İsim, Soyisim, TelefonI alanlarını doldurunuz.");
            }
            else
            {
                MessageBox.Show("Kayıt Ekleme İşleminde Hata Oluştu !");
            }
        }

        private void Doldur()
        {
            List<RehberKayit> RehberKayitlarim = BLL.RehberKayitlariGetir();
            if (RehberKayitlarim != null && RehberKayitlarim.Count > 0)
            {
                lst_liste.DataSource = RehberKayitlarim;
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void lst_liste_DoubleClick(object sender, EventArgs e)
        {
            ListBox L = (ListBox)sender;
            RehberKayit SecilenDeger = (RehberKayit)L.SelectedItem;
            txt_isim.Text = SecilenDeger.Isim;
            txt_soyisim.Text = SecilenDeger.Soyisim;
            txt_telefonI.Text = SecilenDeger.TelefonI;
            txt_telefonII.Text = SecilenDeger.TelefonII;
            txt_telefonIII.Text = SecilenDeger.TelefonIII;
            txt_emailAdres.Text = SecilenDeger.EmailAdres;
            txt_website.Text = SecilenDeger.Website;
            txt_adres.Text = SecilenDeger.Adres;
            txt_aciklama.Text = SecilenDeger.Aciklama;
            grpbox_kayit.Text = "Rehber kayıt güncelle";
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            if (lst_liste.SelectedItem != null)
            {
                // ((RehberKayit)lst_liste.SelectedItem).ID     * kısa olarak kullanımı *

                RehberKayit K = (RehberKayit)lst_liste.SelectedItem;
                int Sonuc = BLL.KayitGuncelle(K.ID, txt_isim.Text, txt_soyisim.Text, txt_telefonI.Text, txt_telefonII.Text, txt_telefonIII.Text, txt_adres.Text,
                     txt_emailAdres.Text, txt_website.Text, txt_aciklama.Text);

                if (Sonuc > 0)
                {
                    MessageBox.Show("Kaydınız Başarılı Bir Şekilde Güncellendi.");
                    Doldur();
                }
                else if (Sonuc == -100)
                {
                    MessageBox.Show("Eksik Parametre Hatası !");
                }
                else
                {
                    MessageBox.Show("Kayıt Ekleme İşleminde Hata Oluştu !");
                }
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Guid SilinecekID = ((RehberKayit)lst_liste.SelectedItem).ID;
            int Sonuc = BLL.KayitSil(SilinecekID);
            if (Sonuc > 0)
            {
                MessageBox.Show("Kaydınız Başarılı Bir Şekilde Silindi.");
                Doldur();
            }
            else
            {
                MessageBox.Show("Kayıt Silme İşleminde Hata Oluştu !");
            }
        }

        private void btn_xml_ver_Click(object sender, EventArgs e)
        {
            int Sonuc = BLL.XMLDataVer();

            if (Sonuc > 0)
            {
                lbl_data_alver_durum.Text = "Durum Açıklaması : XML Data verme işlemi tamamlandı";
            }
            else
            {
                lbl_data_alver_durum.Text = "Durum Açıklaması : Hata Oluştu !";
            }
        }

        private void btn_csv_Click(object sender, EventArgs e)
        {
            int Sonuc = BLL.CSVDataVer();

            if (Sonuc > 0)
            {
                lbl_data_alver_durum.Text = "Durum Açıklaması : CSV Data verme işlemi tamamlandı";
            }
            else
            {
                lbl_data_alver_durum.Text = "Durum Açıklaması : Hata Oluştu !";
            }
        }

        private void btn_json_ver_Click(object sender, EventArgs e)
        {
            int Sonuc = BLL.JsonDataVer();

            if (Sonuc > 0)
            {
                lbl_data_alver_durum.Text = "Durum Açıklaması : JSON Data verme işlemi tamamlandı";
            }
            else
            {
                lbl_data_alver_durum.Text = "Durum Açıklaması : Hata Oluştu !";
            }
        }
    }
}
