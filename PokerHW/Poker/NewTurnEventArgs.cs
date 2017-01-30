using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHW.Poker {
    public class NewTurnEventArgs : EventArgs {
        public NewTurnEventArgs(int CurrentPlayerTurn, int CurrentPlayerOptions, decimal Pot, decimal Bet) {
            this.CurrentPlayerTurn = CurrentPlayerTurn;
            this.CurrentPlayerOptions = CurrentPlayerOptions;
            this.Pot = Pot;
            this.Bet = Bet;
        }

        public int CurrentPlayerTurn {
            get;
        }

        public int CurrentPlayerOptions {
            get;
        }

        public decimal Pot {
            get;
        }

        public decimal Bet {
            get;
        }
    }
}
