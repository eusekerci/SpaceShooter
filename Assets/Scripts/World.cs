using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public Vector3 Center;
    public Vector3 PlayerGravityDirection;
    public float Radius;
    public float GravitationalForce = 10f;

    private Transform _player;

	void Start ()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        Center = transform.position;
        Radius = transform.localScale.x / 2.0f;
    }
	
	void Update ()
    {
        PlayerGravityDirection = (Center - _player.position).normalized;
    }
}
