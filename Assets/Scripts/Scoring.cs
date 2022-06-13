using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField]
    int score = 0;

    [SerializeField]
    Vector3 lastPosition;

    // Use this for initialization
    void Start()
    {
        lastPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((this.transform.position.y - lastPosition.y) > 0)
            score++;

        lastPosition = this.transform.position;
    }

    void OnGUI()
    {
        GUILayout.Label("Score : " + score);
    }
}
