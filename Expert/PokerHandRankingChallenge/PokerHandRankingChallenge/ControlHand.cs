using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PokerHandRankingChallenge;

public class ControlHand
{
    private string[] face;
    private string[] suits;
    private string[] royalFlush;
    private string[] straightflush;
    private List<string> allcards;
    private List<int> countCards;

    public ControlHand(string[] hand)
    {
        allcards = new() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        countCards = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var unsplittedHand = hand;
        face = new string[5];
        suits = new string[5];
        royalFlush = new[] { "10", "J", "Q", "A", "K" };
        straightflush = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        int lengthSubString;
        for (var i = 0; i < unsplittedHand.Length; i++)
        {
            var cardFace = Regex.Split(unsplittedHand[i], @"[a-z]")[0];
            //you also just could build a Regex only for 10 but i think its too much for one use 
            lengthSubString = cardFace == "10" ? 2 : 1;

            face[i] = unsplittedHand[i].Substring(0, lengthSubString);
            suits[i] = unsplittedHand[i].Substring(lengthSubString, 1);
        }
    }


    public string StartControlHands()
    {
        CountCards();

        if (ControlSameSuit())
        {
            if (ControlRoyalFlush())
            {
                return "Royal Flush";
            }

            if (ControlStraightFlush())
            {
                return "Straight Flush";
            }

            //if all Suits are same the more value Combinaiton Four of a Kind
            //and Full Jouse are impossible to achive so it goues right to Flush
            //and if its not RoyalFlush or StraightFlush its 100 % a Flush :D
            return "Flush";
        }

        var wichCombination = ControlRest();
        if (wichCombination != "No Combinaiton")
        {
            return wichCombination;
        }

        return "Result";
    }

    private void CountCards()
    {
        foreach (var cardFace in face)
        {
            for (var i = 0; i < allcards.Count; i++)
            {
                if (cardFace == allcards[i])
                {
                    countCards[i]++;
                }
            }
        }
    }


    private string ControlRest()
    {
        if (countCards.Contains(2) || countCards.Contains(3) || countCards.Contains(4))
        {
            var countPair = countCards.Count(i => i == 2);
            var threeOfAKind = countCards.Count(i => i == 3) == 1;
            var fourOfAKind = countCards.Count(i => i == 4) == 1;
            var onePair = countPair == 1;
            var twoPair = countPair == 2;

            if (fourOfAKind)
            {
                return "Four of A Kind";
            }

            if (threeOfAKind && onePair)
            {
                return "Full House";
            }

            if (threeOfAKind)
            {
                return "Three of A Kind";
            }

            if (twoPair)
            {
                return "Two Pair";
            }

            if (onePair)
            {
                return "One Pair";
            }
        }
        else
        {
            var straight = 0;
            var indexLastCard = -1;
            for (int i = 0; i < countCards.Count; i++)
            {
                if (countCards[i] == 1 && indexLastCard == -1)
                {
                    indexLastCard = i;
                    straight++;
                }
                else if (countCards[i] == 1 && indexLastCard + 1 == i)
                {
                    straight++;
                    indexLastCard++;
                }
            }

            if (straight == 5)
            {
                return "Straight";
            }

            for (int i = countCards.Count - 1; i >= 0; i--)
            {
                if (countCards[i] == 1)
                {
                    return $"HighCard  Card: {allcards[i]}";
                }
            }
        }

        return "No Combinaiton";
    }

    private bool ControlStraightFlush()
    {
        var startIndex = -1;
        for (var i = 0; i < 13; i++)
        {
            if (countCards[i] == 1)
            {
                startIndex = i;
                break;
            }
        }
        for (int i = startIndex; i < startIndex + 4; i++)
        {
            if (countCards[i] != 1)
            {
                return false;
            }
        }
 
        return true;
    }

    private bool ControlSameSuit()
    {
        if (suits.Count(suit => suit.Equals(suits[0])) != 5)
        {
            return false;
        }

        return true;
    }

    private bool ControlRoyalFlush()
    {
        var counter = 0;
        for (int i = 13 - 1; i >= 8; i--)
        {
            if (countCards[i] == 1)
            {
                counter++;
            }
        }
        return counter == 5;
    }
}