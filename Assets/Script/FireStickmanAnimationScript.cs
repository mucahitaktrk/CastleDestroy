using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStickmanAnimationScript : MonoBehaviour
{
    public Animator         _animator;


    void Start()
    {
        _animator = GetComponent<Animator>();
    }

}
