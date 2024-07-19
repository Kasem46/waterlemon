using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericNPC : MonoBehaviour{
    private int influence;
    private int ego;
    private int rizz;
    private int faction;
    private string name;

    public void NPCConstructor(int inf = 0, int eg = 0, int riz = 0, int fac = 0, string nam = "UNNAMED"){
        influence = inf;
        ego = eg;
        rizz = riz;
        faction = fac;
        name = name;
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
