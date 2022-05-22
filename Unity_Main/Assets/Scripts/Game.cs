using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{   
//Konstruktor
    public Game(){
        print("Game created");
        //Player1 = new Player();
        //Player2 = new Player();
    }
//Destuktor
    ~Game(){
        print("Game deleted");
    }
//public Methods 
    public bool checkWin(){
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
        
    }
}