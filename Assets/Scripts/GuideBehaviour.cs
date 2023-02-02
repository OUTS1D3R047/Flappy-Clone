using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideBehaviour : ObstaclesBehaviour
{
    [SerializeField] private float guideSpeed;

    private IEnumerator Delay()
    {
        speed = 0;
        yield return new WaitForSecondsRealtime(1f);
        speed = guideSpeed;
    }

    public void parmDelay()
	{
        this.gameObject.SetActive(true);
        StartCoroutine(this.Delay());
    }

    private void FixedUpdate()
	{
        this.objectBehaviour(speed);
	}

}
