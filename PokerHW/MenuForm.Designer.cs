namespace PokerHW {
    partial class MenuForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.newGameButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.BackColor = System.Drawing.Color.Transparent;
            this.newGameButton.BackgroundImage = global::PokerHW.Properties.Resources.ButtonSquare;
            this.newGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newGameButton.FlatAppearance.BorderSize = 0;
            this.newGameButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.newGameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.newGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.newGameButton.Location = new System.Drawing.Point(82, 156);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(134, 43);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = false;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.BackColor = System.Drawing.Color.Transparent;
            this.optionsButton.BackgroundImage = global::PokerHW.Properties.Resources.ButtonSquare;
            this.optionsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.optionsButton.FlatAppearance.BorderSize = 0;
            this.optionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.optionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.optionsButton.Location = new System.Drawing.Point(82, 235);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(134, 43);
            this.optionsButton.TabIndex = 1;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = false;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundImage = global::PokerHW.Properties.Resources.ButtonSquare;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.exitButton.Location = new System.Drawing.Point(82, 313);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(134, 43);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PokerHW.Properties.Resources.SplashPage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(853, 531);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.newGameButton);
            this.Name = "MenuForm";
            this.ShowIcon = false;
            this.Text = "Texas Holdem Poker";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button exitButton;
    }
}

