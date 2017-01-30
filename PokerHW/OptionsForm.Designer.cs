namespace PokerHW {
    partial class OptionsForm {
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
            this.components = new System.ComponentModel.Container();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.labelPlayerPic = new System.Windows.Forms.Label();
            this.labelPlayersList = new System.Windows.Forms.Label();
            this.comboBoxPlayersList = new System.Windows.Forms.ComboBox();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.listViewAvatars = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonOptionsSave = new System.Windows.Forms.Button();
            this.buttonOptionsCancel = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayerName.ForeColor = System.Drawing.Color.Gold;
            this.labelPlayerName.Location = new System.Drawing.Point(85, 202);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(114, 20);
            this.labelPlayerName.TabIndex = 0;
            this.labelPlayerName.Text = "Player Name:";
            // 
            // labelPlayerPic
            // 
            this.labelPlayerPic.AutoSize = true;
            this.labelPlayerPic.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayerPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayerPic.ForeColor = System.Drawing.Color.Gold;
            this.labelPlayerPic.Location = new System.Drawing.Point(85, 285);
            this.labelPlayerPic.Name = "labelPlayerPic";
            this.labelPlayerPic.Size = new System.Drawing.Size(120, 20);
            this.labelPlayerPic.TabIndex = 1;
            this.labelPlayerPic.Text = "Player Avatar:";
            // 
            // labelPlayersList
            // 
            this.labelPlayersList.AutoSize = true;
            this.labelPlayersList.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayersList.ForeColor = System.Drawing.Color.Gold;
            this.labelPlayersList.Location = new System.Drawing.Point(85, 126);
            this.labelPlayersList.Name = "labelPlayersList";
            this.labelPlayersList.Size = new System.Drawing.Size(127, 20);
            this.labelPlayersList.TabIndex = 2;
            this.labelPlayersList.Text = "List of Players:";
            // 
            // comboBoxPlayersList
            // 
            this.comboBoxPlayersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBoxPlayersList.FormattingEnabled = true;
            this.comboBoxPlayersList.Location = new System.Drawing.Point(290, 123);
            this.comboBoxPlayersList.Name = "comboBoxPlayersList";
            this.comboBoxPlayersList.Size = new System.Drawing.Size(121, 28);
            this.comboBoxPlayersList.TabIndex = 3;
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxPlayerName.Location = new System.Drawing.Point(300, 202);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(100, 26);
            this.textBoxPlayerName.TabIndex = 4;
            // 
            // listViewAvatars
            // 
            this.listViewAvatars.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewAvatars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listViewAvatars.LargeImageList = this.imageList;
            this.listViewAvatars.Location = new System.Drawing.Point(290, 285);
            this.listViewAvatars.MultiSelect = false;
            this.listViewAvatars.Name = "listViewAvatars";
            this.listViewAvatars.Size = new System.Drawing.Size(121, 97);
            this.listViewAvatars.TabIndex = 5;
            this.listViewAvatars.UseCompatibleStateImageBehavior = false;
            this.listViewAvatars.ItemActivate += new System.EventHandler(this.listViewAvatars_ItemActivate);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(60, 60);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonOptionsSave
            // 
            this.buttonOptionsSave.BackColor = System.Drawing.Color.Transparent;
            this.buttonOptionsSave.BackgroundImage = global::PokerHW.Properties.Resources.ButtonSquare;
            this.buttonOptionsSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOptionsSave.FlatAppearance.BorderSize = 0;
            this.buttonOptionsSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonOptionsSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonOptionsSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOptionsSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonOptionsSave.Location = new System.Drawing.Point(132, 438);
            this.buttonOptionsSave.Name = "buttonOptionsSave";
            this.buttonOptionsSave.Size = new System.Drawing.Size(100, 40);
            this.buttonOptionsSave.TabIndex = 6;
            this.buttonOptionsSave.Text = "Save";
            this.buttonOptionsSave.UseVisualStyleBackColor = false;
            this.buttonOptionsSave.Click += new System.EventHandler(this.buttonOptionsSave_Click);
            // 
            // buttonOptionsCancel
            // 
            this.buttonOptionsCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonOptionsCancel.BackgroundImage = global::PokerHW.Properties.Resources.ButtonSquare;
            this.buttonOptionsCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOptionsCancel.FlatAppearance.BorderSize = 0;
            this.buttonOptionsCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonOptionsCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonOptionsCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOptionsCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonOptionsCancel.Location = new System.Drawing.Point(255, 438);
            this.buttonOptionsCancel.Name = "buttonOptionsCancel";
            this.buttonOptionsCancel.Size = new System.Drawing.Size(100, 40);
            this.buttonOptionsCancel.TabIndex = 7;
            this.buttonOptionsCancel.Text = "Cancel";
            this.buttonOptionsCancel.UseVisualStyleBackColor = false;
            this.buttonOptionsCancel.Click += new System.EventHandler(this.buttonOptionsCancel_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.Color.Transparent;
            this.buttonChange.BackgroundImage = global::PokerHW.Properties.Resources.ButtonSquare;
            this.buttonChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonChange.FlatAppearance.BorderSize = 0;
            this.buttonChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonChange.Location = new System.Drawing.Point(300, 234);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(100, 29);
            this.buttonChange.TabIndex = 8;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PokerHW.Properties.Resources.SplashPage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(896, 584);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.buttonOptionsCancel);
            this.Controls.Add(this.buttonOptionsSave);
            this.Controls.Add(this.listViewAvatars);
            this.Controls.Add(this.textBoxPlayerName);
            this.Controls.Add(this.comboBoxPlayersList);
            this.Controls.Add(this.labelPlayersList);
            this.Controls.Add(this.labelPlayerPic);
            this.Controls.Add(this.labelPlayerName);
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.Label labelPlayerPic;
        private System.Windows.Forms.Label labelPlayersList;
        private System.Windows.Forms.ComboBox comboBoxPlayersList;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.ListView listViewAvatars;
        private System.Windows.Forms.Button buttonOptionsSave;
        private System.Windows.Forms.Button buttonOptionsCancel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button buttonChange;
    }
}