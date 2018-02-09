using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndustryLabManager : MonoBehaviour {


    public int waterLvl;
    public int potLvl;
    public int lightLvl;
    public int earthLvl;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void backScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
