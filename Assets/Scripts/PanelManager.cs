using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel, gamePanel, pausePanel, otherGamePanel, mainMenuPanel, returnButton, statisticsPanel, aboutPanel;

    private IEnumerable<Transform> gameOverPanelItems, gamePanelItems, pausePanelItems, otherGamePanelItems, 
                                   mainMenuPanelItems, statisticsPanelItems, aboutPanelItems;
    private List<Transform> panelList = new List<Transform>();

    private Transform returnButtonComponent;
    
    private SaveStatistics saveStatistics;

    private static bool restarted = false;

    protected void Start()
    {
        this.initPanels();
        this.initPanelList();
        this.mainMenu();

        if(restarted)
		{
            this.startGame();
            restarted = false;
		}
    }

    protected void initPanels()
    {
        gamePanelItems = gamePanel.GetComponentsInChildren<Transform>().Skip(1);
        gameOverPanelItems = gameOverPanel.GetComponentsInChildren<Transform>().Skip(1);
        pausePanelItems = pausePanel.GetComponentsInChildren<Transform>().Skip(1);
        otherGamePanelItems = otherGamePanel.GetComponentsInChildren<Transform>().Skip(1);
        mainMenuPanelItems = mainMenuPanel.GetComponentsInChildren<Transform>().Skip(1);
        statisticsPanelItems = statisticsPanel.GetComponentsInChildren<Transform>().Skip(1);
        aboutPanelItems = aboutPanel.GetComponentsInChildren<Transform>().Skip(1);
        returnButtonComponent = returnButton.GetComponent<Transform>();

        saveStatistics = this.gameObject.GetComponent<SaveStatistics>();
    }

    protected void initPanelList()
    {
        panelList.AddRange(gamePanelItems);
        panelList.AddRange(gameOverPanelItems);
        panelList.AddRange(pausePanelItems);
        panelList.AddRange(otherGamePanelItems);
        panelList.AddRange(mainMenuPanelItems);
        panelList.AddRange(statisticsPanelItems);
        panelList.AddRange(aboutPanelItems);
        panelList.Add(returnButtonComponent);
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

    public void mainMenu()
    {
        this.hidePanels(panelList);
        this.enablePanels(mainMenuPanelItems);
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
        Time.timeScale = 1;
        restarted = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.enablePanels(mainMenuPanelItems);
        Time.timeScale = 1;
    }

    public void statistics()
	{
        this.hidePanels(mainMenuPanelItems);
        this.enablePanels(statisticsPanelItems);
        returnButtonComponent.gameObject.SetActive(true);
        
        saveStatistics.outputStatistics();
	}

    public void about()
	{
        this.hidePanels(mainMenuPanelItems);
        this.enablePanels(aboutPanelItems);
        returnButtonComponent.gameObject.SetActive(true);
    }

}
