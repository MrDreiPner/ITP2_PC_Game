using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTypes : MonoBehaviour
{
    //protected bool moveCheck;
    protected int moveMod;
    protected Types atkModUnit;
    protected float atkMod;
    protected Types defModUnit;
    protected float defMod;

    public int MoveMod
    {
        get { return moveMod; }
    }
    public float AtkMod
    {
        get { return defMod; }
    }
    public float DefMod
    {
        get { return defMod; }
    }
    public Types AtkModUnit
    {
        get { return atkModUnit; } 
    }
    public Types DefModUnit
    {
        get { return defModUnit; }
    }

    public enum Types
    {
        infantry, range, cavalry, siege
    };
    //protected bool stop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
