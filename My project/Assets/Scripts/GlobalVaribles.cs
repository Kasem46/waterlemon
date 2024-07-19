using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVaribles : MonoBehaviour {

    //Influence
    public int influence = 100;
    public int influenceCap = 100;

    //Infamy
    public int frame = 100;
    public int fameCap = 100;

    //Energy
    public int energy = 100;
    public int energyCap = 100;

    //Ego
    public int ego = 100;
    public int egoCap = 100;

    //Charisma
    public int rizz = 100;
    public int rizzCap = 100;

    /// <summary>
    /// Factions
    /// This varible is used to determine the player's faction
    /// 0 = No faction
    /// 1 = Royal faction
    /// 2 = Church faction
    /// 3 = Populust faction
    /// 4 = Peasant faction
    /// 5 = Merchant faction
    /// 6 = Military faction
    /// </summary>
    public int faction = 0;


    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
