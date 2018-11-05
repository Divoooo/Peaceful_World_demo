using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CreateNewUser : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public User addNewUser(string username)
    {
        /*      Make logic to return User on first Login
         *      Save User ID's in database
         */
        var ds = new DataService("pw_database.db");
        User newUser = new User();
        newUser.username = username;
        newUser.rand_pass = CreatePassword();

        ds.AddUser(newUser);
        return newUser;
    }

    public string CreatePassword()
    {
        int length = 20;
        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        StringBuilder res = new StringBuilder();
        System.Random rnd = new System.Random();
        while (0 < length--)
        {
            res.Append(valid[rnd.Next(valid.Length)]);
        }
        return res.ToString();
    }

}
