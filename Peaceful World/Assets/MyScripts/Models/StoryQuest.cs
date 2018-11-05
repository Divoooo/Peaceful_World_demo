using SQLite4Unity3d;

public class StoryQuest {
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }

    public int industryPercent { get; set; }
    public int thcPercent { get; set; }
    public int cbdPercent { get; set; }
    public int level { get; set; }
    public int id_by_level { get; set; }
    public string about { get; set; }
    public string items { get; set; }
    
    public bool active = false;
    
    public int price { get; set; }
    public int reward { get; set; }


   
    
}
