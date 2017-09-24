using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public World World;
    public float MovementSpeed;

	void Update ()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        //Vector3 lookingDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0)).normalized;
        //lookingDirection = (((lookingDirection.x * transform.forward.x) + (lookingDirection.y * transform.forward.y) + (lookingDirection.z * transform.forward.z)) * transform.forward);
        //Vector3 currentLookingDir = transform.forward.normalized;
        //Debug.Log(lookingDirection);
        //transform.LookAt(transform.position + new Vector3(lookingDirection.x, 0, lookingDirection.y));
        //float angle = Mathf.Acos((lookingDirection.x * currentLookingDir.x + lookingDirection.y * currentLookingDir.z));
        //transform.Rotate(World.PlayerGravityDirection, angle);

        //Vector3 lookingDirection = Camera.main.ScreenPointToRay(Input.mousePosition).origin - Camera.main.ScreenPointToRay(Input.mousePosition).direction * Camera.main.nearClipPlane;
        //Vector3 res = (lookingDirection + (transform.position - Camera.main.transform.position));
        //Debug.Log(res.x + " " + res.y + " "+ res.z);
        //transform.LookAt(res);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        if(hit.collider != null && hit.collider.name == "MouseTracker")
        {
            transform.LookAt(hit.point, transform.up);
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Cross Product
            Vector3 rotationAxis = new Vector3(transform.forward.y * World.PlayerGravityDirection.z - transform.forward.z * World.PlayerGravityDirection.y,
                                                transform.forward.z * World.PlayerGravityDirection.x - transform.forward.x * World.PlayerGravityDirection.z,
                                                transform.forward.x * World.PlayerGravityDirection.y - transform.forward.y * World.PlayerGravityDirection.x).normalized;

            transform.RotateAround(World.Center, rotationAxis, MovementSpeed);
        }
    }
}
