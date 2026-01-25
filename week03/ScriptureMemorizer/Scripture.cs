public class Scripture
{
    private List<Word> _words = new List<Word>();

    private Reference _reference;

    public Scripture(Reference reference, string text)
    {
        _reference = reference; //gonna get the reference from user

        string[] parsed = text.Split(' '); //break the scripture into individual words

        foreach (string word in parsed)
        {
            _words.Add(new Word(word)); //make the Words and save them
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int randomNumber;

        for (int i = 0; i < numberToHide; i++) //run the hide command as many times as instructed
        {
            do //pick a random word to hide
            {
                randomNumber = random.Next(0, _words.Count);
            } while(_words[randomNumber].IsHidden() && !IsCompletelyHidden()); 
            //keep getting a new random number if that word is already hidden (exceeds expectations)
            //don't get a new number if they're all already hidden. (prevents trying to hide four words when only three are left)

            _words[randomNumber].Hide();
        }
    }

    public string GetDisplayText()
    {
        string displayText = "";

        foreach (Word word in _words)
        {
            displayText = displayText + " " + word.GetDisplayText(); //concatanate each word onto the display string
        }

        displayText = displayText.Remove(0, 1); //get rid of the leading space

        displayText = $"{_reference.GetDisplayText()}\n\n{displayText}"; // tack the reference to the beginning

        return displayText + ".";
    }

    public bool IsCompletelyHidden()
    {
        bool isHidden = true; 
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                isHidden = false; //if any one word isn't hidden, the entirety of the verse isn't hidden.
            }
        }

        return isHidden;
    }
}