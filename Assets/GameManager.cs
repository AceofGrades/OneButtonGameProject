using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject plaformPrefab;

    public int platformCount = 300;

    private void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(2f, 5f);
            spawnPosition.x = Random.Range(-3f, 3f);
            Instantiate(plaformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
