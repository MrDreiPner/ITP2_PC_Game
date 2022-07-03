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

    public Infantry(int playerTag)
    {
        active = false;
        cost = 5;
        hp = 30;
        atk = 15;
        def = 10;
        move = 4;
        range = 1;
        //id = ;
        this.playerTag = playerTag;
        x = 2;
        y = 2.5f;
        type = 0;
        weakness = Types.range;

    }
    // Start is called before the first frame update
    void Start()
    {
        //Unit Selection setup
        GameObject selectionCircle = new GameObject("SelectionCircle");
        selectionCircle.transform.parent = this.transform;
        selectionCircle.transform.position = this.transform.position;
        spriteRenderer = selectionCircle.AddComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("Circle");
        spriteRenderer.sprite = sprite;
        selectionCircle.GetComponent<SpriteRenderer>().enabled = false;
        //Unit Selection setup DONE
        print(cost);
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
        if(playerTag == 1)
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

        //range gehört noch berechnet je nach reichweite funktioniert der angriff oder nicht....
        move = 0;
    }
    public override void Moving() { }
    //falls wait() für alle gleich ist hier implementieren
    public override void Wait() { }
}
