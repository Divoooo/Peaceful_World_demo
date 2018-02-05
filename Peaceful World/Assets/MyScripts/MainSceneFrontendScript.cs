using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneFrontendScript : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject menuButton;
    Text menuButtonText;

    bool menuPanelActive = false;

    // Use this for initialization
    void Start()
    {
        menuButtonText = menuButton.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MenuButton()
    {


        if (!menuPanelActive)
        {
            menuPanelActive = true;
            menuPanel.SetActive(true);
            menuButtonText.text = "Close";

        }
        else
        {
            menuPanelActive = false;
            menuPanel.SetActive(false);

            menuButtonText.text = "Menu";
        }
    }
}