using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Dash")]

public class DashPowerup : PowerupScript
{
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovement>().dashpowerup = true;
    }
}
