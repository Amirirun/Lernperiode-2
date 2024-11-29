using System;

class CombinedProgram
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Wilkommen im Hauptmenü!");
            Console.WriteLine("Wählen Sie eine Option:");
            Console.WriteLine("1 - BMI-Rechner");
            Console.WriteLine("2 - Kalorienrechner");
            Console.WriteLine("3 - Hydration Tracker");
            Console.WriteLine("4 - Körperfettanteil-Rechner");
            Console.WriteLine("0 - Programm beenden");

            string auswahl = Console.ReadLine();

            switch (auswahl)
            {
                case "1":
                    BmiRechner();
                    break;
                case "2":
                    KalorienRechner(); 
                    break;
                case "3":
                    HydrationTracker();
                    break;
                case "4":
                    KoerperfettanteilRechner();
                    break;
                case "0":
                    Console.WriteLine("Programm wird beendet. Auf Wiedersehen!");
                    return;
                default:
                    Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                    break;
            }
        }
    }

    static void BmiRechner()
    {
        // BMI-Rechner Logik hier (aus kalorienxbmi.cs)
        Console.WriteLine("BMI-Rechner");
        string gewichtbmi;
        double gewichtbmi1;
        string groessebmi;
        double groessebmi1;
        double bmi;

        while (true)
        {
            Console.WriteLine("Gebe dein Gewicht in kg ein:");
            gewichtbmi = Console.ReadLine();

            if (double.TryParse(gewichtbmi, out gewichtbmi1) && gewichtbmi1 > 0 && gewichtbmi1 < 250)
                break;
            Console.WriteLine("Ungültige Eingabe.");
        }

        while (true)
        {
            Console.WriteLine("Gebe deine Größe in Metern (z. B. 1,75) ein:");
            groessebmi = Console.ReadLine();

            if (double.TryParse(groessebmi, out groessebmi1) && groessebmi1 > 0 && groessebmi1 < 2.5)
                break;
            Console.WriteLine("Ungültige Eingabe.");
        }

        bmi = gewichtbmi1 / (groessebmi1 * groessebmi1);
        Console.WriteLine($"Dein BMI beträgt: {bmi:F2}");
        if (bmi < 18.5)
            Console.WriteLine("Kategorie: Untergewicht");
        else if (bmi >= 18.5 && bmi < 24.9)
            Console.WriteLine("Kategorie: Normalgewicht");
        else if (bmi >= 25 && bmi < 29.9)
            Console.WriteLine("Kategorie: Übergewicht");
        else
            Console.WriteLine("Kategorie: Adipositas");
    }

    static void KalorienRechner()
    {
        // Kalorienrechner Logik hier (aus kalorienxbmi.cs)
        Console.WriteLine("Kalorienrechner");
        double gewicht1 = GetDoubleInput("Gebe dein Gewicht in kg ein (1-250): ", 1, 250);
        int groesse1 = GetIntInput("Gebe deine Größe in cm ein (26-219): ", 26, 219);
        int alter1 = GetIntInput("Gebe dein Alter in Jahren ein (1-99): ", 1, 99);

        double aktiv1 = 0;
        while (aktiv1 == 0)
        {
            Console.WriteLine("Wie aktiv bist du (1-5):");
            Console.WriteLine("1. Sitzend (wenig Bewegung)");
            Console.WriteLine("2. Leicht aktiv (Sport an 1-3 Tagen)");
            Console.WriteLine("3. Moderat aktiv (Sport an 3-5 Tagen)");
            Console.WriteLine("4. Sehr aktiv (Sport an 6-7 Tagen)");
            Console.WriteLine("5. Extrem aktiv (Hochleistungssportler)");
            if (double.TryParse(Console.ReadLine(), out aktiv1) && aktiv1 >= 1 && aktiv1 <= 5)
            {
                aktiv1 = aktiv1 switch
                {
                    1 => 1.2,
                    2 => 1.375,
                    3 => 1.55,
                    4 => 1.725,
                    5 => 1.9,
                    _ => 0
                };
            }
            else
                aktiv1 = 0;
        }

        Console.WriteLine("Was ist dein Ziel (1-3):");
        Console.WriteLine("1. Abnehmen");
        Console.WriteLine("2. Gewicht halten");
        Console.WriteLine("3. Zunehmen");
        int ziel1 = int.Parse(Console.ReadLine() ?? "2");

        double ergebnis = ((10 * gewicht1) + (6.25 * groesse1) - (5 * alter1)) * aktiv1 + (ziel1 == 1 ? -500 : ziel1 == 3 ? 500 : 0);
        Console.WriteLine($"Dein Kalorienbedarf beträgt: {ergebnis:F2} Kalorien.");
    }

    static void HydrationTracker()
    {
        // Hydration Tracker Logik hier (aus hydration tracker.cs)
        Console.WriteLine("Hydration Tracker");
        Console.Write("Geben Sie Ihr tägliches Ziel in ml ein: ");
        int tagesZiel = int.Parse(Console.ReadLine() ?? "0");
        int aktuelleAufnahme = 0;

        while (aktuelleAufnahme < tagesZiel)
        {
            Console.Write("Wie viel Wasser haben Sie gerade getrunken (in ml)? ");
            aktuelleAufnahme += int.Parse(Console.ReadLine() ?? "0");
            double prozentualerFortschritt = (double)aktuelleAufnahme / tagesZiel * 100;
            Console.WriteLine($"Fortschritt: {prozentualerFortschritt:F2}%");
        }

        Console.WriteLine("Glückwunsch! Ziel erreicht.");
    }

    static void KoerperfettanteilRechner()
    {
        // Körperfettanteil-Rechner Logik hier (aus Körperfettanteilrechner.cs)
        Console.WriteLine("Körperfettanteil-Rechner");
        Console.Write("Geben Sie Ihr Geschlecht ein (m/w): ");
        string geschlecht = Console.ReadLine()?.ToLower();
        double gewicht = GetDoubleInput("Geben Sie Ihr Gewicht in kg ein: ", 1, 250);
        double grösse = GetDoubleInput("Geben Sie Ihre Größe in cm ein: ", 100, 250);
        double taille = GetDoubleInput("Geben Sie Ihren Taillenumfang in cm ein: ", 50, 200);
        double hals = GetDoubleInput("Geben Sie Ihren Halsumfang in cm ein: ", 30, 100);
        double hüfte = geschlecht == "w" ? GetDoubleInput("Geben Sie Ihren Hüftumfang in cm ein: ", 50, 200) : 0;

        double körperfettProzent = geschlecht == "m"
            ? 495 / (1.0324 - 0.19077 * Math.Log10(taille - hals) + 0.15456 * Math.Log10(grösse)) - 450
            : 495 / (1.29579 - 0.35004 * Math.Log10(taille + hüfte - hals) + 0.22100 * Math.Log10(grösse)) - 450;

        Console.WriteLine($"Ihr geschätzter Körperfettanteil beträgt: {körperfettProzent:F2}%");
    }

    static double GetDoubleInput(string prompt, double min, double max)
    {
        double value;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                return value;
            Console.WriteLine("Ungültige Eingabe.");
        }
    }

    static int GetIntInput(string prompt, int min, int max)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                return value;
            Console.WriteLine("Ungültige Eingabe.");
        }
    }
}
