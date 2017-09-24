using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public Vector3 Center;
    public Vector3 PlayerGravityDirection;
    public float GravitationalForce = 10f;

    private Transform _player;

	void Start ()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update ()
    {
        Center = transform.position;
        PlayerGravityDirection = (Center - _player.position).normalized;
	}
}
