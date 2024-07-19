using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour{
    public GameObject player;
    public GameObject exitButton;
    void start(){

    }

    // Update is called once per frame
    void Update(){
        float speed = 0.007f;
        //Simple movement
        if (Input.GetKey(KeyCode.LeftShift)){
            speed /= 2;
        }
        if (Input.GetKey("d") && player.transform.position.x < 33.30029f){
            float a = player.transform.position.x + (speed);
            transform.position = new Vector3(a, -2.93f, 0f);
        } else if (Input.GetKey("a") && player.transform.position.x > -8.340001f){
            float a = player.transform.position.x + (-speed);
            transform.position = new Vector3(a, -2.93f, 0f);
        }
        if (-4f >= player.transform.position.x){
            exitButton.SetActive(true);
        } else {
            exitButton.SetActive(false);
        }
    }
}
