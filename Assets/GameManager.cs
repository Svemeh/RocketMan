using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource rocketman;
    [SerializeField] private AudioSource deathSound;

    [Range(0f, 5f)]
    public float brrrSpeed = 1f;
    public float maxSpeed;
    public Rigidbody2D gameManager2D;
    public GameObject character;
    public bool gameRunning;
     
    [Header("obstacles")]

    public GameObject obstaclePrefab;
    public int obstacleCount;
    [SerializeField] Vector3 spawnPosition = new Vector3();

    [Header("points")]

    public TextMeshProUGUI ScoreDisplay;
    public TextMeshProUGUI HighScoreDisplay;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI ExtraText;
    [SerializeField] private int points = 0;
    [SerializeField] private int highScore = 0;
    [SerializeField] private int tid;

    private void Awake() 
    { 
    gameManager2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        brrrSpeed = 0f;
        HighScoreDisplay.text = highScore.ToString();
        HighScoreDisplay.enabled = true;
        HighScoreText.enabled = true;
        ExtraText.enabled = true;
        spawnPosition = new Vector3(0f, 2.5f, 0f); // reset spawn position til obstacles
        StartCoroutine(PrepStartUp());
    }
    void OnTriggerEnter2D(Collider2D collision) // n�r karakter kolliderer med GameManager
    {
        if (collision.gameObject.name == "karakter" && gameRunning)
        {
            SpawnObstacles();
        }
    }
    void FixedUpdate()
    {
        if (gameRunning)
        {
            Vector2 velocity = gameManager2D.velocity;
            velocity = new Vector3(0, -(brrrSpeed * 2), 0); // fart defienert som scrollspeed * 2
            gameManager2D.velocity = velocity;

            StartCoroutine(Timer()); // teller tid overlevd
        }
    } 
    private void Update()
    {
        points = (int)Mathf.Round(tid * brrrSpeed); // variable " points "
        ScoreDisplay.text = points.ToString(); // oppdaterer scoreDisplay 

        if (points >= highScore)
        {
            highScore = points;
            HighScoreDisplay.text = highScore.ToString();
        } //set highscore
        if (Input.GetKeyDown(KeyCode.Escape))
        {  
            Application.Quit();
        }
    }
    public void StartUp()
    {
        HighScoreDisplay.enabled = false;
        HighScoreText.enabled = false;
        ExtraText.enabled = false;
        points = 0;
        brrrSpeed = 1f;
        gameRunning = true;
        rocketman.Play();
        SpawnObstacles();
        StartCoroutine(SpeedController());
    }
    public void SpawnObstacles() // spawner obstacles
    {
        for (int i = 0; i <= obstacleCount; i++)
        {

            spawnPosition.y += Random.Range(2f, 2.5f); // 4f, 6f // y = y + Random.Range()
            spawnPosition.x = Random.Range(-0.7f, 0.7f);
            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            Destroy(newObstacle, 10); // sletter etter 10 sek

            if (i == obstacleCount) // etter for(i) fullf�rt
            {
                gameManager2D.position = new Vector3(0, spawnPosition.y + 2f - 3, 0);
                spawnPosition = new Vector3(0f, 2.5f, 0f); // reset spawnPosition
            }
        }
    }
    public void EndGame()
    {
        gameRunning = false;
        brrrSpeed = 0f;
        HighScoreDisplay.enabled = true;
        HighScoreText.enabled = true;
        ExtraText.enabled = true;
        rocketman.Stop();
        deathSound.Play();
        character.transform.position = new Vector3(0, 0, 0);
        StartCoroutine(PrepStartUp());
    }
    IEnumerator PrepStartUp()
    {
        tid = 0;
        yield return new WaitForSeconds(2.5f);
        while (!Input.anyKey)
        {
            yield return null;
        }
        StartUp();
    }
    private IEnumerator SpeedController()
    {
        while (gameRunning && maxSpeed > brrrSpeed)
        {
            yield return new WaitForSeconds(1);
            brrrSpeed += 0.1f;
        }
    } // fungerer...
    private IEnumerator Timer() 
    {
        while (!gameRunning)
        {
            yield return null;
        }
        tid += 1;
    }// burde egt fikses men ork
} 
