using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int speed;

    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void LateUpdate()
    {
        rb.velocity = new Vector2(0, 1) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Meteor")
        {
            collision.gameObject.GetComponent<MeteorBehavior>().Hit();
            Destroy(gameObject);
        }
    }
}
