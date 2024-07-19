using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TableManager : MonoBehaviour
{

    private GameManager manager;

    private GenericNPC personA;
    private GenericNPC personB;
    private GenericNPC personC;

    // Start is called before the first frame update
    void Start()
    {
        //randomly populate table with people
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onMouseDown() {
        SceneManager.LoadScene("Plotting");
    }
}
