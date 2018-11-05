using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPrefsManager : MonoBehaviour {


    public static void setUserIds(int id,string random_pass,string username)
    {
        PlayerPrefs.SetInt("user_sqLite_id", id);
        PlayerPrefs.SetString("user_random_pass", random_pass);
        PlayerPrefs.SetString("user_username", username);
        Debug.Log("User: " + username + " with ID: "+ id + " is Successfully Saved!");
    }
    public static string getUserId()
    {
        string id_return = "";
        id_return = PlayerPrefs.GetString("user_id");

        return id_return;
    }
    public static string getUser()
    {
        string id_return = "";
        id_return = PlayerPrefs.GetString("user_id");

        return id_return;
    }

    public static int[] getIndustryData()
    {
        int water_return = 0;
        int pot_return = 0;
        int light_return = 0;
        int earth_return = 0;

        water_return = PlayerPrefs.GetInt("water_level");
        pot_return = PlayerPrefs.GetInt("pot_level");
        light_return = PlayerPrefs.GetInt("light_level");
        earth_return = PlayerPrefs.GetInt("earth_level");

        int[] industryData = new int[] { water_return, pot_return, light_return, earth_return};

        return industryData;

    }
    public static void SetIndustryData(int level, String type)
    {

        PlayerPrefs.SetInt(type, level);
    }
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
