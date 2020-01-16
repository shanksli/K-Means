namespace Kmeans_new
{
    partial class Form1
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
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.GenerateCeterButton = new System.Windows.Forms.Button();
            this.CaculateButton = new System.Windows.Forms.Button();
            this.KTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PGNNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(87, 76);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(75, 23);
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.Text = "打开文件";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // GenerateCeterButton
            // 
            this.GenerateCeterButton.Location = new System.Drawing.Point(265, 75);
            this.GenerateCeterButton.Name = "GenerateCeterButton";
            this.GenerateCeterButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateCeterButton.TabIndex = 1;
            this.GenerateCeterButton.Text = "生成质心";
            this.GenerateCeterButton.UseVisualStyleBackColor = true;
            this.GenerateCeterButton.Click += new System.EventHandler(this.GenerateCeterButton_Click);
            // 
            // CaculateButton
            // 
            this.CaculateButton.Location = new System.Drawing.Point(435, 76);
            this.CaculateButton.Name = "CaculateButton";
            this.CaculateButton.Size = new System.Drawing.Size(75, 23);
            this.CaculateButton.TabIndex = 2;
            this.CaculateButton.Text = "计算";
            this.CaculateButton.UseVisualStyleBackColor = true;
            this.CaculateButton.Click += new System.EventHandler(this.CaculateButton_Click);
            // 
            // KTextBox
            // 
            this.KTextBox.Location = new System.Drawing.Point(87, 152);
            this.KTextBox.Name = "KTextBox";
            this.KTextBox.Size = new System.Drawing.Size(100, 21);
            this.KTextBox.TabIndex = 3;
            this.KTextBox.Text = "2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(87, 273);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1006, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // PGNNameTextBox
            // 
            this.PGNNameTextBox.Location = new System.Drawing.Point(390, 151);
            this.PGNNameTextBox.Name = "PGNNameTextBox";
            this.PGNNameTextBox.Size = new System.Drawing.Size(100, 21);
            this.PGNNameTextBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 629);
            this.Controls.Add(this.PGNNameTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.KTextBox);
            this.Controls.Add(this.CaculateButton);
            this.Controls.Add(this.GenerateCeterButton);
            this.Controls.Add(this.OpenFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button GenerateCeterButton;
        private System.Windows.Forms.Button CaculateButton;
        private System.Windows.Forms.TextBox KTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox PGNNameTextBox;
    }
}

