using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidBattler : MonoBehaviour
{
    // Start is called before the first frame update
    int AIChoice;
    int playerChoice;
    public PlotElementControler controller;


    public void Rock(){
        playerChoice = 0;
        startRaid();
    }
    public void Paper(){
        playerChoice = 1;
        startRaid();
    }
    public void Scissors(){
        playerChoice = 2;
        startRaid();
    }
    //Determine game outcome
    private void startRaid(){
        AIChoice = Random.Range(0, 3);
        if (playerChoice == AIChoice){
            Debug.Log("Draw.");
            controller.resetRaid();
        } else if (playerChoice == AIChoice + 1 || playerChoice == AIChoice - 2) {
            Debug.Log("Win!");
            controller.closeRaid();
        } else {
            Debug.Log("Loss.");
            controller.closeRaid();
        }
    }

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
