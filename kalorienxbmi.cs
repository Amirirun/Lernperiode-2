﻿

        string entscheidung;

        Console.WriteLine("Wilkommen im Menü!");
        Console.WriteLine("Drücke (b) für den BMI-Rechner und (k) für den Kalorienrechner");
        entscheidung = Console.ReadLine();

        if (entscheidung == "b")
        {
            
            string gewichtbmi;
            double gewichtbmi1;
            string groessebmi;
            double groessebmi1;
            double bmi;

            
            while (true)
            {
                Console.WriteLine("Gebe dein Gewicht in kg ein:");
                gewichtbmi = Console.ReadLine();

                if (double.TryParse(gewichtbmi, out gewichtbmi1))
                {
                    if (gewichtbmi1 > 0 && gewichtbmi1 < 250)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Deine Eingabe ist ungültig. Bitte gib ein Gewicht zwischen 1 und 250 kg ein.");
                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl ein.");
                }
            }

            
            while (true)
            {
                Console.WriteLine("Gebe deine Größe in Metern (z. B. 1,75) ein:");
                groessebmi = Console.ReadLine();

                if (double.TryParse(groessebmi, out groessebmi1))
                {
                    if (groessebmi1 > 0 && groessebmi1 < 2.5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Deine Eingabe ist ungültig. Bitte gib eine Größe zwischen 0,5 und 2,5 Metern ein.");
                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl ein.");
                }
            }

            
            bmi = gewichtbmi1 / (groessebmi1 * groessebmi1);

           
            Console.WriteLine($"Dein BMI beträgt: {bmi:F2}");
            if (bmi < 18.5)
            {
                Console.WriteLine("Kategorie: Untergewicht");
            }
            else if (bmi >= 18.5 && bmi < 24.9)
            {
                Console.WriteLine("Kategorie: Normalgewicht");
            }
            else if (bmi >= 25 && bmi < 29.9)
            {
                Console.WriteLine("Kategorie: Übergewicht");
            }
            else
            {
                Console.WriteLine("Kategorie: Adipositas");
            }
        }
        else if (entscheidung == "k")
        {
       
        
            Console.WriteLine("-----------------------------------------------------------");
            string gewicht;
            double gewicht1;


            string grösse;
            int grösse1;

            string alter;
            int alter1;

            string aktiv;
            double aktiv1;

            string ziel;
            int ziel1;

            double ergebnis = 0;


            while (true)
            {
                Console.WriteLine("Gebe dein Gewicht ein:");
                gewicht = Console.ReadLine();

                if (double.TryParse(gewicht, out gewicht1))
                {
                    if (gewicht1 > 0 && gewicht1 < 250)
                    {

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Deine Eingabe ist ungültig. Bitte gib ein Gewicht zwischen 1 und 250 ein.");
                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl ein.");

                }
            }
            Console.WriteLine("-----------------------------------------------------------------------------");


            while (true)
            {
                Console.WriteLine("Gebe deine Größe in cm ein:");
                grösse = Console.ReadLine();


                if (int.TryParse(grösse, out grösse1))
                {

                    if (grösse1 > 25 && grösse1 < 220)
                    {

                        break;
                    }
                    else
                    {

                        Console.WriteLine("Deine Eingabe ist ungültig. Bitte gib eine Größe zwischen 26 und 219 cm ein.");
                    }
                }
                else
                {

                    Console.WriteLine("Ungültige Eingabe. Bitte gib eine gültige Zahl ein.");
                }
            }

            Console.WriteLine("-----------------------------------------------------------------------------");


            while (true)
            {
                Console.WriteLine("Gebe dein Alter ein:");
                alter = Console.ReadLine();

                if (int.TryParse(alter, out alter1))
                {

                    if (alter1 > 0 && alter1 < 100)
                    {

                        break;
                    }
                    else
                    {

                        Console.WriteLine("Deine Eingabe ist ungültig. Bitte gib ein Alter zwischen 1 und 99 ein.");
                    }
                }
                else
                {

                    Console.WriteLine("Ungültige Eingabe. Bitte gib eine gültige Zahl ein.");
                }
            }


            Console.WriteLine("-----------------------------------------------------------------------------");

            while (true)
            {
                Console.WriteLine("Wie aktiv bist du (1, 2, 3, 4, 5):");
                Console.WriteLine("1. Sitzend (wenig Bewegung)");
                Console.WriteLine("2. Leicht aktiv (Sport an 1-3 Tagen)");
                Console.WriteLine("3. Moderat aktiv (Sport an 3-5 Tagen)");
                Console.WriteLine("4. Sehr aktiv (Sport an 6-7 Tagen)");
                Console.WriteLine("5. Extrem aktiv (Hochleistungssportler)");

                aktiv = Console.ReadLine();


                if (double.TryParse(aktiv, out aktiv1) && aktiv1 >= 1 && aktiv1 <= 5)
                {

                    switch (aktiv1)
                    {
                        case 1:
                            aktiv1 = 1.2;
                            break;
                        case 2:
                            aktiv1 = 1.375;
                            break;
                        case 3:
                            aktiv1 = 1.55;
                            break;
                        case 4:
                            aktiv1 = 1.725;
                            break;
                        case 5:
                            aktiv1 = 1.9;
                            break;
                    }


                    break;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl zwischen 1 und 5 ein.");
                }

            }

            Console.WriteLine("-----------------------------------------------------------------------------");

            Console.WriteLine("Was ist dein Ziel (1, 2, 3)");
            Console.WriteLine("1.Abnehmen");
            Console.WriteLine("2.Gewicht halten");
            Console.WriteLine("3.Zunehmen");
            while (true)
            {
                ziel = Console.ReadLine();

                if (int.TryParse(ziel, out ziel1))
                {
                    switch (ziel1)

                    {
                        case 1:
                            ziel1 -= 501;
                            break;

                        case 2:
                            ziel1 -= 2;
                            break;


                        case 3:
                            ziel1 += 497;
                            break;
                    }

                    break;
                }

                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl zwischen 1 und 3 ein.");
                }

            }




            ergebnis = ((10 * gewicht1) + (6.25 * grösse1) - (5 * alter1)) * aktiv1 + ziel1;


            Console.WriteLine($"Dein Kalorienbedarf beträgt: {ergebnis}");

        
    }
        else
        {
            Console.WriteLine("Ungültige Eingabe. Bitte wähle 'b' für BMI oder 'k' für Kalorienrechner.");
        }
    

