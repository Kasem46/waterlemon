using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TableManager : MonoBehaviour
{

    private int peopleAtTable;
    public GenericNPC[] NPCS;
    private GameManager thing;
    public GameObject button;
    public GameObject player;




    // Start is called before the first frame update
    void Start()
    {

        thing = GameObject.Find("GameManager").GetComponent<GameManager>();
        //randomly populate table with people
        peopleAtTable = Random.Range(2, 4);
        NPCS = new GenericNPC[peopleAtTable];
        randomiseNPCs();
        populateSprites();
    }

    void populateSprites() {
        for (int i = 0; i < NPCS.Length; i++) {
            GameObject temp = Instantiate(NPCS[i].getSprite(), this.gameObject.transform);
            temp.transform.localPosition = new Vector3(1*(i - 1), 0, 0);
        }
    }

    void randomiseNPCs() {
        for (int i = 0; i < NPCS.Length; i++) {
            NPCS[i] = thing.NPCs[Random.Range(0, 18)];
        }
        for (int i = 0; i < NPCS.Length; i++) {
            for (int j = 0; j < NPCS.Length; j++) {
                if (i != j && NPCS[i] == NPCS[j]) {
                    randomiseNPCs();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            if (player.transform.position.x < (this.transform.position.x - this.transform.localScale.x / 2f) || player.transform.position.x > (this.transform.position.x + this.transform.localScale.x / 2f))
            {
                button.SetActive(false);
            }
            else
            {
                button.SetActive(true);
            }
        }
    }

    public void goToBattle(){
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Battle");
    }

    public int getNumNPCs(){
        return peopleAtTable;
    }

    public GenericNPC[] getNPCs(){
        return NPCS;
    }
}
