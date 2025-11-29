namespace InvestAI
{
    partial class RegisterScreen
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
            passwordLabel = new Label();
            emailLabel = new Label();
            registerButton = new Button();
            passwordTextBox = new TextBox();
            emailTextBox = new TextBox();
            usernameLabel = new Label();
            usernameTextBox = new TextBox();
            SuspendLayout();
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 12F);
            passwordLabel.Location = new Point(214, 332);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(111, 32);
            passwordLabel.TabIndex = 9;
            passwordLabel.Text = "Password";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 12F);
            emailLabel.Location = new Point(254, 242);
            emailLabel.Margin = new Padding(4, 0, 4, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(71, 32);
            emailLabel.TabIndex = 8;
            emailLabel.Text = "Email";
            // 
            // registerButton
            // 
            registerButton.Font = new Font("Segoe UI", 12F);
            registerButton.Location = new Point(431, 396);
            registerButton.Margin = new Padding(4);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(183, 54);
            registerButton.TabIndex = 7;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Font = new Font("Segoe UI", 12F);
            passwordTextBox.Location = new Point(333, 329);
            passwordTextBox.Margin = new Padding(4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(458, 39);
            passwordTextBox.TabIndex = 6;
            // 
            // emailTextBox
            // 
            emailTextBox.Font = new Font("Segoe UI", 12F);
            emailTextBox.Location = new Point(333, 239);
            emailTextBox.Margin = new Padding(4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(458, 39);
            emailTextBox.TabIndex = 5;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI", 12F);
            usernameLabel.Location = new Point(204, 169);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(121, 32);
            usernameLabel.TabIndex = 11;
            usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Font = new Font("Segoe UI", 12F);
            usernameTextBox.Location = new Point(333, 169);
            usernameTextBox.Margin = new Padding(4);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(458, 39);
            usernameTextBox.TabIndex = 10;
            // 
            // RegisterScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 576);
            Controls.Add(usernameLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(emailLabel);
            Controls.Add(registerButton);
            Controls.Add(passwordTextBox);
            Controls.Add(emailTextBox);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "RegisterScreen";
            Text = "InvestAI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label passwordLabel;
        private Label emailLabel;
        private Button registerButton;
        private TextBox passwordTextBox;
        private TextBox emailTextBox;
        private Label usernameLabel;
        private TextBox usernameTextBox;
    }
}