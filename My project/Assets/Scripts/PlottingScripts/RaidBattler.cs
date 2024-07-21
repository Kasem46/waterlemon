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
    public Button button1;
    public Button button2;
    public Button button3;
    


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
                resultImage.sprite = result1.sprite;
                break;
            case 1: 
                resultImage.sprite = result2.sprite;
                break;
            case 2:
                resultImage.sprite = result3.sprite;
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
        yield return new WaitForSeconds(2);
        resultImageObj.SetActive(true);
        yield return new WaitForSeconds(3);
        resultImageObj.SetActive(false);
    }

    IEnumerator showResult(int win){
        yield return new WaitForSeconds(2);
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
        button1.enabled = false;
        button2.enabled = false;
        button3.enabled = false;
        button1.enabled = true;
        button2.enabled = true;
        button3.enabled = true;
        
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
