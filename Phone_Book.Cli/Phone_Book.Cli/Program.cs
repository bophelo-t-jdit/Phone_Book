using Phone_Book.Cli.App; // App Class


namespace Phone_Book.Cli
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            App.App app = new App.App();

            while (true)
            {
                await app.Start();
            }
        }
    }
}
