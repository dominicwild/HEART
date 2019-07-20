﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithCameraDistanceSmooth : MonoBehaviour {

	public Camera cam;
	public float objectScale = 1.0f;
	private Vector3 initialScale;
    public float rateOfGrowth = 0.01f;
    private float growth = 0f;

	// set the initial scale, and setup reference camera
	void Start ()
	{
		// record initial scale, use this as a basis
		initialScale = transform.localScale;

		// if no specific camera, grab the default camera
		if (cam == null)
		{
			cam = Camera.main;
		}
	}

	// scale object relative to distance from camera plane
	void Update () {
        if(growth >= 1) {
            growth = 1;
        } else {
            growth += rateOfGrowth;
        }

		Plane plane = new Plane(cam.transform.forward, cam.transform.position);
		float dist = plane.GetDistanceToPoint(transform.position);
		transform.localScale = initialScale * dist * objectScale * rateOfGrowth;
	}
}
