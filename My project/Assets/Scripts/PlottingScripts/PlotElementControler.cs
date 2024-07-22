using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotElementControler : MonoBehaviour {
    public GameObject book;
    private GameManager[] test;
    private GenericNPC[] NPCs;
    private GameManager manager;
    private Text FactionText;
    private GameObject[] FactionsArray1;
    private GameObject[] FactionsArray2;
    private GameObject[] FactionsArray3;
    private GameObject[] Buttons;
    private GameObject[] Miror;
    private GameObject[] Raid;
    private GameObject[] Tavern;
    public GameObject Tutorial;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    private GameObject[] Party;
    //Show/Hide main buttons    
    private void setMainButtons() {Buttons = GameObject.FindGameObjectsWithTag ("MainButtons");}
    public void hideMainButtons(){
        foreach(GameObject go in Buttons){
            go.SetActive (false);
        }
    }
    public void showMainButtons(){
        foreach(GameObject go in Buttons){
            go.SetActive (true);
        }
    }
    //Faction book toggles
    public void openFactionBook(){
        hideMainButtons();
        book.SetActive (true);
        factionPage1();
    }
    public void closeFactionBook(){
        foreach(GameObject go in FactionsArray1){
            go.SetActive (false);
        }
        foreach(GameObject go in FactionsArray2){
            go.SetActive (false);
        }
        foreach(GameObject go in FactionsArray3){
            go.SetActive (false);
        }
        book.SetActive(false);
        showMainButtons();
    }
    private void setFactionBook(){
        FactionsArray1 = GameObject.FindGameObjectsWithTag ("FactionPage1");
        FactionsArray2 = GameObject.FindGameObjectsWithTag ("FactionPage2");
        FactionsArray3 = GameObject.FindGameObjectsWithTag ("FactionPage3");
    }
    //Control the pages of the Faction Book
    public void factionPage1(){
        foreach(GameObject go in FactionsArray2){
            go.SetActive (false);
        }
        foreach(GameObject go in FactionsArray1){
            go.SetActive (true);
        }
        foreach(GameObject go in FactionsArray3){
            go.SetActive (false);
        }
    }
    public void factionPage2(){
        foreach(GameObject go in FactionsArray1){
            go.SetActive (false);
        }
        foreach(GameObject go in FactionsArray2){
            go.SetActive (true);
        }
        foreach(GameObject go in FactionsArray3){
            go.SetActive (false);
        }
    }
    public void factionPage3(){
        foreach(GameObject go in FactionsArray1){
            go.SetActive (false);
        }
        foreach(GameObject go in FactionsArray2){
            go.SetActive (false);
        }
        foreach(GameObject go in FactionsArray3){
            go.SetActive (true);
        }
        for (int i = 1; i < 19; i++){
            FactionText = GameObject.Find(i.ToString()).GetComponent<Text> ();
            FactionText.text = "- " + NPCs[i-1].getName() + ". Influence: " + NPCs[i-1].getInfluence(); 
        }
    }

    //Raid Toggles

    public void openRaid(){
        enableTutorial2();
        hideMainButtons();
        foreach(GameObject go in Raid){
            go.SetActive (true);
        }
    }
    public void closeRaid(){
        foreach(GameObject go in Raid){
            go.SetActive (false);
        }
        manager.setDay(manager.getDay() + 1);
        manager.setInfluence(manager.getDailyRecovery() + manager.getInfluence());
        showMainButtons();
    }
    public void closeRaidInitial(){
        foreach(GameObject go in Raid){
            go.SetActive (false);
        }
        showMainButtons();
    }
    private void setRaid(){
        Raid = GameObject.FindGameObjectsWithTag ("Raid");
    }
    //Function to reset UI elements in case of draw
    public void resetRaid(){
        closeRaid();
        openRaid();
    }
    //Mirror Toggles
    public void openMiror(){
        hideMainButtons();
        foreach(GameObject go in Miror){
            go.SetActive (true);
        }
    }
    public void closeMiror(){
        foreach(GameObject go in Miror){
            go.SetActive (false);
        }
        showMainButtons();
    }
    private void setMiror(){
        Miror = GameObject.FindGameObjectsWithTag ("Miror");
    }


    //Tavern Toggles
    public void openTavern(){
        enableTutorial3();
        hideMainButtons();
        foreach(GameObject go in Tavern){
            go.SetActive (true);
        }
    }
    public void closeTavern(){
        foreach(GameObject go in Tavern){
            go.SetActive (false);
        }
        manager.setDay(manager.getDay() + 1);
        manager.setInfluence(manager.getDailyRecovery() + manager.getInfluence());
        showMainButtons();
    }
    public void closeTavernInitial(){
        foreach(GameObject go in Tavern){
            go.SetActive (false);
        }
        showMainButtons();
    }
    private void setTavern(){
        Tavern = GameObject.FindGameObjectsWithTag ("Tavern");
    }
    //Party Preping
     public void openParty(){
        hideMainButtons();
        manager.setDeckType(-1);
        foreach(GameObject go in Party){
            go.SetActive (true);
        }
    }
    public void closeParty(){
        foreach(GameObject go in Party){
            go.SetActive (false);
        }
        showMainButtons();
    }
    private void setParty(){
        Party = GameObject.FindGameObjectsWithTag ("Pinvite");
    }
    //Enable Tutorial
    public void enableTutorialBasic(int a = 0){
        if (manager.getDay() > 0 || a == 1){
            Tutorial.SetActive(false);
        } else {
            Tutorial.SetActive(true);
        }
    }
    public void enableTutorial2(int a = 0){
        if (manager.getDay() > 0 || a == 1){
            Tutorial2.SetActive(false);
        } else {
            Tutorial2.SetActive(true);
        }
    }
    public void enableTutorial3(int a = 0){
        if (manager.getDay() > 0 || a == 1){
            Tutorial3.SetActive(false);
        } else {
            Tutorial3.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start(){
        test = FindObjectsOfType<GameManager>();
        manager = test[0];
        NPCs = manager.getNPCArray();
        setMainButtons();
        enableTutorialBasic();
        setFactionBook();
        setParty();
        setRaid();
        setMiror();
        setTavern();
        closeTavernInitial();
        closeRaidInitial();
        closeFactionBook();
        closeMiror();
        closeParty();
    }

    // Update is called once per frame
    void Update(){
        
    }
}
