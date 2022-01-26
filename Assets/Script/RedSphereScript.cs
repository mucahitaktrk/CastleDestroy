using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSphereScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem     _particleSystem;
    [SerializeField] private GameObject         _gameObject;
    private Vector3                             _vector;
    [SerializeField] private ParticleSystem     _particalEfekt;
    private Vector3 _vector3;


    private void Start()
    {
        Instantiate(_particalEfekt, _vector3, Quaternion.identity);
    }
    private void Update()
    {
        _vector = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        _vector3 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(_particleSystem, _vector, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Finish")
        {
            Instantiate(_particleSystem, _vector, Quaternion.identity);
        }
        if (collision.gameObject.tag == "CastleBlue")
        {
            Instantiate(_particleSystem, _vector, Quaternion.identity);
        }
        if (collision.gameObject.tag == "CastleRed")
        {
            Instantiate(_particleSystem, _vector, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Instantiate(_particleSystem, _vector, Quaternion.identity);
            Instantiate(_gameObject, transform.position, Quaternion.identity);
        }
    }
}
