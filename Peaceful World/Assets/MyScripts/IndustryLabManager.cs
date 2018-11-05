using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IndustryLabManager : MonoBehaviour {

    

    public GameObject waterObject;
    public GameObject potObject;
    public GameObject lightObject;
    public GameObject earthObject;

    public GameManager gm;
    public Text creditText;

    public int waterLvl;
    public int potLvl;
    public int lightLvl;
    public int earthLvl;
    public float credit;

    Text waterPriceText;
    Text potPriceText;
    Text lightPriceText;
    Text earthPriceText;

    Text waterText;
    Text potText;
    Text lightText;
    Text earthText;
    UnityEngine.UI.Slider waterSlider;
    UnityEngine.UI.Slider potSlider;
    UnityEngine.UI.Slider lightSlider;
    UnityEngine.UI.Slider earthSlider;


    public User user;
    // Use this for initialization
    void Start () {

       



    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Awake ()
    {
        gm = GameObject.FindGameObjectWithTag("game_manager").GetComponent<GameManager>();

        user = gm.getStaticUser();
        // user = this.GetComponent<User>().getUser();
        //  Debug.Log("Credit : " +user.cbd_data);
        setUpComponents();
        getData();
        

    }
 
    

    public void UpgradeItem(GameObject button)
    {
        bool isDone = false;
        //TOODOO:: set credit to be saved in Player Prefs

        switch (button.name)
        {
            case "WaterBuyButton":
                if (gm.updateCredit(System.Int32.Parse(waterPriceText.text)))
                {
                    waterLvl++;
                    gm.setIndustryData("industry_water",waterLvl);
                    PlayerPrefsManager.SetIndustryData(waterLvl, "water_level");
                }                            
                break;
            case "PotBuyButton":
                if (gm.updateCredit(System.Int32.Parse(potPriceText.text)))
                {
                    potLvl++;
                    gm.setIndustryData("industry_pot", potLvl);
                    PlayerPrefsManager.SetIndustryData(potLvl, "pot_level");
                }                         
                break;
            case "LightBuyButton":
                if (gm.updateCredit(System.Int32.Parse(lightPriceText.text)))
                {
                    lightLvl++;
                    gm.setIndustryData("industry_light", lightLvl);
                    PlayerPrefsManager.SetIndustryData(lightLvl, "light_level");
                }                               
                break;
            case "EarthBuyButton":
                
                if (gm.updateCredit(System.Int32.Parse(earthPriceText.text)))
                {
                    earthLvl++;
                    gm.setIndustryData("industry_earth", earthLvl);
                    PlayerPrefsManager.SetIndustryData(earthLvl, "earth_level");
                }                               
                break;
            default:
                print("Wrong button name - " + button.name);
                break;
        }
        if(waterLvl %10 == 0 || potLvl %10 == 0 || lightLvl % 10 == 0 || earthLvl % 10 == 0)
        {
            setLevelTexts();
        }
        setSliderTexts();
        setPriceTexts();
        



    }
    

    public void setSliderTexts()
    {
        waterSlider.value = waterLvl % 10;
        potSlider.value = potLvl % 10;
        lightSlider.value = lightLvl % 10;
        earthSlider.value = earthLvl % 10;
    }
    public void setLevelTexts()
    {


        waterText.text = (waterLvl/10).ToString();
        potText.text = (potLvl / 10).ToString();
        lightText.text = (lightLvl / 10).ToString();
        earthText.text = (earthLvl / 10).ToString();
        
        //TOODOO: Save to prefs or database
        //savoryText.text = savoryFlawourValue.ToString();
    }
    public void setPriceTexts()
    {

        
        waterPriceText.text = setPrice(waterLvl).ToString();
        potPriceText.text = setPrice(potLvl).ToString();
        lightPriceText.text = setPrice(lightLvl).ToString();
        earthPriceText.text = setPrice(earthLvl).ToString();
        creditText.text = user.credit.ToString() + " $";
      
    }
    public int setPrice(int level)
    {
        int returPrice = 0 ;
        if(level > 9)
        {
            returPrice = (level * level) * ((int)(level / 10) * 2);
        }else
        {
            returPrice = (level * level);
        }


        return returPrice;
    }


    public void backScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void setUpComponents()
    {
        waterText = waterObject.transform.Find("water_upgrade_text").GetComponent<Text>();
        potText = potObject.transform.Find("pot_upgrade_text").GetComponent<Text>();
        lightText = lightObject.transform.Find("light_upgrade_text").GetComponent<Text>();
        earthText = earthObject.transform.Find("earth_upgrade_text").GetComponent<Text>();
        Debug.Log(waterText.text);

        waterSlider = waterObject.transform.Find("water_slider").GetComponent<UnityEngine.UI.Slider>();
        potSlider = potObject.transform.Find("pot_slider").GetComponent<UnityEngine.UI.Slider>();
        lightSlider = lightObject.transform.Find("light_slider").GetComponent<UnityEngine.UI.Slider>();
        earthSlider = earthObject.transform.Find("earth_slider").GetComponent<UnityEngine.UI.Slider>();

        waterPriceText= waterObject.transform.Find("waterPriceText").GetComponent<Text>();
        potPriceText = potObject.transform.Find("potPriceText").GetComponent<Text>();
        lightPriceText = lightObject.transform.Find("lightPriceText").GetComponent<Text>();
        earthPriceText = earthObject.transform.Find("earthPriceText").GetComponent<Text>();


    }
    public void getData()
    {
      //  user = 
      //  int[] data = PlayerPrefsManager.getIndustryData();
        waterLvl = user.industry_water;
        potLvl = user.industry_pot;
        lightLvl = user.industry_light;
        earthLvl = user.industry_earth;
        credit = user.credit;
        setLevelTexts();
        setSliderTexts();
        setPriceTexts();

    }

    
    


}
