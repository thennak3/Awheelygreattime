using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController instance;

    int pedestrianCollissions = 0;
    int wallCollissions = 0;
    int tipOvers = 0;
    int resets = 0;
    int falls = 0;
    public int startingScore;
    public int pedestrianCollissionScore;
    public int wallCollissionScore;
    public int resetScore;
    public int fallScore;

    public bool calculateFalls = false;

    public bool endLevel;
    int currentScore;
    
	// Use this for initialization
	void Start () {
        if(instance == null)
            instance = this;
        currentScore = startingScore;
	}
	
    public void ReportPedestrianCollission()
    {
        pedestrianCollissions += 1;
        GUIController.instance.SetPedestrianCollissionScore(pedestrianCollissions);
        CalculateScore();
    }

    public void ReportWallCollission()
    {
        wallCollissions += 1;
        GUIController.instance.SetWallCollissionScore(wallCollissions);
        CalculateScore();
    }

    public void ReportReset()
    {
        resets += 1;
        GUIController.instance.SetResetScore(resets);
        CalculateScore();
    }

    void CalculateScore()
    {
        currentScore = startingScore - ((wallCollissions * wallCollissionScore) + (pedestrianCollissions * pedestrianCollissionScore) + (resets * resetScore));
        if (calculateFalls)
        {
            currentScore -= falls * fallScore;
        }

        GUIController.instance.SetTotalScore(currentScore);

    }

    public void ReportFalls()
    {
        falls += 1;
        GUIController.instance.SetFallScore(falls);
        CalculateScore();
    }

}
