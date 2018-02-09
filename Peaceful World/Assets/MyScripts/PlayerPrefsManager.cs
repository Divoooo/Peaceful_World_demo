using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPrefsManager : MonoBehaviour {
    public static void SetCustomDate(string dateName,DateTime date)
    {


        PlayerPrefs.SetString(dateName, date.ToString());
    }
    public static void SetDate(string dateName)
    {
       

        PlayerPrefs.SetString(dateName, System.DateTime.Now.ToBinary().ToString());
    }

    public static DateTime GetActivationDate(string dateName)
    {
        DateTime oldDate;
        Debug.Log("datename: " + dateName);
        long temp = 0;
        string tempString = PlayerPrefs.GetString(dateName);
        
        if (tempString != "")
        {
            temp = Convert.ToInt64(tempString);
            
            oldDate = DateTime.FromBinary(temp);
            Debug.Log("date: " + oldDate);
            return oldDate;
        }
        oldDate = DateTime.Now;
        return oldDate;


    }
    public static void setFlaworValue(int value, string valueName)
    {
        PlayerPrefs.SetInt(valueName, value);
    }
    public static int GetFlaworValue(string valueName)
    {
        int currValue = 0 ;
        currValue = PlayerPrefs.GetInt(valueName);
        
        return currValue;
    }

    public static void SetLastActivityFlawour(string flawourActivity, int value)
    {
        PlayerPrefs.SetInt(flawourActivity, value);
        
    }

    public static int GetLastActivityFlafour(string flawourActivity)
    {
        int currValue = -1;
        currValue = PlayerPrefs.GetInt("sourFlawourActivity");
        if (currValue != -1)
        {
            return currValue;
        }else
        {
            Debug.Log("wrogn index in PlayerPrefs");
            return 1;
        }
    }
}
