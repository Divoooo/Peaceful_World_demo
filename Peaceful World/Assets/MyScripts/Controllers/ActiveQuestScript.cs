using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveQuestScript : MonoBehaviour {
   
   
   // public static ActiveQuests activeQuests;


    // Use this for initialization
    void Start (){


	}

	void Update () {
		
	}
    void Awake()
    {

    }
    public ActiveQuests getActiveQuests(int id)
    {
        ActiveQuests activeQuests = new ActiveQuests();
        var ds = new DataService("pw_database.db");
        activeQuests = ds.GetActiveQuests(id) ?? new ActiveQuests();
        Debug.Log("id : " + activeQuests.id);
        if (activeQuests.sqlit_id != id)
        {
            Debug.Log("Should never be a case cause whe Its addingnewuser it's add quests as well");    
            activeQuests.sqlit_id = id;
            //save it to database
        }
        return activeQuests;
    }

    public void updateActiveQuest(ActiveQuests activeQuests)
    {
        var ds = new DataService("pw_database.db");
        ds.updateActiveQuests(activeQuests);
    }
    public Dictionary<int, DateTime> checkQuests(ActiveQuests activeQuests)
    {



        Dictionary<int, DateTime> quests = new Dictionary<int, DateTime>();

        DateTime dateNow = System.DateTime.Now;
        if (activeQuests.one_quest_time > dateNow)
        {
            quests.Add(activeQuests.one_quest_id, activeQuests.one_quest_time);
        }
        if (activeQuests.two_quest_time > dateNow)
        {
            quests.Add(activeQuests.two_quest_id, activeQuests.two_quest_time);
        }
        if (activeQuests.three_quest_time > dateNow)
        {
            quests.Add(activeQuests.three_quest_id, activeQuests.three_quest_time);
        }
        if (activeQuests.four_quest_time > dateNow)
        {
            quests.Add(activeQuests.four_quest_id, activeQuests.four_quest_time);
        }
        if (activeQuests.five_quest_time > dateNow)
        {
            quests.Add(activeQuests.five_quest_id, activeQuests.five_quest_time);
        }
        if (activeQuests.six_quest_time > dateNow)
        {
            quests.Add(activeQuests.six_quest_id, activeQuests.six_quest_time);
        }
        if (activeQuests.seven_quest_time > dateNow)
        {
            quests.Add(activeQuests.seven_quest_id, activeQuests.seven_quest_time);
        }
        if (activeQuests.eight_quest_time > dateNow)
        {
            quests.Add(activeQuests.eight_quest_id, activeQuests.eight_quest_time);
        }
        if (activeQuests.nine_quest_time > dateNow)
        {
            quests.Add(activeQuests.nine_quest_id, activeQuests.nine_quest_time);
        }
        if (activeQuests.ten_quest_time > dateNow)
        {
            quests.Add(activeQuests.ten_quest_id, activeQuests.ten_quest_time);
        }

        resortActiveQuestsAndSave(quests,activeQuests);
        return quests;

    }
    public void resortActiveQuestsAndSave(Dictionary<int, DateTime> quests, ActiveQuests activeQuests)
    {
        //ActiveQuests tempActiveQuest = new ActiveQuests();
        //tempActiveQuest.id = id;

        int slotNum = 1;
        foreach (var quest in quests)
        {
            switch (slotNum)
            {
                case 1:
                    activeQuests.one_quest_id = quest.Key;
                    activeQuests.one_quest_time = quest.Value;

                    break;
                case 2:
                    activeQuests.two_quest_id = quest.Key;
                    activeQuests.two_quest_time = quest.Value;

                    break;
                case 3:
                    activeQuests.three_quest_id = quest.Key;
                    activeQuests.three_quest_time = quest.Value;

                    break;
                case 4:
                    activeQuests.four_quest_id = quest.Key;
                    activeQuests.four_quest_time = quest.Value;

                    break;
                case 5:
                    activeQuests.five_quest_id = quest.Key;
                    activeQuests.five_quest_time = quest.Value;

                    break;
                case 6:
                    activeQuests.six_quest_id = quest.Key;
                    activeQuests.six_quest_time = quest.Value;

                    break;
                case 7:
                    activeQuests.seven_quest_id = quest.Key;
                    activeQuests.seven_quest_time = quest.Value;

                    break;
                case 8:
                    activeQuests.eight_quest_id = quest.Key;
                    activeQuests.eight_quest_time = quest.Value;

                    break;
                case 9:
                    activeQuests.nine_quest_id = quest.Key;
                    activeQuests.nine_quest_time = quest.Value;

                    break;
                case 10:
                    activeQuests.ten_quest_id = quest.Key;
                    activeQuests.ten_quest_time = quest.Value;

                    break;

                default:
                    Debug.Log("Wrong Index in Active Quests");
                    break;
            }
            slotNum++;
        }

        string dateInput = "Jan 1, 0001";
        DateTime tempDate = DateTime.Parse(dateInput);

        for (int i = 10; i >= slotNum; i--)
        {
            switch (i)
            {
                case 1:
                    activeQuests.one_quest_id = -1;
                    activeQuests.one_quest_time = tempDate;

                    break;
                case 2:
                    activeQuests.two_quest_id = -1;
                    activeQuests.two_quest_time = tempDate;

                    break;
                case 3:
                    activeQuests.three_quest_id = -1;
                    activeQuests.three_quest_time = tempDate;

                    break;
                case 4:
                    activeQuests.four_quest_id = -1;
                    activeQuests.four_quest_time = tempDate;

                    break;
                case 5:
                    activeQuests.five_quest_id = -1;
                    activeQuests.five_quest_time = tempDate;

                    break;
                case 6:
                    activeQuests.six_quest_id = -1;
                    activeQuests.six_quest_time = tempDate;

                    break;
                case 7:
                    activeQuests.seven_quest_id = -1;
                    activeQuests.seven_quest_time = tempDate;

                    break;
                case 8:
                    activeQuests.eight_quest_id = -1;
                    activeQuests.eight_quest_time = tempDate;

                    break;
                case 9:
                    activeQuests.nine_quest_id = -1;
                    activeQuests.nine_quest_time = tempDate;

                    break;
                case 10:
                    activeQuests.ten_quest_id = -1;
                    activeQuests.ten_quest_time = tempDate;

                    break;

                default:
                    Debug.Log("Wrong Index in Active Quests");
                    break;
            }
        }
        
        updateActiveQuest(activeQuests);
    }



}

