using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPicker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void loadLevelPicker()
    {
        SceneManager.LoadScene(1);
    }
    public void loadLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void loadlevel2()
    {
        SceneManager.LoadScene(3);
    }

    public void loadLevel3()
    {
        SceneManager.LoadScene(4);
    }

}
