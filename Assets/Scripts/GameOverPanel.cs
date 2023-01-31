using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private IEnumerable<Transform> gameOverPanelItems;

    void Start()
    {
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
