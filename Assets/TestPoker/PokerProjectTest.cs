using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestPoker
{

    public class PokerProjectTest : MonoBehaviour
    {
        public TestGameCardPoker pokerCards;
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
            player1.playerPosition = 0;

            player2 = new PlayerData();
            player2.playerPosition = 1;

            player3 = new PlayerData();
            player3.playerPosition = 2;


            player1.card1data = new Card(3, 4);
            player1.card2data = new Card(1, 6);

            player2.card1data = new Card(3, 1);
            player2.card2data = new Card(1, 4);

            player3.card1data = new Card(2, 12);
            player3.card2data = new Card(1, 7);

            pdList.Add(player1);
            pdList.Add(player2);
            pdList.Add(player3);

        }
        void TestResult()
        {
            AddPlayersDatas();

            List<Card> flopCardsList = new List<Card>();
            flopCardsList.Add(new Card(3, 10));
            flopCardsList.Add(new Card(4, 8));
            flopCardsList.Add(new Card(1, 10));
            Card TurnCard = new Card(2, 5);
            Card RiverCard = new Card(3, 11);
            foreach (var cdata in flopCardsList)
                Debug.Log(cdata);
            Debug.Log(TurnCard + ",  " + RiverCard);

            for (int x = 0; x < pdList.Count; x++)
            {
                TestGameCardPoker.CompleteResultStruct data = new TestGameCardPoker.CompleteResultStruct();
                TestGameCardPoker.CompleteResultStruct dataOut = new TestGameCardPoker.CompleteResultStruct();
                data.playerCard_1 = pdList[x].card1data;
                data.playerCard_2 = pdList[x].card2data;
                data.flopCards[0] = flopCardsList[0];
                data.flopCards[1] = flopCardsList[1];
                data.flopCards[2] = flopCardsList[2];

                if (useTurnCard) data.turnCard = TurnCard;
                else data.turnCard = Card.nullCard;

                if (useRiverCard) data.riverCard = RiverCard;
                else data.riverCard = Card.nullCard;

                data.playerIdx = pdList[x].playerPosition;

                Debug.Log("playerCard_1 : " + data.playerCard_1 + "  playerCard_2 : " + data.playerCard_2);
                //Debug.Log("data.flopCards[0] : " + data.flopCards[0] + "  data.flopCards[1] : " + data.flopCards[1] + "  data.flopCards[2] : " + data.flopCards[2]);
                // Debug.Log("data.turnCard : " + data.turnCard + "  data.riverCard : " + data.riverCard);


                pokerCards.getPlayerCardsResult(pdList[x].playerPosition, data, out dataOut);
                pdList[x].completeResultStruct = dataOut;

            }

            int bestResult = 10;
            for (int x = 0; x < pdList.Count; x++)
            {
                Debug.Log("-----------------------------------------------");
                Debug.Log("++++++++++ Result idx : " + pdList[x].playerPosition);
                Debug.Log("++++++++++ Result result : " + pdList[x].completeResultStruct.cardsResultValues);
                //TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] cardsResultValues : " + pdList[x].completeResultStruct.cardsResultValues + "\n";
                string bestFive = "";
                foreach (int i in pdList[x].completeResultStruct.bestFive)
                {
                    bestFive = bestFive + i + " : ";
                }
                Debug.Log("player" + x + " bestfive:" + bestFive);
                // TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] bestFive : " + bestFive + " kiker :" + pdList[x].completeResultStruct.kikers.ToString() + "\n";
                Debug.Log("-----------------------------------------------");
                if ((int)pdList[x].completeResultStruct.cardsResultValues < bestResult) bestResult = (int)pdList[x].completeResultStruct.cardsResultValues;
            }

            Debug.Log("bestResult : " + (TestGameCardPoker.CardsResultValues)bestResult);

            List<PlayerData> pdWinnerList = new List<PlayerData>();

            for (int x = 0; x < pdList.Count; x++)
            {
                if (pdList[x].completeResultStruct.cardsResultValues == (TestGameCardPoker.CardsResultValues)bestResult)
                {
                    pdWinnerList.Add(pdList[x]);
                }
            }

            Debug.Log("pdWinnerList Count : " + pdWinnerList.Count);
            for (int x = 0; x < pdWinnerList.Count; x++)
            {
                //TextResult.text = TextResult.text + "Winner : " + pdWinnerList[x].playerPosition + " result : " + pdWinnerList[x].completeResultStruct.cardsResultValues + "\n";
                Debug.Log("Winner : " + pdWinnerList[x].playerPosition + " result : " + pdWinnerList[x].completeResultStruct.cardsResultValues + "\n");
            }


            if (pdWinnerList.Count > 1)
            {
                List<PlayerData> finalWinners = new List<PlayerData>();
                string winnersResult = "";
                switch ((TestGameCardPoker.CardsResultValues)bestResult)
                {
                    case TestGameCardPoker.CardsResultValues.HighCard:
                        finalWinners = pokerCards.getWinnerCheck_HighCard(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.Pair:
                        finalWinners = pokerCards.getWinnerCheck_Pair(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.TwoPair:
                        finalWinners = pokerCards.getWinnerCheck_TwoPair(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.ThreeOfAkind:
                        finalWinners = pokerCards.getWinnerCheck_Tris(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.Straight:
                        finalWinners = pokerCards.getWinnerCheck_Straight(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.Flush:
                        finalWinners = pokerCards.getWinnerCheck_Flush(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.FullHouse:
                        finalWinners = pokerCards.getWinnerCheck_FullHouse(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.FourOfAkind:
                        finalWinners = pokerCards.getWinnerCheck_Poker(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.StraightFlush:
                        finalWinners = pokerCards.getWinner_StraightFlush(pdWinnerList);
                        foreach (PlayerData pd in finalWinners)
                        {
                            winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerPosition + "\n";
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
}