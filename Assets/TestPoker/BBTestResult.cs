﻿//#if USE_PHOTON
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace TestPoker
{

    public class BBTestResult : MonoBehaviour
    {

        public TestGameCardPoker pokerCards;
        int progr = 0;
        int session = 0;
        public void getScreenShoot()
        {
            //Application.CaptureScreenshot("_Screenshot_" + session.ToString() + "_" + progr.ToString() + ".png");	
            progr++;
        }

        void Start()
        {

            session = UnityEngine.Random.Range(1, 100000);

            //GameObject.Find("Dropdown_player_0_1_seme").GetComponent<Dropdown>().value = 3; onDropDownValueChange(GameObject.Find("Dropdown_player_0_1_seme").GetComponent<Dropdown>());
            //GameObject.Find("Dropdown_player_0_1_carta").GetComponent<Dropdown>().value = 2;
            //GameObject.Find("Dropdown_player_0_2_seme").GetComponent<Dropdown>().value = 1; onDropDownValueChange(GameObject.Find("Dropdown_player_0_2_seme").GetComponent<Dropdown>());
            //GameObject.Find("Dropdown_player_0_2_carta").GetComponent<Dropdown>().value = 10;

            //GameObject.Find("Dropdown_player_1_1_seme").GetComponent<Dropdown>().value = 1; onDropDownValueChange(GameObject.Find("Dropdown_player_1_1_seme").GetComponent<Dropdown>());
            //GameObject.Find("Dropdown_player_1_1_carta").GetComponent<Dropdown>().value = 12;
            //GameObject.Find("Dropdown_player_1_2_seme").GetComponent<Dropdown>().value = 3; onDropDownValueChange(GameObject.Find("Dropdown_player_1_2_seme").GetComponent<Dropdown>());
            //GameObject.Find("Dropdown_player_1_2_carta").GetComponent<Dropdown>().value = 10;

            //GameObject.Find("Dropdown_player_2_1_seme").GetComponent<Dropdown>().value = 2; onDropDownValueChange(GameObject.Find("Dropdown_player_2_1_seme").GetComponent<Dropdown>());
            //GameObject.Find("Dropdown_player_2_1_carta").GetComponent<Dropdown>().value = 8;
            //GameObject.Find("Dropdown_player_2_2_seme").GetComponent<Dropdown>().value = 0; onDropDownValueChange(GameObject.Find("Dropdown_player_2_2_seme").GetComponent<Dropdown>());
            //GameObject.Find("Dropdown_player_2_2_carta").GetComponent<Dropdown>().value = 10;

            //GameObject.Find("Dropdown_fold_1_seme").GetComponent<Dropdown>().value = 3; onDropDownValueChange(GameObject.Find("Dropdown_fold_1_seme").GetComponent<Dropdown>());
            //GameObject.Find("Dropdown_fold_1_carta").GetComponent<Dropdown>().value = 11;

            //GameObject.Find("Dropdown_fold_2_seme").GetComponent<Dropdown>().value = 3; onDropDownValueChange(GameObject.Find("Dropdown_fold_2_seme").GetComponent<Dropdown>());
            //GameObject.Find("Dropdown_fold_2_carta").GetComponent<Dropdown>().value = 4;

            //GameObject.Find("Dropdown_fold_3_seme").GetComponent<Dropdown>().value = 0; onDropDownValueChange(GameObject.Find("Dropdown_fold_3_seme").GetComponent<Dropdown>());
            //GameObject.Find("Dropdown_fold_3_carta").GetComponent<Dropdown>().value = 5;

            //GameObject.Find("Dropdown_turn_seme").GetComponent<Dropdown>().value = 3; onDropDownValueChange(GameObject.Find("Dropdown_turn_seme").GetComponent<Dropdown>());
            //GameObject.Find("Dropdown_turn_carta").GetComponent<Dropdown>().value = 9;

            //GameObject.Find("Dropdown_river_seme").GetComponent<Dropdown>().value = 3; onDropDownValueChange(GameObject.Find("Dropdown_river_seme").GetComponent<Dropdown>());
            //GameObject.Find("Dropdown_river_carta").GetComponent<Dropdown>().value = 12;

            GameObject.Find("Dropdown_player_0_1_seme").GetComponent<Dropdown>().value = 2; onDropDownValueChange(GameObject.Find("Dropdown_player_0_1_seme").GetComponent<Dropdown>());
            GameObject.Find("Dropdown_player_0_1_carta").GetComponent<Dropdown>().value = 2;
            GameObject.Find("Dropdown_player_0_2_seme").GetComponent<Dropdown>().value = 3; onDropDownValueChange(GameObject.Find("Dropdown_player_0_2_seme").GetComponent<Dropdown>());
            GameObject.Find("Dropdown_player_0_2_carta").GetComponent<Dropdown>().value = 3;
            GameObject.Find("Dropdown_player_1_1_seme").GetComponent<Dropdown>().value = 3; onDropDownValueChange(GameObject.Find("Dropdown_player_1_1_seme").GetComponent<Dropdown>());
            GameObject.Find("Dropdown_player_1_1_carta").GetComponent<Dropdown>().value = 3;
            GameObject.Find("Dropdown_player_1_2_seme").GetComponent<Dropdown>().value = 0; onDropDownValueChange(GameObject.Find("Dropdown_player_1_2_seme").GetComponent<Dropdown>());
            GameObject.Find("Dropdown_player_1_2_carta").GetComponent<Dropdown>().value = 4;
            GameObject.Find("Dropdown_player_2_1_seme").GetComponent<Dropdown>().value = 2; onDropDownValueChange(GameObject.Find("Dropdown_player_2_1_seme").GetComponent<Dropdown>());
            GameObject.Find("Dropdown_player_2_1_carta").GetComponent<Dropdown>().value = 1;
            GameObject.Find("Dropdown_player_2_2_seme").GetComponent<Dropdown>().value = 1; onDropDownValueChange(GameObject.Find("Dropdown_player_2_2_seme").GetComponent<Dropdown>());
            GameObject.Find("Dropdown_player_2_2_carta").GetComponent<Dropdown>().value = 8;
            GameObject.Find("Dropdown_fold_1_seme").GetComponent<Dropdown>().value = 0; onDropDownValueChange(GameObject.Find("Dropdown_fold_1_seme").GetComponent<Dropdown>());
            GameObject.Find("Dropdown_fold_1_carta").GetComponent<Dropdown>().value = 6;
            GameObject.Find("Dropdown_fold_2_seme").GetComponent<Dropdown>().value = 2; onDropDownValueChange(GameObject.Find("Dropdown_fold_2_seme").GetComponent<Dropdown>());
            GameObject.Find("Dropdown_fold_2_carta").GetComponent<Dropdown>().value = 4;
            GameObject.Find("Dropdown_fold_3_seme").GetComponent<Dropdown>().value = 0; onDropDownValueChange(GameObject.Find("Dropdown_fold_3_seme").GetComponent<Dropdown>());
            GameObject.Find("Dropdown_fold_3_carta").GetComponent<Dropdown>().value = 5;
            GameObject.Find("Dropdown_turn_seme").GetComponent<Dropdown>().value = 3; onDropDownValueChange(GameObject.Find("Dropdown_turn_seme").GetComponent<Dropdown>());
            GameObject.Find("Dropdown_turn_carta").GetComponent<Dropdown>().value = 7;
            GameObject.Find("Dropdown_river_seme").GetComponent<Dropdown>().value = 3; onDropDownValueChange(GameObject.Find("Dropdown_river_seme").GetComponent<Dropdown>());
            GameObject.Find("Dropdown_river_carta").GetComponent<Dropdown>().value = 0;

        }

        // Use this for initialization
        void executeResult()
        {



            /* royal flush
                        data.flopCards[0] = new CardStruct(3,10);
                        data.flopCards[1] = new CardStruct(3,11);
                        data.flopCards[2] = new CardStruct(3,12);
                        data.turnCard = new CardStruct(3,13);
                        data.riverCard = new CardStruct(2,3);
                        data.playerCard_1 = new CardStruct(4,3);
                        data.playerCard_2 = new CardStruct(3,1);
            */
            /* straight Flush
                        data.flopCards[0] = new CardStruct(3,4);
                        data.flopCards[1] = new CardStruct(3,5);
                        data.flopCards[2] = new CardStruct(3,6);
                        data.turnCard = new CardStruct(3,7);
                        data.riverCard = new CardStruct(2,3);
                        data.playerCard_1 = new CardStruct(4,3);
                        data.playerCard_2 = new CardStruct(3,8);
            */
            /* poker
                        data.flopCards[0] = new CardStruct(3,4);
                        data.flopCards[1] = new CardStruct(3,5);
                        data.flopCards[2] = new CardStruct(4,5);
                        data.turnCard = new CardStruct(2,5);
                        data.riverCard = new CardStruct(2,3);
                        data.playerCard_1 = new CardStruct(1,5);
                        data.playerCard_2 = new CardStruct(3,8);
            */

            /*/ full
                        data.flopCards[0] = new CardStruct(3,13);
                        data.flopCards[1] = new CardStruct(4,13);
                        data.flopCards[2] = new CardStruct(4,1);
                        data.turnCard = new CardStruct(2,5);
                        data.riverCard = new CardStruct(2,3);
                        data.playerCard_1 = new CardStruct(1,1);
                        data.playerCard_2 = new CardStruct(2,13);
            */

            /*/ flush
                        data.flopCards[0] = new CardStruct(3,3);
                        data.flopCards[1] = new CardStruct(4,7);
                        data.flopCards[2] = new CardStruct(4,1);
                        data.turnCard = new CardStruct(2,5);
                        data.riverCard = new CardStruct(4,9);
                        data.playerCard_1 = new CardStruct(4,1);
                        data.playerCard_2 = new CardStruct(4,13);
            */

            /*/ straight
                        data.flopCards[0] = new CardStruct(4,5);
                        data.flopCards[1] = new CardStruct(4,6);
                        data.flopCards[2] = new CardStruct(4,1);
                        data.turnCard = new CardStruct(4,7);
                        data.riverCard = new CardStruct(4,8);
                        data.playerCard_1 = new CardStruct(1,1);
                        data.playerCard_2 = new CardStruct(4,9);
            */

            /*/tris
                        data.flopCards[0] = new CardStruct(4,5);
                        data.flopCards[1] = new CardStruct(2,5);
                        data.flopCards[2] = new CardStruct(4,1);
                        data.turnCard = new CardStruct(4,7);
                        data.riverCard = new CardStruct(4,8);
                        data.playerCard_1 = new CardStruct(1,10);
                        data.playerCard_2 = new CardStruct(1,5);
            */

            /*/ twoPair

                        data.flopCards[0] = new CardStruct(4,12);
                        data.flopCards[1] = new CardStruct(2,12);
                        data.flopCards[2] = new CardStruct(4,1);
                        data.turnCard = new CardStruct(0,0);
                        data.riverCard = new CardStruct(0,0);
                        data.playerCard_1 = new CardStruct(3,5);
                        data.playerCard_2 = new CardStruct(1,5);
            */
            /*/pair
                        data.flopCards[0] = new CardStruct(4,12);
                        data.flopCards[1] = new CardStruct(2,12);
                        data.flopCards[2] = new CardStruct(4,1);
                        data.turnCard = new CardStruct(4,7);
                        data.riverCard = new CardStruct(1,6);
                        data.playerCard_1 = new CardStruct(3,5);
                        data.playerCard_2 = new CardStruct(1,4);
            */
            /* /highCard
                        data.flopCards[0] = new CardStruct(4,12);
                        data.flopCards[1] = new CardStruct(2,10);
                        data.flopCards[2] = new CardStruct(4,1);
                        data.turnCard = new CardStruct(4,7);
                        data.riverCard = new CardStruct(1,6);
                        data.playerCard_1 = new CardStruct(3,5);
                        data.playerCard_2 = new CardStruct(1,4);
            */

            Text TextResult = GameObject.Find("TextResult").GetComponent<Text>();
            TextResult.text = "";

            PlayerData p_1 = new PlayerData();
            p_1.playerPosition = 0;
            //p_1.card_1_Value = new CardStruct(3,5);
            //p_1.card_2_Value = new CardStruct(2,5);

            p_1.card1data = new Card((int)GameObject.Find("Dropdown_player_0_1_seme").GetComponent<Dropdown>().value + 1, (int)GameObject.Find("Dropdown_player_0_1_carta").GetComponent<Dropdown>().value + 1);
            p_1.card2data = new Card((int)GameObject.Find("Dropdown_player_0_2_seme").GetComponent<Dropdown>().value + 1, (int)GameObject.Find("Dropdown_player_0_2_carta").GetComponent<Dropdown>().value + 1);

            PlayerData p_2 = new PlayerData();
            p_2.playerPosition = 1;
            p_2.card1data = new Card((int)GameObject.Find("Dropdown_player_1_1_seme").GetComponent<Dropdown>().value + 1, (int)GameObject.Find("Dropdown_player_1_1_carta").GetComponent<Dropdown>().value + 1);
            p_2.card2data = new Card((int)GameObject.Find("Dropdown_player_1_2_seme").GetComponent<Dropdown>().value + 1, (int)GameObject.Find("Dropdown_player_1_2_carta").GetComponent<Dropdown>().value + 1);

            PlayerData p_3 = new PlayerData();
            p_3.playerPosition = 2;
            p_3.card1data = new Card((int)GameObject.Find("Dropdown_player_2_1_seme").GetComponent<Dropdown>().value + 1, (int)GameObject.Find("Dropdown_player_2_1_carta").GetComponent<Dropdown>().value + 1);
            p_3.card2data = new Card((int)GameObject.Find("Dropdown_player_2_2_seme").GetComponent<Dropdown>().value + 1, (int)GameObject.Find("Dropdown_player_2_2_carta").GetComponent<Dropdown>().value + 1);

            List<PlayerData> pdList = new List<PlayerData>();
            if (GameObject.Find("TogglePlayer_0").GetComponent<Toggle>().isOn) pdList.Add(p_1);
            if (GameObject.Find("TogglePlayer_1").GetComponent<Toggle>().isOn) pdList.Add(p_2);
            if (GameObject.Find("TogglePlayer_2").GetComponent<Toggle>().isOn) pdList.Add(p_3);


            List<Card> flopCardsList = new List<Card>();
            /*	        flopCardsList.Add(new CardStruct(3,9));
                        flopCardsList.Add(new CardStruct(1,5));
                        flopCardsList.Add(new CardStruct(2,11));
                        CardStruct TurnCard = new CardStruct(1,11);
                        CardStruct RiverCard = new CardStruct(4,3);*/

            flopCardsList.Add(new Card((int)GameObject.Find("Dropdown_fold_1_seme").GetComponent<Dropdown>().value + 1, (int)GameObject.Find("Dropdown_fold_1_carta").GetComponent<Dropdown>().value + 1));
            flopCardsList.Add(new Card((int)GameObject.Find("Dropdown_fold_2_seme").GetComponent<Dropdown>().value + 1, (int)GameObject.Find("Dropdown_fold_2_carta").GetComponent<Dropdown>().value + 1));
            flopCardsList.Add(new Card((int)GameObject.Find("Dropdown_fold_3_seme").GetComponent<Dropdown>().value + 1, (int)GameObject.Find("Dropdown_fold_3_carta").GetComponent<Dropdown>().value + 1));
            Card TurnCard = new Card((int)GameObject.Find("Dropdown_turn_seme").GetComponent<Dropdown>().value + 1, (int)GameObject.Find("Dropdown_turn_carta").GetComponent<Dropdown>().value + 1);
            Card RiverCard = new Card((int)GameObject.Find("Dropdown_river_seme").GetComponent<Dropdown>().value + 1, (int)GameObject.Find("Dropdown_river_carta").GetComponent<Dropdown>().value + 1);

            //Debug.Log(TurnCard + ": " + TurnCard.suit + "x -turncard- y " + TurnCard.rank);
            //Debug.Log(RiverCard + ": " + RiverCard.suit + "x -turncard- y " + RiverCard.rank);
            for (int x = 0; x < pdList.Count; x++)
            {
                TestGameCardPoker.CompleteResultStruct data = new TestGameCardPoker.CompleteResultStruct();
                TestGameCardPoker.CompleteResultStruct dataOut = new TestGameCardPoker.CompleteResultStruct();
                data.playerCard_1 = pdList[x].card1data;
                data.playerCard_2 = pdList[x].card2data;
                data.flopCards[0] = flopCardsList[0];
                data.flopCards[1] = flopCardsList[1];
                data.flopCards[2] = flopCardsList[2];

                if (GameObject.Find("ToggleTurnCard").GetComponent<Toggle>().isOn) data.turnCard = TurnCard;
                else data.turnCard = Card.nullCard;

                if (GameObject.Find("ToggleRiverCard").GetComponent<Toggle>().isOn) data.riverCard = RiverCard;
                else data.riverCard = Card.nullCard;

                data.playerIdx = pdList[x].playerPosition;

                Debug.Log("playerCard_1 : " + data.playerCard_1 + "  playerCard_2 : " + data.playerCard_2);
                Debug.Log("data.flopCards[0] : " + data.flopCards[0] + "  data.flopCards[1] : " + data.flopCards[1] + "  data.flopCards[2] : " + data.flopCards[2]);
                Debug.Log("data.turnCard : " + data.turnCard + "  data.riverCard : " + data.riverCard);


                pokerCards.getPlayerCardsResult(pdList[x].playerPosition, data, out dataOut);
                pdList[x].completeEvalData = dataOut;
            }

            int bestResult = 10;
            for (int x = 0; x < pdList.Count; x++)
            {
                Debug.Log("-----------------------------------------------");
                Debug.Log("++++++++++ Result idx : " + pdList[x].playerPosition);
                Debug.Log("++++++++++ Result result : " + pdList[x].completeEvalData.cardsResultValues);
                TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] cardsResultValues : " + pdList[x].completeEvalData.cardsResultValues + "\n";
                string bestFive = "";
                foreach (int i in pdList[x].completeEvalData.bestFive)
                {
                    bestFive = bestFive + i + " : ";
                }
                Debug.Log(bestFive);
                TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] bestFive : " + bestFive + " kiker :" + pdList[x].completeEvalData.kikers.ToString() + "\n";
                Debug.Log("-----------------------------------------------");
                if ((int)pdList[x].completeEvalData.cardsResultValues < bestResult) bestResult = (int)pdList[x].completeEvalData.cardsResultValues;
            }

            Debug.Log("bestResult : " + (TestGameCardPoker.CardsResultValues)bestResult);

            List<PlayerData> pdWinnerList = new List<PlayerData>();

            for (int x = 0; x < pdList.Count; x++)
            {
                if (pdList[x].completeEvalData.cardsResultValues == (TestGameCardPoker.CardsResultValues)bestResult)
                {
                    pdWinnerList.Add(pdList[x]);
                }
            }

            Debug.Log("pdWinnerList Count : " + pdWinnerList.Count);
            for (int x = 0; x < pdWinnerList.Count; x++)
            {
                TextResult.text = TextResult.text + "Winner : " + pdWinnerList[x].playerPosition + " result : " + pdWinnerList[x].completeEvalData.cardsResultValues + "\n";
            }


            if (pdWinnerList.Count > 1)
            {
                List<PlayerData> _res = new List<PlayerData>();
                switch ((TestGameCardPoker.CardsResultValues)bestResult)
                {
                    case TestGameCardPoker.CardsResultValues.HighCard:
                        _res = pokerCards.getWinnerCheck_HighCard(pdWinnerList);
                        foreach (PlayerData pd in _res)
                        {
                            TextResult.text = TextResult.text + "FINAL WIN NUMBER : " + _res.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.Pair:
                        _res = pokerCards.getWinnerCheck_Pair(pdWinnerList);
                        foreach (PlayerData pd in _res)
                        {
                            TextResult.text = TextResult.text + "FINAL WIN NUMBER : " + _res.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.TwoPair:
                        _res = pokerCards.getWinnerCheck_TwoPair(pdWinnerList);
                        foreach (PlayerData pd in _res)
                        {
                            TextResult.text = TextResult.text + "FINAL WIN NUMBER : " + _res.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.ThreeOfAkind:
                        _res = pokerCards.getWinnerCheck_Tris(pdWinnerList);
                        foreach (PlayerData pd in _res)
                        {
                            TextResult.text = TextResult.text + "FINAL WIN NUMBER : " + _res.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.Straight:
                        _res = pokerCards.getWinnerCheck_Straight(pdWinnerList);
                        foreach (PlayerData pd in _res)
                        {
                            TextResult.text = TextResult.text + "FINAL WIN NUMBER : " + _res.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.Flush:
                        _res = pokerCards.getWinnerCheck_Flush(pdWinnerList);
                        foreach (PlayerData pd in _res)
                        {
                            TextResult.text = TextResult.text + "FINAL WIN NUMBER : " + _res.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.FullHouse:
                        _res = pokerCards.getWinnerCheck_FullHouse(pdWinnerList);
                        foreach (PlayerData pd in _res)
                        {
                            TextResult.text = TextResult.text + "FINAL WIN NUMBER : " + _res.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.FourOfAkind:
                        _res = pokerCards.getWinnerCheck_Poker(pdWinnerList);
                        foreach (PlayerData pd in _res)
                        {
                            TextResult.text = TextResult.text + "FINAL WIN NUMBER : " + _res.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                    case TestGameCardPoker.CardsResultValues.StraightFlush:
                        _res = pokerCards.getWinner_StraightFlush(pdWinnerList);
                        foreach (PlayerData pd in _res)
                        {
                            TextResult.text = TextResult.text + "FINAL WIN NUMBER : " + _res.Count + " WINNER : " + pd.playerPosition + "\n";
                        }
                        break;
                }
            }

        }


        public void getResult()
        {

            executeResult();

        }

        public void onDropDownValueChange(Dropdown dd)
        {

            switch (dd.value)
            {
                case 0: dd.gameObject.GetComponent<Image>().color = Color.red; break;
                case 1: dd.gameObject.GetComponent<Image>().color = Color.green; break;
                case 2: dd.gameObject.GetComponent<Image>().color = Color.yellow; break;
                case 3: dd.gameObject.GetComponent<Image>().color = Color.magenta; break;
            }

        }

    }
}
//#endif