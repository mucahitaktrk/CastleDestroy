using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroyScript : MonoBehaviour
{
    [SerializeField] private Transform          _transform;
    [SerializeField] private ParticleSystem     _particle;

    Vector3 _vector;

    void Update()
    {
        Destroy(gameObject, 0.1f);
        _vector = new Vector3(_transform.position.x - 0.1f, _transform.position.y, _transform.position.z);
        Instantiate(_particle, _vector, Quaternion.identity);

    }

    private void OnTriggerEnter(Collider other)
    {
        float x = Random.Range(6f, -6f);
        float y = Random.Range(0.1f, 5f);
        Vector3 vector = new Vector3(x, y, transform.position.z);
    }
}
