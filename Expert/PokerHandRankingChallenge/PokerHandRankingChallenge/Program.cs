using PokerHandRankingChallenge;


//Link For Cahllenge : https://edabit.com/challenge/MnPogX5KgggaRpaJo
//Just display What Combination you have on your Hand 

var combinations = new List<string[]>();
combinations.Add(new[] {"10h", "Jh", "Qh", "Ah", "Kh" });
combinations.Add(new[] {"3h", "5h", "Qs", "9h", "Ad" });
combinations.Add(new[] {"10s", "10c", "8d", "10d", "10h" });
combinations.Add(new[] {"4h", "9s", "2s", "2d", "Ad" });
combinations.Add(new[] {"10s", "9s", "8s", "6s", "7s" });
combinations.Add(new[] {"10c", "9c", "9s", "10s", "9h" });
combinations.Add(new[] {"8h", "2h", "8s", "3s", "3c" });
combinations.Add(new[] {"Jh", "9h", "7h", "5h", "2h" });
combinations.Add(new[] {"Ac", "Qc", "As", "Ah", "2d" });
combinations.Add(new[] {"Ad", "Kd", "Qd", "Jd", "9d" });
combinations.Add(new[] {"10h", "Jh", "Qs", "Ks", "Ac" });
combinations.Add(new[] {"3h", "8h", "2s", "3s", "3d" });
combinations.Add(new[] {"4h", "Ac", "4s", "4d", "4c" });
combinations.Add(new[] {"3h", "8h", "2s", "3s", "2d" });
combinations.Add(new[] {"8h", "8s", "As", "Qh", "Kh" });
combinations.Add(new[] {"Js", "Qs", "10s", "Ks", "As" });
combinations.Add(new[] {"Ah", "3s", "4d", "Js", "Qd" });


foreach (var combination in combinations)
{
    var controlHand = new ControlHand(combination);
    Console.WriteLine(controlHand.StartControlHands());
    Thread.Sleep(650);
}

// [TestCase("10h Jh Qh Ah Kh", Result="Royal Flush")]
// [TestCase("3h 5h Qs 9h Ad", Result="High Card")]
// [TestCase("10s 10c 8d 10d 10h", Result="Four of a Kind")]
// [TestCase("4h 9s 2s 2d Ad", Result="Pair")]
// [TestCase("10s 9s 8s 6s 7s", Result="Straight Flush")] Failed
// [TestCase("10c 9c 9s 10s 9h", Result="Full House")]
// [TestCase("8h 2h 8s 3s 3c", Result="Two Pair")]
// [TestCase("Jh 9h 7h 5h 2h", Result="Flush")]
// [TestCase("Ac Qc As Ah 2d", Result="Three of a Kind")]
// [TestCase("Ad Kd Qd Jd 9d", Result="Flush")]
// [TestCase("10h Jh Qs Ks Ac", Result="Straight")]
// [TestCase("3h 8h 2s 3s 3d", Result="Three of a Kind")]
// [TestCase("4h Ac 4s 4d 4c", Result="Four of a Kind")]
// [TestCase("3h 8h 2s 3s 2d", Result="Two Pair")]
// [TestCase("8h 8s As Qh Kh", Result="Pair")]
// [TestCase("Js Qs 10s Ks As", Result="Royal Flush")] Failed
// [TestCase("Ah 3s 4d Js Qd", Result="High Card")] 