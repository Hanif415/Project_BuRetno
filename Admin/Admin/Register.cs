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
    public partial class Register : Form
    {
      
        public Register()
        {
            InitializeComponent();
        }

        public Boolean checkUsername()
        {
            ClassDB db = new ClassDB();
            String username = tbUsername.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM admin WHERE username = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if this username already exists in the database
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void addData()
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=data_siswa;Uid=root;pwd=''");
            MySqlCommand comand;
            connection.Open();

            comand = connection.CreateCommand();
            comand.CommandText = "INSERT INTO  admin (username, password) VALUES (@username, @password)";
            comand.Parameters.AddWithValue("@username", tbUsername.Text);
            comand.Parameters.AddWithValue("@password", tbPassword.Text);

            if (checkUsername())
            {
                MessageBox.Show("This Username Already Exists, Select A Different One", "Duplicate Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
                else
            {
                // execute the query
                if (comand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Register Sucsessful", "Hi, New Admin :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataPendaftaran datapendaftaran = new DataPendaftaran();
                    this.Hide();
                    datapendaftaran.Show();
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addData();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            // remove the focus from the textboxes by making a label the active control
            this.ActiveControl = tbUsername;
        }

        // textbox username ENTER
        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            String username = tbUsername.Text;
            if (username.ToLower().Trim().Equals("first name"))
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = Color.Black;
            }
        }

        // textbox first name LEAVE
        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            String username = tbUsername.Text;
            if (username.ToLower().Trim().Equals("first name") || username.Trim().Equals(""))
            {
                tbUsername.Text = "first name";
                tbUsername.ForeColor = Color.Gray;
            }
        }

        // textbox password ENTER
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            String password = tbPassword.Text;
            if (password.ToLower().Trim().Equals("password"))
            {
                tbPassword.Text = "";
                tbPassword.UseSystemPasswordChar = true;
                tbPassword.ForeColor = Color.Black;
            }
        }

        // textbox password LEAVE
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            String password = tbPassword.Text;
            if (password.ToLower().Trim().Equals("password") || password.Trim().Equals(""))
            {
                tbPassword.Text = "password";
                tbPassword.UseSystemPasswordChar = false;
                tbPassword.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }








    }
}
