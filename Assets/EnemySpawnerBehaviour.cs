using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    public float SpawnRate;
    public GameObject EnemyPrefab;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > SpawnRate)
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            _timer = 0f;
        }
    }
}
