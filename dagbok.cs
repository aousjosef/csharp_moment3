using System.Text.Json;


namespace Dagbok;


public class NoteClass
{
    public string? Author { get; set; }
    public string? Content { get; set; }
}


class DagBokClass
{

    // Skapa en lista med getter och setters. Listan är av typen objekt som kommer från klassen NoteClass
    public List<NoteClass>? Notes { get; set; }

    string fileName = "notedblist.json";
    string jsonContent;


    //Constructor
    public DagBokClass()
    {
        converJsonFileToList();
    }


    public void converJsonFileToList()
    {

        if (!File.Exists(fileName))
        {
            // If the file doesn't exist, create a new empty JSON file
            File.WriteAllText(fileName, "[]");

            //Create empty list
            Notes = new List<NoteClass>();
        }

        else
        {
            //Read all content of json file. put into string.

            jsonContent = File.ReadAllText(fileName);

            // Deserialize the JSON content into a list of NoteClass objects
            Notes = System.Text.Json.JsonSerializer.Deserialize<List<NoteClass>>(jsonContent);

        }





    }


    public void addNote(NoteClass anteckning)
    {

        Notes.Add(anteckning);

        string jsonString = JsonSerializer.Serialize(Notes);

        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("new note has been added!");

    }



    public void deleteNote(int noteIndex)
    {
        if (noteIndex > Notes.Count - 1)
        {
            Console.WriteLine($"Erorr! value must be a a number between 0 and {Notes.Count - 1}");
        }

        else
        {
            Notes.RemoveAt(noteIndex);
            string jsonString = JsonSerializer.Serialize(Notes);

            File.WriteAllText(fileName, jsonString);
            Console.WriteLine($"note with index {noteIndex} succesfully removed!");
        }


    }

    public void showAllNotes()
    {

        int indexOfNote = 0;

        foreach (var n in Notes)
        {
            Console.WriteLine($"[{indexOfNote}] - Av: {n.Author} ");
            Console.WriteLine($"{n.Content} \n");
            indexOfNote++;
        }
    }

}
