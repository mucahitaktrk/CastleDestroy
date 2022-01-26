using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour
{

    private int                  _coin;
    [SerializeField] private Text _coinText;

    private void Update()
    {
        _coinText.text = _coin.ToString();
        Time.timeScale = 1f;
    }

    public void StartScene()
    {
        SceneManager.LoadScene(1);                        
    }
}
