using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

    public Transform Player;
    public Vector3 offset;

    void Start ()
    {
        Debug.Log("Init CameraFollowScript.cs");
    }

    // Update is called once per frame
    void Update ()
    {
        transform.position = Player.position + offset;
    }
}
