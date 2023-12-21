using System;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Labb_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            int choice = 0;
            bool continueProgram = true;

            while (continueProgram == true)
            {
                try 
                {
                    Console.WriteLine(
                        "\nMenyn  " +
                    "\n------------------------------------------------" +
                        "\nVälj ett av alternativen:" +
                        "\n1.) Lägg till person " +
                        "\n2.) Visa alla personer " +
                        "\n3.) Avsluta programmet " +
                        "\n----------------------------------------------------"
                        );
                choice = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                { 
                    Console.WriteLine(e.Message);
                }
                switch (choice)
                {
                    case 1:
                        AddPerson();
                        break;

                    case 2:
                        ListPersons();
                        break;

                    case 3:
                        continueProgram = false;
                        break;

                    default: // Ifall inget annat case körs, ser ni default-case i switch-satsen som är det case som körs.
                        Console.WriteLine("Felaktig indata, du måste ange ett nummer mellan 1 - 3\n");
                        break;
                }
            }

            void AddPerson()
            {
                bool wrongInput = true;
                int userInput = 0;
                string firstname;
                Console.WriteLine("Skriv in förnamnet på personen");
                firstname = Console.ReadLine();
                string lastname;
                Console.WriteLine("Skriv in efternamn på personen ");
                lastname = Console.ReadLine();

                Gender gender = Gender.Man;
                Hair hair = new Hair { };
                DateTime datetime = DateTime.Now;
                string eyeColour = " ";

                bool wrongDate = false;
                do
                {
                    try
                    {
                        Console.WriteLine("När fyller personen år?, skriv i YYYY-MM-DD format ");
                        datetime = DateTime.Parse(Console.ReadLine());
                        wrongDate = false;
                    }
                    catch
                    {
                        Console.WriteLine("Vänligen skriv med siffror och ha med bindesträck ");
                        wrongDate = true;
                    }


                } while (wrongDate == true);
                do
                {
                    try 
                    {
                        Console.WriteLine("Vilket kön har personen? \n1 . Man \n2 . Kvinna \n3 . Ickebinär \n4 . Annat \n5 . Okänd ");
                        bool parse;
                        parse = int.TryParse(Console.ReadLine(), out userInput);

                        if (parse == false || userInput == 0 || userInput < 0 || userInput > 5) 
                        {
                            Console.WriteLine("Du kan bara skriva en siffra mellan 1-5 ");
                            wrongInput = false;
                        }

                        else
                        {
                            wrongInput = true;
                        }

                    }

                    catch
                    {
                        Console.WriteLine("Vänligen skriv med siffor ");
                        wrongInput = true;
                    }


                } while (wrongInput == false);

                switch (userInput) 
                {
                    case 1:
                        gender = Gender.Man;
                        break;

                    case 2: 
                        gender = Gender.Woman;
                        break;

                    case 3:
                        gender = Gender.Nonbinary;
                        break;

                    case 4:
                        gender = Gender.Other;
                        break;

                    case 5:
                        gender = Gender.Unknown;
                        break;
                }

                bool wrongHair = false;
                do 
                { 
                    try 
                    {
                        Console.WriteLine("Vilken hårfärg har personen? ");
                        hair.HairColour = Console.ReadLine();
                        wrongHair = false;
                        if (hair.HairColour.All(Char.IsDigit)) {
                            throw new Exception();
                        } 
                    }
                    catch 
                    {
                        Console.WriteLine(" Vänligen skriv en färg istället ");
                        wrongHair = true;   
                    }

                } while (wrongHair == true);    

                bool hairlength = true;
                do 
                { 
                    
                    {
                        Console.WriteLine("Vad har personen för hårlängd? ");;
                        hair.HairLength = Console.ReadLine();
                        hairlength = false;
                    }
                
                } while (hairlength == true);

                bool wrongEyes = false;
                do 
                {
                    try 
                    {
                        Console.WriteLine("Vad har personen för ögonfärg? ");
                        eyeColour = Console.ReadLine();
                        wrongEyes = false;
                        if (eyeColour.All(Char.IsDigit)) 
                        {
                            throw new Exception();
                        }

                    }
                    catch 
                    { 
                        Console.WriteLine("Vänligen skriv med bokstäver ");
                        wrongEyes= true;
                    }
                
                } while (wrongEyes == true);

                Person person = new Person(firstname, lastname, gender, hair, datetime, eyeColour);
                
                list.Add(person);

            }
            void ListPersons () 
            { 
            foreach (Person person in list)
                {
                    Console.WriteLine(person.ToString()+"\n");
                }
                if (!list.Any()) 
                { 
                    Console.WriteLine("Finns ej tillagda personer ");
                }
            }

        }
        // reference 
        
        //Stackoverflow. (2023). How the int.TryParse actually works.
        // https://stackoverflow.com/questions/15294878/how-the-int-tryparse-actually-works
    }
}
