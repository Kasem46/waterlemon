using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidBattler : MonoBehaviour{
    // Start is called before the first frame update
    int AIChoice;
    int playerChoice;
    public PlotElementControler controller;
    public GameManager[] test;
    public GameManager manager;

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
            if (manager.getFame() >= 0){
                manager.setFame(manager.getFame() + Random.Range(1, 10));
            } else {
                manager.setFame(manager.getFame() + Random.Range(-10, -1));
            }
            manager.SetDailyRecovery(manager.getDailyRecovery() + 1);
        } else {
            Debug.Log("Loss.");
            controller.closeRaid();
            if (manager.getFame() >= 0){
                manager.setFame(manager.getFame() + Random.Range(-10, -1));
            } else {
                manager.setFame(manager.getFame() + Random.Range(1, 10));
            }
        }
    }

    void Start(){
        test = FindObjectsOfType<GameManager>();
        manager = test[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
