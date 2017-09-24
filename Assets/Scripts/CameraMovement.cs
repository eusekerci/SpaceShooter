using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform Player;
    public World World;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.position = Player.position - 10*World.PlayerGravityDirection;
        transform.LookAt(Player, transform.up);
    }
}
