using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;

    //Input fields to be set individually in Unity for each object
    public TextMeshProUGUI headerfield;
    public TextMeshProUGUI contentfield;

    //When waking up destroy different existing instance or create set new one
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update; set cursor to visible and set tooltip inactive
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame; Lets the tooltip follow the mouse
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    //Gets header and content filled with data, sets toolbox to active and fills it with the passed data
    public void SetAndShowToolTip(string header, string content)
    {
        gameObject.SetActive(true);
        headerfield.text = header;
        contentfield.text = content;
    }

    //set toolbox inactive and set text of it to empty strings
    public void HideToolTip()
    {
        gameObject.SetActive(false);
        headerfield.text = string.Empty;
        contentfield.text = string.Empty;
    }
}
