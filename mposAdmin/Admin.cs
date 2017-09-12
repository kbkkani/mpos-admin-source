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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void addNewCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddnewCategory frmnewcategory = new AddnewCategory();
            frmnewcategory.Show();
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addnewproduct frmnewproduct = new Addnewproduct();
            frmnewproduct.Show();
        }

        private void editProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditProducts frmeditproduct = new EditProducts();
            frmeditproduct.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void editCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCategory frmeditcategory = new EditCategory();
            frmeditcategory.ShowDialog();
        }

       
    }
}
