using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCastleHeathScript : MonoBehaviour
{

    public int                                  _redCastleHealt = 100;
    public int                                  _redCastleParticalHealt = 100;
    [SerializeField] private GameObject         _winPanel;
    [SerializeField] private Text               _redCastleHealtText;
    [SerializeField] private Slider             _redCastleHealtSlider;
    [SerializeField] private Material[]         _material;
    private RedCastleColarScript                _redCastleColarScript;
    [SerializeField] Color[]                    _color ;

    private void Start()
    {
        _redCastleColarScript = GameObject.FindGameObjectWithTag("RedCastleTarget").GetComponent<RedCastleColarScript>();
        _winPanel.SetActive(false);
    }

    private void Update()
    {
        if (_redCastleHealt <= 0)
        {
            Time.timeScale = 0;
            _winPanel.SetActive(true);
            _redCastleHealtText.text = 0.ToString();
        }

        Vector3 vector = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f);
        float time = (_redCastleParticalHealt * 25) / 100;
        Debug.Log(time);
        if (_redCastleHealt <= time)
        {
            Instantiate(_redCastleColarScript.particle, vector, transform.rotation);
            _redCastleColarScript._meshRenderer.materials[0].color = Color.Lerp(_redCastleColarScript._meshRenderer.materials[0].color, _color[0], 0.7f * Time.deltaTime);
            _redCastleColarScript._meshRenderer.materials[1].color = Color.Lerp(_redCastleColarScript._meshRenderer.materials[1].color, _color[1], 0.7f * Time.deltaTime);
            _redCastleColarScript._meshRenderer.materials[2].color = Color.Lerp(_redCastleColarScript._meshRenderer.materials[2].color, _color[2], 0.7f * Time.deltaTime);

        }
        
        _redCastleHealtText.text = _redCastleHealt.ToString();
        _redCastleHealtSlider.value = _redCastleHealt;
    }
}
