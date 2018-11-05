using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

	private SQLiteConnection _connection;

	public DataService(string DatabaseName){

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/Plugins/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath); 
      //  _connection.CreateTable<User>();

    }
    /*
	public void CreateDB(){
		_connection.DropTable<User> ();
		_connection.CreateTable<User> ();

		_connection.InsertAll (new[]{
			new Person{
				Id = 1,
				Name = "Tom",
				Surname = "Perez",
				Age = 56
			},
			new Person{
				Id = 2,
				Name = "Fred",
				Surname = "Arthurson",
				Age = 16
			},
			new Person{
				Id = 3,
				Name = "John",
				Surname = "Doe",
				Age = 25
			},
			new Person{
				Id = 4,
				Name = "Roberto",
				Surname = "Huertas",
				Age = 37
			}
		});
	}
    */

    public void createTables()
    {
        _connection.CreateTable<User>();
        _connection.CreateTable<ActiveQuests>();


    }
    public void test()
    {
        _connection.CreateTable<StoryQuest>();
    }
    public void AddUser(User user)
    {
        createTables();
        _connection.Insert(user);
        int userId = GetUserId(user.rand_pass);
        

        ActiveQuests aq = new ActiveQuests();
        aq.sqlit_id = userId;
        _connection.Insert(aq);
        PlayerPrefsManager.setUserIds(userId, user.rand_pass, user.username);
        // user.sqLite_id
    //    return user;
    }
    public int GetUserId(string randPass)
    {
       User tempUser = _connection.Table<User>().Where(x => x.rand_pass == randPass).FirstOrDefault();
        return tempUser.id;
    }
    public void updateActiveQuests(ActiveQuests activeQuests)
    {
        _connection.Update(activeQuests);
    }

  
	public User GetUser(int id){
		return _connection.Table<User>().Where(x => x.id == id).FirstOrDefault();
	}
    public void UpdateUser(User user)
    {
        _connection.Update(user);

    }
    public IEnumerable<StoryQuest>GetQuests()
    {
        return _connection.Table<StoryQuest>().Where(x => x.id == 1);
    }
    public ActiveQuests GetActiveQuests(int id)
    {
        // handle null exception
        return _connection.Table<ActiveQuests>().Where(x => x.sqlit_id == id).FirstOrDefault();
    }
    public StoryQuest GetAllStoryQuests(int level,int id)
    {
        return _connection.Table<StoryQuest>().Where(x => x.level == level).Where(x => x.id_by_level == id).FirstOrDefault();
    }
    public int GetAllStoryQuestsCount(int level)
    {
        return _connection.Table<StoryQuest>().Where(x => x.level == level).Count();
    }

    /*
	public Person CreatePerson(){
		var p = new Person{
				Name = "Johnny",
				Surname = "Mnemonic",
				Age = 21
		};
		_connection.Insert (p);
		return p;
	}
    */
}
