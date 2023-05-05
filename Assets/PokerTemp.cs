using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PokerTemp : MonoBehaviour
{


    class Ranks
    {
        public string getString(int num)
        {
            if (num == 0)
                return "High Card";
            if (num == 1)
                return "Pair";
            if (num == 2)
                return "Two Pair";
            if (num == 3)
                return "Three of a Kind";
            if (num == 4)
                return "Straight";
            if (num == 5)
                return "Flush";
            if (num == 6)
                return "Full House";
            if (num == 7)
                return "Four of a Kind";
            if (num == 8)
                return "Straight Flush";
            if (num == 9)
                return "Royal Flush";

            return "";
        }
    }


}
