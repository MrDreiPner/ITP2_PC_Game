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
        print("unit delated");
    }

    public abstract void attack();
    public abstract void moving();
    //falls wait() für alle gleich ist hier implementieren
    public abstract void wait();

    protected bool active;
    protected int cost;
    protected int atk;
    protected int def;
    protected int move;
    protected int range;
    protected int id;
    protected int playerTag;
    protected int x;
    protected int y;
    protected int type;
    protected int weakness;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}