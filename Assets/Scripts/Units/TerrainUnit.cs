using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainUnit : Unit
{
    public override void Move() 
    {
        // Walk or jump or whatever
        Walk();
    }
    public virtual void Walk()
    {
        Debug.Log("Walk!");
    }
    public virtual void Jump()
    {
        Debug.Log("Jump!");
    }
}
