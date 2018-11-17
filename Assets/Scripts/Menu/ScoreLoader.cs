using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreLoader : MonoBehaviour {

    public Text previousAttempt;
    public Text History;

    public string playerPrefScoreKey;
    public string playerPrefScoreHistoryKey;

	// Use this for initialization
	void Start () {
        
        int score = PlayerPrefs.GetInt(playerPrefScoreKey);
        previousAttempt.text = score.ToString();
        string histcomp = "";
        int[] hist = PlayerPrefsX.GetIntArray(playerPrefScoreHistoryKey);
        for(int i = 1; i < hist.Length;i++)
        {
            Debug.Log(hist[i]);
            histcomp +=  hist[i] + "\r\n";
        }
        History.text = histcomp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
