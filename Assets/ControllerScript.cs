using TMPro;
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
            if (model.IsValidGuess(inputField.text.ToLower().Trim()))
            {
                
                MakeGuess();
            }
        }
    }
    public void MakeGuess()
    {
        model.Guess = inputField.text.ToLower().Trim();
        model.GuessCount++;


        for (int g = 0; g < model.Guess.Length; g++)
        {
            switch (model.UpdateCell(g))
            {
                case 0:
                    view.SetYellow(model.GuessCount - 1, g, model.Guess[g]);
                    break;
                case 1:
                    view.SetGreen(model.GuessCount - 1, g, model.Guess[g]);
                    break;
                default:
                    view.SetGray(model.GuessCount - 1, g, model.Guess[g]);
                    break;
            }
        }
        if (model.Guess.Equals(model.Answer))
        {
            Debug.Log("You Win!");
            WinGame();
            return;
            //--------------------
        }
        if (model.GuessCount >= 6)
        {
            Debug.Log("Game Ends");
            LoseGame();
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

    void WinGame()
    {
        view.End(model.GuessCount);

        EndGame();
    }
    void LoseGame()
    {
        view.End(model.Answer);
        EndGame();
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
        if (inputField.text.Length < model.Guess.Length) //backspaced, so it needs to reflect that in the view
        {
            view.UpdateLetter(model.GuessCount, inputField.text.Length, ' ');
        }
        model.Guess = inputField.text.ToLower().Trim(); 
    }
    public void Backspace() //specific method for the backspace button in the keyboard
    {
        if (model.running && inputField.text != "")
        {
            inputField.text = inputField.text.Remove(inputField.text.Length - 1);
            view.UpdateLetter(model.GuessCount, inputField.text.Length, ' ');
        }
    }
}
