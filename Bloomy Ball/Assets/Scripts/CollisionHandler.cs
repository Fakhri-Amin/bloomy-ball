using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<PlayerController>().ResetPosition();
    }
}
