using System.IO;

namespace tic_tac_tor_MobileApp
{
    public class FileManager
    {
        private static string FilePath => Path.Combine(FileSystem.AppDataDirectory, "gameData.txt");
        public static async Task SaveToFile(string winner, string time)
        {
            string line = $"{DateTime.Now};{winner};{time}";
            //System.Diagnostics.Debug.WriteLine($"Файл сохраняется здесь: {FilePath}");
            await File.AppendAllTextAsync(FilePath, line + Environment.NewLine);
        }

        public static async Task<List<string>> LoadDataFromFile()
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
