using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueCastleHealtScript : MonoBehaviour
{

    public int                                  _blueCastleHealt = 100;
    [SerializeField] private GameObject         _losePanel;
    [SerializeField] private Text               _blueCastleHealtText;
    [SerializeField] private Slider             _blueCastleHealtSlider;
    private BlueCastleColarScript               _blueCastleColarScript;
    [SerializeField] Color[]                    _color;

    private void Start()
    {
        _blueCastleColarScript = GameObject.FindGameObjectWithTag("BlueCastleTarget").GetComponent<BlueCastleColarScript>();
        _losePanel.SetActive(false);
    }

    private void Update()
    {
        if (_blueCastleHealt <= 0)
        {
            Time.timeScale = 0;
            _losePanel.SetActive(true);
            _blueCastleHealtText.text = 0.ToString();
        }
        //else
           //Time.timeScale = 1f;
        if (_blueCastleHealt <= 50)
        {
            _blueCastleColarScript._meshRenderer.materials[0].color = Color.Lerp(_blueCastleColarScript._meshRenderer.materials[0].color, _color[0], 0.3f * Time.deltaTime);
            _blueCastleColarScript._meshRenderer.materials[1].color = Color.Lerp(_blueCastleColarScript._meshRenderer.materials[1].color, _color[1], 0.3f * Time.deltaTime);
            _blueCastleColarScript._meshRenderer.materials[2].color = Color.Lerp(_blueCastleColarScript._meshRenderer.materials[2].color, _color[2], 0.3f * Time.deltaTime);
        }
        _blueCastleHealtText.text = _blueCastleHealt.ToString();
        _blueCastleHealtSlider.value = _blueCastleHealt;
    }

}
