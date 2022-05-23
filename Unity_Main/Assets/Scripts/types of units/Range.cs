using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Units
{

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
        gameObject.AddComponent<Movement>();
        //transform.position = new Vector3(x, y, 0);
        GameObject movePoint = new GameObject("UnitMovePoint");
        movePoint.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void attack(Units target) { }
    public override void moving() { }
    //falls wait() für alle gleich ist hier implementieren
    public override void wait() { }
}
