public class Journal{
    public List<Entry> _entries = new List<Entry>();
    public bool _saved = false; //variable used to check file has been saved before exiting.

    public string _mostRecentFile = "";
    
    public Journal()
    {
    }

    public void AddEntry()
    {
        Entry newEntry = new Entry();
        DateTime theCurrentTime = DateTime.Now;
        PromptGenerator newPrompt = new PromptGenerator();

        newEntry._date = theCurrentTime.ToShortDateString();
        newEntry._promptText = newPrompt.GetRandomPrompt();

        Console.WriteLine(newEntry._promptText);

        newEntry._entryText = Console.ReadLine();
        if (newEntry._entryText == "") //Check whether there is any content in entry (exceeds expectations)
        {
            Console.WriteLine("Cannot save an empty entry");
        }
        else
        {   
            _entries.Add(newEntry);
            _saved = false;
        }
    }

    public void DisplayAll()
    {
        if (_entries.Any())
        {
            foreach(Entry entry in _entries)
            {
                entry.Display();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No entries to display!"); //looks better than nothing happening. (also indicates operation was successful)(exceeds expectations)
        }
    }

    public void SaveToFile(string fileName)
    {

        using (StreamWriter outputFile = new StreamWriter(fileName)) //save info, variables separated by '|'
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }

        _saved = true; //okay to exit
        _mostRecentFile = fileName; //help the user remember where they saved or loaded their journal from / to. (exceeds expectations)
    }

    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName)) //check whether file to load exists (exceeds expectations)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName); //get everything written in target file, w/ each line as one string

            _entries.Clear(); //existing entries should be replaced, so we're clearing any existing entries.

            foreach (string line in lines)
            {
                string[] parts = line.Split("|"); //parse each line from source file into a collection of strings

                Entry savedEntry = new Entry(); //create new entry here instead of using AddEntry(), in order to keep parameters
                savedEntry._date = parts[0];    //on AddEntry() empty. Also, the full method isn't necessary, because we don't
                savedEntry._promptText = parts[1]; // need the current time nor do we need a new prompt.
                savedEntry._entryText = parts[2];

                _entries.Add(savedEntry);
            }

            _saved = true; //It's fine to exit after loading, because any data is already locked in. (exceeds expectations)
            _mostRecentFile = fileName; //help the user remember where they saved or loaded their journal from / to. (exceeds expectations)
        }
        else
        {
            Console.WriteLine("File does not exist and cannot be loaded.");
        }
    }
}
