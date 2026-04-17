using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI ScoreCounter;

    [SerializeField] List<GameObject> LifeCounters;

    [SerializeField] GameManager gameManager;

     public int lifeIndex = 1;

    int score = 0;

    public void IncreaseScore(int Amount)
    {
        score+= Amount;
        ScoreCounter.text = score.ToString();
    }

    public void DecreaseLife()
    {
        if(lifeIndex > -1)
        {
            LifeCounters[lifeIndex].SetActive(false);
            lifeIndex--;
        }
        else
        {
            gameManager.GameOver();
        }
    }

    public void Reset()
    {
        lifeIndex = 1;
        for (int i = 0; i < LifeCounters.Count; i++)
        {
            LifeCounters[i].SetActive(true);
        }

        score = 0;
    }
}
