using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathpoints : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision) => gameManager.Reset();
}
