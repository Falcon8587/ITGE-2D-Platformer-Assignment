using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupScript : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
