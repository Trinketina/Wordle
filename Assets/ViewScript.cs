using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ViewScript : MonoBehaviour
{
    [SerializeField] Sprite blank;
    [SerializeField] Sprite filled;
    [SerializeField] Sprite green;
    [SerializeField] Sprite yellow;
    [SerializeField] Sprite grey;

    [SerializeField] GameObject guesses;

    Button[,] letterBoxes = new Button[6,5];

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

    public void SetGreen(int r, int c)
    {
        //get the guessCount for the Row, and guess char for the Column
        letterBoxes[r, c].image.sprite = green;
    }
    public void SetYellow(int r, int c)
    {
        letterBoxes[r, c].image.sprite = yellow;
    }
    public void SetGrey(int r, int c)
    {
        letterBoxes[r, c].image.sprite = grey;
    }

    /*void FlipGuess(int guessCount) //guessCount used for finding the row of the array to animate | int letter can be used to find the other half of the array, but needs to be divided by 2
    {
        if (startGuess)
        {
            switch (letter)
            {
                case 0:
                    //MAKE A WORKING LERP | Quaternion.Lerp(timer); // once for one 180
                    timer += Time.deltaTime;
                    Mathf.PingPong(0.1f,1);
                    if (timer >= 1)
                    {
                        letter++;
                        timer = 0;
                    }
                    break;
                case 1:
                    //ADD LERP | flip the lerp above for the second 180
                    timer += Time.deltaTime;
                    Mathf.PingPong(0.1f, 1);
                    if (timer >= 1)
                    {
                        letter++;
                        timer = 0;
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                default:
                    startGuess = false;
                    letter = 1;
                    break;
            }
        }

    }*/
}
