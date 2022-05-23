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
        GameObject infObject = new GameObject("Infantry-1");
        infObject.transform.parent = this.transform;
        infObject.AddComponent<Infantry>();
        GameObject rangeObject = new GameObject("Archer-1");
        rangeObject.transform.parent = this.transform;
        rangeObject.AddComponent<Range>();
        GameObject cavObject = new GameObject("Cavalry-1");
        cavObject.transform.parent = this.transform;
        cavObject.AddComponent<Cavalry>();
        GameObject siegeObject = new GameObject("Siege-1");
        siegeObject.transform.parent = this.transform;
        siegeObject.AddComponent<Siege>();



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