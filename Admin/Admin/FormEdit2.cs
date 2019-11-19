using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Admin
{
    public partial class FormEdit2 : Form
    {
        FormEdit FormEdit = new FormEdit();
        public FormEdit2()
        {
            InitializeComponent();
        }

        private void editData()
        {

            String jk = "";
            if (FormEdit.jkLaki)
            {
                jk = "Laki Laki";
            }
            else if (FormEdit.jkPerem)
            {
                jk = "Perempuan";
            }

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=data_siswa;Uid=root;pwd=''");
            connection.Open();

            String updateQuery = "UPDATE data_pendaftaran SET nama_lengkap = '" + FormEdit.namaLengkap + "', tempat_tanggal_lahir = '" + FormEdit.tempatTanggalLahir + "', jenis_kelamin = '" + jk + "', agama = '" + FormEdit.Agama + "', kewarganegaraan = '" + FormEdit.kewargaNegaraan + "', banyak_saudara_kandung = '" + FormEdit.banyakSaudaraKandung + "', usia = '" + FormEdit.Usia + "', banyak_saudara_angkat= '" + FormEdit.banyakSaudaraAngkat + "', bahasa_sehari_hari= '" + FormEdit.BahasaSehariHari + "', berat_badan = '" + FormEdit.beratBadan + "', tinggi_badan = '" + FormEdit.tinggiBadan + "', golongan_darah = '" + FormEdit.golonganDarah + "', penyakit = '" + FormEdit.Penyakit + "', alamat = '" + FormEdit.Alamat + "', nama_ayah_kandung = '" + nama_ayah_kandung.Text + "', nama_ibu_kandung = '" + nama_ibu_kandung.Text + "', ttl_ayah = '" + ttl_ayah_kandung.Text + "', ttl_ibu = '" + ttl_ibu_kandung.Text + "', pekerjaan_ayah = '" + pekerjaan_ayah_kandung.Text + "', pekerjaan_ibu = '" + pekerjaan_ibu_kandung.Text + "', alamat_ortu = '" + alamat_orangtua.Text + "', nama_wali = '" + nama_wali.Text + "', ttl_wali = '" + ttl_wali.Text + "', pendidikan_terakhir_wali = '" + pendidikan_terakhir_wali.Text + "', hubungan_terhadap_anak = '" + hubungan_anak.Text + "', pekerjaan_wali = '" + pekerjaan_wali.Text + "' WHERE id_pendaftaran = " + FormEdit.id;
            MySqlCommand command = new MySqlCommand(updateQuery, connection);

            // execute the query
            if (command.ExecuteNonQuery() == 1)
            {
                DataPendaftaran dataPendaftaran = new DataPendaftaran();
                MessageBox.Show("Berhasil!", "Data Berhasil di update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataPendaftaran.Show();
                this.Hide();
            }
        }

        private void Kirim_Click(object sender, EventArgs e)
        {
            editData();
        }

        private void FormEdit2_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nama_ibu_kandung_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void nama_ayah_kandung_TextChanged(object sender, EventArgs e)
        {

        }   
    }
}
