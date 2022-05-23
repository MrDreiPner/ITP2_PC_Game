using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siege : Units
{
    private int aoeRange; 

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
        aoeRange = 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("trebuchet_01");
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
