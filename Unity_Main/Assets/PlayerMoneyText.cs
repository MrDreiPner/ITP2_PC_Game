using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneyText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string playerTurn;
        if (transform.parent.parent.GetComponent<Game>().turn) playerTurn = " Player 1's turn: \nMoney: " + transform.parent.parent.GetChild(0).GetComponent<Player>().money + " ";
        else playerTurn = " Player 2's turn: \nMoney: " + transform.parent.parent.GetChild(1).GetComponent<Player>().money + " ";
        transform.GetChild(0).GetComponent<Text>().text = playerTurn;
    }
}
