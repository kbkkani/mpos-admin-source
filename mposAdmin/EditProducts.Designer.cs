namespace mposAdmin
{
    partial class EditProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_editproduct = new System.Windows.Forms.Button();
            this.btn_deleteproduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.itemname,
            this.size,
            this.price,
            this.itemtype,
            this.category});
            this.dataGridView1.Location = new System.Drawing.Point(12, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(996, 528);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "CODE";
            this.id.Name = "id";
            this.id.Width = 200;
            // 
            // itemname
            // 
            this.itemname.HeaderText = "ITEM";
            this.itemname.Name = "itemname";
            this.itemname.Width = 200;
            // 
            // size
            // 
            this.size.HeaderText = "SIZE";
            this.size.Name = "size";
            // 
            // price
            // 
            this.price.HeaderText = "PRICE";
            this.price.Name = "price";
            this.price.Width = 150;
            // 
            // itemtype
            // 
            this.itemtype.HeaderText = "ITEM TYPE";
            this.itemtype.Name = "itemtype";
            // 
            // category
            // 
            this.category.HeaderText = "CATEGORY";
            this.category.Name = "category";
            this.category.Width = 200;
            // 
            // btn_editproduct
            // 
            this.btn_editproduct.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_editproduct.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_editproduct.FlatAppearance.BorderSize = 0;
            this.btn_editproduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editproduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_editproduct.Location = new System.Drawing.Point(14, 582);
            this.btn_editproduct.Name = "btn_editproduct";
            this.btn_editproduct.Size = new System.Drawing.Size(173, 88);
            this.btn_editproduct.TabIndex = 1;
            this.btn_editproduct.Text = "EDIT";
            this.btn_editproduct.UseVisualStyleBackColor = false;
            this.btn_editproduct.Click += new System.EventHandler(this.btn_editproduct_Click);
            // 
            // btn_deleteproduct
            // 
            this.btn_deleteproduct.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_deleteproduct.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_deleteproduct.FlatAppearance.BorderSize = 0;
            this.btn_deleteproduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deleteproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteproduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_deleteproduct.Location = new System.Drawing.Point(193, 582);
            this.btn_deleteproduct.Name = "btn_deleteproduct";
            this.btn_deleteproduct.Size = new System.Drawing.Size(173, 88);
            this.btn_deleteproduct.TabIndex = 2;
            this.btn_deleteproduct.Text = "DELETE";
            this.btn_deleteproduct.UseVisualStyleBackColor = false;
            this.btn_deleteproduct.Click += new System.EventHandler(this.btn_deleteproduct_Click);
            // 
            // EditProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1020, 693);
            this.Controls.Add(this.btn_deleteproduct);
            this.Controls.Add(this.btn_editproduct);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EditProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditProducts";
            this.Load += new System.EventHandler(this.EditProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.Button btn_editproduct;
        private System.Windows.Forms.Button btn_deleteproduct;

    }
}