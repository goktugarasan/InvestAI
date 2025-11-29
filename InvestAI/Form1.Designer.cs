namespace InvestAI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            emailLabel = new Label();
            passwordLabel = new Label();
            registerButton = new Button();
            SuspendLayout();
            // 
            // emailTextBox
            // 
            emailTextBox.Font = new Font("Segoe UI", 12F);
            emailTextBox.Location = new Point(312, 227);
            emailTextBox.Margin = new Padding(4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(458, 39);
            emailTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Font = new Font("Segoe UI", 12F);
            passwordTextBox.Location = new Point(312, 321);
            passwordTextBox.Margin = new Padding(4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(458, 39);
            passwordTextBox.TabIndex = 1;
            // 
            // loginButton
            // 
            loginButton.Font = new Font("Segoe UI", 12F);
            loginButton.Location = new Point(410, 384);
            loginButton.Margin = new Padding(4);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(183, 54);
            loginButton.TabIndex = 2;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 12F);
            emailLabel.Location = new Point(233, 230);
            emailLabel.Margin = new Padding(4, 0, 4, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(71, 32);
            emailLabel.TabIndex = 3;
            emailLabel.Text = "Email";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 12F);
            passwordLabel.Location = new Point(193, 324);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(111, 32);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password";
            // 
            // registerButton
            // 
            registerButton.Font = new Font("Segoe UI", 12F);
            registerButton.Location = new Point(410, 462);
            registerButton.Margin = new Padding(4);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(183, 56);
            registerButton.TabIndex = 5;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 576);
            Controls.Add(registerButton);
            Controls.Add(passwordLabel);
            Controls.Add(emailLabel);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(emailTextBox);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "InvestAI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label emailLabel;
        private Label passwordLabel;
        private Button registerButton;
    }
}
