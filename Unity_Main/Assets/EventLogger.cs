using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventLogger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gets String from Game.eventLog and displays it on bottom of the screen
        transform.GetChild(0).GetComponent<Text>().text = transform.parent.parent.GetComponent<Game>().eventLog;
    }
}
