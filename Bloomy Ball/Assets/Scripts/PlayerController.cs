using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float launchForce = 1200f;
    Vector2 startPosition;
    Color startColor;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        startColor = GetComponent<SpriteRenderer>().color;
        startPosition = GetComponent<Rigidbody2D>().position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.grey;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = rb.position;
        Vector2 direction = startPosition - currentPosition;
        direction.Normalize();

        rb.isKinematic = false;
        rb.AddForce(direction * launchForce);

        GetComponent<SpriteRenderer>().color = startColor;
    }
}
