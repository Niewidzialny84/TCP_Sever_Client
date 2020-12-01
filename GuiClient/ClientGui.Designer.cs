namespace GuiClient
{
    partial class ClientGui
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginText = new System.Windows.Forms.Label();
            this.passwText = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.TextBox();
            this.passwdBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.responseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginText
            // 
            this.loginText.AutoSize = true;
            this.loginText.Location = new System.Drawing.Point(63, 52);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(33, 13);
            this.loginText.TabIndex = 0;
            this.loginText.Text = "Login";
            // 
            // passwText
            // 
            this.passwText.AutoSize = true;
            this.passwText.Location = new System.Drawing.Point(43, 78);
            this.passwText.Name = "passwText";
            this.passwText.Size = new System.Drawing.Size(53, 13);
            this.passwText.TabIndex = 1;
            this.passwText.Text = "Password";
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(102, 49);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(100, 20);
            this.userBox.TabIndex = 2;
            // 
            // passwdBox
            // 
            this.passwdBox.Location = new System.Drawing.Point(102, 78);
            this.passwdBox.Name = "passwdBox";
            this.passwdBox.Size = new System.Drawing.Size(100, 20);
            this.passwdBox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(102, 104);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(100, 30);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // responseLabel
            // 
            this.responseLabel.AutoSize = true;
            this.responseLabel.Location = new System.Drawing.Point(99, 33);
            this.responseLabel.Name = "responseLabel";
            this.responseLabel.Size = new System.Drawing.Size(0, 13);
            this.responseLabel.TabIndex = 5;
            // 
            // ClientGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 174);
            this.Controls.Add(this.responseLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwdBox);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.passwText);
            this.Controls.Add(this.loginText);
            this.Name = "ClientGui";
            this.Text = "Login ";
            this.Load += new System.EventHandler(this.ClientGui_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginText;
        private System.Windows.Forms.Label passwText;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.TextBox passwdBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label responseLabel;
    }
}

