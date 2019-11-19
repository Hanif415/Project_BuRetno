using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class FormEdit : Form
    {
        public static int id;
        public static String namaLengkap;
        public static String tempatTanggalLahir;
        public static Boolean jkLaki;
        public static Boolean jkPerem;
        public static String Agama;
        public static String kewargaNegaraan;
        public static String banyakSaudaraKandung;
        public static String Usia;
        public static String BahasaSehariHari;
        public static String banyakSaudaraAngkat;
        public static String bahasaSehariHari;
        public static String beratBadan;
        public static String tinggiBadan;
        public static String golonganDarah;
        public static String Penyakit;
        public static String Alamat;


        public FormEdit()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = int.Parse(tbId.Text);
            namaLengkap = nama_lengkap.Text;
            tempatTanggalLahir = tempat_tanggal_lahir.Text;
            jkLaki = jk_laki_laki.Checked;
            jkPerem = jk_perempuan.Checked;
            Agama = agama.Text;
            kewargaNegaraan = kewarganegaraan.Text;
            banyakSaudaraKandung = banyak_saudara_kandung.Text;
            Usia = tb_usia.Text;
            BahasaSehariHari = bahasa_sehari_hari.Text;
            banyakSaudaraAngkat = banyak_saudara_angkat.Text;
            bahasaSehariHari = bahasa_sehari_hari.Text;
            beratBadan = berat_badan.Text;
            tinggiBadan = tinggi_badan.Text;
            golonganDarah = golongan_darah.Text;
            Penyakit = penyakit.Text;
            Alamat = alamat.Text;
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void kewarganegaraan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
