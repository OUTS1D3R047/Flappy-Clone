using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideBehaviour : ObstaclesBehaviour
{
    [SerializeField] private float guideSpeed, guideDestroyPos;

	private void FixedUpdate()
	{
		if(PlayerPrefs.GetInt("MatchesPlayed") == 0)
		{

		}

	}

}
