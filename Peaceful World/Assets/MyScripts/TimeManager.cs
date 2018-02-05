using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    int currentFlawourYear;
    int currentFlawourMonth;
    int currentFlawourDay;
    int currentFlawourHour;

    


    DateTime lastActiveDate;
    DateTime dateNow;

    public static bool sourFlawourActive = false;
    public static bool spicyFlawourActive = false;
    public static bool sweetFlawourActive = false;
    public static bool bitterFlawourActive = false;
    public static bool savoryFlawourActive = false;

    // DateTime dateTime1 = new DateTime(1970, 1, 1).TotalSeconds;



    private static TimeManager _instance;


    public static TimeManager Instance
    {

        get
        {
            // IF there is currently no instance create instance
            if (_instance == null)
            {
                GameObject TimeManager = new GameObject("TimeManager");
                TimeManager.AddComponent<TimeManager>();
            }
            return _instance;
        }

    }


    // Use this for initialization
    void Awake () {

        /* DateTime datevalue1 = new System.DateTime(2018, 1, 1,12,10,0);
         DateTime datevalue2 = System.DateTime.Now;
         double hours = (datevalue2 - datevalue1).TotalDays;
         Debug.Log("It has been " + hours.ToString() + " days since the beginning of the year");

         long temp = Convert.ToInt64(DateTime.Now.ToBinary().ToString());
         DateTime oldDate = DateTime.FromBinary(temp);
         Debug.Log("Now is " + oldDate.Day + " day");


         lastActiveDate = PlayerPrefsManager.GetActivationDate("lastActiveDate");
         getTimeDetails("sourFlaworDate");
         getTimeDetails("spacyFlaworeDate");
         getTimeDetails("sweetFlaworDate");
         getTimeDetails("bitterFlaworDate");
         getTimeDetails("savoryFlaworDate");
         */
    }

    // Update is called once per frame
    void Update () {
       



        // dateTime1 = DateTime.Now.ge;
        //DateTimeToUnixTimestamp()
    }
    public void getTimeDetails(string dateName)
    {
        DateTime currentActivationDate = PlayerPrefsManager.GetActivationDate(dateName);
        if (currentActivationDate != null)
        {


            switch (dateName)
            {
                case "sourFlaworDate":

                    sourFlawourActive = CheckTime(currentActivationDate);


                    break;
                case "spicyFlaworDate":

                    spicyFlawourActive = CheckTime(currentActivationDate);

                    break;
                case "sweetFlaworDate":

                    sweetFlawourActive = CheckTime(currentActivationDate);

                    break;
                case "bitterFlaworDate":

                    bitterFlawourActive = CheckTime(currentActivationDate);

                    break;
                case "savoryFlaworDate":

                    savoryFlawourActive = CheckTime(currentActivationDate);

                    break;
            }
        }else
        {
            Debug.Log("Theres no actived date");
        }
    }
    public bool CheckTime(DateTime activeTime) {


        DateTime datevalue1 = activeTime;
        DateTime datevalue2 = DateTime.Now;
        double hours = (datevalue2 - datevalue1).TotalHours;
        Debug.Log("It has been " + hours.ToString() + " hours since u Active that Flawor");
        if (hours < 0.11 && hours != 0.000)
        {
            return true;
        }else
        {
            return false;
        }




        

    }
    public void getBooleans()
    {
        Debug.Log("getBoolians");
        lastActiveDate = PlayerPrefsManager.GetActivationDate("lastActiveDate");
        getTimeDetails("sourFlaworDate");
        getTimeDetails("spicyFlaworDate");
        getTimeDetails("sweetFlaworDate");
        getTimeDetails("bitterFlaworDate");
        getTimeDetails("savoryFlaworDate");
    }
   
}
