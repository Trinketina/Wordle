using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

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
    char[] ans;

    string guess = ""; //needs to be limited to 5 chars
    public string Guess
    {
        get { return guess; }
        set { guess = value.Length <= 5 ? value : guess; }
    }

    string[] possibleAnswers;
    string[] possibleGuesses;

    [SerializeField] TextAsset answers;
    [SerializeField] TextAsset guesses;

    public void Setup()
    {

        possibleAnswers = answers.ToString().Split("\n");
        possibleGuesses = guesses.ToString().Split("\n");

        int rand = UnityEngine.Random.Range(0, possibleAnswers.Length - 1);
        answer = possibleAnswers[rand].ToLower().Trim();
    }

    public bool IsValidGuess(string s)
    {
        ans = answer.ToCharArray();
        foreach (string g in possibleAnswers) //for loop that checks array of guess with array of answers
        {

            if (s.Equals(g.Trim()))
            {
                return true;
            }
        }
        foreach (string g in possibleGuesses) //for loop that checks array of guess with array of guesses
        {
            if (s.Equals(g.Trim()))
            {
                return true;
            }
        }
        return false;
    }

    public int UpdateCell(int g)
    {
        if (guess[g].Equals(ans[g]))
        {
            ans[g] = ' ';
            //set the letter to green?
            return 1;
        }
        for (int a = 0; a < ans.Length; a++)
        {
            if (guess[g].Equals(ans[a]))
            {
                if (ans[a] == guess[a] && g != a) { }
                else
                {
                    ans[a] = ' ';
                    //or set the letter to yellow
                    return 0;
                }
            }
        }
        //if not yellow or green, set to gray
        return -1;
    }
}
