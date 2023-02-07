using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel, gamePanel, pausePanel, otherGamePanel, mainMenuPanel, returnButton, statisticsPanel, aboutPanel, guideTMP, pauseButton;
    [SerializeField] private GameObject[] panels;

    private Dictionary<string, IEnumerable<Transform>> panelList = new Dictionary<string, IEnumerable<Transform>>();
    private Transform returnButtonComponent;
    private SaveStatistics saveStatistics;
    private GuideBehaviour guideBehaviour;

    private static bool restarted = false;

    protected void Start()
    {
        this.initPanels();
        this.switchPanels(mainMenuPanel);

        if (restarted)
		{
            this.startGame();
            restarted = false;
            guideBehaviour.parmDelay();

        }
    }

    protected void initPanels()
    {
        foreach (GameObject _panel in panels)
        {
            panelList.Add(_panel.name, _panel.GetComponentsInChildren<Transform>().Skip(1));
        }

        saveStatistics = this.gameObject.GetComponent<SaveStatistics>();
        guideBehaviour = guideTMP.GetComponent<GuideBehaviour>();
    }

    protected void switchPanels(GameObject _panel)
    {
        foreach (KeyValuePair<string, IEnumerable<Transform>> _panelItemDict in panelList)
        {
            if (_panelItemDict.Key == _panel.name)
            {
                this.switchPanelItems(_panelItemDict.Value, true);
            }

            else
            {
                foreach (Transform _panelItem in _panelItemDict.Value)
                {
                    this.switchPanelItems(_panelItemDict.Value, false);
                }
            }
        }
    }

    protected void switchPanelItems(IEnumerable<Transform> _panelItemDictVal, bool _enable)
    {
        foreach (Transform _panelItem in _panelItemDictVal)
        {
            _panelItem.gameObject.SetActive(_enable);
        }
    }

    protected void switchFromMenu(GameObject _panel)
    {
        this.switchPanels(_panel);
        this.enableRetButton();
    }

	protected void enableRetButton()
	{
		this.switchPanelItems(panelList[returnButton.name], true);
	}

    protected void pauseGameOver(GameObject _panel)
	{
        this.switchPanelItems(panelList[otherGamePanel.name], true);
        this.switchPanelItems(panelList[_panel.name], false);
    }

	public void startGame()
	{
		this.switchPanels(gamePanel);
	}

    public void statistics()
    {
        this.switchFromMenu(statisticsPanel);

        saveStatistics.outputStatistics();
    }

    public void about()
    {
        this.switchFromMenu(aboutPanel);
    }

    public void gameOver()
	{
        this.pauseGameOver(pausePanel);
        pauseButton.gameObject.SetActive(false);
	}

	public void pause()
	{
        this.pauseGameOver(gameOverPanel);
        Time.timeScale = 0;
	}

	public void resume()
	{
        this.switchPanelItems(panelList[otherGamePanel.name], false);
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
        this.switchPanels(mainMenuPanel);
		Time.timeScale = 1;
	}

	

}
