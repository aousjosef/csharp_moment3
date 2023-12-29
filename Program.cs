namespace m3;
using Dagbok;

class Program
{
    static void Main(string[] args)
    {

        DagBokClass dagbok = new DagBokClass();

        //   Console.WriteLine(dagbok.aj);
        Console.WriteLine("welcome to dagbok, please choose an option: ");
        void showOptions()
        {

            Console.WriteLine("1. Show all notes. ");
            Console.WriteLine("2. Add a new note. ");
            Console.WriteLine("3. Delete a note. ");
            Console.WriteLine("4. Exit program");
        }




        while (true)
        {
            showOptions();
            var option = Console.ReadLine();
            Console.CursorVisible =true;

            if (int.TryParse(option, out int num))
            {


                switch (num)
                {

                    //Case 1 visa all  notes
                    case 1:
                        Console.WriteLine("You entered 1. Here are all the notes");
                        dagbok.showAllNotes();

                        break;


                    //Skriv en ny note
                    case 2:
                        Console.WriteLine("You entered 2. please enter your name: ");

                        string? author = Console.ReadLine();

                        Console.WriteLine("You entered 2. please enter your note: ");

                        string? content = Console.ReadLine();


                        if (!string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(content))
                        {

                            NoteClass nyAnteckning = new NoteClass
                            {

                                Author = author,
                                Content = content

                            };

                            dagbok.addNote(nyAnteckning);

                        }
                        else
                        {
                            Console.WriteLine("Author or content can not be empty!");
                        }

                        break;


                    //Rader en note
                    case 3:
                        Console.WriteLine("You entered 3. Which note number do you want to remove?");
                        string? noteIndexToBeRemoved = Console.ReadLine();

                        if (int.TryParse(noteIndexToBeRemoved, out int inputvalue))
                        {
                            dagbok.deleteNote(inputvalue);
                        }
                        else
                        {
                            Console.WriteLine("Input has to be a number");
                        }


                        break;


                    //Existing program
                    case 4:
                        Console.WriteLine("Exiting program. Goodbye!");
                        Environment.Exit(0);
                        break;


                    //Default value

                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                        break;
                }



            }

            else
            {
            Console.WriteLine("Input has to be a number");
            }

            //When case ends
            Console.WriteLine("\n");
            Console.WriteLine("What do want to do now? ");


        }


    }
}
