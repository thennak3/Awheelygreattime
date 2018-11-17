using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel(int ID)
    {
        Application.LoadLevel(ID);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
