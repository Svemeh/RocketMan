using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{
    public Rigidbody2D rocketMan;
    public float fart;
    private float xMovement;
    public Animator anim;

    [SerializeField] GameObject managerObject; // managerObject, defineres i Awake
    GameManager managerScript; // gameManager script

    private void Start() => anim = GetComponent<Animator>();

    private void Awake()
    {
        rocketMan = GetComponent<Rigidbody2D>();
        managerObject = GameObject.Find("GameManager");
        managerScript = managerObject.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (managerScript.gameRunning)
        {
            xMovement = Input.GetAxis("Horizontal") * fart;
            if (anim!= null)
            {
                anim.Play("character");
            }
        }
        else
        {
            if (anim != null)
            {
                anim.Play("IdleCharacter");
            }
        }
    }

    private void FixedUpdate()
    {
        if (managerScript.gameRunning)
        {
        Vector2 velocity = rocketMan.velocity;
        velocity.x = xMovement;
        rocketMan.velocity = velocity;
        }
        else
        {
        rocketMan.velocity = new Vector2(0, 0);
        }
    }
}
