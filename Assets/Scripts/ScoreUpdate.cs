using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    [SerializeField] private RoundCount roundCount;
    [SerializeField] private GameObject player1Score, player2Score;
    private Image[] _player1Scores, _player2Scores;
    private int _currentRound;
    private int [] _roundScores;

    private void Awake()
    {
        _currentRound = roundCount.GETCurrentRound();
        _roundScores = new int[5];
        _player1Scores = player1Score.GetComponentsInChildren<Image>();
        _player2Scores = player2Score.GetComponentsInChildren<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _roundScores = roundCount.GETRoundScore();
        Player1Update();
        Player2Update();
    }

    private void Player1Update()
    {
        for (var i = 0; i<_player1Scores.Length; i++)
        {
            switch (_roundScores[i])
            {
                case 1:
                    _player1Scores[i].color = Color.red;
                    break;
                case 2:
                    _player1Scores[i].color = Color.green;
                    break;
                default:
                    _player1Scores[i].color = Color.white;
                    break;
            }
        }
        //TODO highlight current round
        //_player1Scores[_currentRound] 
    }
    private void Player2Update()
    {
        for (var i = 0; i<_player2Scores.Length; i++)
        {
            switch (_roundScores[i])
            {
                case 1:
                    _player2Scores[i].color = Color.green;
                    break;
                case 2:
                    _player2Scores[i].color = Color.red;
                    break;
                default:
                    _player2Scores[i].color = Color.white;
                    break;
            }
        }
        //TODO highlight current round
        //_player1Scores[_currentRound] 
    }
}
