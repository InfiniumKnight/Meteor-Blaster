using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] HudManager hud;

    [SerializeField] GameObject gameOverScreen;

    [SerializeField] GameObject player;

    Vector2 startPosition;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        startPosition = player.transform.position;
    }

    public void GameOver()
    {
        hud.gameObject.SetActive(false);
        player.SetActive(false);

        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Meteor"))
        {
            Destroy(g);
        }
        gameOverScreen.SetActive(false);
        hud.gameObject.SetActive(true);
        hud.Reset();
        player.transform.position = startPosition;
        player.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        player.SetActive(true);
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
