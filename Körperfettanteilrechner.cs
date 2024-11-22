using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Körperfettanteil-Rechner");
        Console.WriteLine("---------------------------------------------");

        
        Console.Write("Geben Sie Ihr Geschlecht ein (m/w): ");
        string geschlecht = Console.ReadLine()?.ToLower();

        Console.Write("Geben Sie Ihr Gewicht in kg ein: ");
        double gewicht = Convert.ToDouble(Console.ReadLine());

        Console.Write("Geben Sie Ihre Größe in cm ein: ");
        double grösse = Convert.ToDouble(Console.ReadLine());

        Console.Write("Geben Sie Ihren Taillenumfang in cm ein: ");
        double taille = Convert.ToDouble(Console.ReadLine());

        double hüfte = 0;
        if (geschlecht == "w")
        {
            Console.Write("Geben Sie Ihren Hüftumfang in cm ein: ");
            hüfte = Convert.ToDouble(Console.ReadLine());
        }

        Console.Write("Geben Sie Ihren Halsumfang in cm ein: ");
        double hals = Convert.ToDouble(Console.ReadLine());

        
        double körperfettProzent = BerechneKoerperfettanteil(geschlecht, gewicht, grösse, taille, hals, hüfte);

        
        Console.WriteLine($"Ihr geschätzter Körperfettanteil beträgt: {körperfettProzent:F2}%");
    }

    static double BerechneKoerperfettanteil(string geschlecht, double gewicht, double grösse, double taille, double hals, double hüfte)
    {
        if (geschlecht == "m")
        {
            
            return 495 / (1.0324 - 0.19077 * Math.Log10(taille - hals) + 0.15456 * Math.Log10(grösse)) - 450;
        }
        else if (geschlecht == "w")
        {
            
            return 495 / (1.29579 - 0.35004 * Math.Log10(taille + hüfte - hals) + 0.22100 * Math.Log10(grösse)) - 450;
        }
        else
        {
            Console.WriteLine("Ungültiges Geschlecht angegeben!");
            return 0;
        }
    }
}

