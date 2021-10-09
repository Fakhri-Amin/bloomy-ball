using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float launchForce = 1200f;
    [SerializeField] float delayTime = 3f;
    [SerializeField] float maxDragDistance = 3f;
    Vector2 startPosition;
    Color startColor;
    Rigidbody2D rb;
    SpriteRenderer sp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        rb.isKinematic = true;
        startPosition = rb.position;
        startColor = sp.color;
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        sp.color = Color.black;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, startPosition);
        if (distance > maxDragDistance)
        {
            Vector2 direction = desiredPosition - startPosition;
            direction.Normalize();
            desiredPosition = startPosition + (direction * maxDragDistance);
        }

        if (desiredPosition.x > startPosition.x)
        {
            desiredPosition.x = startPosition.x;
        }

        rb.position = desiredPosition;
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = rb.position;
        Vector2 direction = startPosition - currentPosition;
        direction.Normalize();

        rb.isKinematic = false;
        rb.AddForce(direction * launchForce);

        sp.color = startColor;
    }

    public void ResetPosition()
    {
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        rb.position = startPosition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }
}
