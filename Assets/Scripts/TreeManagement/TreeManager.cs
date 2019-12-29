using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        public bool IsInRange()
        {
            return min <= actual && actual < max ? true : false; 
        }
        public bool IsEqualMin()
        {
            return min == actual ? true : false;
        }
    }

    [SerializeField]
    public GameObject testRecruit;
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
    public GameObject flagGO;
    public List<GameObject> UNITS;

    [SerializeField]
    private HUDSystems huds;

    private GameObject prefabsParent;

    private void Start()
    {
        huds = GameObject.Find("Sources").GetComponent<HUDSystems>();
        UNITS.Add(GameObject.Find("WoodenStrongold"));
        if (flagGO == null)
        {
            flagGO = new GameObject();
            flagGO.name = "RecruitPoint";
            flagGO.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
    }

    public void TestAddGold()
    {
        gold += 100;
        huds.UpdateGoldText(gold.ToString());
    }
    public void TestAddMinerals()
    {
        minerals += 10;
        huds.UpdateMineralsText(minerals.ToString());
    }
    public void TestAddBlood()
    {
        blood += 1;
        huds.UpdateBloodText(blood.ToString());
    }
    public void TestAddLeafs()
    {
        leafs += 10;
        huds.UpdateLeafsText(leafs.ToString());
    }

    public void InstantiatePrefabsParent()
    { 
        prefabsParent = new GameObject();
        prefabsParent.name = "prefabsParent";
        prefabsParent.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }
    public void DestroyPrefabsParent()
    {
        Destroy(prefabsParent);
    }

public void CheckArmy()
    {
        units.actual = (uint)UNITS.Count;
        string s = units.actual.ToString() + '/' + units.max.ToString();
        huds.UpdateUnitsText(s);
    }
    public void RecruitWarrior()
    {
        int neededSources = testRecruit.GetComponent<Warrior>().costGold;
        // checksources();
        if (neededSources > gold)
            return;
        if (!units.IsInRange()) // check ( w kolejce mogo byc)
            return;
        if (units.IsEqualMin())
        {
            InstantiatePrefabsParent();
        }
        // removesources();
        gold -= neededSources;
        huds.UpdateGoldText(gold.ToString());
        GameObject ngo = Instantiate(testRecruit, flagGO.transform.position, flagGO.transform.rotation, prefabsParent.transform);
        
        UNITS.Add(ngo);
        CheckArmy();
    }

    public void RecruitBowman()
    {
        // bowman!
        
        int neededSources = testRecruit.GetComponent<Warrior>().costGold;
        if (neededSources > gold)
            return;
        if (!units.IsInRange()) // check ( w kolejce mogo byc)
            return;
        if (units.IsEqualMin())
        {
            InstantiatePrefabsParent();
        }
        Debug.Log("bowman recruted!");
        gold -= neededSources;
        huds.UpdateGoldText(gold.ToString());
        GameObject ngo = Instantiate(testRecruit);
        UNITS.Add(ngo);
        CheckArmy();
    }

    public static void RemoveUnit(GameObject go)
    {
        S.UNITS.Remove(go);
        S.CheckArmy();
        if (S.units.IsEqualMin())
        {
            S.DestroyPrefabsParent();
        }
    }
    
    public void UpgradeTree()
    {
        Debug.Log("TreeUpgraded");
    }
}
