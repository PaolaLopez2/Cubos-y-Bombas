﻿using UnityEngine;
using System.Collections;

// Simple Rolling Ball Game code - 18 Oct 2015 Daniel Wood
// Add this code to a script called 'move' and then attach the script to a sphere in your game

[RequireComponent(typeof(Rigidbody))]

public class move : MonoBehaviour
{

    public float xForce = 10.0f;
    public float zForce = 10.0f;
    public float yForce = 500.0f;
    public int life = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.life == 0)
        {
            Destroy(gameObject);
        }

        // this is for the X axis' movement (moving left and right)
        float x = 0.0f;

        if (Input.GetKey(KeyCode.A))
        {
            x = x - xForce;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x = x + xForce;
        }

        // this is for the Z axis' movement (moving backwards and forwards)
        float z = 0.0f;

        if (Input.GetKey(KeyCode.S))
        {
            z = z - zForce;
        }

        if (Input.GetKey(KeyCode.W))
        {
            z = z + zForce;
        }

        // this is for the Y axis' movement (jumping)
        float y = 0.0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = createBullet();
        }

        GetComponent<Rigidbody>().AddForce(x, y, z);

        

    }

    private GameObject createBullet()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.GetComponent<Renderer>().material.color = Color.blue;
        go.name = "blue";
        go.transform.position = gameObject.transform.position;
        go.GetComponent<Collider>().isTrigger = true;
        go.GetComponent<Rigidbody>().useGravity = false;
        go.transform.localScale = new Vector3(.2f, .2f, .2f);
        go.AddComponent<Rigidbody>();
        return go;
    }

    private void OnGUI()
    {
        GUILayout.Label("Player" + this.life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "red")
        {
            Destroy(other.gameObject);
            this.life--;
        }
        
    }
}
