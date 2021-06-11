using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.InputSystem;

public class Knockback : MonoBehaviour
{
    [SerializeField] private bool playerOne;
    [SerializeField] private Vector2 knockbackVector;
    [SerializeField] private GameObject target;
    private PlayerControls _controls;

    private Rigidbody2D _rb, _targetRb;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _targetRb = target.GetComponent<Rigidbody2D>();
        _controls = new PlayerControls();
        _controls.PlayerOne.Attacks.performed += ctx => SendMessage();
    }

    private void SendMessage()
    {
        if (playerOne)
        {
            Debug.Log("Button Pressed");
            _rb.AddForce(knockbackVector);
        }
    }

    private void OnEnable()
    {
        _controls.PlayerOne.Enable();
    }
    private void OnDisable()
    {    
        _controls.PlayerOne.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
