using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public User getUser(int id)
    {
        /* get User from database  
        */
        var ds = new DataService("pw_database.db");
        return ds.GetUser(id);
        //Debug.Log(user.credit.ToString());
    }
}
