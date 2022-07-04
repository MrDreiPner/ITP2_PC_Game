using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour
{
    public string message;

    private void OnMouseEnter()
    {
        TooltipManager._instance.SetAndShowToolTip(message);
    }

    private void OnMouseExit()
    {
        TooltipManager._instance.HideToolTip();
    }
}
