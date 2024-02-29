using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupApply : MonoBehaviour
{
    public PowerupScript powerupScript;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        powerupScript.Apply(collision.gameObject);

        player.transform.position = new Vector3(0, 0, 0);
    }
}

