using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{

    public Text dialogue;

    public float counter = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (counter) {
            case 5:
                dialogue.text = "Attendent: \nWelcome, dear minister, to the ebb and flow of courtly politics";
                break;
            case 4:
                dialogue.text = "Attendent: \nNow, we all know your rise too power is a fluke and nothing else, so don't get used to it!";
                break;
            case 3:
                dialogue.text = "Attendent: \nHowever much so your inexperence, it is up to you now to fix this mess we are in.";
                break;
            case 2:
                dialogue.text = "Attendent: \nThe great factions in our court have grown stagnetnent, and their rot must be exsised.";
                break;
            case 1:
                dialogue.text = "Attendent: \nI have left a guidebook on your table to get you accustomed. Use it well when navigating through parties";
                break;
            case 0:
                dialogue.text = "Attendent: \nUse your wit and your wisdom to take back this broken court";
                break;
            case -1:
                dialogue.text = "Attendent: \nAnd of course should you fail we have your replacement.";
                Invoke("specialTickCounter", 1.5f);
                break;
            case -2:
                dialogue.text = "Attendent: \nuhhhh I mean Good Luck!";
                break;
            case -3:
                SceneManager.LoadScene("Ploting");
                break;
        }
    }

    void specialTickCounter() {
        if (counter != -2) {
            counter--;
        }
    }

    public void TickCounter() {
        counter--;
    }
}
