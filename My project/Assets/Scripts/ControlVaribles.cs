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
            influenceText.text  = "Influence: " + influence;
            egoText.text = "Ego: " + ego;
            rizzText.text = "Rizz: " + rizz;
            energyText.text = "Energy: " + energy;
            if (fame >= 0){
                fameText.text = "Fame: " + fame;
            } else {
                fameText.text = "Infamy: " + (fame * -1);
            } 
        } catch {
            try{ 
                //Find relevent text objects and apply them to GameManager
                influenceText = GameObject.Find("Text_Influence").GetComponent<Text> ();
                fameText = GameObject.Find("Text_Fame").GetComponent<Text> ();
                rizzText = GameObject.Find("Text (Legacy) (4)").GetComponent<Text> ();
                energyText = GameObject.Find("Text (Legacy) (2)").GetComponent<Text> ();
                egoText = GameObject.Find("Text (Legacy) (3)").GetComponent<Text> ();
            } catch {

            }
        }
    }
}
