using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private bool turn; //true = player1, false = player2

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
        bool win = false;

        return win;
    }

//private Variables
    private Player Player1;
    private Player Player2;
    private Grid Map;

    
    // Start is called before the first frame update
    void Start()
    {
        Game Spiel = gameObject.AddComponent<Game>(); //evtl noch ändern
    }

    // Update is called once per frame
    void Update()
    {
        //the win condition should get use here
        /*while (true)
        {
            if (turn)
            {
                //player1 can do whatever he wants


                //reset the values of the units
                //Player1.ResetUnits();
            }
            else
            {
                //player2 can do whatever he wants

                //reset the values of the units
            }
        }*/
        
    }

    public void Buy()
    {
        int choice = 0;
        if(turn == true)
        {
            //muss noch in ein menü embedded werden
            /*choose what to buy:
             *  display player1 money
             *  display all affordable options
             *  each option is represented by an int
             */
            Player1.AddUnit(choice);
        }
        else
        {
            //das selbe mit player2
            Player2.AddUnit(choice);
        }
    }

    //Function for the Round button
    public void ClickTest()
    {
        //turn = !turn;
        Debug.Log("Button geklickt");
       // Debug.Log(turn);
    }
}