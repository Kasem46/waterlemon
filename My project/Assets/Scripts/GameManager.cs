using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //CreateNPC array
    public GenericNPC[] NPCs = new GenericNPC[18];
    //NPC names, current amount: 11
    string[] NPCNames  = new string[] {"Edmund", "Lord Alistair", "Leopold", "Maximus", "Darian", "Aricor", "Everard", "Romarian", "Percival Magnus", "Amara", "Gwendolyn", "Emmaline", "Isadora", "Victoria", "Gabriella", "Matilda Gracebourne", "Regalis", "Thaddeus"};
    string[] NPCLastNames = new string[] {"Octavius", "VII", "Bartholomew", "Thorne", "Blackthorne", "IX", "the Resplendent", "IV", "II", "Starlight", "Valentina", "Esmeralda", "Ravenshield", "Somerset", "III", "XII", "Stormbreaker", "the Great"};
    private string name;
    //Day
    int day = -1;
    //Influence
    int influence = 100;
    int influenceCap = 100;

    //Infamy
    public int fame = 100;
    int fameCap = 100;

    //Energy
    int energy = 100;
    int energyCap = 100;

    //Ego
    int ego = 100;
    int egoCap = 100;

    //Charisma
    int rizz = 100;
    int rizzCap = 100;

    /// <summary>
    /// Factions
    /// This varible is used to determine the player's faction
    /// 0 = No faction
    /// 1 = Royal faction
    /// 2 = Church faction
    /// 3 = Populust faction
    /// 4 = Peasant faction
    /// 5 = Merchant faction
    /// 6 = Military faction
    /// </summary>
    int faction = 0;

    // Start is called before the first frame update
    void Start(){
        DontDestroyOnLoad(this.gameObject);
        for (int i = 0; i < 18; i++){
            GenericNPC temp = ScriptableObject.CreateInstance<GenericNPC>();
            name = NPCNames[Random.Range(0, NPCNames.Length)] + " " + NPCLastNames[Random.Range(0, NPCLastNames.Length)];
            temp.e(1,1,1,1,name);
            NPCs[i] = temp;
        }
    }

    // Update is called once per frame
    void Update(){
        
    }
    
    //Get Functions
    public int getInfluence(){
        return influence;
    }
    public int getFame(){
        return fame;
    }
    public int getEgo(){
        return ego;
    }
    public int getEnergy(){
        return energy;
    }
    public int getRizz(){
        return rizz;
    }
    public int getFaction(){
        return faction;
    }
    public int getDay(){
        return day;
    }

    //Set Functions
    public void setInfluence(int newVal){
        influence = newVal;
    }
    public void setFame(int newVal){
        fame= newVal;
    }
    public void setEgo(int newVal){
        ego = newVal;
    }
    public void setEnergy(int newVal){
        energy = newVal;
    }
    public void setRizz(int newVal){
        rizz = newVal;
    }
    public void setFaction(int newVal){
        faction = newVal;
    }
    public void setDay(int newVal){
        day = newVal;
    }
}
