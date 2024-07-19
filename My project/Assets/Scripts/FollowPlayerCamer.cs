using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamer : MonoBehaviour {

public GameObject player;
void LateUpdate(){
    if (player.transform.position.x < 0){
        transform.position = new Vector3(0, 0f, -10f);
    } else if (player.transform.position.x > 25) {
        transform.position = new Vector3(25, 0f, -10f);
    } else {
        transform.position = new Vector3(player.transform.position.x, 0f, -10f);
    }
    
    }
}
