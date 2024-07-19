using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //functional elements
    private int roundCount = 0;
    public GenericNPC[] NPCs;
    public int numNPCs = 3;
    private bool isPlayerTurn = true;

    //display elements
    public Text battleLog;
    public Dropdown targetSelector;
    public TableManager table;


    //Start is called before the first frame update
    void Start()
    {
        try{

            table = GameObject.Find("table").GetComponent<TableManager>();
        }catch {
            Debug.Log("Oopsie");
        }
        numNPCs = table.getNumNPCs();
        NPCs = new GenericNPC[numNPCs];
        //This is where we will need to get referencees to each of the npcs made in mathew sectio
        for (int i = 0; i < NPCs.Length; i++) {
            NPCs[i] = table.getNPCs()[i];
        }

        //set up selector menu
        for (int i = 0; i < numNPCs; i++) {
            Dropdown.OptionData tempData = new Dropdown.OptionData();
            tempData.text = NPCs[i].getName();
            targetSelector.options.Add(tempData);
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
    }

    //reference key for acction codes
    //Insult - 0
    //Complement - 1
    //Affront - 2
    //Gossip - 3
    //Poison - 4

    public void updateUI() { 
        
    }

    public void playerAction(int type) {
        GenericNPC target = NPCs[targetSelector.value];
        if (isPlayerTurn)
        {
            switch (type)
            {
                case 0:
                    Debug.Log("Insulted");
                    break;
                case 1:
                    Debug.Log("Complemented");
                    break;
                case 2:
                    Debug.Log("Affronted");
                    break;
                case 3:
                    Debug.Log("Gossiped About");
                    break;
                case 4:
                    Debug.Log("Poisoned");
                    break;
                default:
                    Debug.Log("invalid player option");
                    break;
            }

            endPlayerTurn();
        }
    }

    public void endPlayerTurn() { 
        isPlayerTurn = false;
        NPCturn();
    }

    public void NPCturn() {
        //NPCs all pick options
        foreach (GenericNPC person in NPCs) {
            Debug.Log("NPC turn");
        }
        endRound();
    }

    public void endRound() {
        roundCount++;
        isPlayerTurn=true;
    }
}
