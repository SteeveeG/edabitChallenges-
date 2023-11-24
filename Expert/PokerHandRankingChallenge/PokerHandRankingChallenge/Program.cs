using PokerHandRankingChallenge;



//Link For Cahllenge : https://edabit.com/challenge/MnPogX5KgggaRpaJo
//Just display What Combination you have on your Hand 


string[] royalFlush = { "10h", "Jh", "Qh", "Ah", "Kh" };

string[] straightFlush = { "8h", "9h", "10h", "Jh", "7h" };

string[] fourOfAKind = { "10d", "10h", "10s", "6c", "10c" };

string[] fullHouse = { "10d", "10h", "10s", "6c", "6d" };

string[] flush = { "10d", "Jd", "5d", "Ad", "2d" };

string[] straight = { "5h", "6b", "7je", "8c", "9e" };

string[] threeOfAKind = { "10d", "10h", "10s", "6c", "3c" };

string[] twoPair = { "10d", "10h", "6s", "6c", "3c" };

string[] pair = { "10d", "10h", "4s", "6c", "3c" };

string[] highCard = { "Ad", "2h", "9s", "6c", "3c" };



List<string[]> combinations = new List<string[]>
{
    royalFlush, straightFlush, fourOfAKind, fullHouse, flush, straight,
    threeOfAKind,
    twoPair,
    pair,
    highCard
};



foreach (var combination in combinations)
{
    var controlHand = new ControlHand(combination);
    Console.WriteLine(controlHand.StartControlHands());
    Thread.Sleep(650);
}