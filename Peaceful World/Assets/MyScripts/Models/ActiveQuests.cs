using SQLite4Unity3d;


public class ActiveQuests {

    [PrimaryKey, AutoIncrement]
    public int id { get; set; }

   
    public int sqlit_id { get; set; }

    public int one_quest_id { get; set; }
    public System.DateTime one_quest_time { get; set; }

    public int two_quest_id { get; set; }
    public System.DateTime two_quest_time { get; set; }

    public int three_quest_id { get; set; }
    public System.DateTime three_quest_time { get; set; }

    public int four_quest_id { get; set; }
    public System.DateTime four_quest_time { get; set; }

    public int five_quest_id { get; set; }
    public System.DateTime five_quest_time { get; set; }

    public int six_quest_id { get; set; }
    public System.DateTime six_quest_time { get; set; }

    public int seven_quest_id { get; set; }
    public System.DateTime seven_quest_time { get; set; }

    public int eight_quest_id { get; set; }
    public System.DateTime eight_quest_time { get; set; }

    public int nine_quest_id { get; set; }
    public System.DateTime nine_quest_time { get; set; }

    public int ten_quest_id { get; set; }
    public System.DateTime ten_quest_time { get; set; }

   

    
}
