using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Transform player, opponent;
    private LineRenderer _line;
    // Start is called before the first frame update
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.startWidth = 0.2f;
        _line.endWidth = 0.2f;
        _line.startColor = Color.black;
        _line.endColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = player.position;
        var oppPos = opponent.position;
        _line.SetPosition(0,playerPos);
        _line.SetPosition(1,oppPos);
        var dist = Vector2.Distance(playerPos, oppPos);
        _line.startWidth = 0.4f / dist; 
        _line.endWidth = 0.4f / dist; 
    }
}
