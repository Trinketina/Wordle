using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ViewScript : MonoBehaviour
{
    [SerializeField] Sprite blankSprite;
    [SerializeField] Sprite filledSprite;
    [SerializeField] Sprite greenSprite;
    [SerializeField] Sprite yellowSprite;
    [SerializeField] Sprite greySprite;

    [SerializeField] Color green;
    [SerializeField] Color yellow;
    [SerializeField] Color gray;

    [SerializeField] GameObject guesses;

    Button[,] letterBoxes = new Button[6,5];

    [SerializeField] ModelScript model;

    /*float timer = 0;
    int letter = 0;
    bool startGuess;
    bool flipped = false; */
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
        letterBoxes[r, c].image.sprite = greenSprite;
        Image key = GameObject.Find(l.ToString().ToUpper()).GetComponent<Image>();
        key.color = green;
    }
    public void SetYellow(int r, int c, char l)
    {
        letterBoxes[r, c].image.sprite = yellowSprite;
        Image key = GameObject.Find(l.ToString().ToUpper()).GetComponent<Image>();

        if (key.color != green)
            key.color = yellow;

        
    }
    public void SetGrey(int r, int c, char l)
    {
        letterBoxes[r, c].image.sprite = greySprite;
        Image key = GameObject.Find(l.ToString().ToUpper()).GetComponent<Image>();

        if (key.color != green || key.color != yellow)
            key.color = gray;
    }

    public void UpdateLetter(int r, int c, char l)
    {
        letterBoxes[r, c].GetComponentInChildren<TMP_Text>().text = l.ToString();
    }
}
