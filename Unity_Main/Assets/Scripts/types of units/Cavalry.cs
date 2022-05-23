using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalry : Units
{

    public Cavalry()
    {
        active = false;
        cost = 10;
        hp = 45;
        atk = 20;
        def = 15;
        move = 6;
        range = 1;
        //id = ;
        playerTag = 1;
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
