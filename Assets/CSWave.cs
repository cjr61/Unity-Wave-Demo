﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CSWave : MonoBehaviour {

    public GameObject diver;
    float waveHeight = 2.0f; 
    float waveSpeed = 5.0f; 
    float waveFrequency = 1.0f;
    float waterHeight = 0f;
    int accuracy = 20;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
        UpdateWave();
	}

    void UpdateWave()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] verts = mesh.vertices;


        float offset;

        for (int i = 0; i < accuracy; i++)
        {
            offset = waveHeight * Mathf.Cos((Time.time * waveSpeed) + (i * waveFrequency));

            verts[i].y = waterHeight + offset;
        }
        //for (var v = 0; v < verts.Length; v++) {
        ////verts[v].y = Random.Range(0,10);
        //    //double r = Math.Sqrt()
        //    //verts.[v].y = Math.E-
        //}
        mesh.vertices = verts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 entryPoint = diver.transform.position;
        float x0 = entryPoint.x;
        float y0 = entryPoint.y;
        float z0 = entryPoint.z;
    }
}


/*
y(r,t) = A e-r-at cos(2π (r-Vt) /λ);

r = sqrt ((x-x0)*(x-x0)+ (z-z0)*(z-z0))
P0(x0, y0, z0) : center of the wave 
A: amplitude of the wave
V: velocity of the wave
λ: wave length of the wave
a: speed of decaying
t = current time – time of impact (t0)

*/