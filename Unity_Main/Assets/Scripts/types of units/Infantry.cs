using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : Units
{
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
        sprite = Resources.Load<Sprite>("soldier_1"); 
        spriteRenderer.sprite = sprite;
        print(cost);
        gameObject.AddComponent<Movement>();
        //transform.position = new Vector3(x, y, 0);
        GameObject movePoint = new GameObject("UnitMovePoint");
        movePoint.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void attack(Units target)
    { 
        if( != 0)
        float dmg =   
    }
    public override void moving() { }
    //falls wait() für alle gleich ist hier implementieren
    public override void wait() { }
}
