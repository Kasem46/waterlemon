using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToScene : MonoBehaviour {
    public GameManager manager;
    public void moveToGame(){
        SceneManager.LoadScene("Ploting");
    }
    public void moveToMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void moveToTutorial(){
        SceneManager.LoadScene("Tutorial");
    }
    public void QuitGame() { 
        Application.Quit();
    }
}