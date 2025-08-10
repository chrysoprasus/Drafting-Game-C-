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
        bool started = false;
        bool running = true;
        List<Player> team2 = new List<Player>();
        int numOfPicks = 8;

        Team team = new Team();
        

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
                    string? newName = Console.ReadLine();
                    TeamFunctions.nameTeam(team, newName);
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
                Console.WriteLine(TeamFunctions.getTeamName(team));
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
                        Console.WriteLine(" ");
                        Console.Write("Enter Position to filer(C,R,L,D,G):");
                        string? pos = Console.ReadLine()?.ToLower();
                        PlayerFunctions.DisplayPlayers(players.Where(p => p.playerPos.Equals(pos, StringComparison.OrdinalIgnoreCase)).ToList());
                        break;

                    //Drafting
                    case "3":
                        Console.WriteLine(" ");
                        Console.WriteLine($"You have {numOfPicks} picks left!");
                        Console.Write("Enter ranking of player to Draft:");

                        if (int.TryParse(Console.ReadLine(), out int draftedPlayer))
                        {
                            var player = players.FirstOrDefault(p => p.Ranking == draftedPlayer);

                            if (player != null && !player.isDrafted && numOfPicks > 0)
                            {
                                player.isDrafted = true;
                                TeamFunctions.addPlayer(player, TeamFunctions.teamPlayers(team));
                                Console.WriteLine($"You Drafted {player.playerName} !");
                                Console.WriteLine(" ");
                                numOfPicks--;

                            }
                            else if (numOfPicks <= 0)
                            {
                                Console.WriteLine("Out of Picks!");
                            }
                            else
                            {
                                Console.WriteLine("Played Cannot be drafted!");
                            }
                        }
                        break;
                    //Display Team
                    case "4":
                        Console.WriteLine(" ");
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine(TeamFunctions.getTeamName(team));
                        TeamFunctions.DisplayTeam(TeamFunctions.teamPlayers(team));
                        Console.WriteLine(" ");
                        break;
                    //Edit Team
                    case "5":
                        Console.WriteLine(" ");
                        Console.Write("Enter New Team Name:");
                        string? newName = Console.ReadLine();
                        Console.Write("Team Name Changed!");
                        Console.WriteLine(" ");
                        TeamFunctions.nameTeam(team, newName);
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
