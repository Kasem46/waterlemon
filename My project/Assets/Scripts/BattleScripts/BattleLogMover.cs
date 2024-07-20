using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleLogMover : MonoBehaviour
{
    public float speed = 5f;
    private Text thisText;
    private bool isCopy;

    // Start is called before the first frame update
    void Start()
    {
        thisText = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCopy == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            speed += 2f * Time.deltaTime;

            thisText.color = new Color(thisText.color.r, thisText.color.g, thisText.color.b, thisText.color.a - (speed * Time.deltaTime) / 100f);

            if (thisText.color.a <= 0f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void setIsCopy(bool a) { 
        isCopy = a;
    }
}
