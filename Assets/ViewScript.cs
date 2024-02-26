using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ViewScript : MonoBehaviour
{
    float timer = 0;
    int letter = 0;
    bool startGuess;
    bool flipped = false;
    // Start is called before the first frame update
    void Start()
    {
        startGuess = true;
    }

    // Update is called once per frame
    void Update()
    {
        FlipGuess();
    }

    public void UpdateLetter()
    {

    }

    void FlipGuess()
    {
        if (startGuess)
        {
            switch (letter)
            {
                case 0:
                    float x = 0;
                    do
                    {
                        x=Mathf.PingPong(0.1f * Time.deltaTime, 1);
                        Debug.Log(x);
                    } while (x != 0);
                    //Quaternion.Lerp(timer); // once for one 180
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default: 
                    break;
            }
        }

    }
}
