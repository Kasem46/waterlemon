using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //CreateNPC array
    public GenericNPC[] NPCs = new GenericNPC[18];
    public int NumNPCs = 0;
    //Define influence recovery varibles
    private int dailyRecoverPercent = 5;

    //NPC names, 
    string[] NPCNames  = new string[] {"Edmund", "Alistair", "Leopold", "Maximus", "Darian", "Aricor", "Everard", "Romarian", "Percival Magnus", "Amara", "Gwendolyn", "Emmaline", "Isadora", "Victoria", "Gabriella", "Matilda Gracebourne", "Regalis", "Thaddeus", "Arghun"};
    string[] NPCLastNames = new string[] {"Octavius", "VII", "Bartholomew", "Thorne", "Blackthorne", "IX", "the Resplendent", "IV", "II", "Starlight", "Valentina", "Esmeralda", "Ravenshield", "Somerset", "III", "XII", "Stormbreaker", "the Great", "the Annihilator"};
    private string name;
    bool[] FactionsDefeated = new bool[] {false, false, false, false, false, false};
    //Day
    int day = -1;
    //Influence
    int influence;

    //Infamy
    public int fame;

    //Energy
    int energy = 100;

    //Ego
    int ego;

    //Charisma
    int rizz;
    
    //Energy cost Multiplyer
    double EnergyCostMultiplyer = 1;

    //Deck Type
    int deckType;
    //Defeated Factions
    int defeatedFactions = 0;

    //NPC Sprite variables
    [SerializeField]
    private GameObject royal;
    [SerializeField]
    private GameObject royalGoon1;
    [SerializeField]
    private GameObject royalGoon2;
    [SerializeField]
    private GameObject church;
    [SerializeField]
    private GameObject churchGoon1;
    [SerializeField]
    private GameObject churchGoon2;
    [SerializeField]
    private GameObject populist;
    [SerializeField]
    private GameObject populistGoon1;
    [SerializeField]
    private GameObject populistGoon2;
    [SerializeField]
    private GameObject peasent;
    [SerializeField]
    private GameObject peasentGoon1;
    [SerializeField]
    private GameObject peasentGoon2;
    [SerializeField]
    private GameObject merchent;
    [SerializeField]
    private GameObject merchentGoon1;
    [SerializeField]
    private GameObject merchentGoon2;
    [SerializeField]
    private GameObject military;
    [SerializeField]
    private GameObject militaryGoon1;
    [SerializeField]
    private GameObject militaryGoon2;


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
        //Stats randomization
        //influence = Random.Range(30, 50);
        //fame = Random.Range(30, 50);
        influence = 100;
        fame = 100;
        ego = Random.Range(30, 50);
        rizz = Random.Range(30, 50);
        //Create Royal Faction NPCs
        CreateNPC(2, 1, 50, 100, 30, 70, 30, 70);
        CreateNPC(1, 1, 60, 110, 40, 80, 40, 80, "Regent " + NPCNames[Random.Range(0, NPCNames.Length)] + " " + NPCLastNames[Random.Range(0, NPCNames.Length)]);
        //Create Church Faction NPCs
        CreateNPC(2, 2, 50, 100, 30, 70, 0, 50);
        CreateNPC(1, 2, 60, 110, 40, 80, 10, 60, "High Priest " + NPCNames[Random.Range(0, NPCNames.Length)] + " " + NPCLastNames[Random.Range(0, NPCNames.Length)]);
        //Create Populist Faction NPCs
        CreateNPC(2, 3, 0, 50, 50, 100, 30, 70);
        CreateNPC(1, 3, 10, 60, 60, 110, 40, 80, NPCNames[Random.Range(0, NPCNames.Length)] + " the Strongman");
        //Create Peasant Faction NPCs
        CreateNPC(2, 4, 0, 50, 0, 50, 0, 50);
        CreateNPC(1, 4, 10, 60, 10, 60, 10, 60, NPCNames[Random.Range(0, NPCNames.Length)] + " the Wandought" );
        //Create Merchant Faction NPCs
        CreateNPC(3, 5, 100, 100, 30, 70, 50, 100);
        //CreateNPC(2, 5, 30, 70, 30, 70, 50, 100);
        //CreateNPC(1, 5, 40, 80, 40, 80, 60, 110, NPCNames[Random.Range(0, NPCNames.Length)] + " the Gentry");
        //Create Military Faction NPCs
        CreateNPC(2, 6, 50, 100, 30, 70, 0, 50);
        CreateNPC(1, 6, 60, 110, 40, 80, 10, 60, "General " + NPCNames[Random.Range(0, NPCNames.Length)] + " " + NPCLastNames[Random.Range(0, NPCNames.Length)]);

        giveNPCSprites();
    }

    public void giveNPCSprites() {
        NPCs[0].setSprite(royalGoon1);
        NPCs[1].setSprite(royalGoon2);
        NPCs[2].setSprite(royal);
        NPCs[3].setSprite(churchGoon1);
        NPCs[4].setSprite(churchGoon2);
        NPCs[5].setSprite(church);
        NPCs[6].setSprite(populistGoon1);
        NPCs[7].setSprite(populistGoon2);
        NPCs[8].setSprite(populist);
        NPCs[9].setSprite(peasentGoon1);
        NPCs[10].setSprite(peasentGoon2);
        NPCs[11].setSprite(peasent);
        NPCs[12].setSprite(merchentGoon1);
        NPCs[13].setSprite(merchentGoon2);
        NPCs[14].setSprite(merchent);
        NPCs[15].setSprite(militaryGoon1);
        NPCs[16].setSprite(militaryGoon2);
        NPCs[17].setSprite(military);
    }

    // Update is called once per frame
    void Update(){
        if (influence <= 0 || day > 356) {
            SceneManager.LoadScene("Lose");
            Destroy(this.gameObject);
        }  else if (defeatedFactions == 6) {
            SceneManager.LoadScene("Win");
            Destroy(this.gameObject);
        }
    }


    void CreateNPC(int amount = 1, int faction = 0, int minInfluence = 0, int maxInfluence = 100, int minEgo = 0, int maxEgo = 100, int minRizz = 0, int maxRizz = 100, string CustomName = null){
        for (int j = 0; j < amount; j++){
            GenericNPC temp = ScriptableObject.CreateInstance<GenericNPC>();
            if (CustomName == null){
                for (int i = 0; i < NPCs.Length; i++){
                    name = NPCNames[Random.Range(0, NPCNames.Length)] + " " + NPCLastNames[Random.Range(0, NPCNames.Length)];
                    if (name == NPCNames[i]){
                        i--;
                    }
                }
            } else {
                name = CustomName;
            }
            temp.e(Random.Range(minInfluence, maxInfluence), Random.Range(minEgo, maxEgo), Random.Range(minRizz, maxRizz), faction, name);
            NPCs[j + NumNPCs] = temp;
        }
        NumNPCs += amount;
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
    public GenericNPC[] getNPCArray(){
        return NPCs;
    }
    public int getDailyRecovery(){
        return dailyRecoverPercent;
    }
    public double getEnergyCostMultiplyer(){
        return EnergyCostMultiplyer;
    }
    public int getDeckType(){
        return deckType;
    }
    public int getDefeatedFactions(){
        return defeatedFactions;
    }
    public bool getFactionDefeated(int FactionNumber){
        return FactionsDefeated[FactionNumber];
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
    public void SetDailyRecovery(int newVal){
        dailyRecoverPercent = newVal;
    }
    public void setEnergyCostMultiplyer(double newVal){
        EnergyCostMultiplyer = newVal;
    }
    public void setDeckType(int newVal){
        deckType = newVal;
    }
    public void setDefeatedFactions(int newVal){
        defeatedFactions = newVal;
    }
    public void setFactionsDefeated(int FactionNumber, bool newVal){
        FactionsDefeated[FactionNumber] = newVal; 
    }
}
