using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController Instance;

    public Text gameScore;
    public GameObject gameOverTxt;

    public int scoreLeadingZeros;
    public float scoreLerpSpeed;

    private string zeros;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start ()
    {
        zeros = "";

        for (int i = 0; i < scoreLeadingZeros; i++)
        {
            zeros += "0";
        }

        gameOverTxt.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        int currentScore = int.Parse(gameScore.text.ToString());

        if (currentScore != GameController.Instance.gameScore)
        {
            if (GameController.Instance.gameScore - currentScore > 5)
            {
                gameScore.text = Mathf.Round(Mathf.Lerp(currentScore, GameController.Instance.gameScore, scoreLerpSpeed)).ToString(zeros);
            }
            else
            {
                gameScore.text = GameController.Instance.gameScore.ToString(zeros);
            }
        }
	}

    public void ShowGameOverTxt()
    {
        gameOverTxt.SetActive(true);
    }

    public void HideGameOverTxt()
    {
        gameOverTxt.GetComponent<Text>().text = "";
        gameOverTxt.SetActive(false);
    }
}
