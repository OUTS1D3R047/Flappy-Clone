using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBehaviour : MonoBehaviour
{
    private Rigidbody2D rootObstacleRB;


    [SerializeField] protected float speed, destroyPos;

    public float speedPub
    {
        get 
        { 
            return speed; 
        }
        set 
        {
            speed = value;
        }
    }

    void Start()
    {
        rootObstacleRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        this.objectBehaviour();
    }

    protected void objectBehaviour()
	{
        rootObstacleRB.velocity = new Vector2(-speed, 0);

        if (this.transform.position.x < destroyPos)
        {
            Destroy(this.gameObject);
        }
    }
}
