using System;

public class Class1
{
    public class PotData
    {
        public float PotAmount { get; set; }
        public List<PlayerData> PotPlayers { get; set; }
    }

    public class PlayerData
    {
        public string Name { get; set; }
        public float BetAmount { get; set; }
    }

    public class PokerGame
    {
        private PotData MainPot;
        private List<PotData> SidePots;

        public PokerGame()
        {
            MainPot = new PotData();
            SidePots = new List<PotData>();
        }

        public void AddPlayerToMainPot(string playerName, float betAmount)
        {
            PlayerData player = new PlayerData { Name = playerName, BetAmount = betAmount };
            MainPot.PotPlayers.Add(player);
            MainPot.PotAmount += betAmount;
        }

        public void AddPlayerToSidePot(string playerName, float betAmount)
        {
            if (SidePots.Count == 0)
            {
                SidePots.Add(new PotData());
            }

            PlayerData player = new PlayerData { Name = playerName, BetAmount = betAmount };
            SidePots[SidePots.Count - 1].PotPlayers.Add(player);
            SidePots[SidePots.Count - 1].PotAmount += betAmount;
        }

        public void AddPlayersToPots(Dictionary<string, float> playerBets)
        {
            List<string> players = new List<string>(playerBets.Keys);

            // Sort players by bet amount in descending order
            players.Sort((p1, p2) => playerBets[p2].CompareTo(playerBets[p1]));

            foreach (string player in players)
            {
                float betAmount = playerBets[player];

                // Check if the player's bet can be added to the main pot
                if (MainPot.PotAmount == 0 || betAmount >= MainPot.PotAmount)
                {
                    AddPlayerToMainPot(player, betAmount);
                }
                else
                {
                    // Check if there are existing side pots
                    if (SidePots.Count == 0)
                    {
                        SidePots.Add(new PotData());
                    }

                    // Calculate the remaining bet amount
                    float remainingBetAmount = betAmount;
                    foreach (PotData sidePot in SidePots)
                    {
                        remainingBetAmount -= sidePot.PotAmount;
                    }

                    // Check if the remaining bet can be added to the current side pot
                    if (remainingBetAmount > 0)
                    {
                        AddPlayerToSidePot(player, remainingBetAmount);
                    }
                }
            }
        }

        public void Test()
        {
            Dictionary<string, float> playerBets = new Dictionary<string, float>
            {
                { "Player 1", 20 },
                { "Player 2", 30 },
                { "Player 3", 50 },
                { "Player 4", 60 },
                { "Player 5", 40 }
            };

            AddPlayersToPots(playerBets);

            // Output main pot details
            Console.WriteLine("Main Pot Amount: $" + MainPot.PotAmount);
            Console.WriteLine("Main Pot Players:");
            foreach (PlayerData player in MainPot.PotPlayers)
            {
                Console.WriteLine(player.Name + ": $" + player.BetAmount);
            }

            // Output side pot details
            foreach (PotData sidePot in SidePots)
            {
                Console.WriteLine("Side Pot Amount: $" + sidePot.PotAmount);
                Console.WriteLine("Side Pot Players:");
                foreach (PlayerData player in sidePot.PotPlayers)
                {
                    Console.WriteLine(player.Name + ": $" + player.BetAmount);
                }
            }
        }
    }
}
potPlayers list

add folded players

while potPlayerlist.count !==0

	take minBet min (potPlayer.playertotalbet)

	foreach player in potplayerlist

    {
    player.playertotalbet -= minBet;
    if (player.playertotalbet == 0)
        potPlayerlist.remove(player)


    }