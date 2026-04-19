using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    private GameManager gameManager;

    public int Health = 1;

    public int Speed = 1;

    public int ScoreAmount = 1;

    private Rigidbody2D rb;

    HudManager hud;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hud = gameManager.GetHud();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.down * Speed;
    }

    public void Hit()
    {
        Health--;

        if(Health <= 0)
        {
            hud.IncreaseScore(ScoreAmount);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        gameManager.RegisterMeteor(this);
    }

    private void OnDisable()
    {
        gameManager.UnregisterMeteor(this);
    }
}
