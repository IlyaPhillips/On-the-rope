using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

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
        StartCoroutine(PlayerKnockBack());
    }

    IEnumerator PlayerKnockBack()
    {
        var vecBetween = (transform.position - target.transform.position).normalized;
        // _targetRb.AddForce(vecBetween*2,ForceMode2D.Impulse);
        // yield return new WaitForSeconds(0.1f);
        // _targetRb.AddForce(vecBetween*2,ForceMode2D.Impulse);
        // yield return new WaitForSeconds(0.3f);
        _targetRb.AddForce(vecBetween*5,ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.6f);
        if (!_onEdge)
        {
            _rb.AddForce(knockbackVector,ForceMode2D.Impulse);
        }
        else
        {
            _rb.AddForce(5*knockbackVector,ForceMode2D.Impulse);
            rope.breakForce = 1;
            StartCoroutine(resetScene());
        }

        yield return new WaitForSeconds(0.6f);
        _targetRb.AddForce(new Vector2(0,knockbackVector.y/2),ForceMode2D.Impulse);

    }

    IEnumerator resetScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
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
