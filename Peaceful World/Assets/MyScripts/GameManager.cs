using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class GameManager : MonoBehaviour {

    /*  TOODOO: Set Up Player Prefs for all data
     */ 
   
    public static User user;
    public static GameManager GM;
    public static ActiveQuests activeQuests;
    ActiveQuestScript activeQuestScript;
    UserScript userScript;

    public static bool isNew;
    
 
    void Start () {
        if(isNew == false)
        {
            isNew = isNewUser();
            Debug.Log("false " + user.id);
            
            activeQuests = activeQuestScript.getActiveQuests(user.id);
            Debug.Log("acrive ques id " + activeQuests.sqlit_id);
        }


    }
	void Update () {
		
	}
    public void setIndustryData(string data,int value)
    {
        var ds = new DataService("pw_database.db");
        switch (data)
        {
            case "industry_water":
                user.industry_water = value;
                break;
            case "industry_pot":
                user.industry_pot = value;
                break;
            case "industry_light":
                user.industry_light = value;
                break;
            case "industry_earth":
                user.industry_earth = value;
                break;
            default:
                print("Wrong Data name - " + data);
                break;
        }
        //TOODOO: Update database
        ds.UpdateUser(user);
    }
    public bool updateCredit(int value)
    {
        var ds = new DataService("pw_database.db");
        if (haveCredit(value))
        {
           float tempInt = user.credit;
            user.credit = tempInt - value;
            ds.UpdateUser(user);
            return true;
        }else
        {
            Debug.Log("Not Enought Credit");
            return false;
        }
    }
    public bool haveCredit(int value)
    {
        if (user.credit > value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Awake()
    {
        
        DontDestroyOnLoad(this);
        MakeThisTheOnlyGameManager();
        activeQuestScript = GetComponent<ActiveQuestScript>();
        userScript = GetComponent<UserScript>();


    }


                                        //////////////// User //////////////////////

    public bool isNewUser()
    {
        if (PlayerPrefs.GetString("user_username") != null)
        {
            getUser(PlayerPrefs.GetInt("user_sqLite_id"));
            return false;
        }
        else
        {
            //TOODOO: set Active NewUser panel
            GameObject.Find("ScriptHolder").GetComponent<MainSceneFrontendScript>().showPanel();

            return true;
        }
    }
    public User getStaticUser()
    {
        /* get Already signed in user       
        */
        return user;
    }
    public void getUser(int id)
    {
        /* get User from database  
        */
        user = userScript.getUser(id);
    }
    public void setUser(User tempUser)
    {
        tempUser = user;
    }

                                      
                                      ////////////// Active Quests //////////////////////
                                      
   

    public Dictionary<int, DateTime> checkQuests()
    {   
        return activeQuestScript.checkQuests(activeQuests);
    }
    public void updateActiveQuest()
    {
        activeQuestScript.updateActiveQuest(activeQuests);

    }
    public ActiveQuests getActiveQuests()
    {
        return activeQuestScript.getActiveQuests(user.id);
    }
    public int getSlotNum()
    {
        return user.num_of_slots;
    }

                                    ////////////// this Game Object //////////////////////

    void MakeThisTheOnlyGameManager()
    {
        if (GameObject.FindGameObjectsWithTag("game_manager").Length == 2)
        {
            Destroy(gameObject);
        }
    }
    /*
    public void resortActiveQuestsAndSave(Dictionary<int, DateTime> quests)
    {
        ActiveQuests tempActiveQuest = new ActiveQuests();
        int slotNum = 1;
        foreach (var quest in quests)
        {
            switch (slotNum)
            {
                case 1:
                    tempActiveQuest.one_quest_id = quest.Key;
                    tempActiveQuest.one_quest_time = quest.Value;

                    break;
                case 2:
                    tempActiveQuest.two_quest_id = quest.Key;
                    tempActiveQuest.two_quest_time = quest.Value;

                    break;
                case 3:
                    tempActiveQuest.three_quest_id = quest.Key;
                    tempActiveQuest.three_quest_time = quest.Value;

                    break;
                case 4:
                    tempActiveQuest.four_quest_id = quest.Key;
                    tempActiveQuest.four_quest_time = quest.Value;

                    break;
                case 5:
                    tempActiveQuest.five_quest_id = quest.Key;
                    tempActiveQuest.five_quest_time = quest.Value;

                    break;
                case 6:
                    tempActiveQuest.six_quest_id = quest.Key;
                    tempActiveQuest.six_quest_time = quest.Value;

                    break;
                case 7:
                    tempActiveQuest.seven_quest_id = quest.Key;
                    tempActiveQuest.seven_quest_time = quest.Value;

                    break;
                case 8:
                    tempActiveQuest.eight_quest_id = quest.Key;
                    tempActiveQuest.eight_quest_time = quest.Value;

                    break;
                case 9:
                    tempActiveQuest.nine_quest_id = quest.Key;
                    tempActiveQuest.nine_quest_time = quest.Value;

                    break;
                case 10:
                    tempActiveQuest.ten_quest_id = quest.Key;
                    tempActiveQuest.ten_quest_time = quest.Value;

                    break;

                default:
                    Debug.Log("Wrong Index in Active Quests");
                    break;
            }
            slotNum++;
        }
        activeQuests = tempActiveQuest;
        updateActiveQuest();
    }
    */

}
