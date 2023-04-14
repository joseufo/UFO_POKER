using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace TestPoker
{


    [System.Serializable]
    public class PlayerData
    {

        public GameObject playerGameObject;



        public string playerName;
        public int playerPosition;
        public bool isLocalPlayer = false;

        public TestGameCardPoker.CompleteResultStruct completeEvalData;

        public bool isOutOfGame = false;
        public bool runOutOfMoney = false;
        public bool underAllin = false;
        public bool isObserver = false;






        public Card card1data;
        public Card card2data;

        public Transform transform_card_1;
        public Transform transform_card_2;

        public int coeffCardsValOnFlopPhase = 0;
        public int maxCardValOnFlopPhase = 0;
        //public int maxCardValueOnShowDown = 0;





    }
}