using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public Rigidbody2D obstacle;
    [SerializeField] GameObject managerObject; // managerObject, defineres i Awake
    GameManager managerScript; // gameManager script

    private void Awake()
    {
        managerObject = GameObject.Find("GameManager");
        obstacle = GetComponent<Rigidbody2D>();
        managerScript = managerObject.GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "karakter")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>(); // kræsj trigger
            if (rb != null)
            {
                managerScript.EndGame();
            }
        }
    } // kollisjon stopper spill og sletter obstacles

    private void FixedUpdate()
    {
        if (managerScript.gameRunning)
        {
            Vector2 velocity = obstacle.velocity;
            velocity = new Vector3(0, -(managerScript.brrrSpeed * 2), 0); // fart defienert som scrollspeed * 2
            obstacle.velocity = velocity;
        }
        else
        {
            Destroy(obstacle.gameObject); // sletter obstacles upon death
        }
    }
}
