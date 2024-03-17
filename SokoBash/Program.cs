using SokoBash;

internal class Program
{
    public static SceneManager StartGameByPath(string path)
    {
        try
        {
            return new SceneManager(path);

        } catch (System.IO.DirectoryNotFoundException e)
        {
            return null;

        }
    }
    private static void Main(string[] args)
    {
        string filepath = @"..\..\..\..\sokobash_levels";
        SceneManager sokoBash = null;
        try
        {
            sokoBash = new SceneManager(filepath);
        } catch (System.IO.DirectoryNotFoundException e)
        {
            while(sokoBash == null)
            {
                Console.WriteLine("Level Folder invalid. please provide a valid folder path:");
                string userFileInput = Console.ReadLine();
                if (userFileInput != String.Empty)
                {
                    sokoBash = StartGameByPath(userFileInput);
                }
            }
        }

        ConsoleKey key;
        do
        {
            sokoBash.ShowTitleScreen();
            key = Console.ReadKey().Key;

        } while (key != ConsoleKey.Enter && key != ConsoleKey.F1);
        if (key == ConsoleKey.F1) {
            int starterLevelIndex = sokoBash.ShowLevelSelect();
            sokoBash.ShowLevels(starterLevelIndex);
        }
        else
        {
            sokoBash.ShowLevels(0);
        }
        sokoBash.ShowCredits();
    }
}