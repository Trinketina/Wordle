using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    [SerializeField] ViewScript view;
    [SerializeField] ModelScript model;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Setup()
    {

    }

    public void InputLetter(string l)
    {
        model.Guess += l;
        view.UpdateLetter();
    }

    public bool CheckGuess()
    {
        return true;
    }


    void Win()
    {

    }
}
