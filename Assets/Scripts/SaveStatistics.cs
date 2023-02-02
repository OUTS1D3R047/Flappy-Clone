using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveStatistics : MonoBehaviour
{
	[SerializeField] protected TextMeshProUGUI recordValue, gamesPlayedValue;
	[SerializeField] private string matchesPlayedName, recordValueName;

	private int matchesPlayed, yourRecord;

	public int parmMatchesPlayed()
	{
		return matchesPlayed = PlayerPrefs.GetInt(matchesPlayedName);
	}

	public int parmYourRecord()
	{
		return yourRecord = PlayerPrefs.GetInt(recordValueName);
	}

	public void saveMatches()
	{
		this.parmMatchesPlayed();
		
		matchesPlayed++;
		PlayerPrefs.SetInt(matchesPlayedName, matchesPlayed);
	}

	public void saveRecord()
	{
		this.parmYourRecord();

		yourRecord++;
		PlayerPrefs.SetInt(recordValueName, yourRecord);
	}

	public void outputStatistics()
	{
		recordValue.text = this.parmYourRecord().ToString();
		gamesPlayedValue.text = this.parmMatchesPlayed().ToString();
	}
}
