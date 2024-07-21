using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveObjectUp : MonoBehaviour {

    private PlotElementControler controler;
    private MapControl map;
    RectTransform canvas;
    RectTransform button;
    Vector3 startingPosition;
    Vector3 newPosition;
    public float speed;

    void Start(){
        button = gameObject.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        controler = GameObject.Find("Canvas").GetComponent<PlotElementControler>();
        map = GameObject.Find("Map").GetComponent<MapControl>();
        startingPosition = transform.position;
        speed = 10f;
    }
    public void MoveUp(int test){
        if (test == 1){
            controler.openFactionBook();
        }
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
    public void moveDown(int test){
        StartCoroutine(MoveDown(test));
    }
    IEnumerator MoveDown(int test) {
        startingPosition = transform.position;
        newPosition = transform.position;
        while (newPosition.y > -10){
            newPosition = transform.position;
            transform.Translate(0f, -speed * Time.deltaTime , 0f);
            yield return null;
        }
        transform.position = startingPosition;
        if (test == 1){
            controler.closeFactionBook();
        } else {
            controler.closeMiror();
        }
	}
    //Move to the map
    public void moveDownMap(){
        map.showMap();
        StartCoroutine(MoveDownMap());
    }
    IEnumerator MoveDownMap() {
        transform.position = new Vector3(startingPosition.x, startingPosition.y + 10, startingPosition.z);
        newPosition = transform.position;
        while (newPosition.y > startingPosition.y){
            newPosition = transform.position;
            transform.Translate(0f, -speed * Time.deltaTime , 0f);
            yield return null;
        }
        if (newPosition.y != startingPosition.y){
            newPosition.y = startingPosition.y;
        }
	}
    public void moveUpMap(){
        map.showMap();
        StartCoroutine(MoveUpMap());
    }
    IEnumerator MoveUpMap() {
        newPosition = transform.position;
        while (newPosition.y < 10){
            newPosition = transform.position;
            transform.Translate(0f, speed * Time.deltaTime , 0f);
            yield return null;
        }
        transform.position = startingPosition;
        map.hideMapInitial();
	}

}