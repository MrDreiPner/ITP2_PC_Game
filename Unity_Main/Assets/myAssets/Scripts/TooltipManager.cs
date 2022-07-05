using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;

    public TextMeshProUGUI headerfield;
    public TextMeshProUGUI contentfield;

    public int characterWrapLimit;

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

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetAndShowToolTip(string header, string content)
    {
        gameObject.SetActive(true);
        headerfield.text = header;
        contentfield.text = content;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
        headerfield.text = string.Empty;
        contentfield.text = string.Empty;
    }
}
