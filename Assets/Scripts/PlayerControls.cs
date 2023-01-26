using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    protected new Camera camera;
    protected Rigidbody2D playerControl;

    [SerializeField] private KeyCode button = KeyCode.Space;
    [SerializeField] private float speed;

    void Awake()
    {
        camera = Camera.main;
    }

    void Update()
    {
        playerControl = GetComponent<Rigidbody2D>();

        if(Input.GetKeyDown(button))
        {
            playerControl.velocity = new Vector2(0, 2) * speed;
        }
    }
}
