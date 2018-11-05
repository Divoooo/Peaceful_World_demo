using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SmellLabManager : MonoBehaviour {
    public Text sourText;
    public Text spicyText;
    public Text sweetText;
    public Text bitterText;
    public Text savoryText;

    public Text activityStatus;
    public GameObject statusPanel;

    //stats from database
    public int sourFlawourValue;
    public int spicyFlawourValue;
    public int sweetFlawourValue;
    public int bitterFlawourValue;
    public int savoryFlawourValue;

    //booleans for increase or decrease 
    public static bool SourFlawourActive;
    public static bool SpicyFlawourActive;
    public static bool SweetFlawourActive;
    public static bool BitterFlawourActive;
    public static bool SavoryFlawourActive;

    //Index for Prefs
    public int SourFlawourIndex;
    public int SpicyFlawourIndex;
    public int SweetFlawourIndex;
    public int BitterFlawourIndex;
    public int SavoryFlawourIndex;

    DateTime lastActiveDate;
    DateTime dateNow;

    void Awake()
    {

        sourFlawourValue = PlayerPrefsManager.GetFlaworValue("sourFlaworValue");
        spicyFlawourValue = PlayerPrefsManager.GetFlaworValue("spicyFlaworValue");
        sweetFlawourValue = PlayerPrefsManager.GetFlaworValue("sweetFlaworValue");
        bitterFlawourValue = PlayerPrefsManager.GetFlaworValue("bitterFlaworValue");
        savoryFlawourValue = PlayerPrefsManager.GetFlaworValue("savoryFlaworValue");


        lastActiveDate = PlayerPrefsManager.GetActivationDate("lastActiveDate");
        this.GetComponent<TimeManager>().getBooleans();


    }

    // Use this for initialization
    void Start () {
        //get all the stats from databases
        /* SetDecreaseValue(TimeManager.sourFlawourActive, sourFlawourValue);
         SetDecreaseValue(TimeManager.spicyFlawourActive, spicyFlawourValue);
         SetDecreaseValue(TimeManager.sweetFlawourActive, sweetFlawourValue);
         SetDecreaseValue(TimeManager.bitterFlawourActive, bitterFlawourValue);
         SetDecreaseValue(TimeManager.savoryFlawourActive, savoryFlawourValue);
         */
        checkActivity();



     }

     // Update is called once per frame
     void Update () {
         dateNow = DateTime.Now;
     }
     /*
     public void SetDecreaseValue(bool increaseActive,int flawour)
     {

         //TOODOO: FIX THIS TO WORK GOOD

         if (!increaseActive)
         {
             double day = (lastActiveDate - dateNow).TotalHours;
             Debug.Log("For Reduce: " + day + ", and flawour is : "+ flawour);
             if(day > 0.001)
             {
                 int reduceValue = (int)day;
                 Debug.Log("For Reduce: " + reduceValue);
                 if (reduceValue >= flawour)
                 {
                     flawour = 0;
                     Debug.Log("For flavor value: " + sourFlawourValue + ", and flawour is : " + flawour);
                 }
                 else
                 {
                     flawour -= reduceValue;
                     Debug.Log("For Reduce: " + day + ", and flawour is : " + flawour);
                 }

             }

         }
         Debug.Log("Doso");
         saveToPrefs();


     }
     */
  

    public void BuySour()
    {
        this.GetComponent<TimeManager>().getBooleans();
        if (!TimeManager.sourFlawourActive)
        {
            
            PlayerPrefsManager.SetDate("sourFlaworDate");
            sourFlawourValue++;
            Debug.Log("Clicked Button new value: " + sourFlawourValue);
            //  Debug.Log("Clicked Button With Tag : " + this.tag);
            PlayerPrefsManager.SetLastActivityFlawour("sourFlawourIndex", 1);
            saveToPrefs();
        }

    }
    public void BuySpicy()
    {
        this.GetComponent<TimeManager>().getBooleans();
        if (!TimeManager.spicyFlawourActive)
        {
            PlayerPrefsManager.SetDate("spicyFlaworDate");
            spicyFlawourValue++;
            Debug.Log("Clicked Button new value: " + spicyFlawourValue);
            // Debug.Log("Clicked Button With Tag : " + this.tag);
            PlayerPrefsManager.SetLastActivityFlawour("spicyFlawourIndex", 1);
            saveToPrefs();
        }

    }
    public void BuySweet()
    {
        this.GetComponent<TimeManager>().getBooleans();
        if (!TimeManager.sweetFlawourActive)
        {
            PlayerPrefsManager.SetDate("sweetFlaworDate");

            sweetFlawourValue++;
            Debug.Log("Clicked Button new value: " + sweetFlawourValue);
            //  Debug.Log("Clicked Button With Tag : " + this.tag);
            PlayerPrefsManager.SetLastActivityFlawour("sweetFlaworIndex", 1);
            saveToPrefs();
        }

    }
    public void BuyBitter()
    {
        this.GetComponent<TimeManager>().getBooleans();
        if (!TimeManager.bitterFlawourActive)
        {
            PlayerPrefsManager.SetDate("bitterFlaworDate");
            bitterFlawourValue++;
            Debug.Log("Clicked Button new value: " + bitterFlawourValue);
            //   Debug.Log("Clicked Button With Tag : " + this.tag);
            PlayerPrefsManager.SetLastActivityFlawour("bitterFlaworIndex", 1);

            saveToPrefs();
        }

    }
    public void BuySavory()
    {
        this.GetComponent<TimeManager>().getBooleans();
        if (!TimeManager.savoryFlawourActive)
        {
            PlayerPrefsManager.SetDate("savoryFlaworDate");
            savoryFlawourValue++;
            Debug.Log("Clicked Button new value: " + savoryFlawourValue);
            //Debug.Log("Clicked Button With Tag : " + this.tag);
            PlayerPrefsManager.SetLastActivityFlawour("savoryFlaworIndex", 1);

            saveToPrefs();
        }

    }
    public void closeStatus()
    {
        statusPanel.SetActive(false);
    }
    
    public void saveToPrefs()
    {
        PlayerPrefsManager.setFlaworValue(sourFlawourValue, "sourFlaworValue");
        PlayerPrefsManager.setFlaworValue(spicyFlawourValue, "spicyFlaworValue");
        PlayerPrefsManager.setFlaworValue(sweetFlawourValue, "sweetFlaworValue");
        PlayerPrefsManager.setFlaworValue(bitterFlawourValue, "bitterFlaworValue");
        PlayerPrefsManager.setFlaworValue(savoryFlawourValue, "savoryFlaworValue");
        PlayerPrefsManager.SetDate("lastActiveDate");
        setTexts();
    }

    public void setTexts()
    {
        sourText.text = sourFlawourValue.ToString();
        spicyText.text = spicyFlawourValue.ToString();
        sweetText.text = sweetFlawourValue.ToString();
        bitterText.text = bitterFlawourValue.ToString();
        savoryText.text = savoryFlawourValue.ToString();
}
    public void backScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
