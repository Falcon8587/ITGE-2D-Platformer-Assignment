using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Double Jump")]

public class DoubleJumpPowerup : PowerupScript
{
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovement>().DoubleJumpPowerup = true;
    }
}
