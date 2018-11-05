using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSceneFrontend : MonoBehaviour {

   // public QuestScript quest_script;
    public GameManager gm;
   // public Text[] slots;
    public GameObject questItemPrefab;
    public GameObject questItemEmptyPrefab;
    public GameObject questItemBuyPrefab;
    Dictionary<Text, DateTime> slotsObjects = new Dictionary<Text, DateTime>();
    public GameObject scrollContent;
    public ScrollRect scroleView;

    int active_slots_count = 0;
    // Use this for initialization
    void Start () {
        setSlots();
	}
	
	// Update is called once per frame
	void Update () {
        UIupdate();
        //checking for slots .. if one of them is expired call CheckQuests from GameManager
    }
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("game_manager").GetComponent<GameManager>();
        active_slots_count = gm.getStaticUser().num_of_slots;
        Debug.Log("num of slots : " + active_slots_count);
      //  slots = new Text[gm.getSlotNum()];

    }



    public void setSlots()
    {

        int tempSlotsCoutn = 0;
        Dictionary<int, DateTime> quests = new Dictionary<int, DateTime>();
      //  ActiveQuests activeQuests = gm.getActiveQuests(); // mby without it
        quests = gm.checkQuests();
       // active_slots_count = 0;
        foreach (var slot in quests)
        {

            setItems(slot.Key,slot.Value, tempSlotsCoutn);
            tempSlotsCoutn++;
        }
        for (int i = 0; i < (active_slots_count - tempSlotsCoutn); i++)
        {
            setEmptyItems();
        }
        setBuyItem();

    }
    public void UIupdate()
    {
        foreach (var item in slotsObjects)
        {

            item.Key.text = (item.Value - DateTime.Now).ToString();
            if(item.Value <= DateTime.Now)
            {
                // TOODOO: Not tested !
                setSlots();
            }        
        }
    }   
    public void setItems(int id,DateTime expire,int tempSlotsCoutn)
    {
        Text tempText;
        GameObject questItem = Instantiate(questItemPrefab);
        questItem.transform.SetParent(scrollContent.transform, false);
        questItem.GetComponent<Transform>().Find("Quest Id").GetComponent<Text>().text = id.ToString();
        tempText = questItem.GetComponent<Transform>().Find("Quest Date").GetComponent<Text>();
        tempText.text = expire.Hour.ToString();
        slotsObjects.Add(tempText, expire);
    }
    public void setEmptyItems()
    {
        GameObject questItem = Instantiate(questItemEmptyPrefab);
        questItem.transform.SetParent(scrollContent.transform, false);
       

    }
    public void setBuyItem()
    {
        GameObject questItem = Instantiate(questItemBuyPrefab);
        questItem.transform.SetParent(scrollContent.transform, false);


    }


}
