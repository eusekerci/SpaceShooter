using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public World World;
    public float MovementSpeed;
    public bool IsControllerActive;

    private Vector3 _lookingDirection;

    void Start()
    {
        _lookingDirection = Vector3.zero;
    }

	void Update ()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        if (IsControllerActive)
        {
            float inputX = Input.GetAxis("Joy X");
            float inputY = Input.GetAxis("Joy Y");

            if (!(Mathf.Abs(inputX) > 0.01f) && !(Mathf.Abs(inputY) > 0.01f))
                return;
            _lookingDirection = new Vector3(inputX, inputY, 0.0f).normalized;
        }
        else
        {
            _lookingDirection = (Input.mousePosition - new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f)).normalized;
        }
                                                
        //Finally a great solution
        float angle = Mathf.Atan2(_lookingDirection.x, _lookingDirection.y) * Mathf.Rad2Deg;
        transform.LookAt(
            Quaternion.AngleAxis(-1 * angle, World.PlayerGravityDirection) * Camera.main.transform.up +
            transform.position - World.Center, -1 * World.PlayerGravityDirection);
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (!(Mathf.Abs(inputX) > 0.01f) && !(Mathf.Abs(inputY) > 0.01f))
            return;

        //Angle between inputs
        float angle = Mathf.Atan2(-1 * inputX, inputY) * Mathf.Rad2Deg;
           
        //If we want to move depends on where player looks
        //Vector3 vector = Quaternion.AngleAxis(angle, World.PlayerGravityDirection) * transform.forward;

        //If we want to move depends on screen positions
        Vector3 vector = Quaternion.AngleAxis(angle, World.PlayerGravityDirection) * Camera.main.transform.up;

        Vector3 rotationAxis = Vector3.Cross(vector, World.PlayerGravityDirection);

        transform.RotateAround(World.Center, rotationAxis, MovementSpeed);
    }
}
