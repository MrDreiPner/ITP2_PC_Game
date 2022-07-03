using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalry : Units
{
    public Transform movePoint;

    public LayerMask EnterForest = (1 << 10);
    public LayerMask EnterHill = (1 << 7);
    public Cavalry(bool playerTag)
    {
        active = false;
        cost = 10;
        hp = 45;
        atk = 20;
        def = 15;
        move = 6;
        range = 1;
        //id = ;
        this.playerTag = playerTag;
        x = 2;
        y = 2.5f;
        type = Types.cavalry;
        weakness = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("mounted_01");
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
    public override float Defend()
    {
        float def = 1;

        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterHill))
        {
            def += 0.2f;
        }

        return def * this.Defense;
    }
    public override void Attack(Units target)
    {
        //atk, hp, defense, range
        float atkBonus = 1;

        if (target.Weakness == this.type)
            atkBonus = 1.2f;

        float damage = (atkBonus * atk) - target.Defend();

        if (damage > 0)
            target.HP = target.HP - (int)Mathf.Round(damage);

        //ausgabe am bildschirm noch implementieren

        //range gehört noch berechnet je nach reichweite funktioniert der angriff oder nicht....

    }
    public override void Moving() { }
    //falls wait() für alle gleich ist hier implementieren
    public override void Wait() { }
}
