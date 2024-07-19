using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotElementControler : MonoBehaviour {
    public GameObject book;
    private GameObject[] FactionsArray1;
    private GameObject[] FactionsArray2;
    private GameObject[] Buttons;
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
        book.SetActive(false);
        showMainButtons();
    }
    private void setFactionBook(){
        FactionsArray1 = GameObject.FindGameObjectsWithTag ("FactionPage1");
        FactionsArray2 = GameObject.FindGameObjectsWithTag ("FactionPage2");
    }
    //Control the pages of the Faction Book
    public void factionPage1(){
        foreach(GameObject go in FactionsArray2){
            go.SetActive (false);
        }
        foreach(GameObject go in FactionsArray1){
            go.SetActive (true);
        }
    }
    public void factionPage2(){
        foreach(GameObject go in FactionsArray1){
            go.SetActive (false);
        }
        foreach(GameObject go in FactionsArray2){
            go.SetActive (true);
        }
    }
    // Start is called before the first frame update
    void Start(){
        setMainButtons();
        setFactionBook();
        closeFactionBook();
    }

    // Update is called once per frame
    void Update(){
        
    }
}
