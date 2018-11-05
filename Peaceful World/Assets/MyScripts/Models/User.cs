using SQLite4Unity3d;

public class User  {

	[PrimaryKey, AutoIncrement]
    public int id { get; set; }

    //public int sqLite_id { get; set; }
    public string username { get; set; }
    public string rand_pass { get; set; }
    public int num_of_slots { get; set; }

    public int story_quest_level { get; set; }

    public float credit { get; set; }

    public int industry_water { get; set; }
    public int industry_pot { get; set; }
    public int industry_light { get; set; }
    public int industry_earth { get; set; }

    public int sour_water { get; set; }
    public int spicy_water { get; set; }
    public int sweet_water { get; set; }
    public int bitter_water { get; set; }
    public int savory_water { get; set; }

 
    public float thc_data { get; set; }
    public float cbd_data { get; set; }

    public override string ToString ()
	{
        return string.Format ("[Person: Id={0}, username={1}, credit={2}]", id, username,credit);
    //    return username;
    }
   // public string getUsername()
   // {
        
 //   }

}
