using DraftingAppv2;
using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        //easier path finding
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string projectRoot = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
        string playerData = Path.Combine(projectRoot, "data", "testData.csv");

        var players = PlayerFunctions.playerReader(playerData);
        string? teamName = "";
        bool started = false;
        bool running = true;
        List<Player> team = new List<Player>();
        int numOfPicks = 7;
        

        while(running)
        {

            string? input;

            if (!started) 
            {
                Console.Clear();
                Console.WriteLine("Welcome to the NHL Draft program!");
                Console.Write("Press Q to get started:");
                input = Console.ReadLine()?.ToLower();

                if (input == "q")
                {
                    Console.Write("Enter Team Name:");
                    teamName = Console.ReadLine();
                    started = true;
                }
                else
                {
                    Console.WriteLine($"{input} is Invalid!");
                }
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine(new string('-', 100));
                Console.WriteLine(teamName);
                Console.WriteLine(new string('-',100));
                Console.WriteLine("1. View All Players");
                Console.WriteLine("2. Filter by Position");
                Console.WriteLine("3. Draft a Player");
                Console.WriteLine("4. View Team");
                Console.WriteLine("5. Edit Team");
                Console.WriteLine("6. Close");
                Console.Write("Choose an option:");
                input = Console.ReadLine();

                switch(input)
                {
                    //Display Players 
                    case "1":
                        PlayerFunctions.DisplayPlayers(players);
                        break;

                    //Filter by pos
                    case "2":
                        Console.Write("Enter Position to filer(C,R,L,D,G):");
                        string? pos = Console.ReadLine()?.ToLower();
                        PlayerFunctions.DisplayPlayers(players.Where(p => p.playerPos.Equals(pos, StringComparison.OrdinalIgnoreCase)).ToList());
                        break;

                    //Drafting
                    case "3":
                        Console.WriteLine($"You have {numOfPicks} picks left!");
                        Console.Write("Enter ranking of player to Draft:");

                        if (int.TryParse(Console.ReadLine(), out int draftedPlayer))
                        {
                            var player = players.FirstOrDefault(p => p.Ranking == draftedPlayer);

                            if(player != null && !player.isDrafted)
                            {
                                player.isDrafted = true;
                                TeamFunctions.addPlayer(player, team);
                                Console.WriteLine($"You Drafted {player.playerName} !");
                                numOfPicks--;

                            }
                            else
                            {
                                Console.WriteLine("Played Cannot be drafted!");
                            }
                        }
                        break;
                    //Display Team
                    case "4":
                        TeamFunctions.DisplayTeam(team);
                        break;
                    case "5":
                        TeamFunctions.DisplayTeam(team);
                        break;
                    //End
                    case "6":
                        running = false;
                        started = false;
                        break;
                }
            }

            
            
        }

    }
}
