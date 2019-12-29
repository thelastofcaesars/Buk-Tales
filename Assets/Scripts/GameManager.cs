using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _S;
    public static GameManager S
    {
        get
        {
            if (_S == null)
            {
                Debug.LogWarning("GameManager:get - Attempt to get value before it has been set!");
                return null;
            }
            else
            {
                return _S;
            }
        }
        set
        {
            if (_S != null)
            {
                Debug.LogWarning("GameManager:set - Attempt to set value twice!");
            }
            else
            {
                _S = value;
            }
        }
    }

    private TreeManager treeMan;
}
