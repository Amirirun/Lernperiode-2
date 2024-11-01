
string kontieingabe;

int guesses = 0;


Console.WriteLine("Hallo beim quiz");






    Console.WriteLine("Wie viele Kontinente gibt es?");
    int[] kontiauswahl = { 4, 5, 6, 7 };


    for (int i = 0; i < kontiauswahl.Length; i++)
    {
        Console.WriteLine($"Option {i + 1}: {kontiauswahl[i]}");
    }

while (true)
{
    guesses += 1;
    Console.WriteLine("Geben sie ihre Zahl ein");
    kontieingabe = Console.ReadLine();


    if (kontieingabe == "7")
    {
        Console.WriteLine("Deine Eingabe ist richtig");
        Console.WriteLine($"Du hast {guesses} versuche gebraucht");
      
        if (guesses <=2 )
        {
            Console.WriteLine("Du bist schlau");
                
                
                
        }

        else if (guesses >=2 )
        { 
            Console.WriteLine("Geh mal zur Nachhilfe");
        }
        
        break;
    }

    else if (kontieingabe == "5" || kontieingabe == "4" || kontieingabe == "6")

    {
        Console.WriteLine("Deine Zahl ist falsch");
    }

    else

    {

        Console.WriteLine("Ungültige Eingabe");
    }
   
}



Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
string r;


Console.WriteLine("Löse diese Rechnung: 20 * 20");



while (true)
{ 

r = Console.ReadLine();

if (r == "400")
{
    Console.WriteLine("Deine Eingabe ist richtig");
    break;
}


else if (r != "400")

{
    Console.WriteLine("Falsch, versuche nochmal");
}


}
Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");






