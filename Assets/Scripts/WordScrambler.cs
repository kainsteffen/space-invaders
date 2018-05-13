using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordScrambler : MonoBehaviour
{
    public string targetString;
    public float interval;
    private float intervalCooldown;

    private bool scrambling = false;
    private bool fakeLetter = true;

    private Text textDisplay;

    private char[] letters;
    private char[] currentWord;

    private int index;

    // Use this for initialization
    void Start()
    {
        textDisplay = GetComponent<Text>();

        letters = targetString.ToCharArray();

       
    }

    private void OnEnable()
    {
        scrambling = true;

        currentWord = new char[targetString.Length];
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (scrambling)
        {
            intervalCooldown -= Time.deltaTime;

            if (intervalCooldown < 0)
            {
                if (fakeLetter)
                {
                    currentWord[index] = letters[Random.Range(0, letters.Length)];

                    fakeLetter = false;
                }
                else
                {
                    currentWord[index] = letters[index];

                    fakeLetter = true;

                    index++;
                }

                textDisplay.text = new string(currentWord);

                if (textDisplay.text.Equals(targetString))
                {
                    scrambling = false;
                }

                intervalCooldown = interval;
            }
        }
    }
}
