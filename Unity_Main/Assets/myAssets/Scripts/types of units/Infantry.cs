using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Infantry : Units
{
    Movement movement;
    private Vector3Int position;

    public Transform movePoint;

    public LayerMask EnterForest = (1 << 10);
    public LayerMask EnterHill = (1 << 7);

    public Infantry()
    {
        active = false;
        cost = 5;
        hp = 30;
        atk = 15;
        def = 10;
        move = 4;
        range = 1;
        //id = ;
        playerTag = 1;
        x = 2;
        y = 2.5f;
        type = 0;
        weakness = Types.range;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("soldier_01"); 
        spriteRenderer.sprite = sprite;
        print(cost);
        
        //gameObject.AddComponent<Movement>();
        //transform.position = new Vector3(x, y, 0);
        // GameObject movePoint = new GameObject("UnitMovePoint");
        // movePoint.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Unit selection triggers
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
        if(playerTag)
        {
            selectionCircle.GetComponent<SpriteRenderer>().color = Color.red;
            this.GetComponent<SpriteRenderer>().flipX = true;
            //sprite = Resources.Load<Sprite>("Circle");
            //this.GetComponent<SpriteRenderer>().sprite = sprite;
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            selectionCircle.GetComponent<SpriteRenderer>().color = Color.blue;
            //this.GetComponent<SpriteRenderer>().flipY = true;
            //this.GetComponent<SpriteRenderer>().color = Color.blue;
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
        return def* this.Defense;
    }
    public override void Attack(Units target)
    {
        //atk, hp, defense, range
        float atkBonus = 1;

        if (target.Weakness == this.type)
            atkBonus = 1.2f;

        float damage = (atkBonus*atk) - target.Defend();

        if (damage > 0)
            target.HP = target.HP - (int)Mathf.Round(damage);

        //ausgabe am bildschirm noch implementieren

        //range geh�rt noch berechnet je nach reichweite funktioniert der angriff oder nicht....
        move = 0;
    }
    public override void Moving() { }
    //falls wait() f�r alle gleich ist hier implementieren
    public override void Wait() { }
}
