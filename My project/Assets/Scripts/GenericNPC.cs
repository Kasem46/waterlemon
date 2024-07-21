using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericNPC : ScriptableObject{
    private int influence;
    private int ego;
    private int rizz;
    private int faction;
    private string name;
    private GameObject sprite;

    private bool dead = false;

    public void e(int inf = 0, int eg = 0, int riz = 0, int fac = 0, string nam = "UNNAMED"){
        influence = inf;
        ego = eg;
        rizz = riz;
        faction = fac;
        name = nam;
        
    }

    //Get Functions
    public GameObject getSprite() {
        return sprite;    
    }

    public string getName(){
        return name;
    }
    public int getInfluence(){
        return influence;
    }
    public int getRizz(){
        return rizz;
    }
    public int getEgo(){
        return ego;
    }
    public int getFaction(){
        return faction;
    }
    public bool isDead(){
        return dead;
    }

    //Set Functions

    public void setName(string nam){
        name = nam;
    }
    public void setInfluence(int inf){
        influence = inf;
    }
    public void setRizz(int riz){
        rizz = riz;
    }
    public void setEgo(int eg){
        ego = eg;
    }
    public void setFaction(int fac){
        faction = fac;
    }

    public void setSprite(GameObject sp) {
        sprite = sp;
    }
    public void setDead(bool d) {
        dead = d;
    }



}
