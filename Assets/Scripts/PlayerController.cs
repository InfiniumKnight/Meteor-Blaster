using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ProjectilePrefab;

    [SerializeField] HudManager hud;

    [SerializeField] float moveSpeed = 10.0f;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip shootSound;

    [SerializeField] GameObject shotEffect;

    [SerializeField] Transform shotSpawn;

    [SerializeField] SpriteRenderer sprite;

    private Rigidbody2D rb;


    void Start()
    {

        shotEffect.SetActive(false);

        if(hud == null)
        {
            hud = Camera.main.gameObject.GetComponent<HudManager>();
        }

        if(rb == null)
        {
            rb = this.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Meteor")
        {
            StartCoroutine(PlayerHit());
        }
    }

    private IEnumerator PlayerHit()
    {
        hud.DecreaseLife();

        sprite.color = Color.red;

        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        Debug.Log("Hitbox Disabled");

        yield return new WaitForSecondsRealtime(1f);

        sprite.color = Color.white;

        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void Shoot()
    {
        audioSource.PlayOneShot(shootSound);
        shotEffect.SetActive(true);
        Instantiate(ProjectilePrefab, shotSpawn.position, Quaternion.identity);
        StartCoroutine(ShootEffect());
    }

    private IEnumerator ShootEffect()
    {
        yield return new WaitForSecondsRealtime(.15f);
        shotEffect.SetActive(false);
    }
}
