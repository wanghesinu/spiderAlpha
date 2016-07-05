namespace spiderAlpha
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.mainDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDBDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.channelDataView = new System.Windows.Forms.DataGridView();
            this.mainDBDataSetBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.getInfoButton = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDBDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDBDataSetBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(240, 7);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "搜索";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // channelDataView
            // 
            this.channelDataView.AllowUserToAddRows = false;
            this.channelDataView.AllowUserToDeleteRows = false;
            this.channelDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.channelDataView.Location = new System.Drawing.Point(12, 73);
            this.channelDataView.Name = "channelDataView";
            this.channelDataView.ReadOnly = true;
            this.channelDataView.RowTemplate.Height = 23;
            this.channelDataView.Size = new System.Drawing.Size(962, 301);
            this.channelDataView.TabIndex = 4;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 41);
            this.progressBar.Maximum = 18;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(962, 23);
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // getInfoButton
            // 
            this.getInfoButton.Location = new System.Drawing.Point(687, 11);
            this.getInfoButton.Name = "getInfoButton";
            this.getInfoButton.Size = new System.Drawing.Size(75, 23);
            this.getInfoButton.TabIndex = 6;
            this.getInfoButton.Text = "抓取信息";
            this.getInfoButton.UseVisualStyleBackColor = true;
            this.getInfoButton.Click += new System.EventHandler(this.getInfo_Click);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBox.Location = new System.Drawing.Point(83, 9);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 20);
            this.comboBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "选择频道：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 386);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.getInfoButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.channelDataView);
            this.Controls.Add(this.buttonSearch);
            this.Name = "MainForm";
            this.Text = "节目信息抓取工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.mainDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDBDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDBDataSetBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.BindingSource mainDBDataSetBindingSource;
    
        private System.Windows.Forms.BindingSource mainDBDataSetBindingSource1;
        private System.Windows.Forms.DataGridView channelDataView;
        private System.Windows.Forms.BindingSource mainDBDataSetBindingSource2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button getInfoButton;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label1;
    }
}

