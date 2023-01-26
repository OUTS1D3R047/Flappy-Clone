using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBehaviour : MonoBehaviour
{
    private Rigidbody2D rootObstacleRB;
    private Quaternion defaultObstacleRot;


    [SerializeField] private float speed;

    void Start()
    {
        rootObstacleRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rootObstacleRB.velocity = new Vector2(-speed, 0);
    }

    private void FixedUpdate()
    {

        if (this.transform.position.x < -15f)
        {
            Destroy(this.gameObject);
        }
    }
}
