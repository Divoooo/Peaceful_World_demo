using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanelSrcipt : MonoBehaviour {


    public void SmellLabScene()
    {
        SceneManager.LoadScene("SmellLab");
    }
    public void THCLabScene()
    {
        SceneManager.LoadScene("THClab");
    }
    public void IndustryLabScene()
    {
        SceneManager.LoadScene("IndustryLab");
    }
    public void CBDLabScene()
    {
        SceneManager.LoadScene("CBDlab");
    }
    
}
