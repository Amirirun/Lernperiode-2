


double note = 0;
double ergebnis = 0;
int attempts = 0;
string eingabe;






Console.WriteLine("Wilkommen");





while (true)
{
    Console.WriteLine("Gebe deine Note ein(Gebe e zum beenden ein)");
    eingabe = Console.ReadLine();
    


    if (eingabe == "e")
    {
        Console.WriteLine("Alle Noten wurden eingetragen");
        break;

    }

    try
    {
        note = Convert.ToDouble(eingabe);
        ergebnis += note;
        attempts++;
    }


    catch
    {         
        Console.WriteLine("Ungültige Eingabe. Bitte gib eine gültige Note ein.");
    }

    if (note >= 6 || note <= 0)
    {
        Console.WriteLine("Ungültige Eingabe. Bitte gib eine gültige Note ein.");
    }
    


}


if (attempts > 0)
{
    double durchschnitt = ergebnis / attempts;  

    Console.WriteLine($"Der Durchschnitt der {attempts} Noten ist: {durchschnitt:F2}"); 

}










