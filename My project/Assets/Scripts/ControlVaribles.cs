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
        int influence = manager.getInfluence();
        int fame = manager.getFame();
        int ego = manager.getEgo();
        int energy = manager.getEnergy();
        int rizz = manager.getRizz();
        influenceText.text = "Influence: " + influence;
        egoText.text = "Ego: " + ego;
        rizzText.text = "Rizz: " + rizz;
        energyText.text = "Energy: " + energy;
        if (fame >= 0){
            fameText.text = "Fame: " + fame;
        } else {
            fameText.text = "Infamy: " + (fame * -1);
        }
    }
}
