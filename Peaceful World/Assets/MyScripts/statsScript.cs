using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsScript : MonoBehaviour {
    public Text sourLvl;
    public Text spicyLvl;
    public Text sweetLvl;
    public Text bitterLvl;
    public Text savoryLvl;
    public Text industry;
    public Text thc;
    public Text cbd;


	// Use this for initialization
	void Start () {
        sourLvl.text = PlayerPrefsManager.GetFlaworValue("sourFlaworValue").ToString();
        spicyLvl.text = PlayerPrefsManager.GetFlaworValue("spicyFlaworValue").ToString();
        sweetLvl.text = PlayerPrefsManager.GetFlaworValue("sweetFlaworValue").ToString();
        bitterLvl.text = PlayerPrefsManager.GetFlaworValue("bitterFlaworValue").ToString();
        savoryLvl.text = PlayerPrefsManager.GetFlaworValue("savoryFlaworValue").ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
