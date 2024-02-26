using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelScript : MonoBehaviour
{
    int guessCount;
    string correctAnswer;
    string guess; //needs to be limited to 5 chars
    public string Guess 
    { 
        get { return guess; } 
        set { guess = value.Length <= 5 ? value : guess; }
    }

    string[] possibleAnswers;
    string[] possibleGuesses;

}
