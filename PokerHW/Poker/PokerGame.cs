using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHW.CardGameFramework;

namespace PokerHW.Poker {
    public delegate void NewTurnHandler(object sender, NewTurnEventArgs e);     //  New turn delegate.
    public delegate void NewRoundHandler(object sender, NewRoundEventArgs e);   //  New round delegate.
    public delegate void NewBetHandler(object sender, NewBetEventArgs e);       //  New bet delegate (raise)
    public delegate void WinnerHandler(object sender, string winner);           //  Winner delegate.
    public class PokerGame {

        public const int POKER_NUM_OF_CARDS = 5;

        private Deck currentDeck;           //  The deck.
        private List<Player> players;       //  List of Players.
        private GameRound gameRound;        //  Current game round (enum of pre flop, flop, etc..).
        private int currentPlayerTurn;      //  Current player turn.
        private int currentPlayerOptions;   //  Current player's options.
        private int playerRoundStart;       //  Which player should start in the next round.
        private int turnCount;              //  Turn count, used to determine if a new round needs to start.
        private int numOfPlayers;           //  Number of players in the game.
        private int playersInGame;
        private List<Card> dealerHand;      //  The dealer's hand.
        private decimal currentPot;         //  Current game pot.
        private decimal currentBet;         //  Current round bet.
        public event NewTurnHandler newTurnEvent;    //  New turn event
        public event NewRoundHandler newRoundEvent;  //  New round event
        public event NewBetHandler newBetEvent;      //  New bet event.
        public event WinnerHandler winnerEvent;      //  Winner event.

        public List<Player> Players {
            get {
                return players;
            }
        }

        public int CurrentPlayerTurn {
            get {
                return currentPlayerTurn;
            }
        }

        public List<Card> DealerHand {
            get {
                return dealerHand;
            }
        }

        public decimal CurrentPot {
            get {
                return currentPot;
            }
            set {
                currentPot = value;
            }
        }

        public int CurrentPlayerOptions {
            get {
                return currentPlayerOptions;
            }
        }

        public int NumOfPlayers {
            get {
                return numOfPlayers;
            }
        }

        //  A player form calls this function when a player has finished his turn.
        public void endTurn(int playerId, int buttonChosen, decimal bet) {
            switch (buttonChosen) {
                case (int)PlayerForm.PokerButton.Call:
                    players[playerId - 1].Bet = bet;
                    newBetEvent(this, new NewBetEventArgs(playerId, bet));
                    break;
                case (int)PlayerForm.PokerButton.Check:
                    break;
                case (int)PlayerForm.PokerButton.Fold:
                    players[playerId - 1].InGame = false;
                    players[playerId - 1].Folded = true;
                    playersInGame--;
                    turnCount--;
                    break;
                case (int)PlayerForm.PokerButton.Raise:
                    currentBet = bet;
                    players[playerId - 1].Bet = bet;
                    newBetEvent(this, new NewBetEventArgs(playerId, bet));
                    currentPlayerOptions = (int)PlayerForm.Options.Call;
                    turnCount = 0;
                    break;
            }
            if (calcNextTurn())
                startTurn();
            else
                startRound();
        }

        //  Runs when a new game starts.
        public void startGame(bool newGame) {
            currentDeck = new Deck();
            currentDeck.Shuffle();
            if (newGame) {
                numOfPlayers = Properties.Settings.Default.NumOfPlayers;
                players = new List<Player>(numOfPlayers);
                for (int i = 0; i < numOfPlayers; i++) {
                    Player player = new Player(i + 1, currentDeck);
                    players.Add(player);
                }
                dealerHand = new List<Card>(POKER_NUM_OF_CARDS);
                for (int i = 0; i < POKER_NUM_OF_CARDS; i++)
                    dealerHand.Add(currentDeck.Draw());
            }
            else {
                foreach (Player p in players)
                    p.updateDeck(currentDeck);
                dealerHand.Clear();
                for (int i = 0; i < POKER_NUM_OF_CARDS; i++)
                    dealerHand.Add(currentDeck.Draw());
            }
            gameRound = GameRound.Preflop;
            playerRoundStart = 1;
            playersInGame = numOfPlayers;
            currentPot = 0;
            setupPlayers();
            startRound();
        }

        //  Setup players' ingame and folded status.
        private void setupPlayers() {
            for (int i = 0; i < numOfPlayers; i++) {
                players[i].InGame = true;
                players[i].Folded = false;
            }
        }

        //  Runs when a new round starts.
        private void startRound() {
            if (gameRound != GameRound.End) {
                if (currentBet != 0)
                    deductBets();
                if (playersInGame <= 1) {
                    checkWinner();
                    startGame(false);
                }
                currentPlayerTurn = playerRoundStart;
                currentBet = 0;
                turnCount = 0;
                currentPlayerOptions = (int)PlayerForm.Options.Check;
                newRoundEvent(this, new NewRoundEventArgs(gameRound, dealerHand, players));
                startTurn();
            }
            else {
                checkWinner();
                startGame(false);
            }
        }

        //  Checks which player won the round.
        private void checkWinner() {
            int winner = 0, bestHand = -1, highCard = 0;
            foreach (Player p in players) {
                if (!p.Folded) {
                    PokerHandEvaluator evaluator = new PokerHandEvaluator(p.PlayerHand, dealerHand);
                    if (bestHand < (int)evaluator.Value) {
                        winner = p.PlayerId;
                        bestHand = (int)evaluator.Value;
                        highCard = evaluator.SubValue;
                    }
                    else if (bestHand == (int)evaluator.Value) {
                        if (highCard < evaluator.SubValue) {
                            highCard = evaluator.SubValue;
                            winner = p.PlayerId;
                        }
                    }
                }
            }
            players[winner - 1].Balance += CurrentPot;
            winnerEvent(this, players[winner-1].Name);
        }

        //  Called when a new turn starts.
        private void startTurn() {
            newTurnEvent(this, new NewTurnEventArgs(currentPlayerTurn, currentPlayerOptions, currentPot, currentBet));
        }

        //  Calculates current turn, returns true if game should continue to next turn, otherwise (if its a new round), returns false.
        private bool calcNextTurn() {
            currentPlayerTurn = determineNextPlayer(currentPlayerTurn);
            turnCount++;
            if (turnCount == playersInGame) {
                gameRound++;
                playerRoundStart = determineNextPlayer(playerRoundStart);
                return false;
            }
            return true;
        }

        //  Calculates which player should start in this round.
        private int determineNextPlayer(int turn) {
            bool foldedPlayer = true;       //  Boolean variable to check if current turn's player hasn't folded.
            while (foldedPlayer) {
                if (turn == numOfPlayers)
                turn = 1;
            else
                turn++;
            if (!players[turn - 1].Folded)
                foldedPlayer = false;
            }
            return turn;
        }

        //  Deducts bets from every player that made a bet, in the end of a round.
        private void deductBets() {
            decimal totalBets = 0;
            for (int i = 0; i < numOfPlayers; i++) {
                totalBets += players[i].Bet;
                players[i].Balance -= players[i].Bet;
                players[i].Bet = 0;
            }
            currentPot += totalBets;
        }
    }
}
