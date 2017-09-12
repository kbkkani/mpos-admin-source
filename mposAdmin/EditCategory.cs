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
    public partial class EditCategory : Form
    {
        private db con;
        public EditCategory()
        {
            InitializeComponent();
        }

        private void EditCategory_Load(object sender, EventArgs e)
        {
            loadProductsToGrid();
        }

        void loadProductsToGrid()
        {
            DataTable categories;
            con = new db();
            string query = "SELECT id,name FROM categories WHERE online = 1";
            con.MysqlQuery(query);
            categories = con.QueryEx();
            con.conClose();
            for (int i = 0; i < categories.Rows.Count; i++)
            {
                DataRow dr = categories.Rows[i];
                dataGridView1.Rows.Add(
                    dr["id"].ToString(),
                    dr["name"].ToString()
                    );
            }
            categories.Clear();
            // dataGridView1.DataSource = products;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells[0].Value);
                id = int.Parse(a);
            }
            AddnewCategory updateCategory = new AddnewCategory(id);
            updateCategory.ShowDialog();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            loadProductsToGrid();
        }

        void deleteCategory(int cid)
        {
            DialogResult dialogResult = MessageBox.Show("All products related to this category will be deleted. Are you sure want to continue.", "Delete Category", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db con = new db();
                string query = "";
                query = "DELETE FROM `categories` WHERE id = '" + cid + "'";
                con.MysqlQuery(query);
                con.NonQueryEx();
                con.conClose();
            }


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells[0].Value);
                deleteCategory(int.Parse(a));
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                loadProductsToGrid();
            }
        }
    }
}
