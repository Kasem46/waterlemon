using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapControl : MonoBehaviour{
    private GameManager[] test;
    private GenericNPC[] NPCs;
    private GameManager manager;
    private GameObject[] mapParts;
    private GameObject delete;
    public Text tips;
    public Text mode;
    private bool vassalMode = true;
    public GameObject Kings;
    public GameObject Church;
    public GameObject Popu;
    public GameObject Peas;
    public GameObject Merch;
    public GameObject Mil;
    public GameObject KingsB;
    public GameObject ChurchB;
    public GameObject PopuB;
    public GameObject PeasB;
    public GameObject MerchB;
    public GameObject MilB;

    //Set map
    public void setMap(){
        mapParts = GameObject.FindGameObjectsWithTag ("Map");
    }

    public void hideMapInitial(){
        foreach(GameObject go in mapParts){
            go.SetActive (false);
        }
    }
    public void hideMap(){
        foreach(GameObject go in mapParts){
            go.SetActive (false);
        }
        manager.setDay(manager.getDay() + 1);
        manager.setInfluence(manager.getDailyRecovery() + manager.getInfluence());
    }
    public void showMap(){
        foreach(GameObject go in mapParts){
            go.SetActive (true);
        }
        if (manager.getFactionDefeated(0) == true){
            Kings.SetActive(true);
            KingsB.SetActive(false);
        }
        if (manager.getFactionDefeated(1) == true){
            Church.SetActive(true);
            ChurchB.SetActive(false);
        }
        if (manager.getFactionDefeated(2) == true){
            Popu.SetActive(true);
            PopuB.SetActive(false);
        }
        if (manager.getFactionDefeated(3) == true){
            Peas.SetActive(true);
            PeasB.SetActive(false);
        }
        if (manager.getFactionDefeated(4) == true){
            Merch.SetActive(true);
            MerchB.SetActive(false);
        }
        if (manager.getFactionDefeated(5) == true){
            Mil.SetActive(true);
            MilB.SetActive(false);
        }
    }

    //Functions for Vassalizing / Assassinating
    public void RoyalVassal(){
        Vassalize("Royal", 0);
    }
    public void ChurchVassal(){
        Vassalize("Church", 1);
    }
    public void PopulistVassal(){
        Vassalize("Populist", 2);
    }
    public void PeasantVassal(){
        Vassalize("Peasant", 3);
    }
    public void MilitaryVassal(){
        Vassalize("Military", 5);
    }
    public void MerchantVassal(){
        Vassalize("Merchant", 4);
    }

    private bool Vassalize(string factionName, int factionNumber){
        if(NPCs[0 + factionNumber * 3].getInfluence() + NPCs[1 + factionNumber * 3].getInfluence() + NPCs[2 + factionNumber * 3].getInfluence() >= 270 && manager.getFame() >= 80 && vassalMode == true){
            delete = GameObject.Find(factionName);
            delete.SetActive(false);
            manager.setFame(manager.getFame() - 60);
            manager.SetDailyRecovery(manager.getDailyRecovery() + 5);
            manager.setDefeatedFactions(manager.getDefeatedFactions() + 1);
            manager.setFactionsDefeated(factionNumber, true);
            if (manager.getFactionDefeated(0) == true){
                Kings.SetActive(true);
            }
            if (manager.getFactionDefeated(1) == true){
                Church.SetActive(true);
            }
            if (manager.getFactionDefeated(2) == true){
                Popu.SetActive(true);
            }
            if (manager.getFactionDefeated(3) == true){
                Peas.SetActive(true);
            }
            if (manager.getFactionDefeated(4) == true){
                Merch.SetActive(true);
            }
            if (manager.getFactionDefeated(5) == true){
                Mil.SetActive(true);
            }
            return true;
            setMap();
        } else if (NPCs[0 + factionNumber * 3].getInfluence() + NPCs[1 + factionNumber * 3].getInfluence() + NPCs[2 + factionNumber * 3].getInfluence() <= 30 && manager.getFame() <= -80 && vassalMode == false) {
            delete = GameObject.Find(factionName);
            delete.SetActive(false);
            manager.setFame(manager.getFame() - 60);
            manager.SetDailyRecovery(manager.getDailyRecovery() + 5);
            manager.setDefeatedFactions(manager.getDefeatedFactions() + 1);
            manager.setFactionsDefeated(factionNumber, true);
            if (manager.getFactionDefeated(0) == true){
                Kings.SetActive(true);
            }
            if (manager.getFactionDefeated(1) == true){
                Church.SetActive(true);
            }
            if (manager.getFactionDefeated(2) == true){
                Popu.SetActive(true);
            }
            if (manager.getFactionDefeated(3) == true){
                Peas.SetActive(true);
            }
            if (manager.getFactionDefeated(4) == true){
                Merch.SetActive(true);
            }
            if (manager.getFactionDefeated(5) == true){
                Mil.SetActive(true);
            }
            return true;
            setMap();
        } else {
            return false;
        }
    }

    public void ChangeMode(){
        if (vassalMode == true){
            vassalMode = false;
            tips.text = "After reaching a certain infamy threshold, and having a faction lose enough influence, you can destroy that faction.";
            mode.text = "Swap to vassalize";
        } else {
            vassalMode = true;
            tips.text = "After reaching a certain fame threshold, and having a faction reach a certain influence, you can vassalize that faction.";
            mode.text = "Swap to assassinate";
        }
    }
    // Start is called before the first frame update
    void Start(){
        setMap();
        test = FindObjectsOfType<GameManager>();
        manager = test[0];
        NPCs = manager.getNPCArray();
        hideMapInitial();
    }

    // Update is called once per frame
    void Update(){

    }
}
