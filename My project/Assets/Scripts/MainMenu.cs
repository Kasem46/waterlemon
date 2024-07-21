using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject audio;
    // Start is called before the first frame update
    public void openAudio(){
        audio.SetActive(true);
    }
    public void closeAudio(){
        audio.SetActive(false);
    }
    void start(){
        audio.SetActive(false);
    }
    public void quit(){
        Application.Quit();
    }
}
