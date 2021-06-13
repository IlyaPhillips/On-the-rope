using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private RoundCount roundCount;
    [SerializeField] private bool player1;
    private PlayerController _input;
    private Animator _animator;
    private bool _hit;
    

    private static readonly int Win = Animator.StringToHash("Win");
    private static readonly int Lose = Animator.StringToHash("Lose");
    private static readonly int Combat = Animator.StringToHash("Combat");
    private static readonly int Move = Animator.StringToHash("Move");
    private static readonly int Round = Animator.StringToHash("Round");
    private static readonly int Hit = Animator.StringToHash("Hit");
    private static readonly int Idle = Animator.StringToHash("Idle");

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(Combat);
    }

    // Update is called once per frame
    void Update()
    {
        print(roundCount.GETCombat());
        if (roundCount.GETCombat())
        {
            _animator.SetTrigger(Combat);
            var round = roundCount.GETCurrentRound();
            _animator.SetInteger(Round, round);
            var move  = _input.GETLastMove();
            _animator.SetInteger(Move,move);
            
        }

        if (roundCount.GETHit())
        {
            if (!_hit)
            {
                _hit = true;
                _animator.SetBool(Hit, _hit);
                HitLogic();
            }
        }

        if (!roundCount.GETHit())
        {
            _hit = false;
            _animator.SetBool(Hit, _hit);
        }
    }

    private void HitLogic()
    {
        
        var result = roundCount.GETRoundResult();
        if (result == 0)
        {
            _animator.SetTrigger(Idle);
            _hit = false;
        }

        else if (player1)
        {
            
            _animator.SetTrigger(result == 1 ? Win : Lose);
        }

        else
        {
            _animator.SetTrigger(result == 2 ? Win : Lose);
        }
    }
}
