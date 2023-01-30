using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    private GameObject gameOverPanel;
    private IEnumerable<Transform> gameOverPanelItems;

    void Start()
    {
        gameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
        gameOverPanelItems = gameOverPanel.GetComponentsInChildren<Transform>().Skip(1);
        this.manageGameOverPanel(false);        
    }

    public void manageGameOverPanel(bool _enable)
    {
        foreach (Transform gameOverPanelItem in gameOverPanelItems)
        {
            gameOverPanelItem.gameObject.SetActive(_enable);
        }
    }
}
