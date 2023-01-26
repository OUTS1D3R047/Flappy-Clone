using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIncrement : MonoBehaviour
{
	[SerializeField] private TextMeshPro scoreValueTM;
	
	private int scoreValue = 0;

	private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Increment")
		{
			scoreValue++;
			scoreValueTM.text = scoreValue.ToString();
		}
    }
}
