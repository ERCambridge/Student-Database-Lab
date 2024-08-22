using System;


namespace Student_Database_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] studentNames = {"Bob Jones", "Jim Smith", "Alex Berk", "Steve James" };
            string[] studentHometown = {"Detroit", "Seattle", "Pittsburgh","Toronto" };
            string[] studentFavoriteFood = {"Pizza", "Steak", "Hamburger", "Chicken wings" };
            bool willContinue = true;
            do
            {
                listStudents(studentNames);
                int studentChosen = GetANumber(studentNames);
                int indexNum = studentChosen - 1;
                Console.WriteLine($"Student {studentChosen} is {studentNames[indexNum]} ");
                bool isHometown = GetACategory();
                if (isHometown)
                {
                    Console.WriteLine($"{studentNames[indexNum]}'s is from {studentHometown[indexNum]}");
                }
                else
                {
                    Console.WriteLine($"{studentNames[indexNum]}'s favorite food is {studentFavoriteFood[indexNum]}");
                }
                willContinue = moreInput();
            } while (willContinue);
            Console.WriteLine("Thanks for using the program!");
        }

        static void listStudents(string[] studentNames) 
        {
            Console.WriteLine("Type 'list' to see an indexed list of all students or press any key to continue");
            string userResponse = Console.ReadLine().ToLower();
            if(userResponse.Contains("list"))
            {
                for (int i = 0; i < studentNames.Length; i++) 
                {
                    Console.WriteLine($"Student #{(i+1)}: {studentNames[i]}");
                }
            }
        }

        static int indexByName(string[] array) 
        {
            bool isValidName = false;
            string userResponse = "";
            int studentNum = 0;
            do
            {
                Console.WriteLine("\nPlease enter the first or last name of the student you want to know more about");
                userResponse = Console.ReadLine().ToLower();    
                for (int i = 0; i < array.Length; i++)
                {

                    if (array[i].ToLower().Contains(userResponse))
                    {
                        studentNum = (i + 1);
                        isValidName = true;
                        break;
                    }
                }
                if (!isValidName)
                {
                    Console.WriteLine("Not a valid student name. Please try again");
                }
            } while (!isValidName);
            return studentNum;

        }
        static bool moreInput()
        {
            bool isThereInput = false; 
            string whatUserTyped = "";     
            bool getInput = true;   

            do
            {
                
                Console.WriteLine("Would you like to learn about another student? (Y/N)?");
                whatUserTyped = Console.ReadLine();

                whatUserTyped = whatUserTyped.ToUpper();

                string firstChar = whatUserTyped.Substring(0, 1);

                if (firstChar == "Y")
                {
                    getInput = false;
                    isThereInput = true;
                }
                else
                {
                    if (firstChar == "N")
                    {
                        getInput = false;
                        isThereInput = false;
                    }
                }
            } while (getInput); 

            return isThereInput;
        }
        static bool GetACategory() 
        {
            string userResponse = "";
            bool validCategory = false;
            bool isHomeTown = false;
            
            do
            {
                Console.Write("What would you like to know? Enter 'hometown' or 'favorite food':");
                 userResponse = Console.ReadLine().ToLower();
                if (userResponse.Contains("home") || userResponse.Contains("town"))
                {
                    validCategory = true;
                    isHomeTown = true;
                }
                else if (userResponse.Contains("fav") || userResponse.Contains("food")) 
                {
                    validCategory = true;
                    isHomeTown = false;
                }
                else
                {
                    Console.WriteLine("That category does not exist. Please try again.");
                }
            } while (!validCategory);  
            return isHomeTown;
        }

        static int GetANumber(string[] array)
        {
                int theValue = 0;
                bool isValidNumber = false;

                do
                {
                    Console.WriteLine($"\nWhat number student would you like to know more about? enter a number 1-{array.Length}" +
                                      "\nOr enter '0' to search by student name");
                    string userInput = Console.ReadLine();
                    
                    try
                    {
                        theValue = int.Parse(userInput);

                        if (theValue <= array.Length && theValue > 0 )
                        {
                            isValidNumber = true;
                        }
                        else if (theValue == 0) 
                        { 
                            theValue = indexByName(array);
                            isValidNumber = true;
                        }
                        else
                        {
                            Console.WriteLine("Number is not in range of the number of students");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Write($"Invalid response '{userInput}' is not a number. Please try again.");
                    }
                } while (!isValidNumber);

                return theValue;
        }

    }
}
