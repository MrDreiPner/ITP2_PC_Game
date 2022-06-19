using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Units
{
    public Transform movePoint;

    public LayerMask whatStopsMovement = (1 << 6);
    public LayerMask EnterVill = (1 << 8);
    public LayerMask EnterCast = (1 << 9);
    public LayerMask EnterForest = (1 << 10);
    public LayerMask EnterHill = (1 << 7);

    public Range()
    {
        active = false;
        cost = 7;
        hp = 20;
        atk = 20;
        def = 10;
        move = 4;
        range = 3;
        //id = ;
        playerTag = 1;
        x = 2;
        y = 2.5f;
        type = Types.range;
        weakness = Types.cavalry;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("archer_01");
        spriteRenderer.sprite = sprite;
        print(cost);
        //gameObject.AddComponent<Movement>();
        //transform.position = new Vector3(x, y, 0);
        //GameObject movePoint = new GameObject("UnitMovePoint");
        //movePoint.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override float defend()
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
    public override void attack(Units target)
    {
        float atkBonus = 1;

       
        //atk, hp, defense, range
        

        if (target.Weakness == this.type)
            atkBonus += 0.2f;

        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterHill))
        {
            atkBonus += 0.2f;
        }

        float damage = (atkBonus * atk) - target.defend();

        if (damage > 0)
            target.HP = target.HP - (int)Mathf.Round(damage);

        //ausgabe am bildschirm noch implementieren

        //range gehört noch berechnet je nach reichweite funktioniert der angriff oder nicht....
        move = 0;
    }
    public override void moving() { }
    //falls wait() für alle gleich ist hier implementieren
    public override void wait() { }
}
