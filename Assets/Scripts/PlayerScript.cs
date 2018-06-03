using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public const float rotationSpeed = 5f;
    public const float acceleration = 4f;
    public const float moveSpeed = 10f;
    private float moveAccSpeed = 0f;

	// Use this for initialization
	void Start () {
        Debug.Log("Init PlayerScript.cs");
	}
	
	// Update is called once per frame
	void Update () {

        MovePlayer();
        RotatePlayer();

    }

    // FixedUpdate is called just before each physics update
    void FixedUpdate ()
    {

    }


    // Move Player
    private void MovePlayer ()
    {
        bool moving;
        if ( Input.GetButton("Horizontal") || Input.GetButton("Vertical") )
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if ( Input.GetButton("Horizontal") )
        {
            transform.Translate( Vector3.right * Input.GetAxis("Horizontal") * moveAccSpeed * Time.deltaTime, Space.World);
        }
        if ( Input.GetButton("Vertical") )
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveAccSpeed * Time.deltaTime, Space.World);
        }
        if ( moving && ( moveAccSpeed < moveSpeed ) )
        {
            moveAccSpeed += acceleration;
        }
        if ( !moving && ( moveAccSpeed >= 0 ) )
        {
            moveAccSpeed -= acceleration;
        }
    }
    // Rotate Player
    private void RotatePlayer ()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.localScale.y / 2));
        direction.y = transform.localPosition.y;
        Quaternion rotation = Quaternion.LookRotation(direction - transform.localPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
