using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Knockback : MonoBehaviour
{
    
    [SerializeField] private Vector2 knockbackVector;
    [SerializeField] private GameObject target;
    [SerializeField] private SpringJoint2D rope;
    [SerializeField] private LineRenderer ropeLine;
    private bool _onEdge;
    

    private Rigidbody2D _rb, _targetRb;
    // Start is called before the first frame update
    void Awake()
    {
        _onEdge = false;
        _rb = GetComponent<Rigidbody2D>();
        _targetRb = target.GetComponent<Rigidbody2D>();
        
    }

    public void ApplyKnockback()
    {
        if (!_onEdge)
        {
            _rb.AddForce(knockbackVector);
        }
        else
        {
            _rb.AddForce(5*knockbackVector);
            rope.breakForce = 1;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _onEdge = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _onEdge = false;
    }
}
