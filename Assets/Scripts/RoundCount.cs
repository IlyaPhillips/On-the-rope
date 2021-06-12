using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCount : MonoBehaviour
{
    [SerializeField] private GameObject player1, player2;
    private PlayerController _controller1, _controller2;
    private Knockback _player1Knock, _player2Knock;
    private int _move1, _move2;
    private int _winState; // 0 - draw, 1 - player1 win, 2 - player2 win
    private int[] _roundScore;
    private int _currentRound;
    private int _rounds;
    private int _roundResult;
    private bool _combat;

    private void Awake()
    {
        _winState = 0;
        _rounds = 5;
        _roundScore = new int[_rounds];
        _currentRound = 0;
        _controller1 = player1.GetComponent<PlayerController>();
        _controller2 = player2.GetComponent<PlayerController>();
        _player1Knock = player1.GetComponent<Knockback>();
        _player2Knock = player2.GetComponent<Knockback>();
    }

   

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        if (_combat && _currentRound <5)
        {
            
            //foreach round start
            CheckMoves();
            CheckResult(_move1,_move2);
            _roundScore[_currentRound] = _winState;
            _combat = false;
            //for each round end
            
            
            _controller1.keyInput = false;
            _controller2.keyInput = false;
        }

        if (_currentRound >=5)
        {
            EvaluateLoser();
            KnockbackLoser();
            _currentRound = 0;
        }
    }

    private void EvaluateLoser()
    {
        var win = 0;
        var lose = 0;
        foreach (var score in _roundScore)
        {
            switch (score)
            {
                case 0:
                    break;
                case 1:
                    win++;
                    break;
                case 2:
                    lose++;
                    break;
                default:
                    break;
            }
        }

        if (win == lose)
        {
            _roundResult = 0;
        }
        else
        {
            _roundResult = lose > win ? 1 : 2;
        }
        
    }

    private void CheckMoves()
    {
        _move1 = _controller1.GETLastMove();
        _move2 = _controller2.GETLastMove();
    }

    private void CheckResult(int move1,int move2)
    {
        if (move1 == move2)
        {
            _winState = 0;
        }
        else
        { 
            switch (move1)
            {
                case 1:
                    _winState = move2 == 2 ? 2 : 1;
                    break;
                case 2:
                    _winState = move2 == 3 ? 2 : 1;
                    break;
                case 3:
                    _winState = move2 == 1 ? 2 : 1;
                    break;
                default:
                    Debug.Log("Invalid Input CheckResults");
                    break;
            }
        }
    }

    private void KnockbackLoser()
    {
        switch (_roundResult)
        {
            case 0:
                _player2Knock.ApplyKnockback();
                _player1Knock.ApplyKnockback();
                break;
            case 1:
                _player2Knock.ApplyKnockback();
                break;
            case 2:
                _player1Knock.ApplyKnockback();
                break;
            default:
                break;
        }
    }

    public int GETCurrentRound()
    {
        return _currentRound;
    }

    public void SetCurrentRound(int round)
    {
        _currentRound = round;
    }

    public bool GETCombat()
    {
        return _combat;
    }

    public void SetCombat(bool combat)
    {
        _combat = combat;
    }
}
