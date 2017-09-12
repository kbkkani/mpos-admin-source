using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mposAdmin
{
    public partial class AddnewCategory : Form
    {
        Image File;
        private db con;

        private long lastProductId;
        private int categoryID;
        private bool update =false;
        private string imgpath;
        private bool imgUpdate = false;
        public AddnewCategory()
        {
            InitializeComponent();
        }

        public AddnewCategory(int cid)
        {
            InitializeComponent();
            categoryID = cid;
            update = true;
        }

        void loadProductsToGrid(int catid)
        {
            DataTable categories;
            con = new db();
            string query = "SELECT id,name,image FROM categories WHERE online = 1 AND id = '"+catid+"'";
            con.MysqlQuery(query);
            categories = con.QueryEx();
            con.conClose();
            for (int i = 0; i < categories.Rows.Count; i++)
            {
                DataRow dr = categories.Rows[i];
                textBox1.Text = dr["name"].ToString();
                imgpath = dr["image"].ToString();
             
            }
            categories.Clear();
            // dataGridView1.DataSource = products;
        }
        private void updateCategory()
        {
            db con = new db();
            string query = "";
            if (imgUpdate)
            {
                query = "UPDATE `categories` SET `name`='" + textBox1.Text + "',image = '" + _selectedFileName + "' WHERE id = '" + categoryID + "'";
            }
            else {
                query = "UPDATE `categories` SET `name`='" + textBox1.Text + "' WHERE id = '" + categoryID + "'";
            }
            
            con.MysqlQuery(query);
            con.NonQueryEx();
            con.conClose();

            if (imgUpdate)
            {
                doUpload();
            }

           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (update)
            {
                updateCategory();

                string filePath = @"C:\xampp\htdocs\mpos\images\categories\" + imgpath;
                FileInfo file = new FileInfo(filePath);
                if (imgUpdate)
                {
                    if (file.Exists)
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        file.Delete();
                        this.Close();
                    }
                }
                else {
                    this.Close();
                }
                
            }
            else {
                if (textBox1.Text != "")
                {
                    db con = new db();
                    con.MysqlQuery("INSERT INTO categories (name,image) VALUES ('" + textBox1.Text + "','" + _selectedFileName + "')");
                    con.NonQueryEx();
                    con.conClose();
                    doUpload();
                    // this.Close();
                    MessageBox.Show("Category added success!");
                    textBox1.Text = "";
                    label2.Text = "";
                    pictureBox1.Image = null;
                    btn_addimage.Visible = true;
                }
                else
                {
                    MessageBox.Show("Invalid Inputs.");
                } 
            
            }


        
        }

        private string _selectedFileName ="0.jpg";
        private void FileName(string extension)
        {
            string name;
            StringBuilder sb = new StringBuilder();
            foreach (char c in textBox1.Text+DateTime.Now)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                    name = sb.ToString().ToLower();
                    _selectedFileName = name + extension;
                }
            }
        }

        //Upload file
        private void doUpload()
        {
            if (isImageSelect.Equals(true))
            {
                System.IO.File.Copy(_source, _destination, true);
            }
        }


        //Select Category Image
        private string _source = @"C:\xampp\htdocs\mpos\images\categories\0.jpg";
        private string _destination;
        private bool isImageSelect = false;
        private void btn_addimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            if (!op.FileName.Equals(""))
            {
                _source = op.FileName;
                string filename = Path.GetFileName(_source);
                string extension = Path.GetExtension(filename);
                FileName(extension);
                _destination = @"C:\xampp\htdocs\mpos\images\categories\" + _selectedFileName;
                label2.Text = filename;
                isImageSelect = true;
                btn_addimage.Visible = false;
            }
            //show image in pictureBox
            pictureBox1.Image = Image.FromFile(_source);
        }

        private void AddnewCategory_Load(object sender, EventArgs e)
        {
            if (update) {
                btn_addimage.Visible = false;
                loadProductsToGrid(categoryID);
                pictureBox1.Image = Image.FromFile(@"C:\xampp\htdocs\mpos\images\categories\" + imgpath);
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (update) {
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                if (!op.FileName.Equals(""))
                {
                    _source = op.FileName;
                    string filename = Path.GetFileName(_source);
                    string extension = Path.GetExtension(filename);
                    FileName(extension);
                    _destination = @"C:\xampp\htdocs\mpos\images\categories\" + _selectedFileName;
                    label2.Text = filename;
                    isImageSelect = true;
                    btn_addimage.Visible = false;
                }
                //show image in pictureBox
               
                pictureBox1.Image = Image.FromFile(_source);
                
                imgUpdate = true;
            }
        }
    }
}
