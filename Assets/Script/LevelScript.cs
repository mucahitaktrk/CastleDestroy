using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    private Image                       _image;
    [SerializeField] private Sprite[]   sprite;
    private int                         _level;
    public int                          level;

    void Start()
    {
        _image = GetComponent<Image>();
        _level = PlayerPrefs.GetInt("Level");
    }


    void Update()
    {
        if (level < _level)
            _image.sprite = sprite[0]; 
        else if (_level == level)
            _image.sprite = sprite[1];
        else if (level > _level)
            _image.sprite = sprite[2];        
        
    }
}
