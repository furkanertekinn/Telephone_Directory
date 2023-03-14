﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFUI
{
    public partial class Form1 : Form
    {
        TelefonRehberi.BLL.BusinessLogicLayer BLL;
        public Form1()
        {
            InitializeComponent();
            BLL = new TelefonRehberi.BLL.BusinessLogicLayer();
        }
        private void btn_giris_Click(object sender, EventArgs e)
        {
            int Sonuc = BLL.KullaniciKontrol(txt_kullaniciAdi.Text, txt_Sifre.Text);
            if (Sonuc > 0)
            {
                AnaForm form = new AnaForm();
                form.Show();
            }
            else if (Sonuc == -100)
            {
                MessageBox.Show("Form alanlarını eksiksiz olarak doldurunuz");
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı !");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
