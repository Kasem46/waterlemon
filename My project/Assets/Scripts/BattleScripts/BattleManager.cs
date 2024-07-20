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

    private string battleLogText = "";
    [SerializeField]
    private float timer = 3;
    [SerializeField]
    private List<GameObject> buffer = new List<GameObject>();

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
        if (timer <= 0 && buffer.Count > 0)
        {
            GameObject temp = buffer[0];
            buffer.RemoveAt(0);
            temp.SetActive(true);
            temp.GetComponent<BattleLogMover>().setIsCopy(true);
            timer = 3;
        }
        else {
            timer -= Time.deltaTime;
        }
    }

    public void setBattleText(string text) {
        this.battleLogText = text;

        battleLog.text = battleLogText;

        GameObject temp = battleLog.gameObject;
        temp = Instantiate(temp,this.gameObject.transform);
        temp.SetActive(false);
        pushToBuffer(temp);

    }
    public void pushToBuffer(GameObject a) { 
        buffer.Add(a);
    }

    public void playerAction(int type) {
        GenericNPC target = NPCs[targetSelector.value];
        if (isPlayerTurn)
        {
            switch (type)
            {
                case 0:
                    setBattleText("Player Insulted " + target.getName());
                    break;
                case 1:
                    setBattleText("Player Complemented " + target.getName());
                    break;
                case 2:
                    setBattleText("Player Affronted " + target.getName()); 
                    break;
                case 3:
                    setBattleText("Player Gossiped About " + target.getName());
                    break;
                case 4:
                    setBattleText("Player Poisoned " + target.getName());
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
            setBattleText(person.getName() + " did something");
        }
        endRound();
    }

    public void endRound() {
        roundCount++;
        isPlayerTurn=true;
    }
}
