using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{

    private static TreeManager _S;
    public static TreeManager S
    {
        get
        {
            if (_S == null)
            {
                Debug.LogWarning("TreeManager:get - Attempt to get value before it has been set!");
                return null;
            }
            else
            {
                return _S;
            }
        }
        set
        {
            if(_S != null)
            {
                Debug.LogWarning("TreeManager:set - Attempt to set value twice!");
            }
            else
            {
                _S = value;
            }
        }
    }
    struct unitsAlive
    {
        public uint min;
        public uint max;
        public uint actual;

        public unitsAlive(uint min, uint max, uint actual)
        {
            this.min = min;
            this.max = max;
            this.actual = actual;
        }
        public bool IsInMinMaxRange()
        {
            return min < actual && actual < max ? true : false; 
        }
        public bool IsEqualMin()
        {
            return min == actual ? true : false;
        }
    }

    [SerializeField]
    private GameObject testRecruit;
    [SerializeField]
    private int gold = 0;
    [SerializeField]
    private int minerals = 0;
    [SerializeField]
    private int blood = 0;
    [SerializeField]
    private int leafs = 0;
    [SerializeField]
    private unitsAlive units = new unitsAlive(1,10,1);
    [SerializeField]
    private int maxUnitsAlive = 10;

    [SerializeField]
    public static GameObject flagGO;
    public static List<GameObject> UNITS;

    public void TestAddGold()
    {
        gold += 100;
    }
    public void TestAddMinerals()
    {
        minerals += 10;
    }
    public void TestAddBlood()
    {
        blood += 1;
    }
    public void TestAddLeafs()
    {
        leafs += 10;
    }

    public void RecruitWarrior()
    {
        int neededSources = testRecruit.GetComponent<Warrior>().costGold;
        if (neededSources > gold)
            return;
        if (!units.IsInMinMaxRange()) // check ( w kolejce mogo byc)
            return;
        if (units.IsEqualMin())
        {
            GameObject flagGO = new GameObject();
            //flagGO.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        gold -= neededSources;
        units.actual++;
        GameObject ngo = Instantiate(testRecruit, flagGO.transform);
        UNITS.Add(ngo);
    }

    public static void RemoveUnit(GameObject go)
    {
        UNITS.Remove(go);
        S.units.actual--;
        if(S.units.IsEqualMin())
        {
            Destroy(flagGO);
        }
    }
}
