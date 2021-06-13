using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool playerOne;
    [SerializeField] private bool ai;
    private PlayerControls _controls1;

    private PlayerControls _controls2;
    private int _lastMove;

    // Start is called before the first frame update
    private void Awake()
    {
        _lastMove = Random.Range(1, 4);
        if (ai) return;
        switch (playerOne)
        {
            case true:
                _controls1 = new PlayerControls();

                _controls1.PlayerOne.Rock.performed += ctx => SendMove(1);
                _controls1.PlayerOne.Paper.performed += ctx => SendMove(2);
                _controls1.PlayerOne.Scissors.performed += ctx => SendMove(3);
                break;
            case false:
                _controls2 = new PlayerControls();
                _controls2.PlayerTwo.Rock.performed += ctx => SendMove(1);
                _controls2.PlayerTwo.Paper.performed += ctx => SendMove(2);
                _controls2.PlayerTwo.Scissors.performed += ctx => SendMove(3);
                break;
        }
    }

    private void SendMove(int move)
    {
        _lastMove = move;
    }

    public int GETLastMove()
    {
        var aiMove = Random.Range(1, 4);
        if(ai) print(aiMove);
        return !ai ? _lastMove : aiMove;
        //|| _lastMove ==0 
    }

    private void OnEnable()
    {
        if (ai) return;
        switch (playerOne)
        {
            case (true):
                _controls1.Enable();
                break;
            case (false):
                _controls2.Enable();
                break;
        }
    }

    private void OnDisable()
    {
        if (ai) return;
        switch (playerOne)
        {
            case (true):
                _controls1.Disable();
                break;
            case (false):
                _controls2.Disable();
                break;
        }
    }

    // Update is called once per frame
        
    }