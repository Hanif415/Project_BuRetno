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
    public partial class DataPendaftaran : Form
    {
        public DataPendaftaran()
        {
            InitializeComponent();
            display_data();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit();
            FormEdit2 formEdit2 = new FormEdit2();

            if (this.dataGridView1.CurrentRow.Cells[3].Value.ToString().Equals("Laki Laki"))
            {
                formEdit.jk_laki_laki.Checked = true;
            }
            else {
                formEdit.jk_perempuan.Checked = true;
            }

            formEdit.tbId.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            formEdit.nama_lengkap.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            formEdit.tempat_tanggal_lahir.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            formEdit.agama.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            formEdit.kewarganegaraan.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            formEdit.banyak_saudara_kandung.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            formEdit.tb_usia.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            formEdit.banyak_saudara_angkat.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            formEdit.bahasa_sehari_hari.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            formEdit.berat_badan.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
            formEdit.tinggi_badan.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString();
            formEdit.golongan_darah.Text = this.dataGridView1.CurrentRow.Cells[12].Value.ToString();
            formEdit.penyakit.Text = this.dataGridView1.CurrentRow.Cells[13].Value.ToString();
            formEdit.alamat.Text = this.dataGridView1.CurrentRow.Cells[14].Value.ToString();
            formEdit2.nama_ayah_kandung.Text = this.dataGridView1.CurrentRow.Cells[15].Value.ToString();
            formEdit2.nama_ibu_kandung.Text = this.dataGridView1.CurrentRow.Cells[16].Value.ToString();
            formEdit2.nama_ayah_kandung.Text = this.dataGridView1.CurrentRow.Cells[17].Value.ToString();
            formEdit2.ttl_ayah_kandung.Text = this.dataGridView1.CurrentRow.Cells[18].Value.ToString();
            formEdit2.ttl_ibu_kandung.Text = this.dataGridView1.CurrentRow.Cells[19].Value.ToString();
            formEdit2.alamat_orangtua.Text = this.dataGridView1.CurrentRow.Cells[20].Value.ToString();
            formEdit2.nama_wali.Text = this.dataGridView1.CurrentRow.Cells[21].Value.ToString();
            formEdit2.ttl_wali.Text = this.dataGridView1.CurrentRow.Cells[22].Value.ToString();
            formEdit2.pendidikan_terakhir_wali.Text = this.dataGridView1.CurrentRow.Cells[23].Value.ToString();
            formEdit2.hubungan_anak.Text = this.dataGridView1.CurrentRow.Cells[24].Value.ToString();
            formEdit2.pekerjaan_wali.Text = this.dataGridView1.CurrentRow.Cells[25].Value.ToString();

            formEdit2.Show();
            formEdit.Show();
            this.Hide();
        }

        private void btn_hapus_Click(object sender, EventArgs e)
        {
            String selectedId_id = dataGridView1.CurrentRow.Cells["id_pendaftaran"].Value.ToString();

            DialogResult dr = MessageBox.Show("Hapus Data?", "Ingin Menghapus data ini?", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                MySqlConnection conn = Koneksi.getKoneksi();
                MySqlCommand command = conn.CreateCommand();
                conn.Open();
                command.CommandText = "DELETE FROM data_pendaftaran WHERE id_pendaftaran = @id";
                command.Parameters.AddWithValue("@id", selectedId_id);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Terhapus", "Data Berhasil dihapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    display_data();
                }
            }
            else { 
                
            }

        }

        private void display_data() {
            MySqlConnection conn = Koneksi.getKoneksi();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM data_pendaftaran";

            conn.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(ds, "data");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "data";
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataDiterima mdataDiterima = new dataDiterima();
            this.Hide();
            mdataDiterima.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UnDiterima mUnDiterima = new UnDiterima();
            this.Hide();
            mUnDiterima.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            /*DGVPrinter printer = new DGVPrinter();
            printer.Title = "Data Pendaftaran";
            printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = false;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);*/

            if (dataGridView1.Rows.Count > 0) {

                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++) {
                    xcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++) {

                    for (int j = 0; j < dataGridView1.Columns.Count; j++){
                        xcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }


            

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            String namaLengkap = textBox1.Text;
            MySqlConnection conn = Koneksi.getKoneksi();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM data_pendaftaran WHERE nama_lengkap LIKE '%" + namaLengkap + "%'";

            conn.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(ds, "data");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "data";
            conn.Close();
        }
        
    }
}

