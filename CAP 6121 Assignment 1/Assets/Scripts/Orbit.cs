using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Orbit : MonoBehaviour {
    GameObject target;
    string targetName = "Player";

    // Leave these public as we can change them in the inspector for debugging purpose.
    public Transform center;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    // For changing the orbit direction at random.
    public int count = 0;
    public int countMax = 100;
    System.Random rnd = new System.Random();
    public int min = 100;
    public int max = 300;


	// Use this for initialization
	void Start () {
        // Find the Player Game Object with the Tag: "Player".
        target = GameObject.FindWithTag(targetName);
        // Get the target transformation
        center = target.transform;
        // Set this object's inital position to be a certain distance away from the target.
        transform.position = (transform.position - center.position).normalized * radius + center.position;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        /*
         * Check if a certain number clicks reach the threshold, then negate the
         * roatation speed to reverse the direction a new random threshold. 
         */
        if(count >= countMax){
            rotationSpeed *= -1;
            count = 0;
            countMax = rnd.Next(min, max);
        }
        // Rotate this object about the target.
        transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
        // Calculate the correct position the orbiting object needs to be from the target.
        desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        // Use the desired position to move this object.
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        count++;
	}
}
