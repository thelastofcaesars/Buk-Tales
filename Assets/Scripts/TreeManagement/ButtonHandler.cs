using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    TextMesh textmp;
    void AddText(string text)
    {
        TextMesh txt = transform.Find("Text").GetComponent<TextMesh>();
        txt.text = text;
    }
}
