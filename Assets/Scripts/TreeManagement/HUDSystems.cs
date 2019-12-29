using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDSystems : MonoBehaviour
{
    [SerializeField]
    private GameObject goldTxt;
    [SerializeField]
    private GameObject mineralsTxt;
    [SerializeField]
    private GameObject bloodTxt;
    [SerializeField]
    private GameObject leafsText;
    [SerializeField]
    private GameObject unitsTxt;
    

    public void UpdateGoldText(string txt)
    {
        goldTxt.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void UpdateMineralsText(string txt)
    {
        mineralsTxt.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void UpdateBloodText(string txt)
    {
        bloodTxt.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void UpdateLeafsText(string txt)
    {
        leafsText.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void UpdateUnitsText(string txt)
    {
        unitsTxt.GetComponent<TextMeshProUGUI>().text = txt;
    }
    
}
