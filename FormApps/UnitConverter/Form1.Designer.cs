namespace UnitConverter {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.btChange = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tdNum1 = new System.Windows.Forms.TextBox();
            this.tdNum2 = new System.Windows.Forms.TextBox();
            this.nudNum1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btCalc = new System.Windows.Forms.Button();
            this.nudNum2 = new System.Windows.Forms.NumericUpDown();
            this.nudAnser = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnser)).BeginInit();
            this.SuspendLayout();
            // 
            // btChange
            // 
            this.btChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btChange.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btChange.Location = new System.Drawing.Point(225, 109);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(100, 44);
            this.btChange.TabIndex = 0;
            this.btChange.Text = "変換";
            this.btChange.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(142, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "変換前";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(142, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "変換後";
            // 
            // tdNum1
            // 
            this.tdNum1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tdNum1.Location = new System.Drawing.Point(225, 67);
            this.tdNum1.Name = "tdNum1";
            this.tdNum1.Size = new System.Drawing.Size(100, 26);
            this.tdNum1.TabIndex = 3;
            // 
            // tdNum2
            // 
            this.tdNum2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tdNum2.Location = new System.Drawing.Point(225, 176);
            this.tdNum2.Name = "tdNum2";
            this.tdNum2.Size = new System.Drawing.Size(100, 26);
            this.tdNum2.TabIndex = 4;
            // 
            // nudNum1
            // 
            this.nudNum1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudNum1.Location = new System.Drawing.Point(57, 233);
            this.nudNum1.Name = "nudNum1";
            this.nudNum1.Size = new System.Drawing.Size(120, 26);
            this.nudNum1.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "距離変換アプリ";
            // 
            // btCalc
            // 
            this.btCalc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btCalc.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btCalc.Location = new System.Drawing.Point(555, 266);
            this.btCalc.Name = "btCalc";
            this.btCalc.Size = new System.Drawing.Size(92, 33);
            this.btCalc.TabIndex = 7;
            this.btCalc.Text = "計算";
            this.btCalc.UseVisualStyleBackColor = false;
            // 
            // nudNum2
            // 
            this.nudNum2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudNum2.Location = new System.Drawing.Point(243, 233);
            this.nudNum2.Name = "nudNum2";
            this.nudNum2.Size = new System.Drawing.Size(120, 26);
            this.nudNum2.TabIndex = 8;
            // 
            // nudAnser
            // 
            this.nudAnser.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudAnser.Location = new System.Drawing.Point(422, 233);
            this.nudAnser.Name = "nudAnser";
            this.nudAnser.Size = new System.Drawing.Size(120, 26);
            this.nudAnser.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(195, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "÷";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(379, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 19);
            this.label8.TabIndex = 2;
            this.label8.Text = "=";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 333);
            this.Controls.Add(this.nudAnser);
            this.Controls.Add(this.nudNum2);
            this.Controls.Add(this.btCalc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudNum1);
            this.Controls.Add(this.tdNum2);
            this.Controls.Add(this.tdNum1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btChange);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNum1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNum2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btChane;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tdNum1;
        private System.Windows.Forms.TextBox tdNum2;
        private System.Windows.Forms.NumericUpDown nudNum1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btCalc;
        private System.Windows.Forms.NumericUpDown nudNum2;
        private System.Windows.Forms.NumericUpDown nudAnser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

