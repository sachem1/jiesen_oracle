namespace SecrityTool
{
    partial class Form
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
            this.btnEnValue = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeValue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnValue
            // 
            this.btnEnValue.Location = new System.Drawing.Point(283, 193);
            this.btnEnValue.Name = "btnEnValue";
            this.btnEnValue.Size = new System.Drawing.Size(75, 23);
            this.btnEnValue.TabIndex = 0;
            this.btnEnValue.Text = "加密";
            this.btnEnValue.UseVisualStyleBackColor = true;
            this.btnEnValue.Click += new System.EventHandler(this.btnEnValue_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(-5, 74);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(363, 83);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(383, 74);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(363, 83);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "原文";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密文";
            // 
            // btnDeValue
            // 
            this.btnDeValue.Location = new System.Drawing.Point(383, 193);
            this.btnDeValue.Name = "btnDeValue";
            this.btnDeValue.Size = new System.Drawing.Size(75, 23);
            this.btnDeValue.TabIndex = 0;
            this.btnDeValue.Text = "解密";
            this.btnDeValue.UseVisualStyleBackColor = true;
            this.btnDeValue.Click += new System.EventHandler(this.btnDeValue_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnDeValue);
            this.Controls.Add(this.btnEnValue);
            this.Name = "Form";
            this.Text = "Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnValue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeValue;
    }
}

