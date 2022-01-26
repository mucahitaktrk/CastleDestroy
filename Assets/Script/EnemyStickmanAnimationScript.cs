using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStickmanAnimationScript : MonoBehaviour
{

    public Animator         _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

}
