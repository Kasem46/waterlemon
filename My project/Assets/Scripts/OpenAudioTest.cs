using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenAudioTest : MonoBehaviour
{
    // Start is called before the first frame update
    
    private GameManager[] test;
    private GameManager manager;
    public AudioSource test2;
    public Slider slider;
    void Start(){
        test = FindObjectsOfType<GameManager>();
        manager = test[0];
    }

    void changeVolume(){
        test2.volume = manager.getAudio();
    }

    public void setVolume(){
        manager.setAudio(slider.value);
        changeVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
