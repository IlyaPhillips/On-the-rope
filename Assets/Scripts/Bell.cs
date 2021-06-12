using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] private RoundCount roundCount;
    private AudioSource _bellRing;
    private int _currentRound;

    private bool _temphit;
    // Start is called before the first frame update
    void Start()
    {
        _temphit = false;
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
            _temphit = true;
        }

        if (!_temphit || hit) return;
        StartCoroutine(Ring());
        _temphit = false;
        print(_currentRound);

    }

    private IEnumerator Ring()
    {
        //TODO match timing to animations
        while (_currentRound<5)
        {
            _bellRing.Play();
            yield return new WaitForSeconds(0.03f);
            Strike();
            roundCount.SetCombat(true);
            yield return new WaitForSeconds(0.28f);
            Reset();
            roundCount.SetCurrentRound(_currentRound+1);
            yield return new WaitForSeconds(0.28f);
        }
    }

    void Strike()
    {
        transform.rotation = Quaternion.Euler(0, 0, -10);
    }

    void Reset()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
    }
}
