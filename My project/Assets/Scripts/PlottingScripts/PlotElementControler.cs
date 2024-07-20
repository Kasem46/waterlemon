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
        factionPage1();
        book.SetActive (true);
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
        book.SetActive(false);
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

    // Start is called before the first frame update
    void Start(){
        test = FindObjectsOfType<GameManager>();
        manager = test[0];
        NPCs = manager.getNPCArray();
        setMainButtons();
        setFactionBook();
        setMiror();
        closeFactionBook();
        closeMiror();
    }

    // Update is called once per frame
    void Update(){
        
    }
}
