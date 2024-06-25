using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    private int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpwanEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpwanPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        { 
            waveNumber++;
            SpwanEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpwanPosition(), powerupPrefab.transform.rotation);
        }
    }

    void SpwanEnemyWave(int enemieToSpwan)
    {
        for (int i = 0; i < enemieToSpwan; i++)
        {
            Instantiate(enemyPrefab, GenerateSpwanPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpwanPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
