using System.Text.RegularExpressions;

namespace PokerHandRankingChallenge;

public class ControlHand
{
    private string[] face;
    private string[] suits;
    private string[] royalFlush;
    private string[] straightflush;
    public ControlHand(string[] hand)
    {
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


    private string ControlRest()
    {
        var allcards = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        var CountCards = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        foreach (var cardFace in face)
        {
            for (int i = 0; i < allcards.Count; i++)
            {
                if (cardFace == allcards[i])
                {
                    CountCards[i]++;
                }
            }
        }

        if (CountCards.Contains(2) || CountCards.Contains(3) || CountCards.Contains(4))
        {
            var countPair = CountCards.Count(i => i == 2);
            var threeOfAKind = CountCards.Count(i => i == 3) == 1;
            var fourOfAKind = CountCards.Count(i => i == 4) == 1;
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
            for (int i = 0; i < CountCards.Count; i++)
            {
                if (CountCards[i] == 1 && indexLastCard == -1)
                {
                    indexLastCard = i;
                    straight++;
                }
                else if (CountCards[i] == 1 && indexLastCard + 1 == i)
                {
                    straight++;
                    indexLastCard++;
                }
            }

            if (straight == 5)
            {
                return "Straight";
            }

            for (int i = CountCards.Count - 1; i >= 0; i--)
            {
                if (CountCards[i] == 1)
                {
                    return $"HighCard  Card: {allcards[i]}";
                }
            }
        }
        return "No Combinaiton";
    }

    private bool ControlStraightFlush()
    {
        var firstindex = 0;
        for (var i = 0; i < 5; i++)
        {
            if (i == 0)
            {
                for (var j = 0; j < straightflush.Length; j++)
                {
                    if (face[i] == straightflush[j])
                    {
                        firstindex = j;
                        if (face[1] != straightflush[firstindex + 1])
                        {
                            return false;
                        }

                        break;
                    }
                }
            }

            if (face[i] == straightflush[firstindex])
            {
                firstindex++;
            }
            else
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
        for (var i = 0; i < 5; i++)
        {
            if (face[i] == royalFlush[i])
            {
                counter++;
            }
        }

        return counter == 5;
    }
}