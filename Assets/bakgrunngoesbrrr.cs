using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakgrunngoesbrrr : MonoBehaviour
{

    GameManager managerScript; // gameManager script
    [SerializeField] GameObject managerObject; // managerObject, defineres i Awake

    [Range(0f, 10f)]
    private float offset;
    private Material mat;

    private void Awake()
    {
        managerScript = managerObject.GetComponent<GameManager>();
    }
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    
    private void Update()
    {
        offset += (Time.deltaTime * managerScript.brrrSpeed/10) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
