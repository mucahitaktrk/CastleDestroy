using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class StickmanScript : MonoBehaviour
{

    [SerializeField] private float              _speed = 2;
    StickmanCalorScript                         _stickmanCalorScript;
    private float                               _time = 0;
    private float                               _timeBlue = 0;
    private float                               _timeRed = 0;
    private bool                                _collisionBlue = false;
    private bool                                _collisionRed = false;
    private bool                                _direction = false;
    public int                                  _coin;
    private int                                 _count;
    //-------COMPONENT------------------------------------
    private Rigidbody                           _rigidbody;
    private Animator                            _animator;
    private MeshRenderer                        _meshRenderer;
    //-------SCRIPT----------------------------------------
    BlueCastleHealtScript                       _blueCastleHealtScript;
    RedCastleHeathScript                        _redCastleHealtScript;
    private GameObject                          _gameObject;
    [SerializeField] private GameObject         _arrowBlueObject;
    [SerializeField] private GameObject         _arrowRedObject;
    [SerializeField] private Transform          _transform;
    private GameObject                          _redCastleTarget;
    [SerializeField] GameObject                 _planeObjectBlue;
    [SerializeField] GameObject                 _planeObjectRed;
    ArcherPartical archer;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _stickmanCalorScript = transform.GetChild(1).GetComponent<StickmanCalorScript>();
        archer = transform.GetChild(0).GetComponent<ArcherPartical>();
        _blueCastleHealtScript = GameObject.FindGameObjectWithTag("CastleBlue").GetComponent<BlueCastleHealtScript>();
        _redCastleHealtScript = GameObject.FindGameObjectWithTag("CastleRed").GetComponent<RedCastleHeathScript>();
        _animator = GetComponent<Animator>();
        _stickmanCalorScript.gameObject.SetActive(false);
        archer.gameObject.SetActive(false);                
    }

    void Update()
    {
        _gameObject = GameObject.FindGameObjectWithTag("Player");
        _redCastleTarget = GameObject.FindGameObjectWithTag("RedCastleTarget");
        _count = PlayerPrefs.GetInt("Count");
        _time += Time.deltaTime;
        if (_time >= 0.2f)
        {
            _stickmanCalorScript.gameObject.SetActive(true);
            archer.gameObject.SetActive(true);
        }

        if (_stickmanCalorScript._blue)
        {
            _rigidbody.velocity = new Vector3(0, 0, _speed * 5);
            _animator.SetFloat("Speed", Mathf.Abs(_speed));
        }
        if (_stickmanCalorScript._red)
        {
            _rigidbody.velocity = new Vector3(0, 0, -_speed * 5);
            _animator.SetFloat("Speed", Mathf.Abs(_speed));
        }

        if (_collisionBlue)
        {
            _timeBlue += Time.deltaTime;
            if (_timeBlue >= 1f)
            {
                _blueCastleHealtScript._blueCastleHealt -= 2;
                GameObject bullet = Instantiate(_arrowRedObject, _transform.position * 1, Quaternion.identity);
                Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
                rigidbody.AddForce(_transform.forward * -5, ForceMode.Impulse);
                _timeBlue = 0;               
            }
        }

        if (_collisionRed)
        {
            if (_count < 3)
            {
                _timeRed += Time.deltaTime;
            }else if(_count >= 3)
            {
                _timeRed += Time.deltaTime * 2;
            }
            if (_timeRed >= 1f)
            {
                _redCastleHealtScript._redCastleHealt -= 2;
                GameObject bullet = Instantiate(_arrowBlueObject, _transform.position, Quaternion.identity);
                Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
                rigidbody.AddForce(_redCastleTarget.transform.position * 1, ForceMode.Impulse);
                _rigidbody.velocity = new Vector3(0, 0, 0);
                _timeRed = 0;
                _coin += 10;
            }
        }
        _animator.SetBool("CollisionBlue", _collisionBlue);
        _animator.SetBool("CollisionRed", _collisionRed);        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlueBullet" && (!_stickmanCalorScript._blue && !_stickmanCalorScript._red))
        {
            _stickmanCalorScript._skinnedMeshRenderer.material = _stickmanCalorScript._materials[1];
            _stickmanCalorScript._blue = true;
            _direction = true;
            Instantiate(_planeObjectBlue, transform.position, Quaternion.identity);
            _gameObject.tag = "Finish";
            if (_direction)
            {
                Vector3 _directionScale = transform.localScale;
                _directionScale.z *= 1;
                transform.localScale = _directionScale;
            }            
        }

        if (collision.gameObject.tag == "RedBullet" && (!_stickmanCalorScript._red && !_stickmanCalorScript._blue)) 
        {
            Instantiate(_planeObjectRed , transform.position, Quaternion.identity);
            _stickmanCalorScript._skinnedMeshRenderer.material = _stickmanCalorScript._materials[2];
            _stickmanCalorScript._red = true;
            Vector3 _directionScale = transform.localScale;
            _directionScale.z *= -1;
            transform.localScale = _directionScale;
            _direction = true;
            _gameObject.tag = "Finish";
        }

        if (collision.gameObject.tag == "CastleBlue")
        {
            _collisionBlue = true;
            Vector3 _vector = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }

        if (collision.gameObject.tag == "CastleRed")
        {
            _collisionRed = true;
            Vector3 _vector = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }
}

