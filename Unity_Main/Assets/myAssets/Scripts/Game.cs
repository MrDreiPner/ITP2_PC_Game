using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public bool turn; //true = player1, false = player2
    public GameObject BuyUnitMenu;

//Konstruktor
    public Game(){
        //print("Game created");
        //Player1 = new Player(1);
        //Player2 = new Player(2);
        turn = true;
    }
//Destuktor
    ~Game(){
        print("Game deleted");
    }
//public Methods 
    public bool CheckWin(){
        if (turn)
        {
            if (Player1.GetComponent<Player>().ownEnemyCastle)
            {
                Debug.Log("Player 1 wins!");
                return true;
            }
            else return false;
        }
        else
        {
            if (Player2.GetComponent<Player>().ownEnemyCastle)
            {
                Debug.Log("Player 2 wins!");
                return true;
            }
            else return false;
        }
    }

//private Variables
    private GameObject Player1;
    private GameObject Player2;
    //private Grid Map;
    
    /*public void PutUnitsInList()
    {
        GameObject Infantry1 = GameObject.Find("Infantry1");
        GameObject Infantry2 = GameObject.Find("Infantry2");
        GameObject Infantry3 = GameObject.Find("Infantry3");
        GameObject Archer1 = GameObject.Find("Archer1");
        GameObject Cavalry1 = GameObject.Find("Cavalry1");
        Player1.GetComponent<Player>().army.Add(Infantry1);
        Player1.GetComponent<Player>().army.Add(Infantry2);
        Player1.GetComponent<Player>().army.Add(Infantry3);
        Player1.GetComponent<Player>().army.Add(Archer1);
        Player1.GetComponent<Player>().army.Add(Cavalry1);

        Infantry1 = GameObject.Find("Infantry1P2");
        Infantry2 = GameObject.Find("Infantry2P2");
        Infantry3 = GameObject.Find("Infantry3P2");
        Archer1 = GameObject.Find("Archer1P2");
        Cavalry1 = GameObject.Find("Cavalry1P2");
        Player2.GetComponent<Player>().army.Add(Infantry1);
        Player2.GetComponent<Player>().army.Add(Infantry2);
        Player2.GetComponent<Player>().army.Add(Infantry3);
        Player2.GetComponent<Player>().army.Add(Archer1);
        Player2.GetComponent<Player>().army.Add(Cavalry1);
    }*/

    // Start is called before the first frame update
    void Start()
    {
        //Game Spiel = gameObject.AddComponent<Game>(); //evtl noch ändern
        Player1 = GameObject.Find("Player 1");
        Player2 = GameObject.Find("Player 2");
        //PutUnitsInList();
    }

    // Update is called once per frame
    void Update()
    {
        bool win = CheckWin();
        if (win) Destroy(this);
    }

    public void Buy()
    {
        
        var dropdown = transform.GetComponent<Dropdown>();
        if (transform.parent.parent.parent.GetComponent<Game>().turn)
        {
            Vector2 raycastPos = new Vector2(-5.5f, -2.5f);
            RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero, Mathf.Infinity, (1 << 3));
            Debug.Log(turn + "Player1");
            if (hit.collider == null)
            {
                if (dropdown.value == 1)
                {
                    if (Player1.GetComponent<Player>().Money < 5) Debug.Log("Not enough money");
                    else Player1.GetComponent<Player>().AddUnit(dropdown.value);
                    Destroy(dropdown.gameObject);
                }
                else if (dropdown.value == 2)
                {
                    if (Player1.GetComponent<Player>().Money < 7) Debug.Log("Not enough money");
                    else Player1.GetComponent<Player>().AddUnit(dropdown.value);
                    Destroy(dropdown.gameObject);
                }
                else if (dropdown.value == 3)
                {
                    if (Player1.GetComponent<Player>().Money < 10) Debug.Log("Not enough money");
                    else Player1.GetComponent<Player>().AddUnit(dropdown.value);
                    Destroy(dropdown.gameObject);
                }
            }
            else Debug.Log("space occupied");
        }
        else
        {
            Vector2 raycastPos = new Vector2(4.5f, 2.5f);
            RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero, Mathf.Infinity, (1 << 3));
            if(hit.collider == null)
            {
                Debug.Log(turn + "Player2");
                if (dropdown.value == 1)
                {
                    if (Player2.GetComponent<Player>().Money < 5) Debug.Log("Not enough money");
                    else Player2.GetComponent<Player>().AddUnit(dropdown.value + 3);
                }
                else if (dropdown.value == 2)
                {
                    if (Player2.GetComponent<Player>().Money < 7) Debug.Log("Not enough money");
                    else Player2.GetComponent<Player>().AddUnit(dropdown.value + 3);
                }
                else if (dropdown.value == 3)
                {
                    if (Player2.GetComponent<Player>().Money < 10) Debug.Log("Not enough money");
                    else Player2.GetComponent<Player>().AddUnit(dropdown.value + 3);
                }
                Destroy(dropdown.gameObject);
            }
            else Debug.Log("space occupied");
        }
           
    }

    //Function for the Round button
    public void EndTurn()
    {
        if (transform.parent.parent.GetComponent<Game>().turn)
        {
            //Player1 ist am zug
            transform.parent.parent.GetChild(0).GetComponent<Player>().ResetUnits();
            transform.parent.parent.GetChild(0).GetComponent<Player>().money += (3 + (2 * transform.parent.parent.GetChild(0).GetComponent<Player>().ownVillage));

        }
        else
        {
            transform.parent.parent.GetChild(1).GetComponent<Player>().ResetUnits();
            transform.parent.parent.GetChild(1).GetComponent<Player>().money += (3 + (2 * transform.parent.parent.GetChild(1).GetComponent<Player>().ownVillage));
        }
        transform.parent.parent.GetComponent<Game>().turn = !transform.parent.parent.GetComponent<Game>().turn;
        Debug.Log("Button geklickt");
        Debug.Log("parent" + transform.parent.parent.GetComponent<Game>().turn);
        Debug.Log("button" + turn);
    }

    public void BuyMenu()
    {
        GameObject menu = Instantiate(BuyUnitMenu, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
        menu.transform.parent = this.transform;
    }
}