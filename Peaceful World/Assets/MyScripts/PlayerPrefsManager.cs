using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPrefsManager : MonoBehaviour {

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
}
