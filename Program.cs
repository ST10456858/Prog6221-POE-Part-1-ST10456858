
using System;
using System.Collections.Generic;
//using System.Speech.Synthesis; // For speech
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Cybersecurity Chatbot";

        // Skip audio file playback
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nAudio playback is currently disabled.");
        Console.ResetColor();

        // Add voice greeting
        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nInitializing voice system...");
            Console.ResetColor();

           // using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
               // synth.Speak("Welcome to the Cybersecurity Chatbot");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nError with speech synthesis: " + ex.Message);
            Console.ResetColor();
        }

        // Print the ASCII art header
        PrintHeader();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nWelcome to the Cybersecurity Chatbot!");
        Console.ResetColor();

        // Ask for the user's name
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("\nWhat is your name? ");
        Console.ResetColor();

        string userName = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nHello, {userName}! Ask me anything about:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("• Phishing");
        Console.WriteLine("• Passwords");
        Console.WriteLine("• Cookies");
        Console.WriteLine("• Secure connections");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nType 'exit' to end the chat.");
        Console.ResetColor();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nYou: ");
            Console.ResetColor();

            string userInput = Console.ReadLine().ToLower();

            if (userInput == "exit")
            {
                PrintFarewell();
                break;
            }

            string response = GetResponse(userInput);
            PrintResponse(response);

            // Ask if that will be all
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nChatbot: Will that be all? (yes/no): ");
            Console.ResetColor();

            string willThatBeAll = Console.ReadLine().ToLower();

            if (willThatBeAll == "yes")
            {
                PrintFarewell();
                break;
            }
        }
    }

    static void PrintHeader()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\n $$$$$$\\ $$\\     $$\\ $$$$$$$\\  $$$$$$$$\\ $$$$$$$\\        $$$$$$$\\   $$$$$$\\ $$$$$$$$\\ $$\\ ");
        Console.WriteLine("$$  __$$\\\\$$\\   $$  |$$  __$$\\ $$  _____|$$  __$$\\       $$  __$$\\ $$  __$$\\\\__$$  __|$$ |");
        Console.WriteLine("$$ /  \\__|\\$$\\ $$  / $$ |  $$ |$$ |      $$ |  $$ |      $$ |  $$ |$$ /  $$ |  $$ |   $$ |");
        Console.WriteLine("$$ |       \\$$$$  /  $$$$$$$\\ |$$$$$\\    $$$$$$$  |      $$$$$$$\\ |$$ |  $$ |  $$ |   $$ |");
        Console.WriteLine("$$ |        \\$$  /   $$  __$$\\ $$  __|   $$  __$$<       $$  __$$\\ $$ |  $$ |  $$ |   \\__|");
        Console.WriteLine("$$ |  $$\\    $$ |    $$ |  $$ |$$ |      $$ |  $$ |      $$ |  $$ |$$ |  $$ |  $$ |       ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\\$$$$$$  |   $$ |    $$$$$$$  |$$$$$$$$\\ $$ |  $$ |      $$$$$$$  | $$$$$$  |  $$ |   $$\\ ");
        Console.WriteLine(" \\______/    \\__|    \\_______/ \\________|\\__|  \\__|      \\_______/  \\______/   \\__|   \\__|");
        Console.ResetColor();
    }

    static void PrintFarewell()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n╔════════════════════════════════════════════╗");
        Console.WriteLine("║ Chatbot: Goodbye! Stay safe online. 😊     ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.ResetColor();
    }

    static void PrintResponse(string response)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n╔════════════════════════════════════════════╗");
        Console.WriteLine("║ Chatbot: " + response.PadRight(38) + " ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.ResetColor();
    }

    static string GetResponse(string input)
    {
        var keywords = new Dictionary<string, string>
        {
            { "phishing", "Phishing is a type of cyber attack where attackers impersonate legitimate organizations to steal sensitive information. Always verify the sender's email address and avoid clicking on suspicious links." },
            { "password", "A strong password should be at least 12 characters long and include a mix of uppercase letters, lowercase letters, numbers, and special characters. Avoid using easily guessable information." },
            { "cookies", "Cookies are small files stored on your device by websites. They help improve your browsing experience but can also track your online activity. Always check your browser settings to manage cookies." },
            { "secure connection", "A secure connection is indicated by 'https://' in the URL and a padlock icon in the address bar. Avoid entering sensitive information on sites that do not have these indicators." },
            { " how to", "Please specify what you would like to know more about, such as phishing, passwords, cookies, or secure connections." }
        };

        foreach (var keyword in keywords)
        {
            if (input.Contains(keyword.Key))
            {
                // Add color coding based on topic
                if (keyword.Key == "phishing")
                    return "\x1b[38;5;208m" + keyword.Value + "\x1b[0m"; // Orange
                else if (keyword.Key == "password")
                    return "\x1b[38;5;51m" + keyword.Value + "\x1b[0m"; // Light Blue
                else if (keyword.Key == "cookies")
                    return "\x1b[38;5;156m" + keyword.Value + "\x1b[0m"; // Light Green
                else if (keyword.Key == "secure connection")
                    return "\x1b[38;5;213m" + keyword.Value + "\x1b[0m"; // Pink

                return keyword.Value;
            }
        }

        return "\x1b[38;5;160mI'm sorry, I didn't understand that. Can you please ask about phishing, passwords, cookies, or secure connections?\x1b[0m"; // Red
    }
}