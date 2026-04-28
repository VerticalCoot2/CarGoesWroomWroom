using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] List<Transform> wheelMesh = new List<Transform>();
    [SerializeField] List<WheelCollider> wheelCol = new List<WheelCollider>();

    [SerializeField] float acceleration;
    [SerializeField] float breakForce;
    [SerializeField] float maxTurningAngle;

    float curAcceleration = 0;
    float curBreakForce = 0;
    float curTurningAngle = 0;

    private void Awake()
    {
        foreach(Transform wheel in transform.GetChild(2))
        {
            wheelMesh.Add(wheel);
        }

        Transform holder = transform.GetChild(3);
        for(int i = 0; i < holder.childCount;i++)
        {
            wheelCol.Add(holder.GetChild(i).GetComponent<WheelCollider>());
            wheelCol[i].gameObject.transform.position = wheelMesh[i].position;
        }


        acceleration = 1000;
        breakForce = 1000;
        maxTurningAngle = 40;
    }
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        curAcceleration = acceleration * Input.GetAxis("Vertical");
        curTurningAngle = maxTurningAngle * Input.GetAxis("Horizontal");
        
        curBreakForce = breakForce * Convert.ToByte(Input.GetKey(KeyCode.Space));
        
        for(int i =0; i < 2; i++)
        {
            wheelCol[i].steerAngle = curTurningAngle;

        }
        for (int i = 2; i < 4; i++)
        {
            wheelCol[i].steerAngle = -curTurningAngle/10;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
