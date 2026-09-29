/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // Ignore header row

        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            // Accumulate total career points per player ID
            if (players.ContainsKey(playerId)) {
                players[playerId] += points;
            } else {
                players[playerId] = points;
            }
        }

        // Convert the dictionary to an array and sort descending by points score
        var topPlayers = players.ToArray();
        Array.Sort(topPlayers, (p1, p2) => p2.Value.CompareTo(p1.Value));

        // Display the top 10 scoring players
        Console.WriteLine("\nTop 10 Players by Points:");
        for (var i = 0; i < 10 && i < topPlayers.Length; ++i) {
            Console.WriteLine(topPlayers[i]);
        }
    }
}