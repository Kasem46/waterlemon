using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour{
    private GameManager[] test;
    private GenericNPC[] NPCs;
    private GameManager manager;
    private GameObject delete;
    public void VassalRoyal(){
        if(NPCs[0].getInfluence() + NPCs[1].getInfluence() + NPCs[2].getInfluence() == 270 && manager.getInfluence() == 80){
            delete.SetActive(false);
            manager.setInfluence(manager.getInfluence() - 60);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        test = FindObjectsOfType<GameManager>();
        manager = test[0];
        NPCs = manager.getNPCArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
