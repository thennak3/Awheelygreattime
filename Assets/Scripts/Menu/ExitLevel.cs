using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {

    public GameObject exitmenu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button10) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (exitmenu.activeInHierarchy)
                exitmenu.SetActive(false);
            else
                exitmenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && exitmenu.activeInHierarchy)
            Exit();
	}

    public void Exit()
    {
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }
}
