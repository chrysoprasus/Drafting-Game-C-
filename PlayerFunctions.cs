using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Player
{
    public int Ranking {  get; set; }
    public String playerName { get; set; }
    public String playerPos { get; set; }
    public String juniorTeam { get; set; }
    public bool isDrafted { get; set; }

}


namespace DraftingAppv2  
{
    internal class PlayerFunctions
    {
        public static List<Player> playerReader(string filePath)
        {

            var players = new List<Player>();

            try
            {
                using(StreamReader reader = new StreamReader(filePath))
                {
                    string? line;
                    bool isFirstLine = true;
                    int ranking = 1;


                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue;
                        }

                        string[] values = line.Split(',');

                        //skip lines that dont have 3 values
                        if (values.Length < 3) continue;

                        players.Add(new Player 
                        {
                            Ranking = ranking++,
                            playerName = values[0].Trim(),
                            playerPos = values[1].Trim(),
                            juniorTeam = values[2].Trim()

                        });

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return players;
        }

        public static void DisplayPlayers(List<Player> players)
        {
            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"{"Ranking",-10}{"Player",-25}{"Position",-10}{"Junior Team",-40}{"Drafted"}");
            Console.WriteLine(new string('-',100));

            foreach(var p in players)
            {
                Console.WriteLine($"{p.Ranking,-10}{p.playerName,-25}{p.playerPos,-10}{p.juniorTeam,-40}{(p.isDrafted ? "✓" : " ")}");
            }
        }

    }
}
