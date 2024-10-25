using System.ComponentModel.Design;


Random random = new Random();
int randomNumber = random.Next(1, 100); 


int guess = 0;
int attempts = 0;


while (guess != randomNumber)
{

    Console.WriteLine("Geben sie eine Zahl ein");
    guess = Convert.ToInt32(Console.ReadLine());
    attempts++;



    if (guess == randomNumber)
    {
        Console.WriteLine($"Deine Zahl ist richtig, du hattest {attempts} versuche");

    }
  
    
      else if (guess <= randomNumber)
        {
            Console.WriteLine("Die gesuchte Zahl ist grösser");

        }

        else if (guess >= randomNumber)

        {
            Console.WriteLine("Deine gesuchte Zahl ist kleiner");
        }


    }