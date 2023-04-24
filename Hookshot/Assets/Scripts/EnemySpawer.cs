using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawer : MonoBehaviour
{
    public int spawnNumber;
    public float spawnRate = 1.5f;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while(0 < spawnNumber--)
        {
            Instantiate(enemy, transform);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
