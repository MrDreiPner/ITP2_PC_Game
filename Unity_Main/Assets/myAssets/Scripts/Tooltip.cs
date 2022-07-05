using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour
{
    //Input fields to be set individually in Unity for each object
    public string header;
    //textarea, so that the content of tooltips can be easily multilined
    [TextArea]
    public string content;
    //time to wait for displaying the tooltip; wait 500ms while hovering with mouse over object until tooltip is displayed
    private float timetowait = 0.5f;


    //when mouse hovers over object, stop all coroutines(timers) and start the coroutine Starttimer
    private void OnMouseEnter()
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    //when mouse leaves an object, stop all coroutines and call hidetooltip method
    private void OnMouseExit()
    {
        StopAllCoroutines();
        TooltipManager._instance.HideToolTip();
    }

    //StartTimer method which waits 500ms and then calls SetAndShowToolTip Method with header and content parameters
    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timetowait);

        TooltipManager._instance.SetAndShowToolTip(header, content);
    }
}
