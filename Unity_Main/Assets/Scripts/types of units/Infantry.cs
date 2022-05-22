using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : Units
{
    public Infantry()
    {
        active = false;
        cost = 5;
        atk = 15;
        def = 10;
        move = 4;
        range = 1;
        //id = ;
        playerTag = 1;
        x = 0;
        y = 0;
        type = 0;
        weakness = 1;

    }
    // Start is called before the first frame update
    void Start()
    {
        sprite = Resources.Load<Sprite>("Assets/myAssets/soldier_1.png"); 
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        print(cost);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void attack() { }
    public override void moving() { }
    //falls wait() für alle gleich ist hier implementieren
    public override void wait() { }
}
