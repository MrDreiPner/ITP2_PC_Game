using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalry : Units
{

    public LayerMask EnterForest = (1 << 10);
    public LayerMask EnterHill = (1 << 7);
    public Cavalry(bool playerTag)
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        hasAttacked = false;
        cost = 10;
        hp = 45;
        atk = 20;
        def = 15;
        move = 6;
        range = 1;
        type = Types.cavalry;
        weakness = 0;
        GameObject selectionCircle = new GameObject("SelectionCircle");
        selectionCircle.transform.parent = this.transform;
        selectionCircle.transform.position = this.transform.position;
        spriteRenderer = selectionCircle.AddComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("Circle");
        spriteRenderer.sprite = sprite;
        selectionCircle.GetComponent<SpriteRenderer>().enabled = false;
        selectionCircle.GetComponent<SpriteRenderer>().sortingOrder = 5;
        GameObject targetHex = new GameObject("TargetHex");
        targetHex.transform.parent = this.transform;
        targetHex.transform.position = this.transform.position;
        spriteRenderer = targetHex.AddComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("HexaTarg");
        spriteRenderer.sprite = sprite;
        targetHex.GetComponent<SpriteRenderer>().enabled = false;
        targetHex.GetComponent<SpriteRenderer>().sortingOrder = 5;
        print(cost);
    }

    // Update is called once per frame
    void Update()
    {
        Transform selectionCircle = transform.GetChild(0);
        if (active)
        {
            selectionCircle.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<Movement>().enabled = true;
        }
        else
        {
            selectionCircle.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Movement>().enabled = false;
        }
        if (playerTag)
        {
            selectionCircle.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            selectionCircle.GetComponent<SpriteRenderer>().color = Color.red;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public override float Defend()
    {
        float def = 1;

        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterHill))
        {
            def += 0.2f;
        }

        return def * this.Defense;
    }
    public override void Attack(Units target)
    {
        //atk, hp, defense, range
        float atkBonus = 1;

        if (target.Weakness == this.type)
            atkBonus = 1.2f;

        float damage = (atkBonus * atk) - target.Defend();

        if (damage > 0)
            target.HP = target.HP - (int)Mathf.Round(damage);
        
        //checks if the object is still alive 
        if (target.GetComponent<Units>().HP <= 0)
        {
            Destroy(target.gameObject);
        }
        if(playerTag)
            transform.parent.parent.GetComponent<Game>().eventLog = "Player1 Cavalry dealt " + (int)Mathf.Round(damage) + " damage to opponent. ";
        else
            transform.parent.parent.GetComponent<Game>().eventLog = "Player2 Cavalry dealt " + (int)Mathf.Round(damage) + " damage to opponent. ";
    }

    //For Displaying Ingame Stats on Hovering with Mouse
    private void OnMouseEnter()
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    private void OnMouseExit()
    {
        StopAllCoroutines();
        TooltipManager._instance.HideToolTip();
    }

    private IEnumerator StartTimer()
    {
        float timetowait = 0.5f;
        string header = "Cavalry";
        string content = "HP: " + hp.ToString() + "\nAttack: " + atk.ToString() + "\nDefense: " + def.ToString() + "\nMove: " + move.ToString() + "\nRange: " + range.ToString() + "\nCost: " + cost.ToString();

        yield return new WaitForSeconds(timetowait);

        TooltipManager._instance.SetAndShowToolTip(header, content);
    }
}
