using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using Phone_Book.Cli.App.Services;
using System.Text.RegularExpressions;
using Phone_Book.Cli.App.Utils;

namespace Phone_Book.Cli.App
{
    internal class App
    {
        public async Task Start()
        {
            var _client = new HttpClient 
            {
                BaseAddress = new Uri("https://localhost:7056/")
            };

            InputHelper input = new InputHelper();

            bool authenticated = false;

            Console.WriteLine(
                "\n===========================" +
                "\nPhone Book CLI Application!" +
                "\n==========================="
             );

            Console.Write(
                "\n1. Register/Login\n2. View Contacts\n3. Add Contact" + 
                "\n4. Update Contact\n5. Delete Contact\n0. Exit\nPlease select an option: "
             );

            string option = Console.ReadLine() ?? "";

            if (option == null || option == "")
            {
                Console.WriteLine("\nInvalid option. Please try again.");
                return;
            }

            try
            {
                int getOption = Convert.ToInt32(option);

                switch (getOption)
                {
                    case 1:
                        if (authenticated == false)
                        {
                            await RegisterUser(_client, input);
                        }
                        else
                        {
                            Console.WriteLine("\nYou are already logged in.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("\nExiting the application. Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nInvalid option. Please try again.");
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"\nInvalid input. Ensure your input is a number and a valid option. {e.Message}");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nAn error occurred: {e.Message}");
                return;
            }

        }

        private async Task RegisterUser(HttpClient _client, InputHelper input)
        {
            var passwordRegex = new Regex(@"^(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?=.*\d).+$");

            List<string> emailProviders = new List<string> { "gmail.com", "yahoo.com", "outlook.com", "hotmail.com" };

            Console.WriteLine(
                "\n===========================" +
                "\nRegister" +
                "\n==========================="
             );

            Console.Write("\nPlease enter your email: ");

            string email = Console.ReadLine() ?? "";

            Console.Write("\nPlease enter your password: ");

            string password = input.ReadPassword() ?? "";

            if (email == "" || email == null)
            {
                Console.WriteLine("\nEmail cannot be empty.");
                return;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("\nEmail must be a valid email address.");
                return;
            } 
            else if (!emailProviders.Exists(provider => email.EndsWith("@" + provider)))
            {
                Console.WriteLine("\nEmail must be from a valid provider (gmail.com, yahoo.com, outlook.com, hotmail.com).");
                return;
            }

            if (password == "" || password == null)
            {
                Console.WriteLine("\nPassword cannot be empty.");
                return;
            }
            else if (password.Length < 8)
            {
                Console.WriteLine("\nPassword must be at least 8 characters long.");
                return;
            }
            else if (password.Length > 100)
            {
                Console.WriteLine("\nPassword cannot exceed 100 characters.");
                return;
            }
            else if (!passwordRegex.IsMatch(password))
            {
                Console.WriteLine("\nPassword must contain at least one uppercase letter, one special character, and one digit.");
                return;
            }

            Console.Write("\nPlease enter a username you want: ");
            string username = Console.ReadLine() ?? "";

            if (username == "" || username == null)
            {
                Console.WriteLine("\nUsername cannot be empty.");
                return;
            }
            else if (username.Length < 3)
            {
                Console.WriteLine("\nUsername must be at least 3 characters long.");
                return;
            }
            else if (username.Length > 50)
            {
                Console.WriteLine("\nUsername cannot exceed 50 characters.");
                return;
            }

            RegisterRequest registerRequest = new RegisterRequest
            {
                Username = username,
                Email = email,
                Password = password
            };

            var response = await _client.PostAsJsonAsync("api/v1/user/register", registerRequest);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("\nRegistration successful!\n\nStatus: OK");
            }
            else
            {
                Console.WriteLine($"\nRegistration failed. Status: {response.StatusCode}");
            }
        }
    }
}
