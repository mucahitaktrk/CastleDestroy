using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCastleColarScript : MonoBehaviour
{

    public MeshRenderer         _meshRenderer;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
}
