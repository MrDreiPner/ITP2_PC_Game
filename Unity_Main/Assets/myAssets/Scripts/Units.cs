using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//evtl doch interface aber vermutlich abstrakte classe
public abstract class Units : MonoBehaviour
{
    public Transform movePoint;
    public Units(){
        this.active = false;
        print("unit created");
    }
    ~Units(){
        print("unit deleted");
    }
    public abstract void Attack(Units target);
    public abstract float Defend();

    public bool hasAttacked;
    public bool active;
    protected int cost;
    protected int hp;
    protected int atk;
    protected int def;
    public int move;
    protected int range;
    public bool playerTag;
    public Types type;
    protected Types weakness;

    public Types Type
    {
        get;
    }
    public Types Weakness
    {
        get;
    }
    public int Defense
    {
        get { return def; }
        set { def = value; }
    }
    public bool Active
    {
        get { return active; }
        set { active = value; }
    }
    public int Move
    {
        get { return move; }
        set { move = value; }
    }
    public int Cost
    {
        get { return cost; }
    }
    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }

    public enum Types
    {
        infantry, range, cavalry, siege
    };
    protected SpriteRenderer spriteRenderer;
    protected Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}