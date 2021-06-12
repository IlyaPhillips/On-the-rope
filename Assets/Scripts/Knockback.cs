using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.InputSystem;

public class Knockback : MonoBehaviour
{
    
    [SerializeField] private Vector2 knockbackVector;
    [SerializeField] private GameObject target;
    

    private Rigidbody2D _rb, _targetRb;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _targetRb = target.GetComponent<Rigidbody2D>();
        
    }
    public void ApplyKnockback() => _rb.AddForce(knockbackVector);

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
