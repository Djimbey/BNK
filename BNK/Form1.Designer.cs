namespace BNK
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BTN_Filter = new System.Windows.Forms.Button();
            this.BTN_RFilter = new System.Windows.Forms.Button();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.BTN_Del = new System.Windows.Forms.Button();
            this.BTN_Copy = new System.Windows.Forms.Button();
            this.BTN_RefreshData = new System.Windows.Forms.Button();
            this.BTN_Edit = new System.Windows.Forms.Button();
            this.TB_BIK = new System.Windows.Forms.TextBox();
            this.CMB_PZN = new System.Windows.Forms.ComboBox();
            this.TB_RGN = new System.Windows.Forms.TextBox();
            this.CHB_PZN = new System.Windows.Forms.CheckBox();
            this.CHB_RGN = new System.Windows.Forms.CheckBox();
            this.CHB_BIK = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1451, 650);
            this.dataGridView1.TabIndex = 14;
            // 
            // BTN_Filter
            // 
            this.BTN_Filter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_Filter.Location = new System.Drawing.Point(1159, 85);
            this.BTN_Filter.Name = "BTN_Filter";
            this.BTN_Filter.Size = new System.Drawing.Size(147, 25);
            this.BTN_Filter.TabIndex = 12;
            this.BTN_Filter.Text = "Отбор";
            this.BTN_Filter.UseVisualStyleBackColor = true;
            this.BTN_Filter.Click += new System.EventHandler(this.BTN_Filter_Click);
            // 
            // BTN_RFilter
            // 
            this.BTN_RFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_RFilter.Location = new System.Drawing.Point(1312, 85);
            this.BTN_RFilter.Name = "BTN_RFilter";
            this.BTN_RFilter.Size = new System.Drawing.Size(147, 25);
            this.BTN_RFilter.TabIndex = 13;
            this.BTN_RFilter.Text = "Сбросить фильтр";
            this.BTN_RFilter.UseVisualStyleBackColor = true;
            this.BTN_RFilter.Click += new System.EventHandler(this.BTN_RFilter_Click);
            // 
            // BTN_Add
            // 
            this.BTN_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Add.BackgroundImage")));
            this.BTN_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_Add.Location = new System.Drawing.Point(12, 8);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(30, 28);
            this.BTN_Add.TabIndex = 1;
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // BTN_Del
            // 
            this.BTN_Del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Del.BackgroundImage")));
            this.BTN_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_Del.Location = new System.Drawing.Point(120, 8);
            this.BTN_Del.Name = "BTN_Del";
            this.BTN_Del.Size = new System.Drawing.Size(30, 28);
            this.BTN_Del.TabIndex = 4;
            this.BTN_Del.UseVisualStyleBackColor = true;
            this.BTN_Del.Click += new System.EventHandler(this.BTN_Del_Click);
            // 
            // BTN_Copy
            // 
            this.BTN_Copy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Copy.BackgroundImage")));
            this.BTN_Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_Copy.Location = new System.Drawing.Point(48, 8);
            this.BTN_Copy.Name = "BTN_Copy";
            this.BTN_Copy.Size = new System.Drawing.Size(30, 28);
            this.BTN_Copy.TabIndex = 2;
            this.BTN_Copy.UseVisualStyleBackColor = true;
            this.BTN_Copy.Click += new System.EventHandler(this.BTN_Copy_Click);
            // 
            // BTN_RefreshData
            // 
            this.BTN_RefreshData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_RefreshData.BackgroundImage")));
            this.BTN_RefreshData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_RefreshData.Location = new System.Drawing.Point(156, 8);
            this.BTN_RefreshData.Name = "BTN_RefreshData";
            this.BTN_RefreshData.Size = new System.Drawing.Size(30, 28);
            this.BTN_RefreshData.TabIndex = 5;
            this.BTN_RefreshData.UseVisualStyleBackColor = true;
            this.BTN_RefreshData.Click += new System.EventHandler(this.BTN_RefreshData_Click);
            // 
            // BTN_Edit
            // 
            this.BTN_Edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Edit.BackgroundImage")));
            this.BTN_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_Edit.Location = new System.Drawing.Point(84, 8);
            this.BTN_Edit.Name = "BTN_Edit";
            this.BTN_Edit.Size = new System.Drawing.Size(30, 28);
            this.BTN_Edit.TabIndex = 3;
            this.BTN_Edit.UseVisualStyleBackColor = true;
            this.BTN_Edit.Click += new System.EventHandler(this.BTN_Edit_Click);
            // 
            // TB_BIK
            // 
            this.TB_BIK.Location = new System.Drawing.Point(12, 90);
            this.TB_BIK.Name = "TB_BIK";
            this.TB_BIK.Size = new System.Drawing.Size(354, 20);
            this.TB_BIK.TabIndex = 7;
            // 
            // CMB_PZN
            // 
            this.CMB_PZN.FormattingEnabled = true;
            this.CMB_PZN.Location = new System.Drawing.Point(789, 89);
            this.CMB_PZN.Name = "CMB_PZN";
            this.CMB_PZN.Size = new System.Drawing.Size(354, 21);
            this.CMB_PZN.Sorted = true;
            this.CMB_PZN.TabIndex = 11;
            // 
            // TB_RGN
            // 
            this.TB_RGN.Location = new System.Drawing.Point(400, 90);
            this.TB_RGN.Name = "TB_RGN";
            this.TB_RGN.Size = new System.Drawing.Size(354, 20);
            this.TB_RGN.TabIndex = 9;
            // 
            // CHB_PZN
            // 
            this.CHB_PZN.AutoSize = true;
            this.CHB_PZN.Location = new System.Drawing.Point(789, 64);
            this.CHB_PZN.Name = "CHB_PZN";
            this.CHB_PZN.Size = new System.Drawing.Size(45, 17);
            this.CHB_PZN.TabIndex = 10;
            this.CHB_PZN.Text = "Тип";
            this.CHB_PZN.UseVisualStyleBackColor = true;
            this.CHB_PZN.CheckedChanged += new System.EventHandler(this.CHB_PZN_CheckedChanged);
            // 
            // CHB_RGN
            // 
            this.CHB_RGN.AutoSize = true;
            this.CHB_RGN.Location = new System.Drawing.Point(400, 64);
            this.CHB_RGN.Name = "CHB_RGN";
            this.CHB_RGN.Size = new System.Drawing.Size(62, 17);
            this.CHB_RGN.TabIndex = 8;
            this.CHB_RGN.Text = "Регион";
            this.CHB_RGN.UseVisualStyleBackColor = true;
            this.CHB_RGN.CheckedChanged += new System.EventHandler(this.CHB_RGN_CheckedChanged);
            // 
            // CHB_BIK
            // 
            this.CHB_BIK.AutoSize = true;
            this.CHB_BIK.Location = new System.Drawing.Point(12, 67);
            this.CHB_BIK.Name = "CHB_BIK";
            this.CHB_BIK.Size = new System.Drawing.Size(48, 17);
            this.CHB_BIK.TabIndex = 6;
            this.CHB_BIK.Text = "БИК";
            this.CHB_BIK.UseVisualStyleBackColor = true;
            this.CHB_BIK.CheckedChanged += new System.EventHandler(this.CHB_BIK_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 792);
            this.Controls.Add(this.TB_BIK);
            this.Controls.Add(this.CMB_PZN);
            this.Controls.Add(this.TB_RGN);
            this.Controls.Add(this.CHB_PZN);
            this.Controls.Add(this.CHB_RGN);
            this.Controls.Add(this.CHB_BIK);
            this.Controls.Add(this.BTN_Edit);
            this.Controls.Add(this.BTN_RefreshData);
            this.Controls.Add(this.BTN_Copy);
            this.Controls.Add(this.BTN_Del);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.BTN_RFilter);
            this.Controls.Add(this.BTN_Filter);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник БИК";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTN_Filter;
        private System.Windows.Forms.Button BTN_RFilter;
        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.Button BTN_Del;
        private System.Windows.Forms.Button BTN_Copy;
        private System.Windows.Forms.Button BTN_RefreshData;
        private System.Windows.Forms.Button BTN_Edit;
        private System.Windows.Forms.TextBox TB_BIK;
        private System.Windows.Forms.ComboBox CMB_PZN;
        private System.Windows.Forms.TextBox TB_RGN;
        private System.Windows.Forms.CheckBox CHB_PZN;
        private System.Windows.Forms.CheckBox CHB_RGN;
        private System.Windows.Forms.CheckBox CHB_BIK;
        
    }
}

