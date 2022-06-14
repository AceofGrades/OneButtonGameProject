using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject plaformPrefab1;
    public GameObject plaformPrefab2;

    public int platform1Count = 150;
    public int platform2Count = 150;

    private void Start()
    {
        Vector3 spawnPosition1 = new Vector3();
        //Vector3 spawnPosition2 = new Vector3();

        for (int i = 0; i < platform1Count; i++)
        {
            spawnPosition1.y += Random.Range(2f, 5f);
            spawnPosition1.x = Random.Range(-3f, 3f);
            Instantiate(plaformPrefab1, spawnPosition1, Quaternion.identity);
        }

        //for (int i = 0; i < platform2Count; i++)
        //{
        //    spawnPosition2.y += Random.Range(5f, 8f);
        //    spawnPosition2.x = Random.Range(-3f, 3f);
        //    Instantiate(plaformPrefab2, spawnPosition2, Quaternion.identity);
        //}
    }
}
