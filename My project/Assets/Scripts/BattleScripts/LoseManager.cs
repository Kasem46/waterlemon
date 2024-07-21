using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseManager : MonoBehaviour
{
    public Text loseType;

    public int influence;
    public int dayCount;

    // Start is called before the first frame update
    void Start()
    {
        influence = GameObject.Find("GameManager").GetComponent<GameManager>().getInfluence();
        dayCount = GameObject.Find("GameManager").GetComponent<GameManager>().getDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (influence <= 0)
        {
            loseType.text = "Your Inflence wasen't high enough to ward off the blades in the night";
        }
        else
        {
            loseType.text = "Your time is up, we can only hope the next minister does better";
        }
    }
}
