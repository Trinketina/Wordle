using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterBox : MonoBehaviour
{
    [SerializeField] Sprite guessSprite;
    public Color newColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateGuess()
    {
        this.GetComponent<Button>().image.sprite = guessSprite;
        this.GetComponent<Button>().image.color = newColor;
    }
}
