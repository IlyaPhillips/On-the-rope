using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] private RoundCount roundCount;
    private AudioSource _bellRing;
    private int _currentRound;
    private Animator _animator;

    private bool _tempHit;

    private static readonly int BellRing = Animator.StringToHash("BellRing");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _tempHit = false;
        _currentRound = 0;
        _bellRing = GetComponent<AudioSource>();
        StartCoroutine(Ring());
    }

    // Update is called once per frame
    void Update()
    {
        var hit = roundCount.GETHit();
        _currentRound = roundCount.GETCurrentRound();
        if (hit)
        {
            _tempHit = true;
        }

        if (!_tempHit || hit) return;
        StartCoroutine(Ring());
        _tempHit = false;
        print(_currentRound);

    }

    private IEnumerator Ring()
    {
        //TODO match timing to animations
        while (_currentRound<5)
        {
            //_bellRing.Play();
            yield return new WaitForSeconds(0.02f);
            Strike();
            roundCount.SetCombat(true);
            yield return new WaitForSeconds(0.29f);
            roundCount.SetCurrentRound(_currentRound+1);
            yield return new WaitForSeconds(0.29f);
        }
    }

    void Strike()
    {
        _animator.SetTrigger(BellRing);
    }
}
