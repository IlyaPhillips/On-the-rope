using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool playerOne;
    private PlayerControls _controls1;

    private PlayerControls _controls2;
    private int _lastMove;
    public bool keyInput;

    // Start is called before the first frame update
    private void Awake()
    {
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
        keyInput = true;
        // switch (move)
        // {
        //     case 1:
        //         Debug.Log("Rock");
        //         break;
        //     case 2:
        //         Debug.Log("Paper");
        //         break;
        //     case 3:
        //         Debug.Log("Scissors");
        //         break;
        //     default:
        //         Debug.Log("Invalid Input");
        //         break;
        // }
        _lastMove = move;
    }

    public int GETLastMove()
    {
        return _lastMove;
    }

    private void OnEnable()
    {
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