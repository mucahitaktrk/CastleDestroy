using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAnimationScript : MonoBehaviour
{

    public Animator       _animation;

    void Start()
    {
        _animation = GetComponent<Animator>();
    }
}
