using UnityEngine;

public class ModelScript : MonoBehaviour
{
    int guessCount;
    public int GuessCount 
    { 
        get { return guessCount; } 
        set { guessCount = value; } 
    }

    public bool running = true;

    string answer;
    public string Answer
    {
        get { return answer; }
        set { answer = value; }
    }
    string guess = ""; //needs to be limited to 5 chars
    public string Guess 
    { 
        get { return guess; } 
        set { guess = value.Length <= 5 ? value : guess; }
    }

    string[] possibleAnswers;
    string[] possibleGuesses;

    public string[] PossibleAnswers { get { return possibleAnswers; } }
    public string[] PossibleGuesses { get { return possibleGuesses; } }

    [SerializeField] TextAsset answers;
    [SerializeField] TextAsset guesses; 


    public void Setup()
    {
        possibleAnswers = answers.ToString().Split("\n");
        possibleGuesses = guesses.ToString().Split("\n");
    }

}
