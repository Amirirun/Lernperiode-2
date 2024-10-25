using System;

using System;

class Program
{
    static void Main(string[] args)
    {
        string passwort = "ghostesel33";
        string eingabe;

        Console.WriteLine("Geben Sie Ihr Passwort ein:");
        eingabe = Console.ReadLine();

        if (eingabe == passwort)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Das Passwort ist richtig");

            Console.WriteLine("Wilkommen, möchten Sie die Daten sehen? (ja/nein)");
            string antwort = Console.ReadLine();

            if (antwort == "ja")
            {
                Console.WriteLine("Die streng geheimen Daten lauten:");
                Console.WriteLine("1. Geheimer Code: 12345");
                Console.WriteLine("2. Projektname: Alpha");
                Console.WriteLine("3. Zugangsschlüssel: ZXCVBNM");
            }
            else if (antwort == "nein")
            {
                Console.WriteLine("Keine Daten werden angezeigt.");
            }
            else
            {
                Console.WriteLine("Ungültige Antwort.");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Das Passwort ist falsch");
        }

        
        Console.ResetColor();
    }
}




