using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControll : MonoBehaviour
{

    [SerializeField] private GameObject _level1;
    [SerializeField] private GameObject _level2;
    [SerializeField] private GameObject _level3;
    [SerializeField] private GameObject _level4;
    [SerializeField] private GameObject _level5;

    public int _levelIndex = 1;

    void Update()
    {
        _levelIndex = PlayerPrefs.GetInt("Level");
        if(_levelIndex == 0)
        {
            _level1.SetActive(true);
        }
        else if(_levelIndex == 1)
        {
            _level1.SetActive(false);
            _level2.SetActive(true);
        }
        else if(_levelIndex == 2)
        {
            _level2.SetActive(false);
            _level3.SetActive(true);
        }
        else if (_levelIndex == 3)
        {
            _level3.SetActive(false);
            _level4.SetActive(true);
        }
        else if (_levelIndex == 4)
        {
            _level4.SetActive(false);
            _level5.SetActive(true);
        }
    }
}
