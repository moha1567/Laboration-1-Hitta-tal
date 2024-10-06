/* Muhammad Sheik Ali
 * moha1567@hotmail.com
 * KYHA_DSO24
 * Objektorienterad programmering C
 * I detta kodprogrammet så ska den läsa in delsträngar som börjar och slutar på samma siffra utan att ta med bokstäver.
 * Det ska även markeras med färgen blå och sedan addera ihop talen och summera det.
*/

using System;  //Gör det möjligt att använda metoder och olika typer

// Be användaren om en textsträng. Om användaren trycker Enter utan att mata in något, används en standardsträng
Console.WriteLine("Ange en textsträng (tryck Enter för att använda standardsträngen): ");
string input = Console.ReadLine(); 

if (string.IsNullOrEmpty(input)) // Om användaren inte anger något, används standardsträngen nedan
{
    input = "29535123p48723487597645723645";
}


MarkeraSekvenser(input); // Anropar funktionen som ska markera och summera sekvenserna

Console.Write("\n\nTryck på en tangent för att stänga fönstret");
Console.ReadKey();



void MarkeraSekvenser(string input)
{
    long totalSum = 0; // För att hålla reda på summan av alla matchade tal

    for (int i = 0; i < input.Length; i++) // Loopar igenom varje tecken i strängen
    {
        if (char.IsDigit(input[i])) // Kollar om det tecknet är en siffra
        {
            for (int j = i + 1; j < input.Length; j++) // Startar en inre loop för att hitta en matchande slutsiffra
            {
                if (!char.IsDigit(input[j])) // Om tecknet inte är en siffra, avbryter den inre loopen
                {
                    break;
                }

                if (input[i] == input[j]) // Om siffran i och siffran j är detsamma, kontrollera sekvensen
                {

                    // Kontrollera att samma siffra inte finns mellan i och j
                    bool korrektSekvens = true; // Antar att sekvensen är korrekt tills motsatsen bevisats
                    for (int m = i + 1; m < j; m++) // Loopar igenom siffrorna mellan i och j
                    {
                        if (input[m] == input[i]) // Om samma siffra förekommer mellan i och j, markera sekvensen som felaktig
                        {
                            korrektSekvens = false;
                            break; // Avbryt loopen om sekvensen inte är korrekt
                        }
                    }

                    if (korrektSekvens)
                    {
                        // Skriver ut hela strängen med den matchande sekvensen markerad i grönt
                        for (int k = 0; k < input.Length; k++) // Loopar igenom hela strängen för att skriva ut tecknen
                        {
                            if (k >= i && k <= j) // Om positionen är inom den matchade sekvensen
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen; // Färgen på den markerade sekvensen
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Gray; // Sätter färgen till grå för övriga tecken
                            }
                            Console.Write(input[k]);
                        }
                        Console.WriteLine(); 

                        
                        // Plocka ut sekvensen som ett tal och addera det till totalen
                        string tal = input.Substring(i, j - i + 1); // Extraherar den matchade sekvensen som en substring
                        totalSum += long.Parse(tal); // Omvandlar sekvensen till ett tal och adderar det till totalSum

                        break; // Avsluta den inre loopen för att söka vidare från nästa position
                    }
                }
            }
        }
    }

    // Återställ färgen till standardinställningen
    Console.ResetColor();

    // Skriv ut summan av alla matchade tal
    Console.WriteLine($"\nSumma = {totalSum}"); // Skriv ut totalSumman av alla matchade sekvenser
}
