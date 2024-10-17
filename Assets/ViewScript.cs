using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ViewScript : MonoBehaviour
{
    [SerializeField] Sprite blankSprite;
    [SerializeField] Sprite guessedSprite;


    [SerializeField] Color green;
    [SerializeField] Color yellow;
    [SerializeField] Color gray;

    [SerializeField] GameObject guesses;

    Button[,] letterBoxes = new Button[6,5];

    [SerializeField] GameObject endScreen;


    public void Setup()
    {
        HorizontalLayoutGroup[] row = guesses.GetComponentsInChildren<HorizontalLayoutGroup>();
        for (int r = 0; r < row.Length; r++)
        {
            Button[] col = row[r].GetComponentsInChildren<Button>();
            for (int c = 0; c < col.Length; c++)
            {
                letterBoxes[r,c] = col[c];
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGreen(int row, int col, char let)
    {
        //get the guessCount for the Row, and guess index for the Column
        /*letterBoxes[row, col].image.sprite = guessedSprite;
        letterBoxes[row, col].image.color = green;*/

        letterBoxes[row, col].GetComponent<LetterBox>().newColor = green;
        letterBoxes[row, col].animator.SetBool("Pressed", true);

        //set key color
        Image key = GameObject.Find(let.ToString().ToUpper()).GetComponent<Image>();
        key.color = green;
    }
    public void SetYellow(int row, int col, char let)
    {
        //get the guessCount for the Row, and guess index for the Column
        letterBoxes[row, col].image.sprite = guessedSprite;
        letterBoxes[row, col].image.color = yellow;

        //set key color
        Image key = GameObject.Find(let.ToString().ToUpper()).GetComponent<Image>();
        if (key.color != green)
            key.color = yellow;
    }
    public void SetGray(int row, int col, char let)
    {
        //get the guessCount for the Row, and guess index for the Column
        letterBoxes[row, col].image.sprite = guessedSprite;
        letterBoxes[row, col].image.color = gray;

        //set key color
        Image key = GameObject.Find(let.ToString().ToUpper()).GetComponent<Image>();
        if (key.color != green && key.color != yellow)
            key.color = gray;
    }

    public void UpdateLetter(int r, int c, char l)
    {
        if (l == ' ')
            letterBoxes[r, c].image.color = gray;
        else
            letterBoxes[r, c].image.color = Color.white;
        letterBoxes[r, c].GetComponentInChildren<TMP_Text>().text = l.ToString();
    }

    public void End(int g)
    {
        endScreen.GetComponentInChildren<TMP_Text>().text = "Success! In " + g + " tries";
        endScreen.SetActive(true);
    }
    public void End(string w)
    {
        endScreen.GetComponentInChildren<TMP_Text>().text = "The word was " + w.Trim() + "...";
        endScreen.SetActive(true);
    }
}
