using System.Collections.Generic;
using PokerHW.CardGameFramework;

namespace PokerHW.Poker {
    public class PokerHandEvaluator {

        private List<Card> hand;        //  Cards hand, includes the player's 2 cards and the dealer's cards.

        public PokerHand Value {        //  Poker hand value (straight flush, flush, etc).
            get; set;
        }

        public int SubValue {           //  Poker hand sub value (highest pair value in a two pair, three of a kind value, etc).
            get; set;
        }


        public PokerHandEvaluator(List<Card> playerHand, List<Card> dealerHand) {
            hand = new List<Card>();
            foreach (Card c in playerHand)
                hand.Add(c);
            foreach (Card c in dealerHand)
                hand.Add(c);

            //  Sorts the hand number wise.
            hand.Sort(delegate (Card c1, Card c2) {
                return c1.FaceVal.CompareTo(c2.FaceVal);
            });
            evaluateHand();
        }

        //  Evaluates the given hand rank.
        private void evaluateHand() {

            if (isStraightFlush()) {
                Value = PokerHand.StraightFlush;
                return;
            }

            if (isFourOfAKind()) {
                Value = PokerHand.FourOfKind;
                return;
            }

            if (isFullHouse()) {
                Value = PokerHand.FullHouse;
                return;
            }

            if (isFlush()) {
                Value = PokerHand.Flush;
                return;
            }

            if (isStraight()) {
                Value = PokerHand.Straight;
                return;
            }

            if (isThreeOfAKind()) {
                Value = PokerHand.ThreeOfKind;
                return;
            }

            if (isTwoPair()) {
                Value = PokerHand.TwoPair;
                return;
            }

            if (isPair()) {
                Value = PokerHand.Pair;
                return;
            }

            findHighCard();
            Value = PokerHand.HighCard;
        }

        //  Checks what is the high card in the hand.
        private void findHighCard() {
            int highest = 0;
            foreach (Card c in hand) {
                if ((int)c.FaceVal > highest)
                    highest = (int)c.FaceVal;
            }
            SubValue = highest;
        }

        //  Checks if there's a pair in the hand.
        private bool isPair() {
            int highestPair = 0;
            for (int i = 0; i < hand.Count - 1; i++) {
                if (hand[i].FaceVal == hand[i + 1].FaceVal && (int)hand[i].FaceVal > highestPair)
                    highestPair = (int)hand[i].FaceVal;
            }
            if (highestPair > 0) {
                SubValue = highestPair;
                return true;
            }
            return false;
        }

        //  Checks if there's a two-pair in the hand.
        private bool isTwoPair() {
            int firstPair = 0;
            int secondPair = 0;
            for (int i = 0; i < hand.Count - 1; i++) {
                if (hand[i].FaceVal == hand[i + 1].FaceVal && firstPair == 0)
                    firstPair = (int)hand[i].FaceVal;
                else if (hand[i].FaceVal == hand[i + 1].FaceVal && firstPair != 0)
                    secondPair = (int)hand[i].FaceVal;
            }
            if (secondPair != 0) {
                SubValue = secondPair;
                return true;
            }
            return false;
        }

        //  Checks if there's a three of a kind in the hand.
        private bool isThreeOfAKind() {
            int highestThree = 0;
            for (int i = 0; i < hand.Count - 2; i++) {
                if (hand[i].FaceVal == hand[i + 1].FaceVal && hand[i + 1].FaceVal == hand[i + 2].FaceVal && (int)hand[i].FaceVal > highestThree)
                    highestThree = (int)hand[i].FaceVal;
            }
            if (highestThree != 0) {
                SubValue = highestThree;
                return true;
            }
            return false;
        }

        //  Checks if there's a straight in the hand.
        private bool isStraight() {
            for (int i = 0; i < hand.Count - 4; i++) {
                if (hand[i].FaceVal == hand[i + 1].FaceVal - 1 && hand[i + 1].FaceVal == hand[i + 2].FaceVal - 1 &&
                    hand[i + 2].FaceVal == hand[i + 3].FaceVal - 1 && hand[i + 3].FaceVal == hand[i + 4].FaceVal - 1) {
                    SubValue = (int)hand[i + 4].FaceVal;
                    return true;
                }
            }
            return false;
        }

        //  Checks if there's a flush in the hand.
        private bool isFlush() {
            int hearts = 0, diamonds = 0, spades = 0, clubs = 0;
            foreach (Card c in hand) {
                switch (c.Suit) {
                    case Suit.Hearts:
                        hearts++;
                        break;
                    case Suit.Diamonds:
                        diamonds++;
                        break;
                    case Suit.Spades:
                        spades++;
                        break;
                    case Suit.Clubs:
                        clubs++;
                        break;
                }
            }
            if (hearts == Card.CARD_HAND || diamonds == Card.CARD_HAND || spades == Card.CARD_HAND || clubs == Card.CARD_HAND) {
                if (hearts == Card.CARD_HAND) 
                    SubValue = (int)Suit.Hearts;
                if (diamonds == Card.CARD_HAND)
                    SubValue = (int)Suit.Diamonds;
                if (spades == Card.CARD_HAND)
                    SubValue = (int)Suit.Spades;
                if (clubs == Card.CARD_HAND)
                    SubValue = (int)Suit.Clubs;
                //  Since the cards are sorted (number wise), there's no need to go through all of them to find the "highest" card in the flush.
                for (int i = hand.Count-1; i > 3; i--) {
                    if ((int)hand[i].Suit == SubValue) {
                        SubValue = (int)hand[i].FaceVal;
                        return true;
                    }
                }
            }
            return false;       
        }

        //  Checks if there's a fullhouse in the hand.
        private bool isFullHouse() {
            for (int i = 0; i < hand.Count - 4; i++) {
                if (hand[i].FaceVal == hand[i + 1].FaceVal &&
                    hand[i + 2].FaceVal == hand[i + 3].FaceVal && hand[i + 3].FaceVal == hand[i + 4].FaceVal) {
                    SubValue = (int)hand[i + 2].FaceVal;
                    return true;
                }
                else if (hand[i].FaceVal == hand[i + 1].FaceVal && hand[i + 1].FaceVal == hand[i + 2].FaceVal &&
                    hand[i + 3].FaceVal == hand[i + 4].FaceVal) {
                    SubValue = (int)hand[i].FaceVal;
                    return true;
                }
            }
            return false;
        }

        //  Checks if there's a four of a kind in the hand.
        private bool isFourOfAKind() {
            for (int i = 0; i < hand.Count - 3; i++) {
                if (hand[i].FaceVal == hand[i + 1].FaceVal && hand[i + 1].FaceVal == hand[i + 2].FaceVal
                            && hand[i + 2].FaceVal == hand[i + 3].FaceVal) {
                    SubValue = (int)hand[i].FaceVal;
                    return true;
                }
            }
            return false;
        }

        //  Checks if there's a straight flush in the hand.
        private bool isStraightFlush() {
            for (int i = 0; i < hand.Count - 4; i++) {
                if (hand[i].FaceVal == hand[i + 1].FaceVal - 1 && hand[i + 1].FaceVal == hand[i + 2].FaceVal - 1 &&
                    hand[i + 2].FaceVal == hand[i + 3].FaceVal - 1 && hand[i + 3].FaceVal == hand[i + 4].FaceVal - 1) {
                    if (hand[i].Suit == hand[i + 1].Suit && hand[i + 1].Suit == hand[i + 2].Suit &&
                        hand[i + 2].Suit == hand[i + 3].Suit && hand[i + 3].Suit == hand[i + 4].Suit) {
                        SubValue = (int)hand[i + 4].FaceVal;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}