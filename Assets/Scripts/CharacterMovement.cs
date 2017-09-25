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

        //We can do it with just trigonometry later
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
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (Mathf.Abs(inputX) > 0.01f || Mathf.Abs(inputY) > 0.01f)
        {
            //Angle between inputs
            float angle = Mathf.Atan2(-1 * inputX, inputY) * Mathf.Rad2Deg;
           
            //If we want to move depends on where player looks
            //Vector3 vector = Quaternion.AngleAxis(angle, World.PlayerGravityDirection) * transform.forward;

            //If we want to move depends on screen positions
            Vector3 vector = Quaternion.AngleAxis(angle, World.PlayerGravityDirection) * Camera.main.transform.up;

            //Cross Product
            Vector3 rotationAxis = new Vector3(
                vector.y * World.PlayerGravityDirection.z - vector.z * World.PlayerGravityDirection.y,
                vector.z * World.PlayerGravityDirection.x - vector.x * World.PlayerGravityDirection.z,
                vector.x * World.PlayerGravityDirection.y - vector.y * World.PlayerGravityDirection.x).normalized;

            transform.RotateAround(World.Center, rotationAxis, MovementSpeed);
        }
    }
}
