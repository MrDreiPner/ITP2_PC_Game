using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    //private Camera _MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        //_MainCamera = Camera.main;
    }

    GameObject prevUnit = null;

    // Update is called once per frame
    void Update()
    {
        MouseInput();
    }

    void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 raycastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero, Mathf.Infinity, (1 << 3));
            if (hit.collider != null)
            {
                if (hit.collider.gameObject != prevUnit && prevUnit != null)
                {
                    prevUnit.GetComponent<Units>().active = false;
                }
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Unit") && hit.collider.gameObject.GetComponent<Units>().playerTag == transform.parent.parent.GetComponent<Game>().turn)
                {
                    hit.collider.gameObject.GetComponent<Units>().active = true;
                    prevUnit = hit.collider.gameObject;
                }
            }
            else if(prevUnit != null)
            {
                prevUnit.GetComponent<Units>().active = false;
            }
        }

    }
}
