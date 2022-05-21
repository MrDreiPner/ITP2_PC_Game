using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
//Konstruktor
    public Player(){
        print("player was created");
    }
//Destruktor
    ~Player(){
        print("player was deleted");
    }
//public Methods
    public void placeUnit(){

    }
//Private Variables
    private List <Units> army;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}