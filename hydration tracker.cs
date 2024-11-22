using System;

class HydrationTracker
{
    static void Main(string[] args)
    {
        Console.WriteLine(" Hydration Tracker ");
        Console.WriteLine("-----------------------------------");

        
        Console.Write("Geben Sie Ihr tägliches Ziel in ml ein (z. B. 3500): ");
        int tagesZiel = Convert.ToInt32(Console.ReadLine());

        int aktuelleAufnahme = 0;
        string eingabe;

        do
        {
            
            Console.Write("Wie viel Wasser haben Sie gerade getrunken (in ml)? (oder geben Sie 'status' ein, um den Fortschritt anzuzeigen): ");
            eingabe = Console.ReadLine()?.ToLower();

            if (eingabe == "status")
            {
                ZeigeFortschritt(aktuelleAufnahme, tagesZiel);
            }
            else if (int.TryParse(eingabe, out int wasser))
            {
                if (wasser > 0)
                {
                    aktuelleAufnahme += wasser;
                    Console.WriteLine($" {wasser} ml hinzugefügt. Gesamt: {aktuelleAufnahme} ml.");
                    ZeigeFortschritt(aktuelleAufnahme, tagesZiel);
                }
                else
                {
                    Console.WriteLine("Bitte geben Sie eine positive Zahl ein.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Versuchen Sie es erneut.");
            }

        } while (aktuelleAufnahme < tagesZiel);

        Console.WriteLine("\n Glückwunsch! Sie haben Ihr Ziel erreicht! ");
    }

    static void ZeigeFortschritt(int aktuelleAufnahme, int tagesZiel)
    {
        double prozentualerFortschritt = (double)aktuelleAufnahme / tagesZiel * 100;
        Console.WriteLine($" Fortschritt: {aktuelleAufnahme} ml / {tagesZiel} ml ({prozentualerFortschritt:F2}%).");
        if (aktuelleAufnahme >= tagesZiel)
        {
            Console.WriteLine(" Großartig! Sie sind gut hydriert!");
        }
        else
        {
            Console.WriteLine(" Weiter so! Trinken Sie noch mehr Wasser, um Ihr Ziel zu erreichen.");
        }
    }
}
