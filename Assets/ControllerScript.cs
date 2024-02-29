using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
        if (model.running)
        {
            GameRunning();
        }
    }
    void Setup()
    {
        model.Setup();
        view.Setup();
        int rand = UnityEngine.Random.Range(0, model.PossibleAnswers.Length - 1);
        model.Answer = model.PossibleAnswers[rand];

        model.Answer = "flint";


        model.GuessCount = 0;
        Debug.Log(model.Answer);
    }
    void GameRunning()
    {
        if (!inputField.isFocused)
            inputField.ActivateInputField();

        if (!inputField.text.Equals(""))
            inputField.MoveToEndOfLine(false, false);

        if (Input.GetKeyDown(KeyCode.Return))
            CheckGuess();
    }

    // Guess Logic -----------------------------------
    public void CheckGuess()
    {
        if (model.running && inputField.text.Length == 5)
        {
            model.Guess = inputField.text.ToLower().Trim();

            bool validWord = false;
            foreach (string g in model.PossibleAnswers) //for loop that checks array of guess with array of answers
            {

                if (model.Guess.Equals(g.Trim()))
                {
                    validWord = true;
                    break;
                }
            }
            if (!validWord)
            {
                foreach (string g in model.PossibleGuesses) //for loop that checks array of guess with array of guesses
                {
                    if (model.Guess.Equals(g.Trim()))
                    {
                        validWord = true;
                        break;
                    }
                }
            }
            if (validWord)
            {
                MakeGuess();
            }
        }
    }

    private void MakeGuess()
    {
        model.GuessCount++;
        char[] ans = model.Answer.Trim().ToCharArray();

        for (int g = 0; g < model.Guess.Length; g++)
        {
            bool hasColor = false;

            if (model.Guess[g].Equals(ans[g]))
            {
                //set the letter to green?
                ans[g] = ' ';
                view.SetGreen(model.GuessCount - 1, g, model.Guess[g]);
                hasColor = true;
            }
            else
            {
                for (int a = 0; a < ans.Length; a++)
                {
                    if (model.Guess[g].Equals(ans[a]))
                    {
                        ans[a] = ' ';
                        //or set the letter to yellow
                        view.SetYellow(model.GuessCount - 1, g, model.Guess[g]);
                        hasColor = true;
                        break;
                    }
                }
            }
            //if not yellow or green, set to gray
            if (!hasColor)
            {
                view.SetGrey(model.GuessCount - 1, g, model.Guess[g]);
            }
        }
        if (model.Guess.Equals(model.Answer.Trim()) || model.GuessCount >= 6)
        {
            Debug.Log("Game Ends");
            EndGame();
            return;
            //--------------------
        }

        inputField.text = string.Empty;
        model.Guess = inputField.text;



    }
    void EndGame()
    {
        model.running = false;
        inputField.DeactivateInputField();
    }

    // Keyboard -----------------------------------
    public void ButtonLetter(string l)//for some reason buttons don't let you request a char >:C
    {
        if (model.running)
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
            view.UpdateLetter(model.GuessCount, inputField.text.Length - 1, inputField.text[^1]);
        }
        if (inputField.text.Length < model.Guess.Length)
        {
            view.UpdateLetter(model.GuessCount, inputField.text.Length, ' ');
        }
        model.Guess = inputField.text.ToLower().Trim();
    }
    public void Backspace()
    {
        if (model.running)
        {
            inputField.text = inputField.text.Remove(inputField.text.Length - 1);
            view.UpdateLetter(model.GuessCount, inputField.text.Length, ' ');
        }
    }
}
