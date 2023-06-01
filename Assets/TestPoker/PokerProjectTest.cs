using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PokerProjectTest : MonoBehaviour
    {
        public PokerEval pokerCards;
        // Start is called before the first frame update
        bool useTurnCard = true;
        bool useRiverCard = true;

        void Start()
        {
            TestResult();
        }
        PlayerData player1, player2, player3 = new PlayerData();

        List<PlayerData> pdList = new List<PlayerData>();
        void AddPlayersDatas()
        {
            player1 = new PlayerData();
            player1.seatPos = 0;

            player2 = new PlayerData();
            player2.seatPos = 1;

            player3 = new PlayerData();
            player3.seatPos = 2;


            player1.card1data = new Card(SUIT.HEARTS, VALUE.ACE);
            player1.card2data = new Card(SUIT.HEARTS, VALUE.TWO);

            player2.card1data = new Card(3, 1);
            player2.card2data = new Card(1, 4);

            player3.card1data = new Card(SUIT.DIAMONDS, VALUE.EIGHT);
            player3.card2data = new Card(SUIT.HEARTS, VALUE.FOUR);

            pdList.Add(player1);
            pdList.Add(player2);
            pdList.Add(player3);

        }
        void TestResult()
        {
            AddPlayersDatas();

            List<Card> flopCardsList = new List<Card>();
            flopCardsList.Add(new Card(SUIT.DIAMONDS, VALUE.KING));
            flopCardsList.Add(new Card(SUIT.HEARTS, VALUE.JACK));
            flopCardsList.Add(new Card(SUIT.HEARTS, VALUE.THREE));
            Card TurnCard = new Card(SUIT.HEARTS, VALUE.FOUR);
            Card RiverCard = new Card(SUIT.HEARTS, VALUE.FIVE);
            string tableCards = "TableCards: ";
            foreach (var cdata in flopCardsList)
                tableCards += cdata + " | ";
            //Debug.Log("Flop: " + cdata);
            tableCards += TurnCard + " | "; 
            tableCards += RiverCard;
            Debug.Log(tableCards);
            //Debug.Log(TurnCard + ",  " + RiverCard);

            for (int x = 0; x < pdList.Count; x++)
            {
                EvalData data = new EvalData();
                EvalData dataOut = new EvalData();
                data.playerCard_1 = pdList[x].card1data;
                data.playerCard_2 = pdList[x].card2data;
                data.flopCards[0] = flopCardsList[0];
                data.flopCards[1] = flopCardsList[1];
                data.flopCards[2] = flopCardsList[2];

                if (useTurnCard) data.turnCard = TurnCard;
                else data.turnCard = Card.nullCard;

                if (useRiverCard) data.riverCard = RiverCard;
                else data.riverCard = Card.nullCard;

                data.playerIdx = pdList[x].seatPos;

                Debug.Log("playerCards"+(x+1)+": " + data.playerCard_1 + "  |  " + data.playerCard_2);
                //Debug.Log("data.flopCards[0] : " + data.flopCards[0] + "  data.flopCards[1] : " + data.flopCards[1] + "  data.flopCards[2] : " + data.flopCards[2]);
                // Debug.Log("data.turnCard : " + data.turnCard + "  data.riverCard : " + data.riverCard);


                pokerCards.getPlayerCardsResult(pdList[x].seatPos, data, out dataOut);
                pdList[x].completeEvalData = dataOut;

            }

            int bestResult = 10;
            for (int x = 0; x < pdList.Count; x++)
            {
                //Debug.Log("-----------------------------------------------");
                Debug.Log("++++++++++ Result idx : " + pdList[x].seatPos);
                Debug.Log("++++++++++ Result result : " + pdList[x].completeEvalData.cardsResultValues);
                //TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] cardsResultValues : " + pdList[x].completeResultStruct.cardsResultValues + "\n";
                string bestFive = "";
                foreach (int i in pdList[x].completeEvalData.bestFive)
                {
                    bestFive = bestFive + i + " : ";
                }
                Debug.Log("player" + (x+1) + " bestfive:" + bestFive);
                // TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] bestFive : " + bestFive + " kiker :" + pdList[x].completeResultStruct.kikers.ToString() + "\n";
                Debug.Log("-----------------------------------------------");
                if ((int)pdList[x].completeEvalData.cardsResultValues < bestResult) bestResult = (int)pdList[x].completeEvalData.cardsResultValues;
            }

            Debug.Log("bestResult : " + (CardsResultValues)bestResult);

            List<PlayerData> pdWinnerList = new List<PlayerData>();

            for (int x = 0; x < pdList.Count; x++)
            {
                if (pdList[x].completeEvalData.cardsResultValues == (CardsResultValues)bestResult)
                {
                    pdWinnerList.Add(pdList[x]);
                }
            }

            Debug.Log("pdWinnerList Count : " + pdWinnerList.Count);
            for (int x = 0; x < pdWinnerList.Count; x++)
            {
                //TextResult.text = TextResult.text + "Winner : " + pdWinnerList[x].playerPosition + " result : " + pdWinnerList[x].completeResultStruct.cardsResultValues + "\n";
                Debug.Log("Winner : " + pdWinnerList[x].seatPos + " result : " + pdWinnerList[x].completeEvalData.cardsResultValues + "\n");
            }


            if (pdWinnerList.Count > 1)
            {
                List<PlayerData> finalWinners = new List<PlayerData>();
                string winnersResult = "";
                switch ((CardsResultValues)bestResult)
                {
                    case CardsResultValues.HighCard:
                        finalWinners = pokerCards.getWinnerCheck_HighCard(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.seatPos + "\n";
                        }
                        break;
                    case CardsResultValues.Pair:
                        finalWinners = pokerCards.getWinnerCheck_Pair(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.seatPos + "\n";
                        }
                        break;
                    case CardsResultValues.TwoPair:
                        finalWinners = pokerCards.getWinnerCheck_TwoPair(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.seatPos + "\n";
                        }
                        break;
                    case CardsResultValues.ThreeOfAkind:
                        finalWinners = pokerCards.getWinnerCheck_Tris(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.seatPos + "\n";
                        }
                        break;
                    case CardsResultValues.Straight:
                        finalWinners = pokerCards.getWinnerCheck_Straight(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.seatPos + "\n";
                        }
                        break;
                    case CardsResultValues.Flush:
                        finalWinners = pokerCards.getWinnerCheck_Flush(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.seatPos + "\n";
                        }
                        break;
                    case CardsResultValues.FullHouse:
                        finalWinners = pokerCards.getWinnerCheck_FullHouse(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.seatPos + "\n";
                        }
                        break;
                    case CardsResultValues.FourOfAkind:
                        finalWinners = pokerCards.getWinnerCheck_FourOfKind(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.seatPos + "\n";
                        }
                        break;
                    case CardsResultValues.StraightFlush:
                        finalWinners = pokerCards.getWinner_StraightFlush(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.seatPos + "\n";
                        }
                        break;
                }
                Debug.Log(winnersResult);
            }


        }
        // Update is called once per frame
        void Update()
        {

        }
    }
