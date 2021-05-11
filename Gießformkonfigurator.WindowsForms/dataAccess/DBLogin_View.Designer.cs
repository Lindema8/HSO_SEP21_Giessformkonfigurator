
namespace Gießformkonfigurator.WindowsForms.DataAccess
{
    partial class DBLogin_View
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
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.label_Server = new System.Windows.Forms.Label();
            this.label_DB = new System.Windows.Forms.Label();
            this.textBox_DB = new System.Windows.Forms.TextBox();
            this.label_User = new System.Windows.Forms.Label();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label_PW = new System.Windows.Forms.Label();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.button_Connection = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_Server
            // 
            this.textBox_Server.Location = new System.Drawing.Point(343, 152);
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.Size = new System.Drawing.Size(187, 22);
            this.textBox_Server.TabIndex = 0;
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Location = new System.Drawing.Point(256, 155);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(71, 17);
            this.label_Server.TabIndex = 1;
            this.label_Server.Text = "Server-IP:";
            // 
            // label_DB
            // 
            this.label_DB.AutoSize = true;
            this.label_DB.Location = new System.Drawing.Point(246, 190);
            this.label_DB.Name = "label_DB";
            this.label_DB.Size = new System.Drawing.Size(81, 17);
            this.label_DB.TabIndex = 2;
            this.label_DB.Text = "Datenbank:";
            this.label_DB.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_DB
            // 
            this.textBox_DB.Location = new System.Drawing.Point(343, 187);
            this.textBox_DB.Name = "textBox_DB";
            this.textBox_DB.Size = new System.Drawing.Size(187, 22);
            this.textBox_DB.TabIndex = 3;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(246, 227);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(81, 17);
            this.label_User.TabIndex = 4;
            this.label_User.Text = "Username: ";
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(343, 224);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(187, 22);
            this.textBox_User.TabIndex = 5;
            // 
            // label_PW
            // 
            this.label_PW.AutoSize = true;
            this.label_PW.Location = new System.Drawing.Point(254, 266);
            this.label_PW.Name = "label_PW";
            this.label_PW.Size = new System.Drawing.Size(73, 17);
            this.label_PW.TabIndex = 6;
            this.label_PW.Text = "Password:";
            // 
            // textBox_PW
            // 
            this.textBox_PW.Location = new System.Drawing.Point(343, 263);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.Size = new System.Drawing.Size(187, 22);
            this.textBox_PW.TabIndex = 7;
            // 
            // button_Connection
            // 
            this.button_Connection.Location = new System.Drawing.Point(441, 312);
            this.button_Connection.Name = "button_Connection";
            this.button_Connection.Size = new System.Drawing.Size(89, 23);
            this.button_Connection.TabIndex = 8;
            this.button_Connection.Text = "Verbinden";
            this.button_Connection.UseVisualStyleBackColor = true;
            this.button_Connection.Click += new System.EventHandler(this.button_Connection_Click);
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(400, 56);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(0, 17);
            this.label_Status.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(343, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 22);
            this.textBox1.TabIndex = 10;
            // 
            // DBLogin_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.button_Connection);
            this.Controls.Add(this.textBox_PW);
            this.Controls.Add(this.label_PW);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.textBox_DB);
            this.Controls.Add(this.label_DB);
            this.Controls.Add(this.label_Server);
            this.Controls.Add(this.textBox_Server);
            this.Name = "DBLogin_View";
            this.Text = "DBLogin_Controller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Server;
        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.Label label_DB;
        private System.Windows.Forms.TextBox textBox_DB;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label_PW;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.Button button_Connection;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.TextBox textBox1;
    }
}