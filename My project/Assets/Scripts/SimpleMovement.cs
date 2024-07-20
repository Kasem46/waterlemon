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
        float speed = 4f;
        float a = (speed * Time.deltaTime);
        //Simple movement
        if (Input.GetKey(KeyCode.LeftShift)){
            speed /= 2;
        }
        if (Input.GetKey("d") && player.transform.position.x < 31.80383){
            transform.position = new Vector3(player.transform.position.x + a, -2.93f, 0f);
        } else if (Input.GetKey("a") && player.transform.position.x > -8.340001f){
            transform.position = new Vector3(player.transform.position.x -a, -2.93f, 0f);
        }
        if (-4f >= player.transform.position.x){
            exitButton.SetActive(true);
        } else {
            exitButton.SetActive(false);
        }
    }
}
