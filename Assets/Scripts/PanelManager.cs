using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel, gamePanel, pausePanel, otherGamePanel;

    private IEnumerable<Transform> gameOverPanelItems, gamePanelItems, pausePanelItems, otherGamePanelItems;
    private List<Transform> panelList = new List<Transform>();

    protected void Start()
    {
        this.initPanels();
        this.initPanelList();
        this.startGame();
    }

    protected void initPanels()
    {
        gamePanelItems = gamePanel.GetComponentsInChildren<Transform>().Skip(1);
        gameOverPanelItems = gameOverPanel.GetComponentsInChildren<Transform>().Skip(1);
        pausePanelItems = pausePanel.GetComponentsInChildren<Transform>().Skip(1);
        otherGamePanelItems = otherGamePanel.GetComponentsInChildren<Transform>().Skip(1);
    }

    protected void initPanelList()
    {
        panelList.AddRange(gamePanelItems);
        panelList.AddRange(gameOverPanelItems);
        panelList.AddRange(pausePanelItems);
        panelList.AddRange(otherGamePanelItems);
    }

    protected void hidePanels(IEnumerable<Transform> _panel)
    {
        foreach (Transform _panelItem in _panel)
        {
            _panelItem.gameObject.SetActive(false);
        }
    }

    protected void enablePanels(IEnumerable<Transform> _panel)
    {
        foreach (Transform _panelItem in _panel)
        {
            _panelItem.gameObject.SetActive(true);
        }
    }

    public void startGame()
    {
        this.hidePanels(panelList);
        this.enablePanels(gamePanelItems);
    }

    public void gameOver()
    {
        this.enablePanels(otherGamePanelItems);
        this.enablePanels(gameOverPanelItems);
        this.hidePanels(pausePanelItems);
    }

    public void pause()
	{
        this.enablePanels(otherGamePanelItems);
        this.hidePanels(gameOverPanelItems);
        this.enablePanels(pausePanelItems);
        Time.timeScale = 0;
    }

    public void resume()
	{
        this.hidePanels(pausePanelItems);
        this.hidePanels(otherGamePanelItems);
        Time.timeScale = 1;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.startGame();
        Time.timeScale = 1;
    }

    public void exit()
    { 
    }


}
