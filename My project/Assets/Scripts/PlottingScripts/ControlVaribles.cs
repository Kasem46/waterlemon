using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVaribles : MonoBehaviour{

    //Define Ui
    public GameManager manager;
    public Text influenceText;
    public Text fameText;
    public Text egoText;
    public Text rizzText;
    public Text energyText;
    public Text day;
    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        //Get Varibles
        try{
            //Display current value of each stat
            int influence = manager.getInfluence();
            int fame = manager.getFame();
            int ego = manager.getEgo();
            int energy = manager.getEnergy();
            int rizz = manager.getRizz();
            int days = manager.getDay();
            influenceText.text  = "Influence: " + influence;
            energyText.text = "Energy: " + energy;
            day.text = "Day: " + days;
            if (fame >= 0){
                fameText.text = "Fame: " + fame;
            } else {
                fameText.text = "Infamy: " + (fame * -1);
            } 
            try{
                egoText.text = "Ego: " + ego;
                rizzText.text = "Charisma: " + rizz;
            } catch {
                try {
                    rizzText = GameObject.Find("rizzText").GetComponent<Text> ();
                    egoText = GameObject.Find("egoText").GetComponent<Text> ();
                } catch {
                    
                }
            }
        } catch {
            try{ 
                //Find relevent text objects and apply them to GameManager
                influenceText = GameObject.Find("Text_Influence").GetComponent<Text> ();
                energyText = GameObject.Find("Text_Energy").GetComponent<Text> ();
                day = GameObject.Find("dayText").GetComponent<Text> ();
                fameText = GameObject.Find("Text_Fame").GetComponent<Text> ();
                manager.setDay(manager.getDay() + 1);
                manager.setInfluence(manager.getDailyRecovery() + manager.getInfluence());
                switch(manager.getEnergy()){
                    case int n when (n > 60):
                        manager.setEnergy(100);
                        break;
                    case int n when (n >= 40 && n < 60):
                        manager.setEnergy(80);
                        break;
                    case int n when (n >= 20 && n < 40):
                        manager.setEnergy(50);
                        break;
                    case int n when (n >= 10 && n < 20):
                        manager.setEnergy(30);
                        break;
                    case int n when (n >= 1 && n < 10):
                        manager.setEnergy(20);
                        break;
                }
            } catch {

            }
        }
    }
}
