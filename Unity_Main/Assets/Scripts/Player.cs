using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
//Konstruktor
    public Player(){
        //army.Add(new Infantry());
        //army.Add(new Infantry());
        //army.Add(new Infantry());
        print("player was created");
    }
//Destruktor
    ~Player(){
        print("player was deleted");
    }
//public Methods
    public void placeUnit(){
        GameObject childObject = new GameObject("Infantry-1");
        childObject.transform.parent = this.transform;
        childObject.AddComponent<Infantry>();
    }
//Private Variables
    private List <Units> army;

    
    
    // Start is called before the first frame update
    void Start()
    {
        placeUnit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}