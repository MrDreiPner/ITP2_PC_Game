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
        money = 3;
    }
//Destruktor
    ~Player(){
        print("player was deleted");
    }
//public Methods
    public void PlaceUnit(){
        GameObject infObject = new GameObject("Infantry-1");
        infObject.transform.parent = this.transform;
        infObject.AddComponent<Infantry>();
        GameObject rangeObject = new GameObject("Archer-1");
        rangeObject.transform.parent = this.transform;
        rangeObject.AddComponent<Range>();
        /*GameObject cavObject = new GameObject("Cavalry-1");
        cavObject.transform.parent = this.transform;
        cavObject.AddComponent<Cavalry>();
        GameObject siegeObject = new GameObject("Siege-1");
        siegeObject.transform.parent = this.transform;
        siegeObject.AddComponent<Siege>();*/

        army.Add(infObject);
        army.Add(rangeObject);
    }

    public void AddUnit(int choice)
    {
        GameObject newObject;
        switch (choice)
        {
            case 0:
                newObject = new GameObject("Infantry-1");
                newObject.AddComponent<Infantry>();
                money -= 5;
                break;
            case 1:
                newObject = new GameObject("Archer-1");
                newObject.AddComponent<Range>();
                money -= 7;
                break;
            case 2:
                newObject = new GameObject("Cavalry-1");
                newObject.AddComponent<Cavalry>();
                money -= 10;
                break;
            default:
                newObject = new GameObject("Infantry-1");
                newObject.AddComponent<Infantry>();
                money -= 5;
                break;
        }
        newObject.transform.parent = this.transform;
        army.Add(newObject);
    }

    public int Money
    {
        get { return money; }
        set { money = value; }
    }

//Private Variables
    private List <GameObject> army;
    private int money;

    // Start is called before the first frame update
    void Start()
    {
        PlaceUnit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}