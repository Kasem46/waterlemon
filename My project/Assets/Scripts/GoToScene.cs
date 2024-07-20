using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToScene : MonoBehaviour {
    public GameObject Audio;
    public void moveToPlotting(){
        Destroy(Audio);
        SceneManager.LoadScene("Ploting");
    }
    public void moveToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void moveToParty(){
        SceneManager.LoadScene("Party");
    }
    public void moveToBattle() {
        SceneManager.LoadScene("Battle");
    }

    public void QuitGame() { 
        Application.Quit();
    }
}