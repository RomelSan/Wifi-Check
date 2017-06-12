namespace Wifi_Check
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1_test = new System.Windows.Forms.TextBox();
            this.button1_test = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1_credits = new System.Windows.Forms.Label();
            this.button_exportCSV = new System.Windows.Forms.Button();
            this.timer1_wifiScan = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1_test
            // 
            this.textBox1_test.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1_test.Location = new System.Drawing.Point(12, 324);
            this.textBox1_test.Multiline = true;
            this.textBox1_test.Name = "textBox1_test";
            this.textBox1_test.ReadOnly = true;
            this.textBox1_test.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1_test.Size = new System.Drawing.Size(859, 175);
            this.textBox1_test.TabIndex = 0;
            // 
            // button1_test
            // 
            this.button1_test.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1_test.Location = new System.Drawing.Point(12, 12);
            this.button1_test.Name = "button1_test";
            this.button1_test.Size = new System.Drawing.Size(113, 23);
            this.button1_test.TabIndex = 1;
            this.button1_test.Text = "Scan Wifi";
            this.button1_test.UseVisualStyleBackColor = true;
            this.button1_test.Click += new System.EventHandler(this.button1_test_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(859, 277);
            this.dataGridView1.TabIndex = 2;
            // 
            // label1_credits
            // 
            this.label1_credits.AutoSize = true;
            this.label1_credits.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_credits.Location = new System.Drawing.Point(261, 16);
            this.label1_credits.Name = "label1_credits";
            this.label1_credits.Size = new System.Drawing.Size(441, 15);
            this.label1_credits.TabIndex = 3;
            this.label1_credits.Text = "Wifi Check v1.0 by @RomelSan - https://www.github.com/RomelSan";
            // 
            // button_exportCSV
            // 
            this.button_exportCSV.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exportCSV.Location = new System.Drawing.Point(142, 12);
            this.button_exportCSV.Name = "button_exportCSV";
            this.button_exportCSV.Size = new System.Drawing.Size(113, 23);
            this.button_exportCSV.TabIndex = 4;
            this.button_exportCSV.Text = "Export as CSV";
            this.button_exportCSV.UseVisualStyleBackColor = true;
            this.button_exportCSV.Click += new System.EventHandler(this.button_exportCSV_Click);
            // 
            // timer1_wifiScan
            // 
            this.timer1_wifiScan.Interval = 3000;
            this.timer1_wifiScan.Tick += new System.EventHandler(this.timer1_wifiScan_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 507);
            this.Controls.Add(this.button_exportCSV);
            this.Controls.Add(this.label1_credits);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1_test);
            this.Controls.Add(this.textBox1_test);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "Form1";
            this.Text = "Wifi Check";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_test;
        private System.Windows.Forms.Button button1_test;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1_credits;
        private System.Windows.Forms.Button button_exportCSV;
        private System.Windows.Forms.Timer timer1_wifiScan;
    }
}

