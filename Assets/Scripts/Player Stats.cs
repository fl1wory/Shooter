using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "Player",menuName = "Objects")]
public class PlayerStats : ScriptableObject
{
    [Header("Player")]
    [SerializeField] private float _health;
    [SerializeField] private int _dashCount;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [Header("Guns and PowerUps")]
    [SerializeField] private GameObject[] _powerUps;
    [SerializeField] private GameObject[] _guns;

    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public int DashCount
    {
        get { return _dashCount; }
        set { _dashCount = value; }
    }
    public float JumpForce
    {
        get { return _jumpForce; }
        set { _jumpForce = value; }
    }
    public GameObject[] PowerUps
    {
        get { return _powerUps; }
        set { _powerUps = value; }
    }
    public GameObject[] Guns
    {
        get { return _guns; }
        set { _guns = value; }

    }
}
