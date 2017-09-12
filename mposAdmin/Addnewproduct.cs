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
    public partial class Addnewproduct : Form
    {
        Image File;
        private db con;

        private string productId;
        private long categoryID;
        private int itemtype;
        private bool update = false;
        private string imgpath;
        private bool imgUpdate =false;
        public Addnewproduct()
        {
            InitializeComponent();


        }
        public Addnewproduct(string pid)
        {
            InitializeComponent();
            update = true;
            productId = pid;
        }


        //Select Category Image
        private string _source = @"C:\xampp\htdocs\mpos\images\products\0.jpg";
        private string _destination;
        private bool isImageSelect = false;

        private void button1_Click(object sender, EventArgs e)
        {
            _source = @"C:\xampp\htdocs\mpos\images\products\0.jpg";
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            if (!op.FileName.Equals(""))
            {
                _source = op.FileName;
                string filename = Path.GetFileName(_source);
                string extension = Path.GetExtension(filename);
                FileName(extension);
                _destination = @"C:\xampp\htdocs\mpos\images\products\" + _selectedFileName;
                label7.Text = _selectedFileName;
            }
            pictureBox1.Image = Image.FromFile(_source);
            isImageSelect = true;
            button1.Visible = false;
        }

        //set filename
        private string _selectedFileName = "0.jpg";
        private void FileName(string extension)
        {
            string name;
            StringBuilder sb = new StringBuilder();
            foreach (char c in textBox6.Text + DateTime.Now)
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
        private void updateprodut()
        {
            db con = new db();
            string query = "";
            if (imgUpdate)
            {
                query = "UPDATE `products` SET `name`='" + textBox1.Text + "',`size`='" + textBox2.Text + "',`price`='" + textBox4.Text + "',`item_type`='" + itemtype + "',image='" + _selectedFileName + "' WHERE id = '" + productId + "'";
            }
            else {
                query = "UPDATE `products` SET `name`='" + textBox1.Text + "',`size`='" + textBox2.Text + "',`price`='" + textBox4.Text + "',`item_type`='" + itemtype + "' WHERE id = '" + productId + "'";
            }

            
            con.MysqlQuery(query);
            con.NonQueryEx();
            con.conClose();
            doUpload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (update)
            {
                updateprodut();
                string filePath = @"C:\xampp\htdocs\mpos\images\products\" + imgpath;
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
                this.Close();
            }
            else
            {
                bool product_status = false;
                bool process = true;
                if (comboBox2.Text.Equals(""))
                {
                    process = false;
                    MessageBox.Show("Can not null Category! Please add category.");
                }

                if (textBox1.Text.Equals(""))
                {
                    process = false;
                    MessageBox.Show("Product Name can not be null.");
                }

                if (textBox6.Text.Equals(""))
                {
                    process = false;
                    MessageBox.Show("Product code can not be null or duplicate.");
                }

                if (textBox4.Equals(""))
                {
                    process = false;
                    MessageBox.Show("Product price can not be null.");
                }


                product_status = CheckProductAvailable(textBox6.Text);
                if (product_status && process)
                {
                    try
                    {
                        db con = new db();
                        string query = "";
                        query = "INSERT INTO products (id,name,image,category_id,size,price,item_type) VALUES('" + textBox6.Text + "','" + textBox1.Text + "','" + _selectedFileName + "','" + categoryID + "','" + textBox2.Text + "','" + textBox4.Text + "','" + itemtype + "')";
                        con.MysqlQuery(query);
                        con.NonQueryEx();
                        con.conClose();

                        doUpload();
                        pictureBox1.Image = null;
                        _destination = "";
                        MessageBox.Show("Product added success!");
                        clearProductInputs();
                        button1.Visible = true;
                    }
                    catch (Exception er)
                    {

                        MessageBox.Show(er.Message);
                    }
                }
                else {
                    MessageBox.Show("Duplicate Product ID or Invalid Input.");
                }
            }
        }

        private void Addnewproduct_Load(object sender, EventArgs e)
        {
            LoadCategories();
            // Bind combobox to dictionary
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("1", "KOT");
            test.Add("2", "BOT");
            comboBox1.DataSource = new BindingSource(test, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            //stock disabled
            if (update.Equals(false))//new product
            {
                
                textBox3.Enabled = false;
                textBox5.Enabled = false;
            }
            else {

                DataTable products = getProductDetails();
                if (products.Rows.Count > 0)
                {
                    for (int i = 0; i < products.Rows.Count; i++)
                    {

                        textBox3.Enabled = false;
                        textBox5.Enabled = false;
                        comboBox2.Enabled = false;
                        DataRow dr = products.Rows[i];
                        textBox6.Enabled = false;
                        button1.Visible = false;
                        
                        imgpath = dr["image"].ToString() ;
                        textBox6.Text = dr["id"].ToString();
                        textBox1.Text = dr["name"].ToString();
                        textBox2.Text = dr["size"].ToString();
                        textBox4.Text = dr["price"].ToString();
                       // comboBox1.SelectedIndex = comboBox1.Items.IndexOf(dr["itemtype"].ToString());
                      //  comboBox2.Text = dr["category"].ToString();
                       
                 
                        
                    }
                }
                pictureBox1.Image = Image.FromFile(@"C:\xampp\htdocs\mpos\images\products\" + imgpath);
            }
            
        }

        //get product data
        private DataTable getProductDetails() {
            DataTable products;
            db con = new db();
            con.MysqlQuery("select * from products where online = 1 and id = '"+productId+"'");
            products = con.QueryEx();
            con.conClose();
            return products;
        }

        void LoadCategories()
        {
            db con = new db();
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            DataTable products;
            con.MysqlQuery("select * from categories where online = 1");
            products = con.QueryEx();
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            if (products.Rows.Count > 0)
            {
                for (int i = 0; i < products.Rows.Count; i++)
                {
                    DataRow dr = products.Rows[i];
                    comboSource.Add(dr["id"].ToString(), dr["name"].ToString());
                }
                AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                comboBox2.DataSource = new BindingSource(comboSource, null);
                comboBox2.DisplayMember = "Value";
                comboBox2.ValueMember = "Key";
                comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            con.conClose();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            string key = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Key;
            categoryID = long.Parse(key);
            //MessageBox.Show(categoryID.ToString());
        }

        void clearProductInputs()
        {
            textBox6.Text = "";
            textBox1.Text = "";
            label7.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
        }

        private bool CheckProductAvailable(string code)
        {
            bool st = false;
            DataTable product = new DataTable();
            db con = new db();
            string query = "SELECT (CASE WHEN (COUNT(id)>0) THEN 0 ELSE 1 END) AS status FROM `products` WHERE id = '" + code + "' ";
            con.MysqlQuery(query);
            product = con.QueryEx();

            foreach (DataRow row in product.Rows)
            {
                if (row["status"].ToString().Equals("1"))
                {
                    st = true;
                }
                else
                {
                    st = false;
                }
            }

            return st;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
            itemtype = int.Parse(key);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (update)
            {
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                if (!op.FileName.Equals(""))
                {
                    _source = op.FileName;
                    string filename = Path.GetFileName(_source);
                    string extension = Path.GetExtension(filename);
                    FileName(extension);
                    _destination = @"C:\xampp\htdocs\mpos\images\products\" + _selectedFileName;
                    label2.Text = filename;
                    isImageSelect = true;
                    button1.Visible = false;
                }
                //show image in pictureBox

                pictureBox1.Image = Image.FromFile(_source);

                imgUpdate = true;
            }
        }






    }
}
