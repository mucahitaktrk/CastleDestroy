using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class UiScript : MonoBehaviour
{
    [SerializeField] private Slider     _redCastleHealthSlider;
    [SerializeField] private Slider     _blueCastleHealthSlider;
    [SerializeField] private GameObject _tryAgainPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private Text       _coinText;
    [SerializeField] private Text       _nextLevelCoin;
    [SerializeField] private Text       _climpCoinText;
    [SerializeField] private Text       _xCoin;
    public int                          _coin = 0;
    private LevelControll               _levelControll;

    void Start()
    {
        _coin = PlayerPrefs.GetInt("Coin");
        _levelControll = GameObject.Find("LevelControll").GetComponent<LevelControll>();
    }

    void Update()
    {
        _xCoin.text = " X " + 100;
        _nextLevelCoin.text = 100.ToString();
        _climpCoinText.text = "" + 100 * 2;
        _coinText.text = _coin.ToString();

        PlayerPrefs.SetInt("Coin", _coin);

    }

    public void TryAginButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);        
    }

    public void WinButton()
    {
        Time.timeScale = 1f;
        _coin += 100;
        SceneManager.LoadScene(0);
        _levelControll._levelIndex++;
        PlayerPrefs.SetInt("Level", _levelControll._levelIndex);
        PlayerPrefs.SetInt("Coin", _coin);
    }

    public void ClimpButton()
    {
        Time.timeScale = 1f;
        _coin += 200;
        PlayerPrefs.SetInt("Coin", _coin);
        _levelControll._levelIndex++;
        PlayerPrefs.SetInt("Level", _levelControll._levelIndex);
        SceneManager.LoadScene(0);
    }
}

