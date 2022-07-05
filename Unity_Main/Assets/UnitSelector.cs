using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    bool isDone;
    //private Camera _MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        //_MainCamera = Camera.main;
        //isDone = false;
    }

    GameObject prevUnit = null;
    GameObject targetUnit = null;

    // Update is called once per frame
    void Update()
    {
        UnitSel();
        TargetSel();

    }
    void UnitSel()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 raycastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero, Mathf.Infinity, (1 << 3));
            if (hit.collider != null)
            {
                if (prevUnit != null)
                {
                    //Here we check the attack
                    if (hit.collider.gameObject.GetComponent<Units>().playerTag != prevUnit.GetComponent<Units>().playerTag
                        && prevUnit.GetComponent<Units>().hasAttacked != true)
                    {
                        if (prevUnit.GetComponent<Units>().type == Units.Types.range)
                        {
                            Debug.Log("is archer");
                            if (Mathf.Abs(prevUnit.transform.position.x - hit.collider.gameObject.transform.position.x) <= 2
                                && Mathf.Abs(prevUnit.transform.position.y - hit.collider.gameObject.transform.position.y) <= 2)
                            {
                                prevUnit.GetComponent<Units>().Attack(hit.collider.gameObject.GetComponent<Units>());
                                prevUnit.GetComponent<Units>().hasAttacked = true;
                            }
                            else transform.parent.parent.GetComponent<Game>().eventLog = " Target out of Range ";
                        }
                        else if (Mathf.Abs(prevUnit.transform.position.x - hit.collider.gameObject.transform.position.x) <= 1
                                 && Mathf.Abs(prevUnit.transform.position.y - hit.collider.gameObject.transform.position.y) <= 1)
                        {
                            Debug.Log("is melee");
                            prevUnit.GetComponent<Units>().Attack(hit.collider.gameObject.GetComponent<Units>());
                            prevUnit.GetComponent<Units>().hasAttacked = true;
                        }
                        else
                        {
                            transform.parent.parent.GetComponent<Game>().eventLog = " Target out of Range ";
                        }

                    }
                    else if (hit.collider.gameObject != prevUnit && prevUnit.GetComponent<Units>().type != Units.Types.cavalry)
                    {
                        prevUnit.GetComponent<Units>().active = false;
                    }
                }
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Unit") && hit.collider.gameObject.GetComponent<Units>().playerTag == transform.parent.parent.GetComponent<Game>().turn)
                {
                    hit.collider.gameObject.GetComponent<Units>().active = true;
                    if (prevUnit != null)
                        prevUnit.GetComponent<Units>().active = false;
                    prevUnit = hit.collider.gameObject;
                }
            }
            else if (prevUnit != null)
            {
                prevUnit.GetComponent<Units>().active = false;
                prevUnit = null;
            }
        }
    }

    void TargetSel()
    {

        if (prevUnit != null && prevUnit.GetComponent<Units>().hasAttacked == false)
        {
            Vector2 raycastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero, Mathf.Infinity, (1 << 3));
            if (hit.collider != null && prevUnit.GetComponent<Units>().playerTag != hit.collider.gameObject.GetComponent<Units>().playerTag)
            {
                if (targetUnit != null && targetUnit != hit.collider.gameObject)
                {
                    targetUnit.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
                }
                if (prevUnit.GetComponent<Units>().type == Units.Types.range)
                {
                    if (Mathf.Abs(prevUnit.transform.position.x - hit.collider.gameObject.transform.position.x) <= 2
                        && Mathf.Abs(prevUnit.transform.position.y - hit.collider.gameObject.transform.position.y) <= 2)
                    {
                        hit.collider.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.yellow;
                        hit.collider.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        hit.collider.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.gray;
                        hit.collider.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
                else if (Mathf.Abs(prevUnit.transform.position.x - hit.collider.gameObject.transform.position.x) <= 1
                         && Mathf.Abs(prevUnit.transform.position.y - hit.collider.gameObject.transform.position.y) <= 1)
                {
                    hit.collider.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.yellow;
                    hit.collider.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    hit.collider.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.gray;
                    hit.collider.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                }
                targetUnit = hit.collider.gameObject;
            }
            /*if(targetUnit != null)
            {
                targetUnit.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            }*/
        }
        else
        {
            if (targetUnit != null)
            {
                targetUnit.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}

