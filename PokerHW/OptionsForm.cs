using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerHW {
    public partial class OptionsForm : Form {
        public const int PLAYER1 = 0;                 //  Final representing player 1.
        public const int PLAYER2 = 1;                 //  Final representing player 2.
        public const int PLAYER3 = 2;                 //  Final representing player 3.

        private int NumOfPlayers;                     //  Number of players in game.
        private List<string> PlayerNames;             //  List of player names, used as a "cache".
        private List<string> PlayerImages;            //  List of player images, used as a "cache".

        public OptionsForm(int NumOfPlayers) {
            InitializeComponent();
            this.NumOfPlayers = NumOfPlayers;
        }

        //  Runs when the player has clicked the Save button.
        //  Saves all the user configurations made.
        private void buttonOptionsSave_Click(object sender, EventArgs e) {
            Properties.Settings.Default.Player1Name = PlayerNames[PLAYER1];
            Properties.Settings.Default.Player1Image = PlayerImages[PLAYER1];
            Properties.Settings.Default.Player2Name = PlayerNames[PLAYER2];
            Properties.Settings.Default.Player2Image = PlayerImages[PLAYER2];
            Properties.Settings.Default.Player3Name = PlayerNames[PLAYER3];
            Properties.Settings.Default.Player3Image = PlayerImages[PLAYER3];
            this.Close();
        }

        //  Runs when the player has clicked the Cancel button.
        //  Closes the options form and discards any changes made.
        private void buttonOptionsCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        //  Runs when the player chooses a photo from the imagelist.
        //  Saves the photo chosen by the player.
        private void listViewAvatars_ItemActivate(object sender, EventArgs e) {
            if (listViewAvatars.SelectedItems.Count != 0 && comboBoxPlayersList.SelectedIndex != -1)
                PlayerImages[comboBoxPlayersList.SelectedIndex] = (listViewAvatars.SelectedItems[0]).ImageKey;
        }

        //  Runs when the player has clicked the Change button.
        //  Saves the player name change.
        private void buttonChange_Click(object sender, EventArgs e) {
                PlayerNames[comboBoxPlayersList.SelectedIndex] = textBoxPlayerName.Text;
                comboBoxPlayersList.Items[comboBoxPlayersList.SelectedIndex] = textBoxPlayerName.Text;
        }

        //  Runs when the options form has loaded.
        //  Initializes the listview and the imagelist.
        private void OptionsForm_Load(object sender, EventArgs e) {
            PlayerNames = new List<string>(NumOfPlayers);
            PlayerImages = new List<string>(NumOfPlayers);
            comboBoxPlayersList.Items.Add("Player1");
            comboBoxPlayersList.Items.Add("Player2");
            comboBoxPlayersList.Items.Add("Player3");
            string image1 = Properties.Settings.Default.DefaultImage1;
            string image2 = Properties.Settings.Default.DefaultImage2;
            string image3 = Properties.Settings.Default.DefaultImage3;
            string image4 = Properties.Settings.Default.DefaultImage4;
            imageList.Images.Add(image1, Image.FromFile(image1));
            listViewAvatars.Items.Add(image1, image1);
            listViewAvatars.Items[0].Text = "";
            imageList.Images.Add(image2, Image.FromFile(image2));
            listViewAvatars.Items.Add(image2, image2);
            listViewAvatars.Items[1].Text = "";
            imageList.Images.Add(image3, Image.FromFile(image3));
            listViewAvatars.Items.Add(image3, image3);
            listViewAvatars.Items[2].Text = "";
            imageList.Images.Add(image4, Image.FromFile(image4));
            listViewAvatars.Items.Add(image4, image4);
            listViewAvatars.Items[3].Text = "";
            for (int i = 0; i < NumOfPlayers; i++) {
                PlayerNames.Add("Player" + i);
                PlayerImages.Add(image1);
            }
            comboBoxPlayersList.SelectedIndex = PLAYER1;
        }
    }
}
