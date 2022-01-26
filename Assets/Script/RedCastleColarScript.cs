using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCastleColarScript : MonoBehaviour
{


    public MeshRenderer     _meshRenderer;
    public ParticleSystem particle;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
}
