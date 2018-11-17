using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class FinishLevel : MonoBehaviour, IHasActions {
    public MovementScript movementScript;
    public GameObject endLevelCanvas;
    // Use this for initialization

    public Text pedestrianCollissionText;
    public Text wallCollissionsText;
    public Text tipOverText;
    public Text resetsText;
    public Text currentScore;
    public Text fallScore;

    public string levelName = "Level1ScoreHistory";
    public string lastScoreName = "Level1LastScore";

    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void DoAction()
    {
        movementScript.KillMovement();
        movementScript.enabled = false;

        endLevelCanvas.SetActive(true);
        pedestrianCollissionText.text = GUIController.instance.pedestrianCollissionText.text;
        wallCollissionsText.text = GUIController.instance.wallCollissionsText.text;
        resetsText.text = GUIController.instance.resetsText.text;
        currentScore.text = GUIController.instance.currentScore.text;
        if(fallScore!= null)
            fallScore.text = GUIController.instance.fallText.text;
        PlayerPrefs.SetInt(lastScoreName, Convert.ToInt32(currentScore.text));
        int[] lastScores = PlayerPrefsX.GetIntArray(levelName, 0, 10);
        for(int i = lastScores.Length -1; i > 0;i--)
        {
            lastScores[i] = lastScores[i - 1];
        }
        lastScores[0] = Convert.ToInt32(currentScore.text);
        PlayerPrefsX.SetIntArray(levelName, lastScores);
        PlayerPrefs.Save();
        GameController.instance.endLevel = true;
    }

    public bool IsActive()
    {
        throw new NotImplementedException();
    }
}
