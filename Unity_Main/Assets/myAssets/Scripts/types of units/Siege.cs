using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siege : Units
{
    //private int aoeRange; 

    public Siege()
    {
        active = false;
        cost = 20;
        hp = 60;
        atk = 30;
        def = 15;
        move = 4;
        range = 3;
        //id = ;
        playerTag = 1;
        x = 2;
        y = 2.5f;
        type = Types.siege;
        weakness = Types.infantry;
        //aoeRange = 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("trebuchet_01");
        spriteRenderer.sprite = sprite;
        print(cost);
        //gameObject.AddComponent<Movement>();
        //transform.position = new Vector3(x, y, 0);
        //GameObject movePoint = new GameObject("UnitMovePoint");
       // movePoint.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //attack gehört noch verändert
    public override float Defend()
    {
        return 1f;
    }
    public override void Attack(Units target)
    {
        //atk, hp, defense, range
        float atkBonus = 1;

        if (target.Weakness == this.type)
            atkBonus = 1.2f;

        float damage = (atkBonus * atk) - target.Defense;

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
