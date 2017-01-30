using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokerHW.Poker;

namespace PokerHW {
    public partial class MenuForm : Form {

        private List<PlayerForm> playerFormList;
        public MenuForm() {
            InitializeComponent();
        }

        //  Starts a new poker game.
        private void newGameButton_Click(object sender, EventArgs e) {
            PokerGame pokerGame = new PokerGame();
            Hide();
            for (int i = 1; i <= Properties.Settings.Default.NumOfPlayers; i++) {
                ExitGameHandler exitHandler = new ExitGameHandler(PlayerForm_Exit);
                PlayerForm playerForm = new PlayerForm(i, pokerGame);
                playerForm.exitGameEvent += exitHandler;
                playerFormList.Add(playerForm);
                playerForm.Show();
                //  TODO: Register event at each player form's (for the exit button, if one exits, the whole game stops.
            }
            pokerGame.startGame(true);
        }

        //  Loads the options form.
        private void optionsButton_Click(object sender, EventArgs e) {
            using (OptionsForm optionsForm = new OptionsForm(Properties.Settings.Default.NumOfPlayers)) {
                Hide();
                optionsForm.ShowDialog();
                Show();
            }
        }

        //  Shuts down all player forms.
        private void PlayerForm_Exit(int form) {
            for(int i = 0; i < playerFormList.Count; i++) 
                playerFormList[i].closeForm();
            playerFormList.Clear();
            Show();
        }

        private void MenuForm_Load(object sender, EventArgs e) {
            playerFormList = new List<PlayerForm>();
        }
    }
}
