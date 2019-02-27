using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    float spawnDelay = 10f;

    private float time;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnDelay)
        {
            time = 0;
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
