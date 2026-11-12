using Phone_Book.Cli.App; // App Class


namespace Phone_Book.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App.App app = new App.App();

            int count = 6;

            while (count > 0)
            {
                app.Start();
                count--;
            }
        }
    }
}
