using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHW.Poker {
    public class NewBetEventArgs : EventArgs {
        public NewBetEventArgs(int PlayerId, decimal Bet) {
            this.PlayerId = PlayerId;
            this.Bet = Bet;
        }

        public int PlayerId {
            get;
        }

        public decimal Bet {
            get;
        }
    }
}
