using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endtrigger : MonoBehaviour
{
   public GameManager GameManager;

    private void OnTriggerEnter2D(Collider2D collision) => GameManager.End();
}
