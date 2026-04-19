using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    [SerializeField] private MeteorPooling meteorPool;

    [SerializeField] float cooldown = 2f;

    //[SerializeField] float TimeSinceSpawn = 0;

    [SerializeField] float spawnRange = 7;

    [SerializeField] float cooldownShorteningRate = 0.05f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            SpawnMeteor();

            timer = 0f;
            cooldown = Mathf.Clamp(cooldown - cooldownShorteningRate, 0.25f, 2f);
        }
    }

    private void SpawnMeteor()
    {
        MeteorType type = GetRandomType();

        Vector2 pos = new Vector2(
            transform.position.x + Random.Range(-spawnRange, spawnRange),
            transform.position.y
        );

        meteorPool.Spawn(type, pos);
    }

    private MeteorType GetRandomType()
    {
        int value = Random.Range(0, System.Enum.GetValues(typeof(MeteorType)).Length);
        return (MeteorType)value;
    }
}
