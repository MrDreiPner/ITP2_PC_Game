using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Units
{

    public LayerMask whatStopsMovement = (1 << 6);
    public LayerMask EnterVill = (1 << 8);
    public LayerMask EnterCast = (1 << 9);
    public LayerMask EnterForest = (1 << 10);
    public LayerMask EnterHill = (1 << 7);

    public Range(bool playerTag)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        hasAttacked = false;
        cost = 7;
        hp = 20;
        atk = 20;
        def = 10;
        move = 4;
        range = 3;
        //id = ;
        x = 2;
        y = 2.5f;
        type = Types.range;
        weakness = Types.cavalry;
        GameObject selectionCircle = new GameObject("SelectionCircle");
        selectionCircle.transform.parent = this.transform;
        selectionCircle.transform.position = this.transform.position;
        spriteRenderer = selectionCircle.AddComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("Circle");
        spriteRenderer.sprite = sprite;
        selectionCircle.GetComponent<SpriteRenderer>().enabled = false;
        selectionCircle.GetComponent<SpriteRenderer>().sortingOrder = 5;
        print(cost);
        //gameObject.AddComponent<Movement>();
        //transform.position = new Vector3(x, y, 0);
        //GameObject movePoint = new GameObject("UnitMovePoint");
        //movePoint.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Transform selectionCircle = transform.GetChild(0);
        if (active)
        {
            selectionCircle.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<Movement>().enabled = true;
        }
        else
        {
            selectionCircle.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Movement>().enabled = false;
        }
        if (playerTag)
        {
            selectionCircle.GetComponent<SpriteRenderer>().color = Color.blue;
            //this.GetComponent<SpriteRenderer>().flipY = true;
            //this.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            selectionCircle.GetComponent<SpriteRenderer>().color = Color.red;
            this.GetComponent<SpriteRenderer>().flipX = true;
            //this.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    public override float Defend()
    {
        float def = 1;

        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterHill))
        {
            def += 0.2f;
        }
        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterForest))
        {
            def += 0.2f;
        }
        return def * this.Defense;
    }
    public override void Attack(Units target)
    {
        float atkBonus = 1;

       
        //atk, hp, defense, range
        

        if (target.Weakness == this.type)
            atkBonus += 0.2f;

        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterHill))
        {
            atkBonus += 0.2f;
        }

        float damage = (atkBonus * atk) - target.Defend();

        if (damage > 0)
            target.HP = target.HP - (int)Mathf.Round(damage);
        
        //checks if the object is still alive 
        if (target.GetComponent<Units>().HP <= 0)
        {
            Destroy(target.gameObject);
        }
        //ausgabe am bildschirm noch implementieren

        //range gehört noch berechnet je nach reichweite funktioniert der angriff oder nicht....
        move = 0;
        Debug.Log("Combat was triggered" + (int)Mathf.Round(damage));
    }
    public override void Moving() { }
    //falls wait() für alle gleich ist hier implementieren
    public override void Wait() { }
}
