using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private int roundCount = 0;
    public GenericNPC[] NPCs;
    public int numNPCs = 3;
    private bool isPlayerTurn = true;

    //Start is called before the first frame update
    void Start()
    {
        NPCs = new GenericNPC[numNPCs];
        //This is where we will need to get referencees to each of the npcs made in mathew section
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //reference key for acction codes
    //Insult - 0
    //Complement - 1
    //Affront - 2
    //Gossip - 3
    //Poison - 4

    public void playerAction(int type) { 
        

        endPlayerTurn();
    }

    public void endPlayerTurn() { 
        isPlayerTurn = false;
        NPCturn();
    }

    public void NPCturn() { 
        //NPCs all pick options
    }

    public void endRound() {
        roundCount++;
        isPlayerTurn=true;
    }
}
