using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Team
{
    public string teamName { get; set; }
    public List<Player> players { get; set; } = new List<Player>();
}

namespace DraftingAppv2
{
    internal class TeamFunctions
    {
        public static void addPlayer(Player plr, List<Player> team)
        {
            team.Add(plr);
        }

        public static void removePlayer(Player plr, List<Player> team)
        { 
            team.Remove(plr);
        }
        
        public static void DisplayTeam(List<Player> team)
        {
            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"{"Ranking",-10}{"Player",-25}{"Position",-10}{"Junior Team",-40}{"Drafted"}");
            Console.WriteLine(new string('-', 100));

            foreach (var p in team)
            {
                Console.WriteLine($"{p.Ranking,-10}{p.playerName,-25}{p.playerPos,-10}{p.juniorTeam,-40}{(p.isDrafted ? "✓" : " ")}");
            }
        }
        public static void nameTeam(Team t, string name)
        {
            t.teamName = name;
        }

        public static string getTeamName(Team t)
        {
            return t.teamName;
        }

        public static List<Player> teamPlayers(Team t)
        {
            return t.players;
        }
    }
}
