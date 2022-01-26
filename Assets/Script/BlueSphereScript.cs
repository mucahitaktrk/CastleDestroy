using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSphereScript : MonoBehaviour
{

    [SerializeField] private ParticleSystem _particleSystem;
    private Vector3                         _vector;
    private Vector3                         _efectVector;
    [SerializeField] private GameObject     _gameObject;
    [SerializeField] private ParticleSystem _particalEfect;
    [SerializeField] private GameObject[]   _feedBack;
    private int                             _count = 0;

    private void Start()
    {
        Instantiate(_particalEfect, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        _efectVector = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
        _vector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _count = PlayerPrefs.GetInt("Count");
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            _count++;
            Instantiate(_particleSystem, _vector, Quaternion.identity);
            Debug.Log(_count);
            PlayerPrefs.SetInt("Count", _count);
            if (_count > 3)
                Instantiate(_feedBack[0], _efectVector, Quaternion.identity);
            else if (_count > 1)
                Instantiate(_feedBack[1], _efectVector, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Finish")
        {
            _count = 0;
            PlayerPrefs.SetInt("Count", _count);
            Instantiate(_particleSystem, _vector, Quaternion.identity);
            Destroy(this);
        }
        if (collision.gameObject.tag == "CastleBlue")
        {
            _count = 0;
            PlayerPrefs.SetInt("Count", _count);
            Instantiate(_particleSystem, _vector, Quaternion.identity);
            Destroy(this);
        }
        if (collision.gameObject.tag == "CastleRed")
        {
            _count = 0;
            PlayerPrefs.SetInt("Count", _count);
            Instantiate(_particleSystem, _vector, Quaternion.identity);
            Destroy(this);
        }
        if (collision.gameObject.tag == "Wall")
        {
            _count = 0;
            PlayerPrefs.SetInt("Count", _count);
            Instantiate(_particleSystem, _vector, Quaternion.identity);
            Instantiate(_gameObject, transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}
