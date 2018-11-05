using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

    //public static bool isNew;
    // Use this for initialization
    void Start () {
        if (!isNew())
        {

          //  GameObject gm = GameObject.FindGameObjectWithTag("game_manager");
          //  gm.AddComponent<GameManager>().getUser(PlayerPrefs.GetInt("user_sqLite_id"));
         //   gm.SetActive(true);
        }
       // checkNewUser();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public bool checkNewUser()
    {
      //  var ds = new DataService("pw_database.db");
        if (PlayerPrefs.GetString("user_username") != null)
        {
            /*
            Debug.Log("Welcome : " + PlayerPrefs.GetString("user_username"));
            try
            {
               // Check if he is in database
                ds.getUser(PlayerPrefs.GetInt("user_sqLite_id"), PlayerPrefs.GetString("user_username"));
            }
            catch (Exception e)
            {
                Debug.Log("Error: " + e);
                return;
            }
            */
            return true;
        }
        else
        {
            return false;
            Debug.Log("nema");
            /*
             * show new user Panel
             * 
             * 
             */
            //add ju user form set active
            // addNewUser();
        }

        // PlayerPrefs.GetString("user_sqLite_id");
        // PlayerPrefs.GetString("user_random_pass");

    }
    public bool isNew()
    {
        if (PlayerPrefs.GetString("user_username") != null)
        {
            return false;
        }
        else
        {
            //TOODOO: set Active NewUser panel
            return true;
        }
    }

}
