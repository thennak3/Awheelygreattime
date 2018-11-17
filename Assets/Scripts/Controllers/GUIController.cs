using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GUIController : MonoBehaviour {

    // Use this for initialization

    public static GUIController instance;

    public Text pedestrianCollissionText;
    public Text wallCollissionsText;
    public Text tipOverText;
    public Text resetsText;
    public Text currentScore;
    public Text fallText;
    public Text objectivesRemaining;
    public Text objectiveText;

    void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void SetPedestrianCollissionScore(int score)
    {
        pedestrianCollissionText.text = score.ToString();
    }

    public void SetWallCollissionScore(int score)
    {
        wallCollissionsText.text = score.ToString();
    }

    public void SetTipOverScore(int score)
    {
        tipOverText.text = score.ToString();
    }

    public void SetResetScore(int score)
    {
        resetsText.text = score.ToString();
    }

    public void SetFallScore(int score)
    {
        fallText.text = score.ToString();
    }

    public void SetTotalScore(int score)
    {
        currentScore.text = score.ToString();
    }

    public void SetObjectivesRemaining(int score)
    {
        objectivesRemaining.text = score.ToString();
    }

    public void SetObjectiveText(string text)
    {
        objectiveText.text = text;
    }

}
