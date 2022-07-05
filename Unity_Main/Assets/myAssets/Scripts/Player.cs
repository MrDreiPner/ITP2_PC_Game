using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //von Gabs ab hier test bis zum kommentar Konstruktor
    public GameObject infantryPrefab;
    public GameObject cavalryPrefab;
    public GameObject archerPrefab;
    public GameObject infantryPrefab2;
    public GameObject cavalryPrefab2;
    public GameObject archerPrefab2;
    public bool playerTag;
    public bool ownEnemyCastle; //WinCondition
    public bool ownMine;
    public int ownVillage;
    //Konstruktor
    public Player(bool playerTag)
    {
        print("player was created");
        money = 3;
        this.playerTag = playerTag;
    }
    //Destruktor
    ~Player(){
        print("player was deleted");
    }
    //public Methods
    public void EnemyCastleOccupied(Vector2 Castle) //Checks each units location to find out if opponents castle is taken
    {
        Vector2 raycastPos = Castle;
        RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero, Mathf.Infinity, (1 << 3));
        if (hit.collider != null)
        {
            for(int i = 0; i< transform.childCount; i++)
            {
                if (transform.GetChild(i).name == "MovePoint") continue;
                if (transform.GetChild(i).position.x == Castle.x && transform.GetChild(i).position.y == Castle.y)
                {
                    ownEnemyCastle = true;
                    break;
                }
            }
        }
    }
    public void AddUnit(int choice)
    {
        //Spawns newly bought unit at player's castle
        GameObject newObject;
        switch (choice)
        {
            case 1:
                newObject = Instantiate(infantryPrefab, new Vector3(-5.5f, -2.5f,5), Quaternion.identity, this.transform.parent) as GameObject;
                money -= 5;
                break;
            case 2:
                newObject = Instantiate(archerPrefab, new Vector3(-5.5f, -2.5f, 5), Quaternion.identity, this.transform.parent) as GameObject;
                money -= 7;
                break;
            case 3:
                newObject = Instantiate(cavalryPrefab, new Vector3(-5.5f, -2.5f, 5), Quaternion.identity, this.transform.parent) as GameObject;
                money -= 10;
                break;
            case 4:
                newObject = Instantiate(infantryPrefab2, new Vector3(4.5f, 2.5f, 5), Quaternion.identity, this.transform.parent) as GameObject;
                money -= 5;
                break;
            case 5:
                newObject = Instantiate(archerPrefab2, new Vector3(4.5f, 2.5f, 5), Quaternion.identity, this.transform.parent) as GameObject;
                money -= 7;
                break;
            case 6:
                newObject = Instantiate(cavalryPrefab2, new Vector3(4.5f, 2.5f, 5), Quaternion.identity, this.transform.parent) as GameObject;
                money -= 10;
                break;
            default:
                newObject = new GameObject("Infantry-1");
                break;
        }
        newObject.transform.parent = this.transform;
    }
    //this function resets the values of each unit a player has when they ends their turn
    public void ResetUnits()
    {
       
        for (int i = 0; i < (transform.childCount); i++)
        {
            if (transform.GetChild(i).name == "MovePoint") continue;
            if (transform.GetChild(i).GetComponent<Units>().type == Units.Types.infantry)
            {
                transform.GetChild(i).GetComponent<Units>().move = 4;
            }
            else if (transform.GetChild(i).GetComponent<Units>().type == Units.Types.cavalry)
            {
                transform.GetChild(i).GetComponent<Units>().move = 6;
            }
            else if (transform.GetChild(i).GetComponent<Units>().type == Units.Types.range)
            {
                transform.GetChild(i).GetComponent<Units>().move = 4;
            }
            transform.GetChild(i).GetComponent<Units>().hasAttacked = false;
        }
        Debug.Log("Refresh gets called");
    }
    public int Money
    {
        get { return money; }
        set { money = value; }
    }

    //Private Variables
    public int money;

    // Start is called before the first frame update
    void Start()
    {
        ownVillage = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}