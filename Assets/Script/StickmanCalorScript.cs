using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StickmanCalorScript : MonoBehaviour
{

    public SkinnedMeshRenderer          _skinnedMeshRenderer;
    [SerializeField] public Material[]  _materials;
    public bool                         _red = false;
    public bool                         _blue = false;


    void Start()
    {
        _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

}
