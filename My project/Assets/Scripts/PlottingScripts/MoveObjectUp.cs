using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveObjectUp : MonoBehaviour {

    RectTransform canvas;
    RectTransform button;
    Vector3 startingPosition;
    Vector3 newPosition;
    public float speed;

    void Start(){
        button = gameObject.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        startingPosition = transform.position;
        speed = 1f;
    }
    public void MoveUp(){
        StartCoroutine(moveUp());
    }
    IEnumerator moveUp () {
        transform.position = new Vector3(startingPosition.x, startingPosition.y - 10, startingPosition.z);
        newPosition = transform.position;
        while (newPosition.y < startingPosition.y){
            newPosition = transform.position;
            transform.Translate(0f, speed * Time.deltaTime , 0f);
            yield return null;
        }
        if (newPosition.y != startingPosition.y){
            newPosition.y = startingPosition.y;
        }
	}
    public void moveDown(){
        newPosition = transform.position;
        transform.Translate(0f, speed * Time.deltaTime , 0f);
    }
}