using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpwanManger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    private int enemyCount;
    private int waveNumber = 1;
    private PlayerController playerControllerScript;

    public int WaveNumber
    {
        get { return waveNumber; }
        set { waveNumber = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        SpwanEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpwanPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isGameActive)
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if (enemyCount == 0)
            {
                waveNumber++;
                SpwanEnemyWave(waveNumber);
                Instantiate(powerupPrefab, GenerateSpwanPosition(), powerupPrefab.transform.rotation);
            }
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
