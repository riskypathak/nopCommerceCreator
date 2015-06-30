namespace nopCommerceCreator
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSQLUser = new System.Windows.Forms.TextBox();
            this.txtSqlPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowsePath = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtSubdomain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.chkBinding = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdminEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkDBExits = new System.Windows.Forms.CheckBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSqlServerName = new System.Windows.Forms.TextBox();
            this.radioWindowsAuth = new System.Windows.Forms.RadioButton();
            this.radioSQLAuth = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(449, 301);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sql Server UserName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sql Server Password:";
            // 
            // txtSQLUser
            // 
            this.txtSQLUser.Location = new System.Drawing.Point(128, 146);
            this.txtSQLUser.Name = "txtSQLUser";
            this.txtSQLUser.Size = new System.Drawing.Size(146, 20);
            this.txtSQLUser.TabIndex = 3;
            this.txtSQLUser.Text = "sa";
            // 
            // txtSqlPass
            // 
            this.txtSqlPass.Location = new System.Drawing.Point(128, 172);
            this.txtSqlPass.Name = "txtSqlPass";
            this.txtSqlPass.Size = new System.Drawing.Size(146, 20);
            this.txtSqlPass.TabIndex = 4;
            this.txtSqlPass.Text = "infosys";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Source Store Path";
            // 
            // btnBrowsePath
            // 
            this.btnBrowsePath.Location = new System.Drawing.Point(449, 2);
            this.btnBrowsePath.Name = "btnBrowsePath";
            this.btnBrowsePath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsePath.TabIndex = 6;
            this.btnBrowsePath.Text = "Browse";
            this.btnBrowsePath.UseVisualStyleBackColor = true;
            this.btnBrowsePath.Click += new System.EventHandler(this.btnBrowsePath_Click);
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(116, 7);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(327, 20);
            this.txtSourcePath.TabIndex = 7;
            this.txtSourcePath.Text = "C:\\Risky\\Projects\\Waqar\\nopCommerce_3.60_NoSource";
            // 
            // txtSubdomain
            // 
            this.txtSubdomain.Location = new System.Drawing.Point(116, 53);
            this.txtSubdomain.Name = "txtSubdomain";
            this.txtSubdomain.Size = new System.Drawing.Size(104, 20);
            this.txtSubdomain.TabIndex = 8;
            this.txtSubdomain.Text = "nop_first";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Subdomain Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Site Name";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(116, 30);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(104, 20);
            this.txtSiteName.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(226, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(250, 30);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(104, 20);
            this.txtIP.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(360, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(387, 31);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(44, 20);
            this.txtPort.TabIndex = 16;
            // 
            // chkBinding
            // 
            this.chkBinding.AutoSize = true;
            this.chkBinding.Location = new System.Drawing.Point(442, 34);
            this.chkBinding.Name = "chkBinding";
            this.chkBinding.Size = new System.Drawing.Size(101, 17);
            this.chkBinding.TabIndex = 17;
            this.chkBinding.Text = "Binding Require";
            this.chkBinding.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Admin Email";
            // 
            // txtAdminEmail
            // 
            this.txtAdminEmail.Location = new System.Drawing.Point(128, 19);
            this.txtAdminEmail.Name = "txtAdminEmail";
            this.txtAdminEmail.Size = new System.Drawing.Size(146, 20);
            this.txtAdminEmail.TabIndex = 19;
            this.txtAdminEmail.Text = "riskypathak@gmail.com";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Admin Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(128, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(146, 20);
            this.txtPassword.TabIndex = 21;
            this.txtPassword.Text = "infosys";
            // 
            // chkDBExits
            // 
            this.chkDBExits.AutoSize = true;
            this.chkDBExits.Checked = true;
            this.chkDBExits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDBExits.Location = new System.Drawing.Point(280, 94);
            this.chkDBExits.Name = "chkDBExits";
            this.chkDBExits.Size = new System.Drawing.Size(106, 17);
            this.chkDBExits.TabIndex = 22;
            this.chkDBExits.Text = "Create Database";
            this.chkDBExits.UseVisualStyleBackColor = true;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(128, 93);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(146, 20);
            this.txtDatabaseName.TabIndex = 23;
            this.txtDatabaseName.Text = "nop_first";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Database Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "Sql Server Name";
            // 
            // txtSqlServerName
            // 
            this.txtSqlServerName.Location = new System.Drawing.Point(128, 68);
            this.txtSqlServerName.Name = "txtSqlServerName";
            this.txtSqlServerName.Size = new System.Drawing.Size(146, 20);
            this.txtSqlServerName.TabIndex = 26;
            this.txtSqlServerName.Text = "localhost";
            // 
            // radioWindowsAuth
            // 
            this.radioWindowsAuth.AutoSize = true;
            this.radioWindowsAuth.Location = new System.Drawing.Point(9, 121);
            this.radioWindowsAuth.Name = "radioWindowsAuth";
            this.radioWindowsAuth.Size = new System.Drawing.Size(140, 17);
            this.radioWindowsAuth.TabIndex = 27;
            this.radioWindowsAuth.Text = "Windows Authentication";
            this.radioWindowsAuth.UseVisualStyleBackColor = true;
            // 
            // radioSQLAuth
            // 
            this.radioSQLAuth.AutoSize = true;
            this.radioSQLAuth.Checked = true;
            this.radioSQLAuth.Location = new System.Drawing.Point(158, 121);
            this.radioSQLAuth.Name = "radioSQLAuth";
            this.radioSQLAuth.Size = new System.Drawing.Size(117, 17);
            this.radioSQLAuth.TabIndex = 28;
            this.radioSQLAuth.TabStop = true;
            this.radioSQLAuth.Text = "SQL Authentication";
            this.radioSQLAuth.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSqlServerName);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.radioSQLAuth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAdminEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.radioWindowsAuth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSQLUser);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtSqlPass);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.chkDBExits);
            this.groupBox1.Controls.Add(this.txtDatabaseName);
            this.groupBox1.Location = new System.Drawing.Point(12, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 205);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 336);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkBinding);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSubdomain);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.btnBrowsePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreate);
            this.Name = "Form1";
            this.Text = "nopCommerce Creator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSQLUser;
        private System.Windows.Forms.TextBox txtSqlPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowsePath;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtSubdomain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.CheckBox chkBinding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAdminEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkDBExits;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSqlServerName;
        private System.Windows.Forms.RadioButton radioWindowsAuth;
        private System.Windows.Forms.RadioButton radioSQLAuth;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

