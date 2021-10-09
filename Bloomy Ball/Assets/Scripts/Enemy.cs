using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool isGrounded = true;
    [SerializeField] GameObject explosionVFX;
    BoxCollider2D box;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (ShouldDieFromCollision(other))
        {
            Die();
        }
    }

    private bool ShouldDieFromCollision(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player)
        {
            return true;
        }

        if (other.contacts[0].normal.y < -0.5)
        {
            return true;
        }

        box = GetComponent<BoxCollider2D>();
        if (box.IsTouchingLayers(LayerMask.GetMask("Ground")) && !isGrounded)
        {
            return true;
        }

        return false;
    }

    void Die()
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
