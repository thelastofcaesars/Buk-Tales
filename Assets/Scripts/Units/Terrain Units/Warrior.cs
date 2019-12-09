using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : TerrainUnit
{
    public override void Walk()
    {
        base.Walk();
        transform.SetPositionAndRotation(Vector3.right, Quaternion.identity);
    }
    
}
