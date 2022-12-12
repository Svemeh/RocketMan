using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstacleCount;
    bakgrunngoesbrrr backgroundScript;

    [Header("points")]
    [SerializeField] GameObject plane; // bakgrunn object
    [SerializeField] int points = 0;
    [SerializeField] int highScore = 0;
    [SerializeField] int tid;
    private float elapsed = 0f;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < obstacleCount; i++)
        {
            spawnPosition.y += Random.Range(1f, 3f);
            spawnPosition.x = Random.Range(-1f, 1f);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        }
    }

    void Awake()
    {
        backgroundScript = plane.GetComponent<bakgrunngoesbrrr>(); // henter script for bakgrunnscoll
    }

    void Update()
    {
        elapsed += Time.deltaTime; // venter til 1. sekund har gått
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            tid = (int)Mathf.Round(Time.time); // variable " tid " 
        }

        points = (int)Mathf.Round(tid * backgroundScript.brrrSpeed); // variable " points "

        if (points >= highScore)
        {
            highScore = points;
        }

    }
}
