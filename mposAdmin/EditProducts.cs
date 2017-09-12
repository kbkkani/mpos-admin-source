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
    public partial class EditProducts : Form
    {
        private db con;
        public EditProducts()
        {
            InitializeComponent();
        }

        void getAllproducts() { 
        
        
        }

        private void EditProducts_Load(object sender, EventArgs e)
        {
            loadProductsToGrid();
        }

        void loadProductsToGrid()
        {
            
            DataTable products;
            con = new db();
            string query = "SELECT products.id,products.name AS itemname,products.size,products.price,(IF(products.item_type='1','KOT','BOT')) AS itemtype,categories.name AS category FROM products JOIN categories ON categories.id=products.category_id ORDER BY products.id DESC";
            con.MysqlQuery(query);
            products = con.QueryEx();
            
           
            for (int i = 0; i < products.Rows.Count; i++)
            {
                DataRow dr = products.Rows[i];
                dataGridView1.Rows.Add(
                    dr["id"].ToString(),
                    dr["itemname"].ToString(),
                    dr["size"].ToString(),
                    dr["price"].ToString(),
                    dr["itemtype"].ToString(),
                    dr["category"].ToString()
                    );
            }
            con.conClose();
            products.Clear();
           // dataGridView1.DataSource = products;
        }

        private void btn_editproduct_Click(object sender, EventArgs e)
        {
            string id="";
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells[0].Value);
                id = a;
            }

            Addnewproduct frmUpdateproduct = new Addnewproduct(id);
            frmUpdateproduct.ShowDialog();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            loadProductsToGrid();
        }

        private void btn_deleteproduct_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells[0].Value);
                deleteProduct(a);
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                loadProductsToGrid();
            }
        }

        void deleteProduct(string pid) {
            DialogResult dialogResult = MessageBox.Show("Are You sure want to delete this product.", "Delete Product", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db con = new db();
                string query = "";
                query = "DELETE FROM `products` WHERE id = '" + pid + "'";
                con.MysqlQuery(query);
                con.NonQueryEx();
                con.conClose();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





    }
}
