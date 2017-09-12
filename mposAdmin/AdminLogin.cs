using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mposAdmin
{
    public partial class AdminLogin : Form
    {
        private db con;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (checkAuth(textBox1.Text, textBox2.Text))
                {
                    Admin frmad = new Admin();
                    frmad.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("Invalid Login");
                }
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
            
        }

        private bool checkAuth(string username,string password) {
            DataTable user;
            con = new db();

            SessionData.SetMd5PasswordToConvert(password);
            string md5pass = SessionData.md5Password;

            string query = "SELECT * FROM `users` WHERE users.username='" + username + "' AND users.password = '" + md5pass + "' AND users.user_type= 'A'";
            con.MysqlQuery(query);
            user = con.QueryEx();
            con.conClose();

            string currentCellValue = string.Empty;
            foreach (DataRow dr in user.Rows)
            {
                currentCellValue = dr["id"].ToString();
            }


            if (user.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
