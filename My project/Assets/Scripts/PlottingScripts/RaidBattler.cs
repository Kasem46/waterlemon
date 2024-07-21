using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaidBattler : MonoBehaviour{
    // Start is called before the first frame update
    int AIChoice;
    int playerChoice;
    public PlotElementControler controller;
    public GameManager[] test;
    public GameManager manager;
    public Text result;
    public Image resultImage;
    public GameObject resultImageObj;
    public Image result1;
    public Image result2;
    public Image result3;


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
        switch (AIChoice){
            case 0:
                resultImage = result1;
                break;
            case 1: 
                resultImage = result2;
                break;
            case 2:
                resultImage = result3;
                break;
        }
        StartCoroutine(showAiChoice());
        if (playerChoice == AIChoice){
            StartCoroutine(showResult(1));
            controller.resetRaid();
        } else if (playerChoice == AIChoice + 1 || playerChoice == AIChoice - 2) {
            StartCoroutine(showResult(0));
            if (manager.getFame() >= 0){
                manager.setFame(manager.getFame() + Random.Range(1, 10));
            } else {
                manager.setFame(manager.getFame() + Random.Range(-10, -1));
            }
            manager.SetDailyRecovery(manager.getDailyRecovery() + 1);
        } else {
            StartCoroutine(showResult(2));
            if (manager.getFame() >= 0){
                manager.setFame(manager.getFame() + Random.Range(-10, -1));
            } else {
                manager.setFame(manager.getFame() + Random.Range(1, 10));
            }
        }
    }

    IEnumerator showAiChoice(){
        yield return new WaitForSeconds(3);
        resultImageObj.SetActive(true);
        yield return new WaitForSeconds(3);
        resultImageObj.SetActive(false);
    }

    IEnumerator showResult(int win){
        yield return new WaitForSeconds(3);
        switch (win){
            case 0:
                result.text = "Result: Victory!\nFame increased!";
                break;
            case 1:
                result.text = "Result: Draw.";
                break;
            case 2:
                result.text = "Result: Loss.\nFame decreased.";
                break;
        }
        yield return new WaitForSeconds(3);
        result.text = "Result: ";
        switch (win){
            case 0:
            case 2:
                controller.closeRaid();
                break;
        }
        
    }

    void Start(){
        test = FindObjectsOfType<GameManager>();
        manager = test[0];
        resultImageObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
