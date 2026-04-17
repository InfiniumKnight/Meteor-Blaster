using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    public int Health = 1;

    public int Speed = 1;

    public int ScoreAmount = 1;

    private Rigidbody2D rb;

    HudManager hud;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hud = GameObject.FindGameObjectWithTag("Hud").GetComponent<HudManager>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, -1) * Speed;
    }

    public void Hit()
    {
        Health--;

        if(Health <= 0)
        {
            hud.IncreaseScore(ScoreAmount);
            Destroy(gameObject);
        }
    }
}
