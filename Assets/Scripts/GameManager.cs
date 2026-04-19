using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] HudManager hud;

    [SerializeField] GameObject gameOverScreen;

    [SerializeField] GameObject player;

    Vector2 startPosition;

    private readonly List<MeteorBehavior> activeMeteors = new();

    public HudManager GetHud() => hud;

    private void Awake()
    {
        Instance = this;
    }

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
        ResetMeteors();

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

    public void RegisterMeteor(MeteorBehavior meteor)
    {
        if (!activeMeteors.Contains(meteor))
        {
            activeMeteors.Add(meteor);
        }
    }

    public void UnregisterMeteor(MeteorBehavior meteor)
    {
        if (activeMeteors.Contains(meteor))
        {
            activeMeteors.Remove(meteor);
        }
    }

    private void ResetMeteors()
    {
        foreach (var meteor in activeMeteors)
        {
            meteor.gameObject.SetActive(false);
        }

        activeMeteors.Clear();
    }
}
