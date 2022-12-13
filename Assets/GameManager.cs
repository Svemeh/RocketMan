using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstacleCount;
    bakgrunngoesbrrr backgroundScript;
    public Vector3 spawnPosition = new Vector3();

    public GameObject spawner; // test
    public Rigidbody2D gameManager2D;
    [SerializeField] GameObject plane; // bakgrunn object

    [Header("points")]
    
    [SerializeField] int points = 0;
    [SerializeField] int highScore = 0;
    [SerializeField] int tid;
    private float elapsed = 0f;

    private void Start()
    {
        SpawnObstacles();
    }

    private void Awake()
    {
        backgroundScript = plane.GetComponent<bakgrunngoesbrrr>(); // henter script for bakgrunnscoll
        gameManager2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
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
    public void SpawnObstacles() // spawner obstacles
    {
        for (int i = 0; i <= obstacleCount; i++)
        {

            spawnPosition.y += Random.Range(1.5f, 2.5f); // 4f, 6f // y = y + Random.Range()
            spawnPosition.x = Random.Range(-1f, 1f);
            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            Destroy(newObstacle, 10); // sletter etter 10 sek

            if (i == obstacleCount) // etter for(i) fullført
            {
                gameManager2D.position = new Vector3(0, spawnPosition.y-3, 0);
                spawnPosition = new Vector3(0f, 2.5f, 0f); // reset spawnPosition
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision) // når karakter kolliderer med GameManager
    {
        if (collision.gameObject.name == "karakter")
        {
            Debug.Log("karakter triggered");
            SpawnObstacles();
        }
    }
    private void FixedUpdate()
    {
        Vector2 velocity = gameManager2D.velocity;
        velocity = new Vector3(0, -(backgroundScript.brrrSpeed * 2), 0); // fart defienert som scrollspeed * 2
        gameManager2D.velocity = velocity;
    }
}
