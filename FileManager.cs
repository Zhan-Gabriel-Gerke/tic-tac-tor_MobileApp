using System.IO;

namespace tic_tac_tor_MobileApp
{
    public class FileManager
    {
        private static string fileName = "gameData.txt";
        private static string FilePath => Path.Combine(FileSystem.AppDataDirectory, fileName);

        public static async Task SaveGame(string winner, string time)
        {
            string line = $"{DateTime.Now};{winner};{time}";
            await File.AppendAllTextAsync(FilePath, line + Environment.NewLine);
        }

        public static async Task<List<string>> LoadGameAsync()
        {
            var list = new List<string>();
            if (File.Exists(FilePath))
            {
                var lines = await File.ReadAllLinesAsync(FilePath);
                list.AddRange(lines);
            }
            return list;
        }
    }

}
