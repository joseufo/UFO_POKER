using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
class EvalHand : Card
{


    public int[] Evaluate(Card[] playerHand, Card[] dealer, int cardsShown)
    {
        // Returns a size 3 int array:
        //    [0] = hand rank
        //    [1] = the high card of that hand
        //    [2] = secondary high card, if [1] was a tie with another hand
        //          ex. two pair with 8 and 6's:  [2, 8, 6]
        //              two pair with 8 and 5's:  [2, 8, 5] , (5 < 6), first hand will win

        bool pair = false;      //find use
        bool twopair = false;
        bool three = false;
        bool straight = false;
        bool flush = false;
        bool fullhouse = false; //find use
        bool four = false;
        bool straightFlush = false;     //find use
        bool royal = false;             //find use

        int[] handVal = { 0, 0, 0 };
        int[] pairs = { 0, 0 };
        int threeval = 0;
        int straightTop = 0;

        //to do: maybe turn to methods but not necessary 

        #region High Card
        handVal[0] = 0;
        handVal[1] = (int)playerHand[0].Value;
        handVal[2] = (int)playerHand[1].Value;
        #endregion

        #region Pair and 2Pair
        if (playerHand[0].Value == playerHand[1].Value)
        {
            handVal[0] = 1;
            handVal[1] = (int)playerHand[0].Value;
            pair = true;
        }
        else
        {
            for (int i = 0; i < cardsShown; i++)
            {
                if (playerHand[0].Value == dealer[i].Value)
                {
                    handVal[0] = 1;
                    handVal[1] = (int)playerHand[0].Value;
                    handVal[2] = (int)playerHand[1].Value;
                    pair = true;
                }
            }
            for (int i = 0; i < cardsShown; i++)
            {
                if (playerHand[1].Value == dealer[i].Value)
                {
                    if (pair)
                    {
                        if (handVal[1] != (int)dealer[i].Value)
                        {
                            handVal[0] = 2;
                            handVal[2] = (int)playerHand[1].Value;
                            pairs[0] = handVal[1];
                            pairs[1] = handVal[2];
                            twopair = true;
                        }
                    }
                    else
                    {
                        handVal[0] = 1;
                        handVal[1] = (int)playerHand[1].Value;
                        handVal[2] = (int)playerHand[0].Value;
                        pair = true;

                    }
                }
            }
        }


        #endregion

        #region Three
        if (playerHand[0].Value == playerHand[1].Value)
        {
            for (int i = 0; i < cardsShown; i++)
            {
                if (playerHand[0].Value == dealer[i].Value)
                {
                    handVal[0] = 3;
                    handVal[1] = (int)playerHand[0].Value;
                    handVal[2] = 0;
                    threeval = handVal[1];
                    three = true;
                }
            }
        }
        else
        {
            int threecount = 0;
            for (int i = 0; i < cardsShown; i++)
            {
                if (playerHand[0].Value == dealer[i].Value)
                {
                    threecount++;
                    if (threecount == 2)
                    {
                        handVal[0] = 3;
                        handVal[1] = (int)playerHand[0].Value;
                        handVal[2] = 0;
                        threeval = handVal[1];
                        three = true;
                        break;
                    }
                }
            }
            if (threecount != 2)
            {
                threecount = 0;
                for (int i = 0; i < cardsShown; i++)
                {
                    if (playerHand[1].Value == dealer[i].Value)
                    {
                        threecount++;
                        if (threecount == 2)
                        {
                            handVal[0] = 3;
                            handVal[1] = (int)playerHand[1].Value;
                            handVal[2] = 0;
                            three = true;
                            threeval = handVal[1];
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region Straight

        int[] straightcheck = new int[2 + cardsShown];

        straightcheck[0] = (int)playerHand[0].Value;
        straightcheck[1] = (int)playerHand[1].Value;
        for (int i = 0; i < cardsShown; i++)
            straightcheck[i + 2] = (int)dealer[i].Value;

        // Sorting and relove duplicate values
        Array.Sort(straightcheck);
        var reduced = straightcheck.Distinct().ToArray();

        //Console.Write("straigh stat, first to last " + straightcheck[0] + " " + straightcheck[straightcheck.Length - 1] + " \n\n");

        // check for wheel (lowest straight with ace as 1)
        if (reduced[0] == 2 && reduced[1] == 3 &&
            reduced[2] == 4 && reduced[3] == 5 && reduced[reduced.Length - 1] == 14)
        {
            straight = true;
            handVal[0] = 4;
            handVal[1] = 5;
            handVal[2] = 0;
            straightTop = handVal[1];
        }

        for (int i = (reduced.Length - 1); i > 3; i--)
        {
            if (reduced[i] == (reduced[i - 1] + 1))
                if (reduced[i - 1] == (reduced[i - 2] + 1))
                    if (reduced[i - 2] == (reduced[i - 3] + 1))
                        if (reduced[i - 3] == (reduced[i - 4] + 1))
                        {
                            straight = true;
                            handVal[0] = 4;
                            handVal[1] = reduced[i];
                            handVal[2] = 0;
                            straightTop = handVal[1];
                            break;
                        }
        }
        #endregion

        #region Flush
        int d_count = 0, h_count = 0, c_count = 0, s_count = 0;


        foreach (Card element in playerHand)
        {
            if (element.Suit == SUIT.CLUBS)
                c_count++;
            if (element.Suit == SUIT.SPADES)
                s_count++;
            if (element.Suit == SUIT.DIAMONDS)
                d_count++;
            if (element.Suit == SUIT.HEARTS)
                h_count++;
        }
        // foreach wont work with deal because we need "empty card" objects, 
        for (int i = 0; i < cardsShown; i++)
        {
            if (dealer[i].Suit == SUIT.CLUBS)
                c_count++;
            if (dealer[i].Suit == SUIT.SPADES)
                s_count++;
            if (dealer[i].Suit == SUIT.DIAMONDS)
                d_count++;
            if (dealer[i].Suit == SUIT.HEARTS)
                h_count++;
        }

        if (c_count == 5 || s_count == 5 || h_count == 5 || d_count == 5)
        {
            flush = true;
            handVal[0] = 5;
            handVal[1] = 0;
            handVal[2] = 0;
        }

        #endregion

        #region Full House
        if (twopair && three)
        {
            if (threeval == pairs[0])
            {
                handVal[0] = 6;
                handVal[1] = (int)playerHand[0].Value;
                handVal[2] = (int)playerHand[1].Value;
            }
            else
            {
                handVal[0] = 6;
                handVal[1] = (int)playerHand[1].Value;
                handVal[2] = (int)playerHand[0].Value;
            }
        }

        #endregion

        #region Four
        if (three)
        {
            int fourCount = 0;
            for (int i = 0; i < cardsShown; i++)
            {
                if (playerHand[0].Value == dealer[i].Value)
                    fourCount++;
            }
            if (fourCount == 3)
            {
                handVal[0] = 7;
                handVal[1] = (int)playerHand[0].Value;
                handVal[2] = 0;
                four = true;
            }
            if (!four)
            {
                fourCount = 0;
                for (int i = 0; i < cardsShown; i++)
                {
                    if (playerHand[1].Value == dealer[i].Value)
                        fourCount++;
                }
                if (fourCount == 3)
                {
                    handVal[0] = 7;
                    handVal[1] = (int)playerHand[1].Value;
                    handVal[2] = 0;
                    four = true;
                }
            }
        }
        #endregion

        #region Straight & Royal Flush 
        if (straight && flush)
        {
            Card[] fullhand = new Card[cardsShown + 2];
            fullhand[0] = playerHand[0];
            fullhand[1] = playerHand[1];
            for (int i = 0; i < cardsShown; i++)
                fullhand[i + 2] = dealer[i];

            foreach (SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach (Card c1 in fullhand)
                    if ((int)c1.Value == straightTop && c1.Suit == s)
                        foreach (Card c2 in fullhand)
                            if ((int)c2.Value == (straightTop - 1) && c2.Suit == s)
                                foreach (Card c3 in fullhand)
                                    if ((int)c3.Value == (straightTop - 2) && c3.Suit == s)
                                        foreach (Card c4 in fullhand)
                                            if ((int)c4.Value == (straightTop - 3) && c4.Suit == s)
                                                foreach (Card c5 in fullhand)
                                                    if (((int)c5.Value == straightTop - 4 && c5.Suit == s) || ((int)c5.Value == (straightTop + 9) && c5.Suit == s))
                                                    {
                                                        straightFlush = true;
                                                        if (straightTop == 14)
                                                        {
                                                            handVal[0] = 9;
                                                            handVal[1] = 0;
                                                            handVal[2] = 0;
                                                        }

                                                        else
                                                        {
                                                            handVal[0] = 8;
                                                            handVal[1] = straightTop;
                                                            handVal[2] = 0;
                                                        }
                                                    }
            }

        }
        #endregion


        return handVal;
    }
}
