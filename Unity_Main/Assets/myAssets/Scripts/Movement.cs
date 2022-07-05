using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Transform movePoint;
    //public Infantry unitValues;

    public LayerMask whatStopsMovement = (1 << 6);
    public LayerMask EnterVill = (1 << 8);
    public LayerMask EnterCast = (1 << 9);
    public LayerMask EnterForest = (1 << 10);
    public LayerMask EnterHill = (1 << 7);
    public LayerMask MeetUnit = (1 << 3);
    

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject unitMovePoint = new GameObject("MovePoint");
        //movePoint = null;
        unitMovePoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        movePoint = unitMovePoint.transform;
        this.transform.GetComponent<Units>().movePoint = unitMovePoint.transform;
        unitMovePoint.transform.parent = this.transform.parent;
        //movePoint = unitMovePoint.transform.position;
}

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        if(this.GetComponent<Units>().move > 0)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= .0f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if ((!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                        && (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, MeetUnit)))
                    {
                        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterVill) ||
                            Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterCast))
                        {
                            Debug.Log("Huzza!");
                        }
                        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterHill))
                        {
                            Debug.Log("On top of the world!");
                        }
                        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterForest))
                        {
                            Debug.Log("I am Groot!");
                        }
                        this.GetComponent<Units>().move--; 
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        Debug.Log("Movin out!");
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if ((!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                        && (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, MeetUnit)))
                    {
                        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, EnterVill) ||
                            Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, EnterCast))
                        {
                            Debug.Log("Huzza!");
                        }
                        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterHill))
                        {
                            Debug.Log("On top of the world!");
                        }
                        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, EnterForest))
                        {
                            Debug.Log("I am Groot!");
                        }
                        this.GetComponent<Units>().move--;
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        Debug.Log("Movin out!");
                    }
                }
            }
        }
    }
}
