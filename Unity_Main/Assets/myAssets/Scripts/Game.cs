using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{
    public bool turn; //true = player1, false = player2
    public GameObject BuyUnitMenu;
    public string eventLog;

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

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find("Player 1");
        Player2 = GameObject.Find("Player 2");
    }

    // Update is called once per frame
    void Update()
    {
        if (turn) Player1.GetComponent<Player>().EnemyCastleOccupied(new Vector2(4.5f, 2.5f));
        else Player2.GetComponent<Player>().EnemyCastleOccupied(new Vector2(-5.5f, -2.5f));
        bool win = CheckWin();
        if (win)
        {
            Destroy(this);
            if(turn) SceneManager.LoadScene(2);
            else SceneManager.LoadScene(3);
        }
        
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
                    if (Player1.GetComponent<Player>().Money < 5) transform.parent.parent.parent.GetComponent<Game>().eventLog = " Not enough money ";
                    else Player1.GetComponent<Player>().AddUnit(dropdown.value);
                    Destroy(dropdown.gameObject);
                }
                else if (dropdown.value == 2)
                {
                    if (Player1.GetComponent<Player>().Money < 7) transform.parent.parent.parent.GetComponent<Game>().eventLog = " Not enough money ";
                    else Player1.GetComponent<Player>().AddUnit(dropdown.value);
                    Destroy(dropdown.gameObject);
                }
                else if (dropdown.value == 3)
                {
                    if (Player1.GetComponent<Player>().Money < 10) transform.parent.parent.parent.GetComponent<Game>().eventLog = " Not enough money ";
                    else Player1.GetComponent<Player>().AddUnit(dropdown.value);
                    Destroy(dropdown.gameObject);
                }
            }
            else transform.parent.parent.parent.GetComponent<Game>().eventLog = " Space already occupied ";
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
                    if (Player2.GetComponent<Player>().Money < 5) transform.parent.parent.parent.GetComponent<Game>().eventLog = " Not enough money ";
                    else Player2.GetComponent<Player>().AddUnit(dropdown.value + 3);
                }
                else if (dropdown.value == 2)
                {
                    if (Player2.GetComponent<Player>().Money < 7) transform.parent.parent.parent.GetComponent<Game>().eventLog = " Not enough money ";
                    else Player2.GetComponent<Player>().AddUnit(dropdown.value + 3);
                }
                else if (dropdown.value == 3)
                {
                    if (Player2.GetComponent<Player>().Money < 10) transform.parent.parent.parent.GetComponent<Game>().eventLog = " Not enough money ";
                    else Player2.GetComponent<Player>().AddUnit(dropdown.value + 3);
                }
                Destroy(dropdown.gameObject);
            }
            else transform.parent.parent.parent.GetComponent<Game>().eventLog = " Space already occupied ";
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