using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject obstacle, gameOverPanel;

    private GameObject[] obstacles;
    private GOPanel goPanel;

    public GameObject[] obstaclesPub 
    {
        get
		{
            return obstacles;
		}

		set 
        {
            obstacles = value;
        }
    }

    void Start()
    {
        goPanel = gameOverPanel.GetComponent<GOPanel>();
    }

	private void FixedUpdate()
	{
        obstacles = GameObject.FindGameObjectsWithTag(obstacle.tag);
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == obstacle.tag)
        {
            goPanel.gameOver(obstaclesPub, 0, false);
        }
    }
}
