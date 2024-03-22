using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeynDoor : MonoBehaviour
{
    public GameObject Door;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(Door);
        Destroy(gameObject);
    }
}
