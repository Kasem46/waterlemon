using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    //functional elements
    private int roundCount = 0;
    public GenericNPC[] NPCs;
    public int numNPCs = 3;
    private bool isPlayerTurn = true;
    GameManager manager;

    //display elements
    public Text battleLog;
    public Dropdown targetSelector;
    public TableManager table;
    public GameObject Audio;

    private string battleLogText = "";
    [SerializeField]
    private float timer = 3;
    [SerializeField]
    private List<GameObject> buffer = new List<GameObject>();

    [SerializeField]
    private GameObject arrow;

    [SerializeField]
    private GameObject NPC1Render;
    [SerializeField]
    private GameObject NPC2Render;
    [SerializeField]
    private GameObject NPC3Render;

    //Start is called before the first frame update
    void Start()
    {
        try{

            table = GameObject.Find("table").GetComponent<TableManager>();
            Audio = GameObject.Find("Audio Source");
            manager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

        setupNPCSprites();
    }

    private void setupNPCSprites() {
        NPC1Render.SetActive(true);
        NPC2Render.SetActive(true);
        NPC3Render.SetActive(true);
        if (NPCs.Length == 2)
        {
            NPC1Render.GetComponent<Image>().sprite = NPCs[0].getSprite().GetComponent<SpriteRenderer>().sprite;
            NPC3Render.GetComponent<Image>().sprite = NPCs[1].getSprite().GetComponent<SpriteRenderer>().sprite;
            NPC2Render.SetActive(false);
        }
        else if (NPCs.Length == 3) {
            NPC1Render.GetComponent<Image>().sprite = NPCs[0].getSprite().GetComponent<SpriteRenderer>().sprite;
            NPC2Render.GetComponent<Image>().sprite = NPCs[1].getSprite().GetComponent<SpriteRenderer>().sprite;
            NPC3Render.GetComponent<Image>().sprite = NPCs[2].getSprite().GetComponent<SpriteRenderer>().sprite;
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

    public void rotateArrow() {
        if (NPCs.Length == 3)
        {
            arrow.transform.eulerAngles = new Vector3(0, 0, arrow.transform.eulerAngles.z - 90);
        }
        else if (NPCs.Length == 2) {
            arrow.transform.eulerAngles = new Vector3(0, 0, arrow.transform.eulerAngles.z - 120);
        }
    }

    public void updateUI() {
        if (timer <= 0 && buffer.Count > 0)
        {
            GameObject temp = buffer[0];
            buffer.RemoveAt(0);
            temp.SetActive(true);
            temp.GetComponent<BattleLogMover>().setIsCopy(true);
            timer = 3;

            rotateArrow();
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

        battleLog.text = "";

    }
    public void pushToBuffer(GameObject a) { 
        buffer.Add(a);
    }

    public void playerAction(int type) {
        GenericNPC target = NPCs[targetSelector.value];
        if (isPlayerTurn && buffer.Count == 0)
        {
            switch (type)
            {
                case 0:
                    insult(targetSelector.value, false, (float)manager.getRizz());
                    setBattleText("Player Insulted " + target.getName());
                    break;
                case 1:
                    complement(targetSelector.value, false, (float)manager.getRizz());
                    setBattleText("Player Complemented " + target.getName());
                    break;
                case 2:
                    affront(targetSelector.value, false, (float)manager.getRizz());
                    setBattleText("Player Affronted " + target.getName()); 
                    break;
                case 3:
                    gossip(targetSelector.value, false,(float)manager.getRizz());
                    setBattleText("Player Gossiped About " + target.getName());
                    break;
                case 4:
                    poison(targetSelector.value,(float)manager.getRizz());
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
            setBattleText(person.getName() + NPCAction(Random.Range(0,4),person));
        }
        endRound();
    }

    public void endRound() {
        roundCount++;
        isPlayerTurn=true;
    }

    public int selectTarget(GenericNPC doer, int action) {
        int temp = Random.Range(0, NPCs.Length + 1);
        if (temp != NPCs.Length)
        {
            if (action == 0 || action == 2) {
                for (int i = 0; i < NPCs.Length; i++){
                    temp = i;
                    if (NPCs[temp].getFaction() == 4 && doer.getFaction() != 4) {
                        return temp;
                    }
                }
            
            }

            if (NPCs[temp] == doer)
            {
                temp = selectTarget(doer, action);
                if (temp == NPCs.Length) {
                    return temp;
                }
            }
            //check to not insult your own faction
            if (NPCs[temp].getFaction() == doer.getFaction() && (action == 0 || action == 2))
            {
                temp = selectTarget(doer, action);
                if (temp == NPCs.Length) {
                    return temp;
                }
            }
        }

        return temp;
    }

    public string NPCAction(int action, GenericNPC doer) {
        string targetName;
        int target = selectTarget(doer,action);
        GenericNPC targetedNPC;
        if (target == NPCs.Length)
        {
            targetName = "Player";
        }
        else {
            targetedNPC = NPCs[target];
            targetName = NPCs[target].getName();
        }
        switch (action) { 
            case 0:
                insult(target, true, (float)doer.getRizz());
                return " Insulted " + targetName;
            case 1:
                complement(target, true, (float)doer.getRizz());
                return " complemented " + targetName;
            case 2:
                affront(target, true, (float)doer.getRizz());
                return " affronted " + targetName;
            case 3:
                gossip(target,true,(float)doer.getRizz());
                return " gossiped about " + targetName;
            default:
                return " picks an Invalid option";
        
        }
    }


    public void insult(int target, bool NPC, float doerRiz) {
        if (NPC)
        {
            if (target == NPCs.Length)
            {
                //NPC target player
                manager.setInfluence(manager.getInfluence() - (int)((10f * (doerRiz / 100f))*((float)(100 -manager.getEgo())/100f)));

            }
            else {
                //NPC target NPC
                NPCs[target].setInfluence(NPCs[target].getInfluence() - (int)((10f * (doerRiz / 100f)) * ((float)(100 - NPCs[target].getEgo()) / 100f)));
            }

        }
        else {
            //Player target NPC
            manager.setEnergy(manager.getEnergy() - (int)(10f*manager.getEnergyCostMultiplyer()));
            manager.setFame(manager.getFame() - 5);
            NPCs[target].setInfluence(NPCs[target].getInfluence() - (int)((10f * (doerRiz / 100f)) * ((float)(100 - NPCs[target].getEgo()) / 100f)));
        }
    }

    public void complement(int target, bool NPC, float doerRiz)
    {
        if (NPC)
        {
            if (target == NPCs.Length)
            {
                //NPC target player
                manager.setInfluence(manager.getInfluence() + (int)(10f * (doerRiz / 100f) ));

            }
            else
            {
                //NPC target NPC
                NPCs[target].setInfluence(NPCs[target].getInfluence() + (int)(10f * (doerRiz / 100f)));
            }

        }
        else
        {
            //Player target NPC
            manager.setEnergy(manager.getEnergy() - (int)(10f * manager.getEnergyCostMultiplyer()));
            manager.setFame(manager.getFame() + 5);
            NPCs[target].setInfluence(NPCs[target].getInfluence() + (int)(10f * (doerRiz / 100f)));
        }
    }

    public void affront(int target, bool NPC, float doerRiz)
    {
        if (NPC)
        {
            if (target == NPCs.Length)
            {
                //NPC target player
                manager.setInfluence(manager.getInfluence() - (int)((20f * (doerRiz / 100f)) * ((float)(100 - manager.getEgo()) / 100f)));

            }
            else
            {
                //NPC target NPC
                NPCs[target].setInfluence(NPCs[target].getInfluence() - (int)((20f * (doerRiz / 100f)) * ((float)(100 - NPCs[target].getEgo()) / 100f)));
            }

        }
        else
        {
            //Player target NPC
            manager.setEnergy(manager.getEnergy() - (int)(20f * manager.getEnergyCostMultiplyer()));
            manager.setFame(manager.getFame() - 10);
            NPCs[target].setInfluence(NPCs[target].getInfluence() - (int)((20f * (doerRiz / 100f)) * ((float)(100 - NPCs[target].getEgo()) / 100f)));
        }
    }

    public void gossip(int target, bool NPC, float doerRiz)
    {
        if (NPC)
        {
            if (target == NPCs.Length)
            {
                //NPC target player
                manager.setInfluence(manager.getInfluence() - (int)((10f * (doerRiz / 100f)) * ((float)(100 - manager.getEgo()) / 100f)));
                
            }
            else
            {
                //NPC target NPC
                NPCs[target].setInfluence(NPCs[target].getInfluence() - (int)((10f * (doerRiz / 100f)) * ((float)(100 - NPCs[target].getEgo()) / 100f)));
            }

        }
        else
        {
            //Player target NPC
            manager.setEnergy(manager.getEnergy() - (int)(15f * manager.getEnergyCostMultiplyer()));
            manager.setFame(manager.getFame() + 10);
            NPCs[target].setInfluence(NPCs[target].getInfluence() - (int)((10f * (doerRiz / 100f)) * ((float)(100 - NPCs[target].getEgo()) / 100f)));
        }
    }

    public void poison(int target,float doerRiz) { 
        manager.setEnergy(manager.getEnergy() - 20);
        int successChance = Random.Range(1, 101);
        if ((float)successChance <= doerRiz)
        {
            NPCs[target].setEgo(NPCs[target].getEgo() - 15);
            NPCs[target].setRizz(NPCs[target].getRizz() - 15);
            setBattleText("Poisoning Succeeded");
        }
        else {
            setBattleText("Poisoning Failed");
        }
        manager.setFame(manager.getFame() - 20);
        
    }

    public void LEAVE() {
        if (isPlayerTurn && buffer.Count == 0)
        {
            Destroy(table.gameObject);
            Destroy(Audio.gameObject);
            SceneManager.LoadScene("Ploting");
        }
    }
}
