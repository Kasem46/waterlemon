using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TableManager : MonoBehaviour
{

    private int peopleAtTable;
    public GenericNPC[] NPCS;
    private GameManager thing;


    // Start is called before the first frame update
    void Start()
    {
        
        thing = GameObject.Find("GameManager").GetComponent<GameManager>();
        //randomly populate table with people
        peopleAtTable = Random.Range(1,4);
        NPCS = new GenericNPC[peopleAtTable];
        for (int i  = 0; i < NPCS.Length; i++){
            NPCS[i] = thing.NPCs[Random.Range(0,18)];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToBattle(){
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Battle");
    }
}
