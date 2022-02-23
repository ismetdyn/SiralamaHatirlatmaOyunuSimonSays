using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje5._40_SiralamaHatirlatmaOyunuSimonSays
{
    public partial class frmSiralamaHatirlatma : Form
    {
        public frmSiralamaHatirlatma()
        {
            InitializeComponent();
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            sayi++;
            secilenSira = "";
            lDurum.Text = "";
            backgroundWorker1.RunWorkerAsync();
        }

        int sayi = 0;
        string gercekSira = "", secilenSira = "";


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i= 0; i < sayi; i++)
            {
                Control ctrl = groupBox1.Controls["button" + gercekSira.Split(',')[i]];
                ctrl.Text = Convert.ToString(i + 1);
                System.Threading.Thread.Sleep(1000);
            }
            butonlariTemizle();
        }
        private void frmSiralamaHatirlatma_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            gercekSira = ListeKaristir();
        }


        private string ListeKaristir()
        {
            ArrayList dizi = new ArrayList();
            for(int i = 0; i < groupBox1.Controls.Count; i++)
            {
                dizi.Add(i.ToString());
            }
            string sayilar = "";
            Random r = new Random();
            while(dizi.Count > 0)
            {
                int rastgele = r.Next(0, dizi.Count);
                sayilar += dizi[rastgele] + ",";
                dizi.RemoveAt(rastgele);
            }
            return sayilar;
        }
        private void buttonlar_Click(object sender, EventArgs e)
        {
            secilenSira += (sender as Button).Name.ToString().Replace("button", "") + ",";
            if (gercekSira.Substring(0, secilenSira.Length) == secilenSira)
            {
                lDurum.Text = "doğru seçim";
            }
            else
            {
                lDurum.Text = "YANLIŞ yaptınız ve yandınız.";
                groupBox1.Enabled = false;
                for(int i= 0; i < groupBox1.Controls.Count; i++)
                {
                    Control ctrl = groupBox1.Controls["button" + gercekSira.Split(',')[i]];
                    ctrl.Text = Convert.ToString(i + 1);
                }
            }
        }

        private void butonlariTemizle()
        {
            for(int i = 1; i <= groupBox1.Controls.Count; i++)
            {
                Control ctrl= groupBox1.Controls["button" + i];
                ctrl.Text = "";
            }
        }
    }
}
