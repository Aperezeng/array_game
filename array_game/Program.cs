using System;

using static System.Convert;
System.Random random = new System.Random();
{
    const string CHOICE_NUMBERS = "1";
    const string CHOICE_SYMBOLS = "2";
    const string CHOICE_LETTERS = "3";
    const int LOWER_NUMBERS = 0; 
    const int UPPER_NUMBERS = 9; 
    const int LOWER_RANGE_LOWERCASE = 97; // ASCII lower case "a"
    const int UPPER_RANGE_LOWERCASE = 122; // ASCII lower case "z"
    
    // Welcome message to the user
    Console.WriteLine("Welcome to this Pseudo game to practice 2D arrays");

    //will allow user to enter the number of rows they want on their playground
    Console.WriteLine("How many rows do you want to generate?");
    int rows = ToInt32(Console.ReadLine());

    //will allow user to enter the number of columns they want on their playground
    Console.WriteLine("How many columns do you want to generate?");
    int columns = ToInt32(Console.ReadLine());

    //original 2D array syntax
    string[,] playground = new string [rows, columns];
    Console.WriteLine(
        "Select a data type to populate your grid. Enter '1' for numbers, '2' for symbols, or '3' for letters");
    string choice = Console.ReadLine();

    
    //For Loop that will populate array with random numbers
    if (CHOICE_NUMBERS.Contains(choice))
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //variable syntax that will create random numbers for all cells in our array
                int randomNumbers = random.Next(LOWER_NUMBERS, UPPER_NUMBERS);
                // Convert the numbers to strings
                string numbers = randomNumbers.ToString();
                playground[i, j] = numbers;
            }
        }

    if (CHOICE_SYMBOLS.Contains(choice))
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                char evenSymbol = '$';
                char oddSymbol = '*';
                {
                    // Check if the sum of indices (i + j) is even or odd
                    if ((i + j) % 2 == 0)
                    {
                        //Print evenSymbol for even sum
                        playground[i, j] = evenSymbol.ToString();
                    }
                    else
                    {
                        // Print oddSymbol for odd sum
                        playground[i, j] = oddSymbol.ToString();
                    }
                }
            }
        }

    if (CHOICE_LETTERS.Contains(choice))
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                {
                    int lowerAbc = random.Next(LOWER_RANGE_LOWERCASE, UPPER_RANGE_LOWERCASE);
                    // Convert the ASCII value to a string
                    string randomLetter = ((char)lowerAbc).ToString();
                    playground[i, j] = randomLetter;
                }
            }
        }

    ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Yellow };

    //For Loop that will go through each cell and let us find out what value is at each index
    for (int i = 0; i < playground.GetLength(0); i++)
    {
        for (int j = 0; j < playground.GetLength(1); j++)
        {
            Console.ForegroundColor = colors[j % colors.Length];
            Console.Write($"[{i},{j}]: {playground[i, j]} \t");
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    // Will ask user what new numerical value they want 
    Console.WriteLine("Enter a new value to override the index value of your choice");

    // user will enter a value 
    string input = Convert.ToString(Console.ReadLine());

    // Will ask the user which row number they will override its original value
    Console.WriteLine($"in which row would you like to place this {input}?");

    //User will enter their wished row
    int iAxis = ToInt32(Console.ReadLine());

    // Will ask the user the column number to override its original value
    Console.WriteLine($"In which column would you like to place this {input}?");

    //User will enter their wished column
    int jAxis = ToInt32(Console.ReadLine());

    //code to replace the old value with the new value
    string result = Convert.ToString(playground[iAxis, jAxis]);
    playground[iAxis, jAxis] = input;
    Console.WriteLine($"The value {result} at index [{iAxis}, {jAxis}] has been replaced with {input}");

    string vertical = "|";
    string horizontal = " - -";
    
    //iterate through each row
    for (int i = 0; i < playground.GetLength(0); i++)
    {
        for (int k = 0; k < columns * 2.2; k++) // Adjust length of border
        {
            Console.Write(horizontal);
        }
        Console.WriteLine();
        
        // Iterate through each column  
        for (int j = 0; j < playground.GetLength(1); j++)
        {
            Console.Write(vertical); // Print "|" for each row
            Console.ForegroundColor = colors[j % colors.Length];
            Console.Write($"[{i},{j}]: {playground[i, j]}");
        }
        Console.WriteLine(vertical); // Print "|" at the end of each row
        Console.WriteLine();
    }
    
    //will print bottom border after the last column
    for (int m = 0; m < playground.GetLength(1) * 2.4 -1; m++)
    {
        Console.Write(horizontal);
    }
}

public class random
{
    
}











