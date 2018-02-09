using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneFrontendScript : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject menuButton;
    Text menuButtonText;

    public GameObject statsPanel;

    bool menuPanelActive = false;
    bool statsPanelActive = false;

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
            statsPanel.SetActive(false);
            statsPanelActive = false;
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
    public void statsButton()
    {


        if (!statsPanelActive)
        {
            statsPanelActive = true;
            menuPanel.SetActive(false);
            menuPanelActive = false;
            statsPanel.SetActive(true);
           // menuButtonText.text = "Close";

        }
        else
        {
            statsPanelActive = false;
            statsPanel.SetActive(false);

           // menuButtonText.text = "Menu";
        }
    }
   
}