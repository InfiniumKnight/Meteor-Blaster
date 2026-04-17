using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> MeteorPrefabs;

    [SerializeField] float Cooldown = 2f;

    [SerializeField] float TimeSinceSpawn = 0;

    [SerializeField] float SpawnRange = 7;

    [SerializeField] float CooldownShorteningRate = 0.05f;

    void Update()
    {
        if(TimeSinceSpawn >= Cooldown)
        {
            Instantiate(MeteorPrefabs[Random.Range(0, MeteorPrefabs.Count - 1)], new Vector2(gameObject.transform.position.x+Random.Range(-SpawnRange,SpawnRange), gameObject.transform.position.y), Quaternion.identity);
            TimeSinceSpawn = 0;
            Cooldown = Mathf.Clamp(Cooldown - CooldownShorteningRate, 0.25f, 2);
        }
        else
        {
            TimeSinceSpawn += Time.deltaTime;
        }
    }
}
