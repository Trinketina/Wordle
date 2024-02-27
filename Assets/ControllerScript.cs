using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    [SerializeField] ViewScript view;
    [SerializeField] ModelScript model;
    [SerializeField] TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        view = FindObjectOfType<ViewScript>();
        model = FindObjectOfType<ModelScript>();
        inputField = FindObjectOfType<TMP_InputField>();

        inputField.characterLimit = 5;

        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inputField.isFocused)
            inputField.ActivateInputField();
        if (!inputField.text.Equals(""))
            inputField.MoveToEndOfLine(false, false);

        if (Input.GetKeyDown(KeyCode.Return))
            CheckGuess();
    }
    void Setup()
    {
        model.Setup();
        view.Setup();
        int a = UnityEngine.Random.Range(0, model.PossibleAnswers.Length - 1);
        model.Answer = model.PossibleAnswers[a];

        model.GuessCount = 0;
    }

    public void ButtonLetter(string l)//for some reason buttons don't let you request a char >:C
    {
        inputField.text = (inputField.text.Length < 5) ? inputField.text += l : inputField.text; // this updates the input box which calls InputNewLetter()
    }
    public void InputNewLetter()
    {
        if (!inputField.text.Equals(""))
        {
            switch (inputField.text[^1])
            {
                case '0':
                    Backspace();
                    return;
                case '1':
                    Backspace();
                    return;
                case '2':
                    Backspace();
                    return;
                case '3':
                    Backspace();
                    return;
                case '4':
                    Backspace();
                    return;
                case '5':
                    Backspace();
                    return;
                case '6':
                    Backspace();
                    return;
                case '7':
                    Backspace();
                    return;
                case '8':
                    Backspace();
                    return;
                case '9':
                    Backspace();
                    return;
                //--------------------
                default:
                    break;
            }
            inputField.text.ToLower();
        }
        
    }

    public void CheckGuess()
    {
        Debug.Log("starting guess");
        model.Guess = inputField.text.ToLower();

        Debug.Log("GUESS: "+model.Guess);
        Debug.Log("ANSWER: "+model.Answer);
        bool validWord = false;
        foreach (string g in model.PossibleGuesses) //for loop that checks array of guess with array of answer
        {
            Debug.Log(g);
            if (model.Guess.Equals(g))
            {
                validWord = true;
                break;
            }
        }
        if (!validWord)
        {
            foreach (string g in model.PossibleAnswers) //for loop that checks array of guess with array of answer
            {
                if (model.Guess.Equals(g))
                {
                    validWord = true;
                    break;
                }
            }
        }
        if (validWord && model.GuessCount < 6)
        {
            Debug.Log("is a valid word");
            MakeGuess();
        }
    }

    private void MakeGuess()
    {
        model.GuessCount++;
        Debug.Log("checking guess");
        if (model.Guess.Equals(model.Answer))
        {
            Debug.Log("Win!");
            Win();
            return;
            //--------------------
        }

        char[] ans = model.Answer.ToCharArray();
        for (int g = 0; g < model.Guess.Length; g++)
        {
            bool hasColor = false;
            Debug.Log("wrong answer, getting colors");
            for (int a = 0; a < ans.Length; a++)
            {
                if (model.Guess[g].Equals(ans[a]))
                {
                    Debug.Log("found a letter");
                    ans[a] = ' ';
                    if (g == a)
                    {
                        //set the letter to green?
                        view.SetGreen(model.GuessCount-1, g);
                        hasColor = true;
                        break;
                    }
                    //or set the letter to yellow
                    view.SetYellow(model.GuessCount - 1, g);
                    hasColor = true;
                    break;
                }
            }
            //if not yellow or green, set to gray
            if (!hasColor)
            {
                view.SetGrey(model.GuessCount - 1, g);
            }
        }
    }

    void Win()
    {

    }

    public void Backspace()
    {
        inputField.text = inputField.text.Remove(inputField.text.Length-1);
    }

}
