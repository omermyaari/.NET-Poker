using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHW.CardGameFramework;

namespace PokerHW.Poker {
    public class NewRoundEventArgs : EventArgs {
        public NewRoundEventArgs(GameRound Round, List<Card> DealerHand, List<Player> Players) {
            this.Round = Round;
            this.DealerHand = DealerHand;
            this.Players = Players;
        }

        public GameRound Round {
            get;
        }

        public List<Card> DealerHand {
            get;
        }

        public List<Player> Players {
            get;
        }
    }
}
