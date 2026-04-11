namespace QLDangKyHocPhan
{
    partial class FormStudent
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.dgvLopHocPhan = new System.Windows.Forms.DataGridView();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.dgvDaDangKy = new System.Windows.Forms.DataGridView();
            this.lblTongTinChi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHocPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(42, 27);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(113, 29);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Xin chào:";
            // 
            // dgvLopHocPhan
            // 
            this.dgvLopHocPhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopHocPhan.Location = new System.Drawing.Point(47, 80);
            this.dgvLopHocPhan.Name = "dgvLopHocPhan";
            this.dgvLopHocPhan.ReadOnly = true;
            this.dgvLopHocPhan.RowHeadersWidth = 51;
            this.dgvLopHocPhan.RowTemplate.Height = 24;
            this.dgvLopHocPhan.Size = new System.Drawing.Size(982, 247);
            this.dgvLopHocPhan.TabIndex = 1;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(350, 351);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(104, 46);
            this.btnDangKy.TabIndex = 2;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(594, 351);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(104, 46);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy đăng ký";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // dgvDaDangKy
            // 
            this.dgvDaDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaDangKy.Location = new System.Drawing.Point(47, 422);
            this.dgvDaDangKy.Name = "dgvDaDangKy";
            this.dgvDaDangKy.ReadOnly = true;
            this.dgvDaDangKy.RowHeadersWidth = 51;
            this.dgvDaDangKy.RowTemplate.Height = 24;
            this.dgvDaDangKy.Size = new System.Drawing.Size(982, 206);
            this.dgvDaDangKy.TabIndex = 4;
            // 
            // lblTongTinChi
            // 
            this.lblTongTinChi.AutoSize = true;
            this.lblTongTinChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTinChi.Location = new System.Drawing.Point(46, 644);
            this.lblTongTinChi.Name = "lblTongTinChi";
            this.lblTongTinChi.Size = new System.Drawing.Size(109, 22);
            this.lblTongTinChi.TabIndex = 5;
            this.lblTongTinChi.Text = "Tổng tín chỉ:";
            // 
            // FormStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 700);
            this.Controls.Add(this.lblTongTinChi);
            this.Controls.Add(this.dgvDaDangKy);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.dgvLopHocPhan);
            this.Controls.Add(this.lblWelcome);
            this.Name = "FormStudent";
            this.Text = "FormStudent";
            this.Load += new System.EventHandler(this.FormStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHocPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDangKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dgvLopHocPhan;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dgvDaDangKy;
        private System.Windows.Forms.Label lblTongTinChi;
    }
}