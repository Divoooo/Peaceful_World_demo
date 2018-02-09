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
    public void checkActivity()
    {
        SourFlawourIndex = PlayerPrefsManager.GetLastActivityFlafour("sourFlawourIndex");
        SpicyFlawourIndex = PlayerPrefsManager.GetLastActivityFlafour("spicyFlawourIndex");
        SweetFlawourIndex = PlayerPrefsManager.GetLastActivityFlafour("sweetFlawourIndex");
        BitterFlawourIndex = PlayerPrefsManager.GetLastActivityFlafour("bitterFlaworValue");
        SavoryFlawourIndex = PlayerPrefsManager.GetLastActivityFlafour("savoryFlaworValue");


        DateTime datevalue1 = lastActiveDate;
        DateTime datevalue2 = DateTime.Now;

        DateTime currentDate;
        double minutesDouble = (datevalue2 - datevalue1).TotalMinutes;
        int minutes = (int)minutesDouble; 
        Debug.Log(" vrijeme : " + minutes.ToString());
        
        string status = "From last activiti past " + minutes + " min @For every 5 minutes we take 1 lvl @"  ;
        if (!TimeManager.sourFlawourActive && SourFlawourIndex == 0)
        {
            currentDate = PlayerPrefsManager.GetActivationDate("sourFlaworDate");
            
            if (minutes > 5)
            {
                double curDouble = (datevalue2 - currentDate).TotalMinutes;
                int curInt = (int)curDouble;

              
                if (curInt >= sourFlawourValue)
                {
                    int lvlNow = spicyFlawourValue;
                    sourFlawourValue = 0;
                    status += "Sour Lvl was : " + sourFlawourValue + " minus " + (minutes / 5) + ", And now is lvl : " + sourFlawourValue + "@";
                    PlayerPrefsManager.SetDate("sourFlaworDate");

                }
                else
                {
                    int lvlNow = spicyFlawourValue;
                    sourFlawourValue -= curInt;
                    status += "Sour Lvl was : " + sourFlawourValue + " minus " + (minutes / 5) + ", And now is lvl : " + sourFlawourValue + "@";
                    PlayerPrefsManager.SetDate("sourFlaworDate");

                }

            }
        }
        if (!TimeManager.spicyFlawourActive)
        {
            currentDate = PlayerPrefsManager.GetActivationDate("spicyFlaworDate");
            // minutes = (lastActiveDate - dateNow).TotalMinutes;
            if (minutes > 5)
            {
                double curDouble = (datevalue2 - currentDate).TotalMinutes;
                int curInt = (int)curDouble;
                if (curInt >= spicyFlawourValue)
                {
                    int lvlNow = spicyFlawourValue;
                    spicyFlawourValue = 0;
                    status += "Spicy Lvl was : " + lvlNow + " minus " + (minutes / 5) + ", And now is lvl : " + sourFlawourValue + "@";
                    PlayerPrefsManager.SetDate("spicyFlaworDate");
                }
                else
                {
                    int lvlNow = spicyFlawourValue;
                    spicyFlawourValue -= curInt;
                    status += "Spicy Lvl was : " + lvlNow + " minus " + (minutes / 5) + ", And now is lvl : " + sourFlawourValue + "@";
                    PlayerPrefsManager.SetDate("spicyFlaworDate");
                }

            }
        }
        if (!TimeManager.sweetFlawourActive)
        {
            currentDate = PlayerPrefsManager.GetActivationDate("sweetFlaworDate");
            // double minutes = (lastActiveDate - dateNow).TotalMinutes;
            if (minutes > 5)
            {
                double curDouble = (datevalue2 - currentDate).TotalMinutes;
                int curInt = (int)curDouble;
                if (curInt >= sweetFlawourValue)
                {
                    int lvlNow = sweetFlawourValue;
                    sweetFlawourValue = 0;
                    status += "Sweet Lvl was : " + lvlNow + " minus " + (minutes / 5) + ", And now is lvl : " + sweetFlawourValue + "@";
                    PlayerPrefsManager.SetDate("sweetFlaworDate");
                }
                else
                {
                    int lvlNow = sweetFlawourValue;
                    sweetFlawourValue -= curInt;
                    status += "Sweet Lvl was : " + lvlNow + " minus " + (minutes / 5) + ", And now is lvl : " + sweetFlawourValue + "@";
                    PlayerPrefsManager.SetDate("sweetFlaworDate");

                }

            }
        }
        if (!TimeManager.bitterFlawourActive)
        {
            currentDate = PlayerPrefsManager.GetActivationDate("bitterFlaworDate");
            // double minutes = (lastActiveDate - dateNow).TotalMinutes;
            if (minutes > 5)
            {
                double curDouble = (datevalue2 - currentDate).TotalMinutes;
                int curInt = (int)curDouble;
                if (curInt >= bitterFlawourValue)
                {
                    int lvlNow = bitterFlawourValue;
                    bitterFlawourValue = 0;
                    status += "Bitter Lvl was : " + lvlNow + " minus " + (minutes / 5) + ", And now is lvl : " + bitterFlawourValue + "@";
                    PlayerPrefsManager.SetDate("bitterFlaworDate");
                }
                else
                {
                    int lvlNow = bitterFlawourValue;
                    bitterFlawourValue -= curInt;
                    status += "Bitter Lvl was : " + lvlNow + " minus " + (minutes / 5) + ", And now is lvl : " + bitterFlawourValue + "@";
                    PlayerPrefsManager.SetDate("bitterFlaworDate");

                }

            }
        }
        if (!TimeManager.savoryFlawourActive)
        {
            currentDate = PlayerPrefsManager.GetActivationDate("savoryFlaworDate");
            //  double minutes = (lastActiveDate - dateNow).TotalMinutes;
            if (minutes > 5)
            {
                double curDouble = (datevalue2 - currentDate).TotalMinutes;
                int curInt = (int)curDouble;
                if (curInt >= savoryFlawourValue)
                {
                    int lvlNow = savoryFlawourValue;
                    savoryFlawourValue = 0;
                    status += "Savory Lvl was : " + lvlNow + " minus " + (minutes / 5) + ", And now is lvl : " + savoryFlawourValue + "@";
                    PlayerPrefsManager.SetDate("savoryFlaworDate");

                }
                else
                {
                    int lvlNow = savoryFlawourValue;
                    savoryFlawourValue -= curInt;
                    status += "Savory Lvl was : " + lvlNow + " minus " + (minutes / 5) + ", And now is lvl : " + savoryFlawourValue + "@";
                    PlayerPrefsManager.SetDate("savoryFlaworDate");


                }

            }
        }
        saveToPrefs();
        if (minutes > 0.25)
        {
            statusPanel.SetActive(true);
            status = status.Replace("@", "@" + System.Environment.NewLine);
            activityStatus.text = status;

        }
        

    }

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
