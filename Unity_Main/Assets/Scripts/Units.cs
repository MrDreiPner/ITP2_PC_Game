using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//evtl doch interface aber vermutlich abstrakte classe
public abstract class Units : MonoBehaviour
{
    public Units(){
        this.active = false;
        print("unit created");
    }
    ~Units(){
        print("unit deleted");
    }
    public abstract void attack(Units target);
    public abstract void moving();
    //falls wait() für alle gleich ist hier implementieren
    public abstract void wait();

    protected bool active;
    protected int cost;
    protected float hp;
    protected int atk;
    protected int def;
    protected int move;
    protected int range;
    //protected int id;
    protected int playerTag;
    protected float x;
    protected float y;
    protected Types type;
    protected Types weakness;

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
    public float HP
    {
        get { return hp; }
        set { hp -= value; }
    }

    protected enum Types
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