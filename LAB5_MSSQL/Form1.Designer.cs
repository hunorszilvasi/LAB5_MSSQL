namespace LAB5_MSSQL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            menuStrip2 = new MenuStrip();
            addProductsToolStripMenuItem = new ToolStripMenuItem();
            newProductToolStripMenuItem = new ToolStripMenuItem();
            increaseExistingStockToolStripMenuItem = new ToolStripMenuItem();
            categoriesToolStripMenuItem = new ToolStripMenuItem();
            salesHistoryToolStripMenuItem = new ToolStripMenuItem();
            addCategoryToolStripMenuItem = new ToolStripMenuItem();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(37, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(804, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(37, 212);
            button1.Name = "button1";
            button1.Size = new Size(255, 23);
            button1.TabIndex = 1;
            button1.Text = "Add Product";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 24);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(896, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(37, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(354, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(397, 27);
            button2.Name = "button2";
            button2.Size = new Size(108, 23);
            button2.TabIndex = 4;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(511, 27);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 5;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { addProductsToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(896, 24);
            menuStrip2.TabIndex = 6;
            menuStrip2.Text = "menuStrip2";
            // 
            // addProductsToolStripMenuItem
            // 
            addProductsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newProductToolStripMenuItem, increaseExistingStockToolStripMenuItem, categoriesToolStripMenuItem });
            addProductsToolStripMenuItem.Name = "addProductsToolStripMenuItem";
            addProductsToolStripMenuItem.Size = new Size(66, 20);
            addProductsToolStripMenuItem.Text = "Products";
            // 
            // newProductToolStripMenuItem
            // 
            newProductToolStripMenuItem.Name = "newProductToolStripMenuItem";
            newProductToolStripMenuItem.Size = new Size(192, 22);
            newProductToolStripMenuItem.Text = "New product";
            newProductToolStripMenuItem.Click += newProductToolStripMenuItem_Click;
            // 
            // increaseExistingStockToolStripMenuItem
            // 
            increaseExistingStockToolStripMenuItem.Name = "increaseExistingStockToolStripMenuItem";
            increaseExistingStockToolStripMenuItem.Size = new Size(192, 22);
            increaseExistingStockToolStripMenuItem.Text = "Increase Existing Stock";
            increaseExistingStockToolStripMenuItem.Click += increaseExistingStockToolStripMenuItem_Click;
            // 
            // categoriesToolStripMenuItem
            // 
            categoriesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salesHistoryToolStripMenuItem, addCategoryToolStripMenuItem });
            categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            categoriesToolStripMenuItem.Size = new Size(192, 22);
            categoriesToolStripMenuItem.Text = "Categories";
            categoriesToolStripMenuItem.Click += categoriesToolStripMenuItem_Click;
            // 
            // salesHistoryToolStripMenuItem
            // 
            salesHistoryToolStripMenuItem.Name = "salesHistoryToolStripMenuItem";
            salesHistoryToolStripMenuItem.Size = new Size(180, 22);
            salesHistoryToolStripMenuItem.Text = "Sales History";
            salesHistoryToolStripMenuItem.Click += salesHistoryToolStripMenuItem_Click;
            // 
            // addCategoryToolStripMenuItem
            // 
            addCategoryToolStripMenuItem.Name = "addCategoryToolStripMenuItem";
            addCategoryToolStripMenuItem.Size = new Size(180, 22);
            addCategoryToolStripMenuItem.Text = "Add Category";
            addCategoryToolStripMenuItem.Click += addCategoryToolStripMenuItem_Click;
            // 
            // button4
            // 
            button4.Location = new Point(298, 212);
            button4.Name = "button4";
            button4.Size = new Size(117, 23);
            button4.TabIndex = 7;
            button4.Text = "Refresh";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            Controls.Add(menuStrip2);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private MenuStrip menuStrip1;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem addProductsToolStripMenuItem;
        private ToolStripMenuItem newProductToolStripMenuItem;
        private ToolStripMenuItem increaseExistingStockToolStripMenuItem;
        private Button button4;
        private ToolStripMenuItem categoriesToolStripMenuItem;
        private ToolStripMenuItem salesHistoryToolStripMenuItem;
        private ToolStripMenuItem addCategoryToolStripMenuItem;
    }
}

