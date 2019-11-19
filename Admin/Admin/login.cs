using MySql.Data.MySqlClient;
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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ClassDB db = new ClassDB();

            String username = uname.Text;
            String password = pass.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `admin` WHERE `username = @uname and `password`= @pass", db.getConnection());
            command.Parameters.Add("@uname", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if the user exists or not
            if (table.Rows.Count > 0)
            {
                this.Hide();
                DataPendaftaran datapendaftaran = new DataPendaftaran();
                datapendaftaran.Show();
            }

            else
            {
                // check if the username field is empty
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username To Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // check if the password field is empty
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your password To Login", "Empty password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // check if the username or the password don't exist
                else
                {
                    MessageBox.Show("Wrong username or password", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ClassDB db = new ClassDB();

            String username = uname.Text;
            String password = pass.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM admin WHERE username = @uname and password= @pass", db.getConnection());
            command.Parameters.Add("@uname", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if the user exists or not
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Login Berhasil", "Selamat Datang", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                this.Hide();
                DataPendaftaran datapendaftaran = new DataPendaftaran();
                datapendaftaran.Show();
            }

            else
            {
                // check if the username field is empty
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username To Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // check if the password field is empty
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your password To Login", "Empty password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // check if the username or the password don't exist
                else
                {
                    MessageBox.Show("Wrong username or password", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void uname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
