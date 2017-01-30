using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHW.CardGameFramework;

namespace PokerHW.Poker {
    public class Player {

        public enum PlayerCardSettings {          //  Represents the index of the first and second hand,
            FirstCard, SecondCard, MaxCardsInHand      //  and the maximum number of cards in a player's hand.
        }

        private int playerId;
        private decimal balance;
        private string name;
        private string image;
        private Deck currentDeck;
        private List<Card> playerHand;

        public string Image {
            get {
                return image;
            }
        }

        public string Name {
            get {
                return name;
            }
        }

        public decimal Balance {
            get {
                return balance;
            }
            set {
                balance = value;
            }
        }

        public List<Card> PlayerHand {
            get {
                return playerHand;
            }
        }

        public bool InGame {
            get; set;
        }

        public decimal Bet {
            get; set;
        }

        public bool Folded {
            get; set;
        }

        public int PlayerId {
           get {
                return playerId;
            }
        }

        public Player(int playerId, Deck currentDeck) {
            this.playerId = playerId;
            this.currentDeck = currentDeck;
            this.balance = Properties.Settings.Default.InitialBalance;
            switch (playerId) {
                case 1:
                    this.name = Properties.Settings.Default.Player1Name;
                    this.image = Properties.Settings.Default.Player1Image;
                    break;
                case 2:
                    this.name = Properties.Settings.Default.Player2Name;
                    this.image = Properties.Settings.Default.Player2Image;
                    break;
                case 3:
                    this.name = Properties.Settings.Default.Player3Name;
                    this.image = Properties.Settings.Default.Player3Image;
                    break;
            }
            playerHand = new List<Card>((int)PlayerCardSettings.MaxCardsInHand);
            playerHand.Add(currentDeck.Draw());
            playerHand.Add(currentDeck.Draw());
        }

        public void updateDeck(Deck currentDeck) {
            this.currentDeck = currentDeck;
            playerHand.Clear();
            playerHand.Add(currentDeck.Draw());
            playerHand.Add(currentDeck.Draw());
        }
    }
}
