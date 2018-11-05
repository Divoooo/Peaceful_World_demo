using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoryQuestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //  Debug.Log("Story quests count: " + getRandomQuestsByLevel(1).GetEnumerator(1);

        foreach (var item in getRandomQuestsByLevel())
        {
              Debug.Log("Quest Id: " + item.Value.id_by_level);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public int getStoryQuestLevel()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("game_manager").GetComponent<GameManager>();
        return gm.getStaticUser().story_quest_level;
    }
    public Dictionary<int, StoryQuest> getRandomQuestsByLevel()
    {
        var ds = new DataService("pw_database.db");

        int level = 0;    
        int[] ids = new int[3];
        int questCount = 0;       
        int questKeys = 0;

        
        System.Random rnd = new System.Random();
        Dictionary<int, StoryQuest> returnQuests = new Dictionary<int, StoryQuest>();
        level = getStoryQuestLevel();

        questCount = ds.GetAllStoryQuestsCount(level);
        ids = getRandNumbers(questCount + 1);

        foreach (int item in ids)
        {
            Debug.Log("item id: " + item);
            returnQuests.Add(questKeys, ds.GetAllStoryQuests(level, item));
            questKeys++;
        }

        return returnQuests;

    }
    public int[] getRandNumbers(int range)
    {
        int[] randNums = new int[3];
        int randOne;
        int randTwo;
        int randThree;

        System.Random rnd = new System.Random();
        randOne = rnd.Next(1, range);
        randTwo = rnd.Next(1, range);
        randThree = rnd.Next(1, range);
        while (randOne == randTwo)
        {
            randTwo = rnd.Next(1, range);
        }
        while(randThree == randOne && randThree == randTwo)
        {
            randThree = rnd.Next(1, range);
        }
        randNums[0] = randOne;
        randNums[1] = randTwo;
        randNums[2] = randThree;

        return randNums;


    }
}
