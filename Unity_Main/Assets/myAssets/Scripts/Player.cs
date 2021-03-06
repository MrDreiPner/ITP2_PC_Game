using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //von Gabs ab hier test bis zum kommentar Konstruktor
    public GameObject infantryPrefab;
    public GameObject cavalryPrefab;
    public GameObject archerPrefab;
    public GameObject rangePrefab;//Siege wird gelöscht
    public GameObject infantryPrefab2;
    public GameObject cavalryPrefab2;
    public GameObject archerPrefab2;
    public bool playerTag;

    //Konstruktor
    public Player(bool playerTag)
    {
        //army.Add(new Infantry());
        //army.Add(new Infantry());
        //army.Add(new Infantry());
        print("player was created");
        money = 3;
        this.playerTag = playerTag;
    }
    //Destruktor
    ~Player(){
        print("player was deleted");
    }
//public Methods
    public void PlaceUnit(){
        //Versuch um gleich prefabs hinzuzufügen:
        //https://www.youtube.com/watch?v=eACZk-XDP2A
        /*GameObject infantry = Instantiate(infantryPrefab, transform.position, Quaternion.identity) as GameObject;
        infantry.transform.parent = this.transform;
        GameObject infantry2 = Instantiate(infantryPrefab, transform.position, Quaternion.identity) as GameObject;
        infantry2.transform.parent = this.transform;
        GameObject archer = Instantiate(archerPrefab, transform.position, Quaternion.identity) as GameObject;
        archer.transform.parent = this.transform; */
        /* das war schon vorher da
        GameObject infObject = new GameObject("Infantry-1");
        infObject.transform.parent = this.transform;
        infObject.AddComponent<Infantry>();
        GameObject rangeObject = new GameObject("Archer-1");
        rangeObject.transform.parent = this.transform;
        rangeObject.AddComponent<Range>();
        rangeObject.GetComponent<Range>().playerTag = 2;
        */

        //das war schon auskommentiert
        /*GameObject cavObject = new GameObject("Cavalry-1");
        cavObject.transform.parent = this.transform;
        cavObject.AddComponent<Cavalry>();
        GameObject siegeObject = new GameObject("Siege-1");
        siegeObject.transform.parent = this.transform;
        siegeObject.AddComponent<Siege>();*/

        //das war nicht auskommentiert
        /*army.Add(infObject);
        army.Add(rangeObject);*/
    }

    public void AddUnit(int choice)
    {
        GameObject newObject;
        switch (choice)
        {
            case 1:
                newObject = Instantiate(infantryPrefab, transform.position, Quaternion.identity, this.transform.parent) as GameObject;
                money -= 5;
                break;
            case 2:
                newObject = Instantiate(archerPrefab, transform.position, Quaternion.identity, this.transform.parent) as GameObject;
                money -= 7;
                break;
            case 3:
                newObject = Instantiate(cavalryPrefab, transform.position, Quaternion.identity, this.transform.parent) as GameObject;
                money -= 10;
                break;
            case 4:
                newObject = Instantiate(infantryPrefab2, transform.position, Quaternion.identity, this.transform.parent) as GameObject;
                money -= 5;
                break;
            case 5:
                newObject = Instantiate(archerPrefab2, transform.position, Quaternion.identity, this.transform.parent) as GameObject;
                money -= 7;
                break;
            case 6:
                newObject = Instantiate(cavalryPrefab2, transform.position, Quaternion.identity, this.transform.parent) as GameObject;
                money -= 10;
                break;
            default:
                newObject = new GameObject("Infantry-1");
                break;
        }
        newObject.transform.parent = this.transform;
        army.Add(newObject);
    }
    //this function should reset the values of each unit a player has when he/she ends his/her turn
    public void ResetUnits()
    {
        //army.Count return the amount of elements in the list
        if(army.Count != 0)
        {
            foreach(GameObject unit in army)
            {
                
            }
        }
        
    }
    public int Money
    {
        get { return money; }
        set { money = value; }
    }

    //Private Variables
    private List <GameObject> army;
    public int money;

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