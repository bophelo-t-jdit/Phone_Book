using System;
using System.Collections.Generic;
using System.Text;

namespace Phone_Book.Cli.App
{
    internal class InputHelper
    {
        public string ReadPassword()
        {
            var password = new StringBuilder();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password.Remove(password.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
            }

            return password.ToString();
        }
    }
}
