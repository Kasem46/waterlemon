using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatEditor : MonoBehaviour{


    // Start is called before the first frame update
    public GameManager[] test;
    public GameManager manager;
    void Start(){
        //Find GameManager
        test = FindObjectsOfType<GameManager>();
        manager = test[0];
    }

    public void changeRizz(){
        if (manager.getRizz() == 100){
            //Todo: Add text saying Rizz can't be any higher
            Debug.Log("Can't go any higher");
        } else {
            manager.setRizz(manager.getRizz() + Random.Range(1, 10));
            if (manager.getRizz() > 100){
                manager.setRizz(100);
            }
            manager.setInfluence(manager.getInfluence() - Random.Range(5, 10));
        }
        
    }

    public void changeEgo(){
        if (manager.getEgo() == 100){
            //Todo: Add text saying Ego can't be any higher
            Debug.Log("Can't go any higher");
        } else {
            manager.setEgo(manager.getEgo() + Random.Range(1, 10));
            if (manager.getEgo() > 100){
                manager.setEgo(100);
            }
            manager.setInfluence(manager.getInfluence() - Random.Range(5, 10));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
