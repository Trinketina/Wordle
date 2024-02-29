using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [SerializeField] GameObject winScreen;


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

    public void SetGreen(int r, int c, char l)
    {
        //get the guessCount for the Row, and guess index for the Column
        letterBoxes[r, c].image.sprite = guessedSprite;
        letterBoxes[r, c].image.color = green;
        Image key = GameObject.Find(l.ToString().ToUpper()).GetComponent<Image>();
        key.color = green;
    }
    public void SetYellow(int r, int c, char l)
    {
        letterBoxes[r, c].image.sprite = guessedSprite;
        letterBoxes[r, c].image.color = yellow;
        Image key = GameObject.Find(l.ToString().ToUpper()).GetComponent<Image>();

        if (key.color != green)
            key.color = yellow;

        
    }
    public void SetGrey(int r, int c, char l)
    {
        letterBoxes[r, c].image.sprite = guessedSprite;
        letterBoxes[r, c].image.color = gray;
        Image key = GameObject.Find(l.ToString().ToUpper()).GetComponent<Image>();

        if (key.color != green || key.color != yellow)
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

    public void Win(int g)
    {
        winScreen.GetComponentInChildren<TMP_Text>().text = "Success! In " + g + " tries";
        winScreen.SetActive(true);
    }
}
