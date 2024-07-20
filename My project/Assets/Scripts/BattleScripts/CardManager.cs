using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject Insult;
    public GameObject Complement;
    public GameObject Affront;
    public GameObject Gossip;
    public GameObject Poison;

    private GameObject[] cardset1;
    private GameObject[] cardset2;
    private GameObject[] cardset3;

    [SerializeField]
    private int handType = 0;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        cardset1 = new GameObject[3];
        cardset1[0] = Insult;
        cardset1[1] = Complement;
        cardset1[2] = Gossip;

        cardset2 = new GameObject[3];
        cardset2[0] = Insult;
        cardset2[1] = Complement;
        cardset2[2] = Affront;

        cardset3 = new GameObject[3];
        cardset3[0] = Insult;
        cardset3[1] = Affront;
        cardset3[2] = Poison;
        foreach (GameObject card in cardset1){
            card.SetActive(false);
        }
        foreach (GameObject card in cardset2)
        {
            card.SetActive(false);
        }
        foreach (GameObject card in cardset3)
        {
            card.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        catch {
            Debug.Log("card based oopsie");
        
        }
        handType = manager.getDeckType();
        choseCardset(handType);
    }

    void choseCardset(int set) {
        GameObject[] cardset;
        switch (set) {
            case 0:
                cardset = cardset1;
                break;
            case 1:
                cardset = cardset2;
                break;
            case 2:
                cardset = cardset3;
                break;
            default:
                Debug.Log("InvalidCardset");
                cardset = new GameObject[1];
                break;
        }

        for (int i = 0; i < cardset.Length; i++) {
            cardset[i].SetActive(true);
            cardset[i].transform.localPosition = new Vector3((i-1)*120,-158.5f,3.8f);
        }
    }
}
