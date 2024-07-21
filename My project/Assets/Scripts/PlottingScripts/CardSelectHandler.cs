using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectHandler : MonoBehaviour
{
    private GameManager[] test;
    private GameManager manager;
    
    public GameObject Deck1;
    public GameObject Deck2;
    public GameObject Deck3;
    public GameObject DisplayDeck;
    // Start is called before the first frame update
    
    void Start(){
        test = FindObjectsOfType<GameManager>();
        manager = test[0];
    }
    // Update is called once per frame
    void Update(){
        switch(manager.getDeckType()){
            case -1:
                DisplayDeck.SetActive(true);
                Deck1.SetActive(false);
                Deck2.SetActive(false);
                Deck3.SetActive(false);
                break;
            case 0:
                Debug.Log("1");
                DisplayDeck.SetActive(false);
                Deck1.SetActive(true);
                Deck2.SetActive(false);
                Deck3.SetActive(false);
                break;
            case 1:
                DisplayDeck.SetActive(false);
                Deck1.SetActive(false);
                Deck2.SetActive(true);
                Deck3.SetActive(false);
                break;
            case 2:
                DisplayDeck.SetActive(false);
                Deck1.SetActive(false);
                Deck2.SetActive(false);
                Deck3.SetActive(true);
                break;
        }
    }
}
