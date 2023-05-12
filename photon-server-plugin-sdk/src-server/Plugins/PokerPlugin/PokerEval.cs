using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlugin
{
    public class PlayerData
    {

        public string playerName;
        public int playerPosition;
        public int playerActorNo;

        public float Coins;

        public float CurrentBet;
        public float TotalBet;

        public EvalData completeEvalData;

        public float turnAmount;
        public bool isOutOfGame = false;
        public bool runOutOfMoney = false;
        public bool underAllin = false;
        public bool isObserver = false;

        public Card card1, card2;

        public Card card3data, card4data;

        public bool turnComplete;

        PlayerRole playerRole;
        //public int coeffCardsValOnFlopPhase = 0;
        //public int maxCardValOnFlopPhase = 0;
        //public int maxCardValueOnShowDown = 0;



    }
    public class CardData { public int suit; public int rank; }

    public enum SUIT { NULL = 0, HEARTS = 1, DIAMONDS = 2, CLUBS = 3, SPADES = 4 }
    public enum VALUE { NULL = 0, ACE = 1, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING }
    public struct Card
    {
        public int suit { get; private set; }
        public int rank { get; private set; }

        public Card(int s, int r)
        {
            this.suit = s;
            this.rank = r;
            this.Suit = (SUIT)s;
            this.Value = (VALUE)r;

            cardData = new CardData();
            cardData.suit = this.suit;
            cardData.rank = this.rank;
        }
        public Card(SUIT s, VALUE v)
        {
            this.suit = (int)s;
            this.rank = (int)v;
            this.Suit = s;
            this.Value = v;

            cardData = new CardData();
            cardData.suit = this.suit;
            cardData.rank = this.rank;
        }
        public void SetCardData(int s, int r)
        {
            this.suit = s;
            this.rank = r;
            this.Suit = (SUIT)s;
            this.Value = (VALUE)r;

            cardData = new CardData();
            cardData.suit = this.suit;
            cardData.rank = this.rank;
        }
        public void SetCardData(SUIT s, VALUE v)
        {
            this.suit = (int)s;
            this.rank = (int)v;
            this.Suit = s;
            this.Value = v;

            cardData = new CardData();
            cardData.suit = this.suit;
            cardData.rank = this.rank;

        }



        //SUIT _suit;
        public SUIT Suit { get; private set; }
        //VALUE _value;
        public VALUE Value { get; private set; }

        public static Card nullCard
        {
            get { return new Card(0, 0); }
        }
        public CardData cardData;
        //public int rank { get => (int)Value; }
        public override string ToString()
        {
            return string.Format("[{0}, {1}]", (SUIT)suit, rank);
        }

        public static bool operator ==(Card a, Card b)
        {

            return a.suit == b.suit && a.rank == b.rank;
        }

        public static bool operator !=(Card a, Card b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Card))
                return false;

            Card other = (Card)obj;
            return this == other;
        }

        public override int GetHashCode()
        {
            return suit.GetHashCode() ^ rank.GetHashCode();
        }


    }

    public enum CardsResultValues { RoyalFlush, StraightFlush, FourOfAkind, FullHouse, Flush, Straight, ThreeOfAkind, TwoPair, Pair, HighCard, Null }
    public class EvalData
    {
        public bool wonHand = false;
        public Card playerCard_1;
        public Card playerCard_2;
        public Card[] flopCards = new Card[3];
        public Card turnCard;
        public Card riverCard;
        public int kikers = 0;
        public int maxCardValue = 0;
        public int playerIdx;
        public CardsResultValues cardsResultValues;

        public Card FullHighCards = Card.nullCard;

        public List<int> FlushOrderedCardsValue = new List<int>();
        public List<int> TrisOthersCards = new List<int>();
        public Card TwoPairHighCards = Card.nullCard;
        public int TwoPairFifthCard = 0;
        public List<int> PairOthersBestCards = new List<int>();
        public int PairValue = 0;
        public int HighCardValue;
        public List<int> HighCardOthersBestCards = new List<int>();
        public List<int> bestFive = new List<int>();
    }
    public class PokerEval
    {
        public string ResultText;

        public EvalData EvaluatePlayerRanks(PlayerData playerData, List<Card> tableCards)
        {
            EvalData data = new EvalData();
            EvalData dataOut = new EvalData();
            data.playerCard_1 = playerData.card1;
            data.playerCard_2 = playerData.card2;
            data.flopCards[0] = tableCards[0];
            data.flopCards[1] = tableCards[1];
            data.flopCards[2] = tableCards[2];
            data.turnCard = tableCards[3];
            data.riverCard = tableCards[4];
            getPlayerCardsResult(playerData.playerPosition, data, out dataOut);
            return dataOut;
        }
        public List<PlayerData> FindPokerPotWinners(List<PlayerData> PlayerList)
        {
            int bestResult = 10;
            for (int x = 0; x < PlayerList.Count; x++)
            {
                //Debug.Log("-----------------------------------------------");
                //Debug.Log("++++++++++ Result idx : " + PlayerList[x].playerData.playerPosition);
                //Debug.Log("++++ Result idx : " + PlayerList[x].playerData.playerPosition + "++++++ Result result : " + PlayerList[x].playerData.completeEvalData.cardsResultValues);
                //TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] cardsResultValues : " + pdList[x].completeResultStruct.cardsResultValues + "\n";
                string bestFive = "";
                foreach (int i in PlayerList[x].completeEvalData.bestFive)
                {
                    bestFive = bestFive + i + " : ";
                }
                //Debug.Log(PlayerList[x].PlayerName + "- bestfive:" + bestFive);
                // TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] bestFive : " + bestFive + " kiker :" + pdList[x].completeResultStruct.kikers.ToString() + "\n";
                //Debug.Log("-----------------------------------------------");
                if ((int)PlayerList[x].completeEvalData.cardsResultValues < bestResult) bestResult = (int)PlayerList[x].completeEvalData.cardsResultValues;
            }

            //Debug.Log("bestResult : " + (CardsResultValues)bestResult);

            List<PlayerData> pdWinnerList = new List<PlayerData>();

            for (int x = 0; x < PlayerList.Count; x++)
            {
                if (PlayerList[x].completeEvalData.cardsResultValues == (CardsResultValues)bestResult)
                {
                    pdWinnerList.Add(PlayerList[x]);
                }
            }
            List<PlayerData> finalWinners = new List<PlayerData>();
            //Debug.Log("pdWinnerList Count : " + pdWinnerList.Count);
            for (int x = 0; x < pdWinnerList.Count; x++)
            {
                //TextResult.text = TextResult.text + "Winner : " + pdWinnerList[x].playerPosition + " result : " + pdWinnerList[x].completeResultStruct.cardsResultValues + "\n";
                //Debug.Log("Winner : " + pdWinnerList[x].playerName + " result : " + pdWinnerList[x].completeEvalData.cardsResultValues + "\n");
                finalWinners.Add(pdWinnerList[x]);
            }


            string winnersResult = "";
            if (pdWinnerList.Count > 1)
            {
                finalWinners.Clear();
                winnersResult = "";
                switch ((CardsResultValues)bestResult)
                {
                    case CardsResultValues.HighCard:
                        finalWinners = getWinnerCheck_HighCard(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                        }
                        break;
                    case CardsResultValues.Pair:
                        finalWinners = getWinnerCheck_Pair(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                        }
                        break;
                    case CardsResultValues.TwoPair:
                        finalWinners = getWinnerCheck_TwoPair(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                        }
                        break;
                    case CardsResultValues.ThreeOfAkind:
                        finalWinners = getWinnerCheck_Tris(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                        }
                        break;
                    case CardsResultValues.Straight:
                        finalWinners = getWinnerCheck_Straight(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                        }
                        break;
                    case CardsResultValues.Flush:
                        finalWinners = getWinnerCheck_Flush(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                        }
                        break;
                    case CardsResultValues.FullHouse:
                        finalWinners = getWinnerCheck_FullHouse(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                        }
                        break;
                    case CardsResultValues.FourOfAkind:
                        finalWinners = getWinnerCheck_FourOfKind(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                        }
                        break;
                    case CardsResultValues.StraightFlush:
                        finalWinners = getWinner_StraightFlush(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                        }
                        break;
                }
            }
            string playersWinners = "";
            foreach (var player in finalWinners)
                playersWinners += player.playerName + ".. ";
            if (finalWinners.Count == 1)
                ResultText = "Winner Player : " + playersWinners;
            else
            {

                //Debug.Log(player.PlayerName);
                //Debug.Log("Draw!, Split pot with");
                ResultText = "Draw!, Split pot with " + playersWinners;
                //isDraw = true;
            }
            //Debug.Log(winnersResult);
            return finalWinners;
        }


        public void getPlayerCardsResult(int playerId, EvalData completeResultStructIN, out EvalData completeResultStructOUT)
        {

            completeResultStructOUT = null;

            if (check_RoyalFlush(completeResultStructIN)) { completeResultStructIN.cardsResultValues = CardsResultValues.RoyalFlush; completeResultStructIN.playerIdx = playerId; completeResultStructOUT = completeResultStructIN; return; }
            if (check_StraightFlush(completeResultStructIN)) { completeResultStructIN.cardsResultValues = CardsResultValues.StraightFlush; completeResultStructIN.playerIdx = playerId; completeResultStructOUT = completeResultStructIN; return; }
            if (check_FourOfAkind(completeResultStructIN)) { completeResultStructIN.cardsResultValues = CardsResultValues.FourOfAkind; completeResultStructIN.playerIdx = playerId; completeResultStructOUT = completeResultStructIN; return; }
            if (check_Full(completeResultStructIN)) { completeResultStructIN.cardsResultValues = CardsResultValues.FullHouse; completeResultStructIN.playerIdx = playerId; completeResultStructOUT = completeResultStructIN; return; }
            if (check_flush(completeResultStructIN)) { completeResultStructIN.cardsResultValues = CardsResultValues.Flush; completeResultStructIN.playerIdx = playerId; completeResultStructOUT = completeResultStructIN; return; }
            if (check_straight(completeResultStructIN)) { completeResultStructIN.cardsResultValues = CardsResultValues.Straight; completeResultStructIN.playerIdx = playerId; completeResultStructOUT = completeResultStructIN; return; }
            if (check_tris(completeResultStructIN)) { completeResultStructIN.cardsResultValues = CardsResultValues.ThreeOfAkind; completeResultStructIN.playerIdx = playerId; completeResultStructOUT = completeResultStructIN; return; }
            if (check_TwoPair(completeResultStructIN)) { completeResultStructIN.cardsResultValues = CardsResultValues.TwoPair; completeResultStructIN.playerIdx = playerId; completeResultStructOUT = completeResultStructIN; return; }
            if (check_Pair(completeResultStructIN)) { completeResultStructIN.cardsResultValues = CardsResultValues.Pair; completeResultStructIN.playerIdx = playerId; completeResultStructOUT = completeResultStructIN; return; }
            if (check_HighCard(completeResultStructIN)) { completeResultStructIN.cardsResultValues = CardsResultValues.HighCard; completeResultStructIN.playerIdx = playerId; completeResultStructOUT = completeResultStructIN; return; }



        }


        bool check_RoyalFlush(EvalData data)
        {
            bool tmpRet = false;
            int seme = 0;
            if (justCheck_Flush(data, out seme) == false)
            {
                return tmpRet;
            }

            //Debug.Log("chech_RoyalFlush semeValue : " + seme);

            List<Card> allCards = getAllCardsData(data);
            List<Card> flushCards = new List<Card>();

            foreach (Card v in allCards) if (v.suit == seme) flushCards.Add(v);

            int toCheckPoint = 10;
            Card res = Card.nullCard;
            for (int x = 0; x < flushCards.Count; x++)
            {
                switch (x)
                {
                    case 0: res = flushCards.Find(item => item.rank == toCheckPoint); if (res.rank == 0) return tmpRet; break;
                    case 1: toCheckPoint = 11; res = flushCards.Find(item => item.rank == toCheckPoint); if (res.rank == 0) return tmpRet; break;
                    case 2: toCheckPoint = 12; res = flushCards.Find(item => item.rank == toCheckPoint); if (res.rank == 0) return tmpRet; break;
                    case 3: toCheckPoint = 13; res = flushCards.Find(item => item.rank == toCheckPoint); if (res.rank == 0) return tmpRet; break;
                    case 4: toCheckPoint = 1; res = flushCards.Find(item => item.rank == toCheckPoint); if (res.rank == 0) return tmpRet; break;
                }
            }
            tmpRet = true;
            data.bestFive.Add(10); data.bestFive.Add(11); data.bestFive.Add(12); data.bestFive.Add(13); data.bestFive.Add(1);
            data.kikers = getKiker(flushCards, data.playerCard_1, data.playerCard_2);
            //Debug.Log("chech_RoyalFlush toCheckPoint : " + toCheckPoint + " : " + res);
            return tmpRet;
        }

        bool check_StraightFlush(EvalData data)
        {
            bool tmpRet = false;

            int aceLoc = -1;
            Dictionary<int, int> tempDict = new Dictionary<int, int>() { { 10, 10 }, { 11, 11 }, { 12, 12 }, { 13, 13 } };
            List<Card> allCards = getAllCardsData(data);
            for (int i = 0; i < allCards.Count; i++)
            {
                if (allCards[i].rank == 1)
                {
                    //allCards[i] = new Card(allCards[i].suit, 14);
                    aceLoc = i;
                }
                if (tempDict.ContainsKey(allCards[i].rank))
                {
                    tempDict.Remove(allCards[i].rank);
                }
            }
            if (aceLoc != -1)
            {
                if (tempDict.Count == 0)
                    allCards[aceLoc] = new Card(allCards[aceLoc].suit, 14);
            }

            //List<Card> allCards = getAllCardsData(data);
            List<int> allCardsInt = new List<int>();
            foreach (Card v in allCards) { allCardsInt.Add((int)v.rank); }
            Card _res = Card.nullCard;
            List<int> tmpListOfFiveSequence = new List<int>();
            List<Card> carscheck = new List<Card>();
            foreach (int i in allCardsInt)
            {
                //_res = BBStaticData.newGetSequenceForNumer(i, allCardsInt);
                _res = newGetSequenceForNumer(i, allCardsInt);
                //Debug.Log("check_flush -> : " + _res);
                if (_res.suit >= 5)
                {
                    tmpListOfFiveSequence.Add((int)_res.rank);
                    carscheck.Add(_res);
                }
            }

            //foreach(int v in tmpListOfFiveSequence) Debug.Log("check_flush tmpListOfFiveSequence -> : " + v);

            if (tmpListOfFiveSequence.Count > 0)
            {
                carscheck.OrderByDescending(x => x.rank);
                tmpListOfFiveSequence.Sort();
                tmpListOfFiveSequence.Reverse();
                data.maxCardValue = tmpListOfFiveSequence[0];
                data.bestFive.Add(tmpListOfFiveSequence[0]); data.bestFive.Add(tmpListOfFiveSequence[0] - 1); data.bestFive.Add(tmpListOfFiveSequence[0] - 2); data.bestFive.Add(tmpListOfFiveSequence[0] - 3); data.bestFive.Add(tmpListOfFiveSequence[0] - 4);

                tmpRet = true;
            }

            if (!tmpRet) return tmpRet;


            //List<Card> allCards = getAllCardsData(data);
            int suitest = (int)carscheck[0].suit;

            for (int x = 0; x < 5; x++)
            {
                //Debug.Log("chech_RoyalFlush : " + allCards[x] + " : " + s);
                if (carscheck[x].suit != suitest)
                {
                    tmpRet = false;
                }
            }


            return tmpRet;

        }
        public static Card newGetSequenceForNumer(int toCheck, List<int> numberList)
        {

            //Debug.Log("============================================1===================getSequenceForNumer===================================--> toCheck : " + toCheck);

            if (toCheck > 10) return new Card(0, 0);

            int checkForStarting = toCheck;
            int result = 0;
            int counter = 0;
            int maxVal = 0;

            for (int x = 0; x < numberList.Count; x++)
            {
                result = numberList.Find(item => item == checkForStarting);
                //   Debug.Log("============================================1===================getSequenceForNumer===================================--> result : " + result + " checkForStarting : " + checkForStarting + " counter : " + counter);

                checkForStarting++;

                if (result != 0)
                {
                    counter++;
                    maxVal = result;
                }
                else
                {
                    break;
                }
                //Debug.Log("-2-> result : " + result + " checkForStarting : " + checkForStarting + " counter : " + counter);
            }
            return new Card(counter, maxVal);
        }

        bool check_FourOfAkind(EvalData data)
        {
            bool tmpret = false;

            List<Card> allCards = getAllCardsData(data);

            for (int i = 0; i < allCards.Count; i++)
            {
                if (allCards[i].rank == 1)
                {
                    allCards[i] = new Card(allCards[i].suit, 14);
                }
            }

            int counter = 0;
            bool gotFourKind = false;
            int maxCardValue = 0;
            List<Card> pokerList = new List<Card>();

            for (int x = 0; x < allCards.Count; x++)
            {
                pokerList.Clear();
                for (int y = 0; y < allCards.Count; y++)
                {
                    if (allCards[x].rank == allCards[y].rank)
                    {
                        counter++;
                        pokerList.Add(allCards[y]);
                        if (counter == 4)
                        {
                            gotFourKind = true;
                            maxCardValue = (int)allCards[y].rank;
                            break;
                        }
                    }
                }
                if (gotFourKind)
                {
                    break;
                }
                counter = 0;
            }

            List<int> othersCard = new List<int>();
            foreach (Card v in allCards)
            {
                if (v.rank != (float)maxCardValue)
                {
                    othersCard.Add((int)v.rank);
                }
            }

            othersCard.Sort();
            othersCard.Reverse();

            if (gotFourKind)
            {
                tmpret = true;
                data.maxCardValue = maxCardValue;
                data.kikers = getKiker(pokerList, data.playerCard_1, data.playerCard_2);
                //Debug.Log("+++++++++++++++++++poker : " + maxCardValue + " : " + othersCard[0]);

                data.bestFive.Add(maxCardValue); data.bestFive.Add(maxCardValue); data.bestFive.Add(maxCardValue); data.bestFive.Add(maxCardValue); data.bestFive.Add(othersCard[0]);
            }

            return tmpret;
        }

        bool check_Full(EvalData data)
        {
            List<Card> allCards = getAllCardsData(data);
            List<Card> allCardsToRemove = allCards;
            bool tmpRet = false;

            int counter = 0;
            bool gotTris = false;
            bool gotPair = false;
            int maxCardValueTris = 0;
            int maxCardValuePair = 0;

            for (int x = 0; x < allCards.Count; x++)
            {
                for (int y = 0; y < allCards.Count; y++)
                {
                    if (allCards[x].rank == allCards[y].rank)
                    {
                        counter++;
                        if (counter == 3)
                        {
                            gotTris = true;
                            maxCardValueTris = (int)allCards[y].rank;
                            break;
                        }
                    }
                }
                if (gotTris)
                {
                    break;
                }
                counter = 0;
            }

            if (gotTris)
            {
                for (int x = 0; x < allCardsToRemove.Count; x++)
                {
                    if (allCardsToRemove[x].rank == maxCardValueTris)
                    {
                        allCardsToRemove.Remove(allCardsToRemove[x]);
                    }
                }

                for (int x = 0; x < allCardsToRemove.Count; x++)
                {
                    for (int y = 0; y < allCardsToRemove.Count; y++)
                    {
                        if (allCardsToRemove[x].rank == allCardsToRemove[y].rank)
                        {
                            counter++;
                            if (counter == 2)
                            {
                                gotPair = true;
                                maxCardValuePair = (int)allCardsToRemove[y].rank;
                                break;
                            }
                        }
                    }
                    if (gotPair)
                    {
                        break;
                    }
                    counter = 0;
                }

                if (gotPair)
                {
                    tmpRet = true;
                    //data.FullHighCards.suit = maxCardValueTris;
                    //data.FullHighCards.rank = maxCardValuePair;
                    data.FullHighCards.SetCardData(maxCardValueTris, maxCardValuePair);
                    data.bestFive.Add(maxCardValueTris); data.bestFive.Add(maxCardValueTris); data.bestFive.Add(maxCardValueTris); data.bestFive.Add(maxCardValuePair); data.bestFive.Add(maxCardValuePair);
                }

            }
            else
            {
                tmpRet = false;
            }

            return tmpRet;

        }

        bool check_flush(EvalData data)
        {
            bool tmpRet = false;
            int seme;
            if (justCheck_Flush(data, out seme))
            {
                List<Card> allCards = getAllCardsData(data);
                List<int> flushCardsInt = new List<int>();
                foreach (Card v in allCards)
                {
                    if (v.suit == seme)
                    {
                        flushCardsInt.Add((int)v.rank);
                    }
                }

                for (int x = 0; x < flushCardsInt.Count; x++)
                {
                    if (flushCardsInt[x] == 1) flushCardsInt[x] = 14;
                }

                flushCardsInt.Sort();
                flushCardsInt.Reverse();
                data.maxCardValue = flushCardsInt[0];
                data.FlushOrderedCardsValue = flushCardsInt;
                tmpRet = true;
                data.bestFive.Clear();
                for (int x = 0; x < 5; x++)
                {
                    data.bestFive.Add(flushCardsInt[x]);
                }
            }
            return tmpRet;
        }

        bool check_straight(EvalData data)
        {
            bool tmpRet = false;

            int aceLoc = -1;
            Dictionary<int, int> tempDict = new Dictionary<int, int>() { { 10, 10 }, { 11, 11 }, { 12, 12 }, { 13, 13 } };
            List<Card> allCards = getAllCardsData(data);
            for (int i = 0; i < allCards.Count; i++)
            {
                if (allCards[i].rank == 1)
                {
                    //allCards[i] = new Card(allCards[i].suit, 14);
                    aceLoc = i;
                }
                if (tempDict.ContainsKey(allCards[i].rank))
                {
                    tempDict.Remove(allCards[i].rank);
                }
            }
            if (aceLoc != -1)
            {
                if (tempDict.Count == 0)
                    allCards[aceLoc] = new Card(allCards[aceLoc].suit, 14);
            }

            //List<Card> allCards = getAllCardsData(data);
            List<int> allCardsInt = new List<int>();
            foreach (Card v in allCards) { allCardsInt.Add((int)v.rank); }
            Card _res = Card.nullCard;
            List<int> tmpListOfFiveSequence = new List<int>();
            foreach (int i in allCardsInt)
            {
                //_res = BBStaticData.newGetSequenceForNumer(i, allCardsInt);
                _res = newGetSequenceForNumer(i, allCardsInt);
                //Debug.Log("check_flush -> : " + _res);
                if (_res.suit >= 5)
                {
                    tmpListOfFiveSequence.Add((int)_res.rank);
                }
            }

            //foreach(int v in tmpListOfFiveSequence) Debug.Log("check_flush tmpListOfFiveSequence -> : " + v);

            if (tmpListOfFiveSequence.Count > 0)
            {
                tmpListOfFiveSequence.Sort();
                tmpListOfFiveSequence.Reverse();
                data.maxCardValue = tmpListOfFiveSequence[0];
                data.bestFive.Add(tmpListOfFiveSequence[0]); data.bestFive.Add(tmpListOfFiveSequence[0] - 1); data.bestFive.Add(tmpListOfFiveSequence[0] - 2); data.bestFive.Add(tmpListOfFiveSequence[0] - 3); data.bestFive.Add(tmpListOfFiveSequence[0] - 4);
                tmpRet = true;
            }

            return tmpRet;
        }

        bool check_tris(EvalData data)
        {
            bool tmpRet = false;
            List<Card> allCards = getAllCardsData(data);

            for (int i = 0; i < allCards.Count; i++)
            {
                if (allCards[i].rank == 1)
                {
                    allCards[i] = new Card(allCards[i].suit, 14);
                }
            }

            int counter = 0;
            // bool gotTris = false;
            //int maxCardValueTris = 0;
            List<int> tmpListOfTris = new List<int>();

            for (int x = 0; x < allCards.Count; x++)
            {
                for (int y = 0; y < allCards.Count; y++)
                {
                    if (allCards[x].rank == allCards[y].rank)
                    {
                        counter++;
                        if (counter == 3)
                        {
                            tmpListOfTris.Add((int)allCards[y].rank);
                            counter = 0;
                            continue;
                        }
                    }
                }
                counter = 0;
            }

            if (tmpListOfTris.Count > 0)
            {
                tmpListOfTris.Sort();
                tmpListOfTris.Reverse();
                data.maxCardValue = tmpListOfTris[0];

                List<int> otherList = new List<int>();
                for (int x = 0; x < allCards.Count; x++)
                {
                    if ((int)allCards[x].rank != tmpListOfTris[0])
                    {
                        otherList.Add((int)allCards[x].rank);
                    }
                }
                otherList.Sort();
                otherList.Reverse();
                data.TrisOthersCards = otherList;
                tmpRet = true;
                data.bestFive.Add(tmpListOfTris[0]); data.bestFive.Add(tmpListOfTris[1]); data.bestFive.Add(tmpListOfTris[2]); data.bestFive.Add(otherList[0]); data.bestFive.Add(otherList[1]);
            }

            return tmpRet;


        }

        bool check_TwoPair(EvalData data)
        {
            bool tmpRet = false;
            List<Card> allCards = getAllCardsData(data);

            for (int i = 0; i < allCards.Count; i++)
            {
                if (allCards[i].rank == 1)
                {
                    allCards[i] = new Card(allCards[i].suit, 14);
                }
            }

            int counter = 0;
            List<Card> tmpListOfPair = new List<Card>();

            for (int x = 0; x < allCards.Count; x++)
            {
                for (int y = 0; y < allCards.Count; y++)
                {
                    if (allCards[x].rank == allCards[y].rank)
                    {
                        counter++;
                        if (counter == 2)
                        {
                            Card _res = tmpListOfPair.Find(item => item == allCards[y]);
                            if (_res == Card.nullCard) tmpListOfPair.Add(allCards[y]);
                            counter = 0;
                            continue;
                        }
                    }
                }
                counter = 0;
            }

            //foreach(CardStruct v in tmpListOfPair)
            //Debug.Log(data.playerIdx + " : ***** 1 *** TwoPairHighCards -> tmpListOfPair : " + v);

            if (tmpListOfPair.Count > 1)
            {
                List<int> bestTwoPair = new List<int>();
                for (int x = 0; x < tmpListOfPair.Count; x++)
                {
                    //Debug.Log("tmpListOfPair -> : " + tmpListOfPair[x]);
                    bestTwoPair.Add((int)tmpListOfPair[x].rank);
                }
                bestTwoPair.Sort();
                bestTwoPair.Reverse();
                data.TwoPairHighCards = new Card((int)bestTwoPair[0], (int)bestTwoPair[1]);
                //Debug.Log("******** TwoPairHighCards -> : " + data.TwoPairHighCards);
                data.maxCardValue = bestTwoPair[0];
                List<Card> listForKiker = new List<Card>();
                for (int x = 0; x < allCards.Count; x++)
                {
                    if (allCards[x].rank == (float)bestTwoPair[0] || allCards[x].rank == (float)bestTwoPair[1])
                    {
                        listForKiker.Add(allCards[x]);
                    }
                }
                data.kikers = getKiker(listForKiker, data.playerCard_1, data.playerCard_2);
                List<int> otherCardList = new List<int>();
                for (int x = 0; x < allCards.Count; x++)
                {
                    if (allCards[x].rank == (float)bestTwoPair[0] || allCards[x].rank == (float)bestTwoPair[1])
                    {
                    }
                    else
                    {
                        otherCardList.Add((int)allCards[x].rank);
                    }
                }
                otherCardList.Sort();
                otherCardList.Reverse();
                data.TwoPairFifthCard = otherCardList[0];
                data.bestFive.Add((int)data.TwoPairHighCards.suit); data.bestFive.Add((int)data.TwoPairHighCards.suit); data.bestFive.Add((int)data.TwoPairHighCards.rank); data.bestFive.Add((int)data.TwoPairHighCards.rank); data.bestFive.Add(otherCardList[0]);
                tmpRet = true;
            }

            return tmpRet;
        }

        bool check_Pair(EvalData data)
        {

            bool tmpRet = false;
            List<Card> allCards = getAllCardsData(data);

            for (int i = 0; i < allCards.Count; i++)
            {
                if (allCards[i].rank == 1)
                {
                    allCards[i] = new Card(allCards[i].suit, 14);
                }
            }

            int counter = 0;
            List<int> otherCards = new List<int>();
            List<Card> forKiker = new List<Card>();

            int pairCard = 0;

            for (int x = 0; x < allCards.Count; x++)
            {
                for (int y = 0; y < allCards.Count; y++)
                {
                    if (allCards[x].rank == allCards[y].rank)
                    {
                        counter++;
                        if (counter == 2)
                        {
                            counter = 0;
                            pairCard = (int)allCards[y].rank;
                            break;
                        }
                    }
                }
                counter = 0;
            }

            if (pairCard != 0)
            {
                for (int x = 0; x < allCards.Count; x++)
                {
                    if (allCards[x].rank != (float)pairCard)
                    {
                        int _res = otherCards.Find(item => item == (int)allCards[x].rank);
                        //Debug.Log("otherCards _res : " + _res + " allCards[x] : " + allCards[x]);
                        if (_res == 0)
                        {
                            otherCards.Add((int)allCards[x].rank);
                        }
                    }
                    else
                    {
                        forKiker.Add(allCards[x]);
                    }
                }

                data.PairValue = pairCard;
                data.kikers = getKiker(forKiker, data.playerCard_1, data.playerCard_2);
                otherCards.Sort();
                otherCards.Reverse();
                data.PairOthersBestCards = otherCards;
                data.bestFive.Add(pairCard); data.bestFive.Add(pairCard); data.bestFive.Add(otherCards[0]); data.bestFive.Add(otherCards[1]); data.bestFive.Add(otherCards[2]);
                tmpRet = true;
            }



            return tmpRet;
        }

        bool check_HighCard(EvalData data)
        {
            List<Card> allCards = getAllCardsData(data);
            List<int> allCardsInt = new List<int>();
            List<Card> forKiker = new List<Card>();
            for (int x = 0; x < allCards.Count; x++)
            {
                allCardsInt.Add((int)allCards[x].rank);
            }

            for (int i = 0; i < allCardsInt.Count; i++)
            {
                if (allCardsInt[i] == 1) allCardsInt[i] = 14;
            }

            allCardsInt.Sort();
            allCardsInt.Reverse();

            for (int i = 0; i < allCardsInt.Count; i++)
            {
                //Debug.Log("check_HighCard---------------->> : " + allCardsInt[i]);
            }

            data.HighCardValue = allCardsInt[0];
            data.HighCardOthersBestCards = allCardsInt;

            Card _res = allCards.Find(item => item.rank == (float)data.HighCardValue);
            forKiker.Add(_res);

            data.kikers = getKiker(forKiker, data.playerCard_1, data.playerCard_2);
            data.bestFive.Add(allCardsInt[0]); data.bestFive.Add(allCardsInt[1]); data.bestFive.Add(allCardsInt[2]); data.bestFive.Add(allCardsInt[3]); data.bestFive.Add(allCardsInt[4]);
            return true;

        }

        bool justCheck_Flush(EvalData data, out int seme)
        {
            seme = 0;
            bool tmpRet = false;

            List<Card> allCards = getAllCardsData(data);
            int semeCounter = 0;
            int semeValue = 0;
            for (int s = 1; s < 5; s++)
            {
                for (int x = 0; x < allCards.Count; x++)
                {
                    //Debug.Log("chech_RoyalFlush : " + allCards[x] + " : " + s);
                    if (allCards[x].suit == s)
                    {
                        semeCounter++;
                        if (semeCounter == 5)
                        {
                            semeValue = s;
                            break;
                        }
                    }
                }
                semeCounter = 0;
            }

            //Debug.Log("check_Flush : " + semeValue);

            if (semeValue != 0)
            {
                seme = semeValue;
                // data.kikers = getKiker(
                tmpRet = true;
            }

            return tmpRet;
        }

        List<Card> getAllCardsData(EvalData data)
        {
            List<Card> allCards = new List<Card>();
            foreach (Card c in data.flopCards) { allCards.Add(c); }
            if (data.turnCard != Card.nullCard) allCards.Add(data.turnCard);
            if (data.riverCard != Card.nullCard) allCards.Add(data.riverCard);
            allCards.Add(data.playerCard_1);
            allCards.Add(data.playerCard_2);
            return allCards;
        }

        int getKiker(List<Card> bestFive, Card playerCard_1, Card playerCard_2)
        {


            List<Card> listWithOutPlayerCards = new List<Card>();
            int tmpRet = -1;

            Card _res = bestFive.Find(item => item == playerCard_1);
            if (_res == Card.nullCard) listWithOutPlayerCards.Add(playerCard_1);
            _res = bestFive.Find(item => item == playerCard_2);
            if (_res == Card.nullCard) listWithOutPlayerCards.Add(playerCard_2);

            if (listWithOutPlayerCards.Count > 0)
            {
                List<int> _l = new List<int>();
                foreach (Card v in listWithOutPlayerCards)
                {
                    _l.Add((int)v.rank);
                }
                _l.Sort();
                _l.Reverse();
                tmpRet = _l[0];
            }
            else
            {

            }

            return tmpRet;
        }


        public List<PlayerData> getWinnerCheck_HighCard(List<PlayerData> pdList)
        {
            List<PlayerData> tmpRet;
            List<int> tmpRetToRemove = new List<int>();

            int highCard = 0; // check list 0
            for (int x = 0; x < pdList.Count; x++)
            {
                //Debug.Log("getWinnerCheck_HighCard start -> : " + x + " : " + "pdList[x].completeResultStruct.HighCardOthersBestCards[0] : " + pdList[x].completeResultStruct.HighCardOthersBestCards[0]);
                if (pdList[x].completeEvalData.HighCardOthersBestCards[0] > highCard)
                {
                    highCard = pdList[x].completeEvalData.HighCardOthersBestCards[0];
                }
            }

            //Debug.Log("getWinnerCheck_HighCard highCard : " + highCard); 

            for (int x = 0; x < pdList.Count; x++)
            {
                if (pdList[x].completeEvalData.HighCardOthersBestCards[0] < highCard)
                {
                    //Debug.Log("getWinnerCheck_HighCard REMOVE : " + pdList[x].playerPosition + " : " + pdList[x].completeResultStruct.HighCardOthersBestCards[0]); 
                    tmpRetToRemove.Add(pdList[x].playerPosition);
                }
            }

            for (int x = 0; x < tmpRetToRemove.Count; x++)
            {
                PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]);
                pdList.Remove(pd);
            }

            highCard = 0; // check list 1
            if (pdList.Count > 1)
            {
                tmpRetToRemove.Clear();
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.HighCardOthersBestCards[1] > highCard) { highCard = pdList[x].completeEvalData.HighCardOthersBestCards[1]; } }
                //Debug.Log("getWinnerCheck_HighCard highCard [1] : " + highCard); 
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.HighCardOthersBestCards[1] < highCard) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }
            }

            highCard = 0; // check list 2
            if (pdList.Count > 1)
            {
                tmpRetToRemove.Clear();
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.HighCardOthersBestCards[2] > highCard) { highCard = pdList[x].completeEvalData.HighCardOthersBestCards[2]; } }
                //Debug.Log("getWinnerCheck_HighCard highCard [2] : " + highCard); 
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.HighCardOthersBestCards[2] < highCard) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }
            }

            highCard = 0; // check list 3
            if (pdList.Count > 1)
            {
                tmpRetToRemove.Clear();
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.HighCardOthersBestCards[3] > highCard) { highCard = pdList[x].completeEvalData.HighCardOthersBestCards[3]; } }
                //Debug.Log("getWinnerCheck_HighCard highCard [3] : " + highCard); 
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.HighCardOthersBestCards[3] < highCard) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }
            }

            highCard = 0; // check list 4
            if (pdList.Count > 1)
            {
                tmpRetToRemove.Clear();
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.HighCardOthersBestCards[4] > highCard) { highCard = pdList[x].completeEvalData.HighCardOthersBestCards[4]; } }
                //Debug.Log("getWinnerCheck_HighCard highCard [3] : " + highCard); 
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.HighCardOthersBestCards[4] < highCard) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }
            }


            //Debug.Log("getWinnerCheck_HighCard tmpRetToRemove count : " + pdList.Count); 

            tmpRet = pdList;
            return tmpRet;

        }

        public List<PlayerData> getWinnerCheck_Pair(List<PlayerData> pdList)
        {

            string pairWinDebug = "Winnerss: ";
            foreach (var winner in pdList)
                pairWinDebug += "[" + winner.playerName + ", " + winner.playerPosition + "], ";
            //Debug.LogError(pairWinDebug);
            List<int> tmpRetToRemove = new List<int>();

            int maxPairValue = 0;
            for (int x = 0; x < pdList.Count; x++)
            {
                if (pdList[x].completeEvalData.PairValue > maxPairValue) { maxPairValue = pdList[x].completeEvalData.PairValue; }
            }
            //Debug.Log("getWinnerCheck_Pair start -> *** maxPairValue *** : " + maxPairValue);
            for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.PairValue < maxPairValue) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
            for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }

            if (pdList.Count > 1)
            {

                tmpRetToRemove.Clear();
                int maxOthersCardValue = 0;
                for (int x = 0; x < pdList.Count; x++)
                {

                    //Debug.Log("--------------->>>getWinnerCheck_Pair start -> pdList PairOthersBestCards : " + pdList[x].completeResultStruct.PairOthersBestCards[x]);

                    if (pdList[x].completeEvalData.PairOthersBestCards[0] > maxOthersCardValue) { maxOthersCardValue = pdList[x].completeEvalData.PairOthersBestCards[0]; }
                }
                //Debug.Log("getWinnerCheck_Pair start -> maxPairValue [0]: " + maxOthersCardValue);
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.PairOthersBestCards[0] < maxOthersCardValue) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }

                maxOthersCardValue = 0; // check 1
                if (pdList.Count > 1)
                {
                    tmpRetToRemove.Clear();
                    for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.PairOthersBestCards[1] > maxOthersCardValue) { maxOthersCardValue = pdList[x].completeEvalData.PairOthersBestCards[1]; } }
                    //Debug.Log("getWinnerCheck_Pair start -> maxPairValue [1]: " + maxOthersCardValue);
                    for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.PairOthersBestCards[1] < maxOthersCardValue) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                    for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }
                }

                maxOthersCardValue = 0; // check 2 last
                if (pdList.Count > 1)
                {
                    tmpRetToRemove.Clear();
                    for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.PairOthersBestCards[2] > maxOthersCardValue) { maxOthersCardValue = pdList[x].completeEvalData.PairOthersBestCards[2]; } }
                    //Debug.Log("getWinnerCheck_Pair start -> maxPairValue [2]: " + maxOthersCardValue);
                    for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.PairOthersBestCards[2] < maxOthersCardValue) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                    for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }
                }
            }


            return pdList;
        }

        public List<PlayerData> getWinnerCheck_TwoPair(List<PlayerData> pdList)
        {


            string pairWinDebug = "Winnerss: ";
            foreach (var winner in pdList)
                pairWinDebug += "[" + winner.playerName + ", " + winner.playerPosition + "], ";

            List<int> tmpRetToRemove = new List<int>();

            float highCardPair_x = 0;
            //int kiker = 0;
            for (int x = 0; x < pdList.Count; x++)
            {
                //Debug.Log("kiker : " + pdList[x].playerPosition + " kiker : " + pdList[x].completeResultStruct.kikers);
                if (pdList[x].completeEvalData.TwoPairHighCards.suit > highCardPair_x) { highCardPair_x = pdList[x].completeEvalData.TwoPairHighCards.suit; }
            }
            //Debug.Log("getWinnerCheck_TwoPair start -> highCardPair_x : " + highCardPair_x);

            for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.TwoPairHighCards.suit < highCardPair_x) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
            for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }

            if (pdList.Count > 1)
            {
                // going to check second pair
                tmpRetToRemove.Clear();
                //Debug.Log("getWinnerCheck_TwoPair start -> check 1 pdList.Count : " + pdList.Count);
                float highCardPair_y = 0;
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.TwoPairHighCards.rank > highCardPair_y) { highCardPair_y = pdList[x].completeEvalData.TwoPairHighCards.rank; } }
                //Debug.Log("getWinnerCheck_TwoPair start -> highCardPair_Y : " + highCardPair_y);
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.TwoPairHighCards.rank < highCardPair_y) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }

                if (pdList.Count > 1)
                {
                    //Debug.Log("getWinnerCheck_TwoPair start -> check 2 Y > 1 pdList.Count : " + pdList.Count);
                    // check fifth card and kiker
                    tmpRetToRemove.Clear();
                    float fifithCard = 0;
                    for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.TwoPairFifthCard > fifithCard) { fifithCard = pdList[x].completeEvalData.TwoPairFifthCard; } }
                    //Debug.Log("getWinnerCheck_TwoPair *** fifithCard *** : " + fifithCard);
                    for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.TwoPairFifthCard < fifithCard) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                    for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }

                    if (pdList.Count > 1)
                    {
                        //Debug.Log("getWinnerCheck_TwoPair start -> check ***fifithCard*** pdList.Count : " + pdList.Count);
                    }
                    else
                    {

                    }
                }
                else
                {
                    //Debug.Log("getWinnerCheck_TwoPair start -> check 2 Y == 1 pdList.Count : " + pdList.Count);
                }
            }
            else
            {
                //Debug.Log("getWinnerCheck_TwoPair start -> check 1 pdList.Count : " + pdList.Count);
            }


            return pdList;
        }

        public List<PlayerData> getWinnerCheck_Tris(List<PlayerData> pdList)
        {
            List<int> tmpRetToRemove = new List<int>();
            float highCardTris = 0; //completeResultStruct.maxCardValue
                                    //int kiker = 0;

            for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.maxCardValue > highCardTris) { highCardTris = pdList[x].completeEvalData.maxCardValue; } }
            //Debug.Log("****************getWinnerCheck_Tris start -> highCardTris : " + highCardTris);

            for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.maxCardValue < highCardTris) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
            for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }
            //Debug.Log("****************getWinnerCheck_Tris start -> pdList.Count : " + pdList.Count);

            if (pdList.Count > 1)
            { // check fourth card
                int bestOthers = 0;
                tmpRetToRemove.Clear();
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.TrisOthersCards[0] > bestOthers) { bestOthers = pdList[x].completeEvalData.TrisOthersCards[0]; } }
                //Debug.Log("check fourth card ****************getWinnerCheck_Tris start -> bestOthers : " + bestOthers);
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.TrisOthersCards[0] < bestOthers) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }

                if (pdList.Count > 1)
                { // check fifth card
                    bestOthers = 0;
                    tmpRetToRemove.Clear();
                    for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.TrisOthersCards[1] > bestOthers) { bestOthers = pdList[x].completeEvalData.TrisOthersCards[1]; } }
                    //Debug.Log("check fifth card ****************getWinnerCheck_Tris start -> bestOthers : " + bestOthers);
                    for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.TrisOthersCards[1] < bestOthers) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                    for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }
                }

            }

            return pdList;
        }

        public List<PlayerData> getWinnerCheck_Straight(List<PlayerData> pdList)
        {
            List<int> tmpRetToRemove = new List<int>();

            float highCard = 0;

            for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.bestFive[0] > highCard) { highCard = pdList[x].completeEvalData.bestFive[0]; } }
            //Debug.Log("****************getWinnerCheck_straight start -> highCard : " + highCard);


            for (int y = 0; y < pdList.Count - 1; y++)
            {
                highCard = 0;
                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.bestFive[y] > highCard) { highCard = pdList[x].completeEvalData.bestFive[y]; } }

                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.bestFive[y] < highCard) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }
                //Debug.Log("****************getWinnerCheck_Straight ******  -> pdList.Count : [" + y + "] : " + pdList.Count);
            }
            return pdList;
        }

        public List<PlayerData> getWinnerCheck_Flush(List<PlayerData> pdList)
        {
            List<int> tmpRetToRemove = new List<int>();

            for (int x = 0; x < pdList.Count; x++)
            {
                if (pdList[x].completeEvalData.FlushOrderedCardsValue[x] == 1)
                {
                    pdList[x].completeEvalData.FlushOrderedCardsValue[x] = 14;
                }
            }

            float highCard = 0;
            for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.FlushOrderedCardsValue[0] > highCard) { highCard = pdList[x].completeEvalData.FlushOrderedCardsValue[0]; } }
            //Debug.Log("****************getWinnerCheck_Flush start -> highCard : " + highCard);

            if (pdList.Count > 1)
            {
                for (int y = 0; y < 5; y++) //pdList.Count - 1
                {
                    highCard = 0;
                    for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.bestFive[y] > highCard) { highCard = pdList[x].completeEvalData.bestFive[y]; } }

                    for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.bestFive[y] < highCard) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                    for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }
                    //Debug.Log("****************getWinnerCheck_Flush ******  -> pdList.Count : [" + y + "] : " + pdList.Count);
                }
            }

            return pdList;
        }

        public List<PlayerData> getWinnerCheck_FullHouse(List<PlayerData> pdList)
        {
            List<int> tmpRetToRemove = new List<int>();

            for (int x = 0; x < pdList.Count; x++)
            {
                //if (pdList[x].completeResultStruct.FullHighCards.suit == 1) pdList[x].completeResultStruct.FullHighCards.suit = 14;
                //if (pdList[x].completeResultStruct.FullHighCards.rank == 1) pdList[x].completeResultStruct.FullHighCards.rank = 14;
                if (pdList[x].completeEvalData.FullHighCards.suit == 1) pdList[x].completeEvalData.FullHighCards.SetCardData(14, 14);
            }

            float highCard_x_tris = 0;
            float highCard_y_tris = 0;

            for (int y = 0; y < pdList.Count; y++)
            {
                highCard_x_tris = 0;
                tmpRetToRemove.Clear();

                if (pdList[y].completeEvalData.FullHighCards.suit > highCard_x_tris) { highCard_x_tris = pdList[y].completeEvalData.FullHighCards.suit; }

                for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.FullHighCards.suit < highCard_x_tris) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }

            }

            if (pdList.Count > 1)
            {

                for (int y = 0; y < pdList.Count; y++)
                {
                    highCard_y_tris = 0;
                    tmpRetToRemove.Clear();
                    if (pdList[y].completeEvalData.FullHighCards.rank > highCard_y_tris) { highCard_y_tris = pdList[y].completeEvalData.FullHighCards.rank; }

                    for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.FullHighCards.rank < highCard_y_tris) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
                    for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }

                }

            }
            return pdList;
        }

        public List<PlayerData> getWinnerCheck_FourOfKind(List<PlayerData> pdList)
        {

            List<int> tmpRetToRemove = new List<int>();
            //int fifthCard = 0;
            int maxCard = 0;

            for (int x = 0; x < pdList.Count; x++)
            {
                if (pdList[x].completeEvalData.maxCardValue > maxCard) { maxCard = pdList[x].completeEvalData.maxCardValue; }
            }
            for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.maxCardValue < maxCard) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
            for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }


            return pdList;
        }

        public List<PlayerData> getWinner_StraightFlush(List<PlayerData> pdList)
        {

            List<int> tmpRetToRemove = new List<int>();
            int maxCard = 0;

            for (int x = 0; x < pdList.Count; x++)
            {
                //Debug.Log("getWinner_StraightFlush --1->> maxCard : " + pdList[x].completeResultStruct.maxCardValue);
                if (pdList[x].completeEvalData.maxCardValue > maxCard) { maxCard = pdList[x].completeEvalData.maxCardValue; }
            }

            for (int x = 0; x < pdList.Count; x++) { if (pdList[x].completeEvalData.maxCardValue < maxCard) { tmpRetToRemove.Add(pdList[x].playerPosition); } }
            for (int x = 0; x < tmpRetToRemove.Count; x++) { PlayerData pd = pdList.Find(item => item.playerPosition == tmpRetToRemove[x]); pdList.Remove(pd); }


            //Debug.Log("getWinner_StraightFlush --->> maxCard : " + maxCard);

            return pdList;
        }

    }
}
