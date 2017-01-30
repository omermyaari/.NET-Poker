using System;
using PokerHW.Poker;
using PokerHW.CardGameFramework;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Threading;

namespace PokerHW {
    public delegate void ExitGameHandler(int form);
    public partial class PlayerForm : Form {
        public enum Options { Call, Check }       //  If no player has raised his bet before this player's turn,
                                                  //  this player can use the check button.
        public enum Bet {
            b10 = 10, b25 = 25,                   //  Enum representing the chips.
            b50 = 50, b100 = 100
        }

        public enum PokerButton {                 //  Enum representing the poker buttons.
            Fold, Check, Call, Raise
        }

        public enum TableCard {                  //  Enum representing the dealer's cards.
            First, Second, Third, Fourth, Fifth
        }

        private bool firstRound;                  //  Boolean indicating that a new game has started.
        private int playerId;                     //  This player's id number.
        private int player2Id;                    //  Player 2 id number.
        private int player3Id;                    //  Player 3 id number.
        private int currentPlayerOptions;         //  Current player options (check / call).
        private List<Player> players;             //  List that holds current players.
        private List<Card> dealerHand;            //  List that holds the dealer's cards.
        private decimal playerBet;                //  Decimal indicating the player's current bet.
        private decimal tableBet;                 //  Decimal indicating the table's current bet.
        private GameRound gameRound;              //  Indicates current game round (preflop, flop, etc).
        private PokerGame game;                   //  Game logic.
        public event ExitGameHandler exitGameEvent;

        public PlayerForm(int playerId, PokerGame game) {
            InitializeComponent();
            this.playerId = playerId;
            this.game = game;
            NewTurnHandler newTurnHandler = new NewTurnHandler(NewTurn);
            NewRoundHandler newRounderHandler = new NewRoundHandler(NewRound);
            NewBetHandler newBetHandler = new NewBetHandler(DrawPlayerBet);
            WinnerHandler winnerHandler = new WinnerHandler(DisplayWinner);
            game.newTurnEvent += newTurnHandler;
            game.newRoundEvent += newRounderHandler;
            game.newBetEvent += newBetHandler;
            game.winnerEvent += winnerHandler;
            firstRound = true;
        }

        //  Binds the other players to their place in this player's form.
        private void bindOtherPlayers() {
            player2Id = playerId - 1;
            if (player2Id == 0)
                player2Id = players.Count;
            player3Id = playerId + 1;
            if (player3Id == players.Count + 1)
                player3Id = 1;
        }

        //  Starts a new round (after receiving a signal from the logic class).
        private void NewRound(object sender, NewRoundEventArgs e) {
            //  If its a new game.
            if (firstRound) {
                dealerHand = e.DealerHand;
                players = e.Players;
                bindOtherPlayers();
                initGameUI();
                firstRound = false;
            }
            gameRound = e.Round;
            hidePlayerChips();
            switch (gameRound) {
                case GameRound.Preflop:
                    LoadCard(thisPlayerCard1, players[playerId - 1].PlayerHand[(int)Player.PlayerCardSettings.FirstCard]);
                    thisPlayerCard1.Visible = true;
                    LoadCard(thisPlayerCard2, players[playerId - 1].PlayerHand[(int)Player.PlayerCardSettings.SecondCard]);
                    thisPlayerCard2.Visible = true;
                    break;
                case GameRound.Flop:
                    LoadCard(tableCard1, dealerHand[(int)TableCard.First]);
                    tableCard1.Visible = true;
                    LoadCard(tableCard2, dealerHand[(int)TableCard.Second]);
                    tableCard2.Visible = true;
                    LoadCard(tableCard3, dealerHand[(int)TableCard.Third]);
                    tableCard3.Visible = true;
                    break;
                case GameRound.Turn:
                    LoadCard(tableCard4, dealerHand[(int)TableCard.Fourth]);
                    tableCard4.Visible = true;
                    break;
                case GameRound.River:
                    LoadCard(tableCard5, dealerHand[(int)TableCard.Fifth]);
                    tableCard5.Visible = true;
                    break;
                /*
                //  If we wanted to add a new round:
                case GameRound.NewRound:
                    LoadCard(tableCard6, dealerHand[SIXTH_TABLE_CARD]);
                    tableCard5.Visible = true;
                    bla bla;
                    break;
                */
            }
        }

        //  Hides the dealer's cards in the start of a new game.
        private void HideDealerCards() {
            tableCard1.Visible = false;
            tableCard2.Visible = false;
            tableCard3.Visible = false; 
            tableCard4.Visible = false;
            tableCard5.Visible = false;
            //  If we add a new level, we need to hide its card (sixth card) in this method, too.
            //  tableCard.Visible = false;
        }

        //  Starts a new turn (after receiving a signal from the logic class).
        private void NewTurn(object sender, NewTurnEventArgs e) {
            turnLightsOff();
            updateBalances();
            textBoxTotalBets.Text = e.Pot.ToString();
            currentPlayerOptions = e.CurrentPlayerOptions;
            tableBet = e.Bet;
            //  If current turn is this player's turn.
            if (e.CurrentPlayerTurn == playerId) {
                showMainControls(true);
                picBoxLightThisPlayer.Visible = true;
            }
            else {
                if (e.CurrentPlayerTurn == player2Id)
                    picBoxLightPlayer2.Visible = true;
                else
                    picBoxLightPlayer3.Visible = true;
            }
        }

        //  Shows a popup message that declares the winner of the game.
        private void DisplayWinner(object sender, string winner) {
            textBoxTotalBets.Text = 0.ToString();
            updateBalances();
            MessageBox.Show(winner + " won!");
            HideDealerCards();
        }

        // Updates the UI on first run.
        private void initGameUI() {
            updateNames();
            updateBalances();
            updateAvatars();
        }

        //  Updates this player and the other players' names.
        private void updateNames() {
            labelThisPlayerName.Text = players[playerId - 1].Name;
            labelPlayer2Name.Text = players[player2Id - 1].Name;
            labelPlayer3Name.Text = players[player3Id - 1].Name;
        }

        //  Updates this player and the other players' balances.
        private void updateBalances() {
            textBoxThisPlayerCash.Text = (players[playerId - 1].Balance).ToString();
            textBoxPlayer2Cash.Text = (players[player2Id - 1].Balance).ToString();
            textBoxPlayer3Cash.Text = (players[player3Id - 1].Balance).ToString();
        }

        //  Updates this player and the other players' avatars.
        private void updateAvatars() {
            picBoxThisPlayer.Image = Image.FromFile(players[playerId - 1].Image);
            picBoxPlayer2.Image = Image.FromFile(players[player2Id - 1].Image);
            picBoxPlayer3.Image = Image.FromFile(players[player3Id - 1].Image);
        }

        //  Shows (or hides) the coin buttons.
        public void showCoinButtons(bool show) {
            button10.Visible = show;
            button25.Visible = show;
            button50.Visible = show;
            button100.Visible = show;
        }

        //  Shows (or hides) the raise control buttons.
        public void showRaiseControl(bool show) {
            if (tableBet == 0)
                playerBet = 0;
            else
                playerBet = tableBet;
            textBoxRaise.Text = playerBet.ToString();
            buttonRaiseOk.Visible = show;
            buttonRaiseCancel.Visible = show;
            labelRaiseAmount.Visible = show;
            textBoxRaise.Visible = show;
            showCoinButtons(show);
        }

        //  Shows (or hides) the fold, check, call, raise buttons.
        public void showMainControls(bool show) {
            if (currentPlayerOptions == (int)Options.Check) {
                buttonFold.Visible = show;
                buttonCheck.Visible = show;
                buttonRaise.Visible = show;
            }
            else {
                buttonFold.Visible = show;
                buttonCall.Visible = show;
                buttonCall.Text = "Call " + tableBet;
                buttonRaise.Visible = show;
            }
        }

        //  Runs when the player clicks the fold button.
        private void buttonFold_Click(object sender, EventArgs e) {
            showMainControls(false);
            picBoxLightThisPlayer.Visible = false;
            game.endTurn(playerId, (int)PokerButton.Fold, playerBet);
        }

        //  Runs when the player has clicked the exit button.
        private void buttonExit_Click(object sender, EventArgs e) {
            exitGameEvent(playerId - 1);
        }

        //  Shows the raise control buttons, after the Raise button has been clicked.
        private void buttonRaise_Click(object sender, EventArgs e) {
            showMainControls(false);
            showRaiseControl(true);
        }

        //  Increases the bet raise by 10.
        private void button10_Click(object sender, EventArgs e) {
            if (checkBalance(playerBet + (int)Bet.b10)) {
                playerBet += (int)Bet.b10;
                textBoxRaise.Text = playerBet.ToString();
            }
            else
                MessageBox.Show(Properties.Resources.BetTooHigh);
        }

        //  Increases the bet raise by 25.
        private void button25_Click(object sender, EventArgs e) {
            if (checkBalance(playerBet + (int)Bet.b25)) {
                playerBet += (int)Bet.b25;
                textBoxRaise.Text = playerBet.ToString();
            }
            else
                MessageBox.Show(Properties.Resources.BetTooHigh);
        }

        //  Increases the bet raise by 50.
        private void button50_Click(object sender, EventArgs e) {
            if (checkBalance(playerBet + (int)Bet.b50)) {
                playerBet += (int)Bet.b50;
                textBoxRaise.Text = playerBet.ToString();
            }
            else
                MessageBox.Show(Properties.Resources.BetTooHigh);
        }

        //  Increases the bet raise by 100.
        private void button100_Click(object sender, EventArgs e) {
            if (checkBalance(playerBet + (int)Bet.b100)) {
                playerBet += (int)Bet.b100;
                textBoxRaise.Text = playerBet.ToString();
            }
            else
                MessageBox.Show(Properties.Resources.BetTooHigh);

        }

        //  Cancels the raise and shows the main controls again.
        private void buttonRaiseCancel_Click(object sender, EventArgs e) {
            playerBet = 0;
            showRaiseControl(false);
            showMainControls(true);
        }

        //  Sends the bet amount to the PokerGame logic (after the OK button in the Raise control has been clicked).
        private void buttonRaiseOk_Click(object sender, EventArgs e) {
            decimal oldBet = tableBet;
            tableBet = playerBet;
            if (tableBet == oldBet) 
                MessageBox.Show(Properties.Resources.NotRaised);
            else {
                showRaiseControl(false);
                picBoxLightThisPlayer.Visible = false;
                game.endTurn(playerId, (int)PokerButton.Raise, playerBet);
            }
        }

        //  Checks player's balance.
        private bool checkBalance(decimal amount) {
            if (amount - players[playerId - 1].Balance > 0)
                return false;
            else
                return true;
        }

        //  Runs when the player clicks the check button.
        private void buttonCheck_Click(object sender, EventArgs e) {
            showMainControls(false);
            picBoxLightThisPlayer.Visible = false;
            game.endTurn(playerId, (int)PokerButton.Check, playerBet);
        }

        //  Runs when the player clicks the call button.
        private void buttonCall_Click(object sender, EventArgs e) {
            showMainControls(false);
            playerBet = tableBet;
            picBoxLightThisPlayer.Visible = false;
            game.endTurn(playerId, (int)PokerButton.Call, playerBet);
        }

        //  "Turns" all player lights off (the picture indicating which player is now playing).
        private void turnLightsOff() {
            picBoxLightPlayer2.Visible = false;
            picBoxLightPlayer3.Visible = false;
            picBoxLightThisPlayer.Visible = false;
        }

        //  Hides all player chips (bets) in the start of a new round.
        private void hidePlayerChips() {
            picBoxChipsThisPlayer.Visible = false;
            picBoxChipsPlayer2.Visible = false;
            picBoxChipsPlayer3.Visible = false;
            labelChipsThisPlayer.Visible = false;
            labelChipsPlayer2.Visible = false;
            labelChipsPlayer3.Visible = false;
        }

        //  Called upon by the game logic when a bet has been made, in order to draw it in the UI.
        private void DrawPlayerBet(object sender, NewBetEventArgs e) {
            if (e.PlayerId == playerId) {
                picBoxChipsThisPlayer.Visible = true;
                labelChipsThisPlayer.Text = e.Bet.ToString();
                labelChipsThisPlayer.Visible = true;
            }
            else if (e.PlayerId == player2Id) {
                picBoxChipsPlayer2.Visible = true;
                labelChipsPlayer2.Text = e.Bet.ToString();
                labelChipsPlayer2.Visible = true;
            }
            else {
                picBoxChipsPlayer3.Visible = true;
                labelChipsPlayer3.Text = e.Bet.ToString();
                labelChipsPlayer3.Visible = true;
            }

        }

        //  Loads a given card into a given picturebox.
        private void LoadCard(PictureBox pb, Card c) {
            try {
                StringBuilder image = new StringBuilder();

                switch (c.Suit) {
                    case Suit.Diamonds:
                        image.Append("di");
                        break;
                    case Suit.Hearts:
                        image.Append("he");
                        break;
                    case Suit.Spades:
                        image.Append("sp");
                        break;
                    case Suit.Clubs:
                        image.Append("cl");
                        break;
                }

                switch (c.FaceVal) {
                    case FaceValue.Ace:
                        image.Append("1");
                        break;
                    case FaceValue.King:
                        image.Append("k");
                        break;
                    case FaceValue.Queen:
                        image.Append("q");
                        break;
                    case FaceValue.Jack:
                        image.Append("j");
                        break;
                    case FaceValue.Ten:
                        image.Append("10");
                        break;
                    case FaceValue.Nine:
                        image.Append("9");
                        break;
                    case FaceValue.Eight:
                        image.Append("8");
                        break;
                    case FaceValue.Seven:
                        image.Append("7");
                        break;
                    case FaceValue.Six:
                        image.Append("6");
                        break;
                    case FaceValue.Five:
                        image.Append("5");
                        break;
                    case FaceValue.Four:
                        image.Append("4");
                        break;
                    case FaceValue.Three:
                        image.Append("3");
                        break;
                    case FaceValue.Two:
                        image.Append("2");
                        break;
                }

                image.Append(Properties.Settings.Default.CardGameImageExtension);
                string cardGameImagePath = Properties.Settings.Default.CardGameImagePath;
                image.Insert(0, cardGameImagePath);
                //check to see if the card should be faced down or up;
                pb.Image = new Bitmap(image.ToString());
            }
            catch (ArgumentOutOfRangeException) {
                MessageBox.Show("Card images are not loading correctly.  Make sure all card images are in the right location.");
            }
        }

        //  Closes the form (using by the MenuForm when one form has closed).
        public void closeForm() {
            this.Close();
        }
    }
}