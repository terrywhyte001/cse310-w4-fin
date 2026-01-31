using System;
using System.Collections.Generic;

namespace PersonalFinanceManager.Services
{
    /// <summary>
    /// Provides input validation utilities
    /// Demonstrates: Input validation requirements
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validates and gets a decimal input from user
        /// </summary>
        public static decimal GetValidDecimal(string prompt, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Input cannot be empty.");
                    continue;
                }

                if (decimal.TryParse(input, out decimal result))
                {
                    if (result < min || result > max)
                    {
                        Console.WriteLine($"Error: Amount must be between {min} and {max}.");
                        continue;
                    }
                    return result;
                }

                Console.WriteLine("Error: Please enter a valid decimal number.");
            }
        }

        /// <summary>
        /// Validates and gets an integer input from user
        /// </summary>
        public static int GetValidInteger(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Input cannot be empty.");
                    continue;
                }

                if (int.TryParse(input, out int result))
                {
                    if (result < min || result > max)
                    {
                        Console.WriteLine($"Error: Number must be between {min} and {max}.");
                        continue;
                    }
                    return result;
                }

                Console.WriteLine("Error: Please enter a valid integer.");
            }
        }

        /// <summary>
        /// Validates and gets a string input from user
        /// </summary>
        public static string GetValidString(string prompt, int minLength = 1, int maxLength = 100)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Input cannot be empty.");
                    continue;
                }

                if (input.Length < minLength || input.Length > maxLength)
                {
                    Console.WriteLine($"Error: Input length must be between {minLength} and {maxLength} characters.");
                    continue;
                }

                return input.Trim();
            }
        }

        /// <summary>
        /// Validates and gets a date input from user
        /// </summary>
        public static DateTime GetValidDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Input cannot be empty.");
                    continue;
                }

                if (DateTime.TryParse(input, out DateTime result))
                {
                    if (result > DateTime.Now)
                    {
                        Console.WriteLine("Error: Date cannot be in the future.");
                        continue;
                    }
                    return result;
                }

                Console.WriteLine("Error: Please enter a valid date (format: yyyy-MM-dd).");
            }
        }

        /// <summary>
        /// Gets a choice from a list of options
        /// </summary>
        public static string GetValidChoice(string prompt, List<string> options)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.ToUpper();

                if (options.Contains(input))
                {
                    return input;
                }

                Console.WriteLine($"Error: Please enter one of: {string.Join(", ", options)}");
            }
        }

        /// <summary>
        /// Validates amount is positive
        /// </summary>
        public static bool IsValidAmount(decimal amount)
        {
            return amount > 0;
        }

        /// <summary>
        /// Validates string is not null or empty
        /// </summary>
        public static bool IsValidString(string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
