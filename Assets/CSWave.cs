using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CSWave : MonoBehaviour {

    public GameObject diver;
    public float amplitude=1;
    public float wavelength=1;
    public float velocity=1;
    public float rateOfDecay=.5f;

    Vector3 entryPoint;
    bool showWave = false;
    float impactTime;
    float t;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
        if (showWave)
            UpdateWave();
	}

    void UpdateWave()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] verts = mesh.vertices;

        for (var v = 0; v < verts.Length; v++) {
            float r = Mathf.Sqrt(Mathf.Pow(verts[v].x - entryPoint.x, 2) + Mathf.Pow(verts[v].z - entryPoint.z, 2));
            float currentTime = Time.time;
            t = currentTime - impactTime;

            float height = amplitude * Mathf.Exp((r * -1) - rateOfDecay * t) * Mathf.Cos(2 * Mathf.PI * (r - velocity * t) / wavelength);

            verts[v].y = height;
        }
        mesh.vertices = verts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    private void OnTriggerEnter(Collider other)
    {
        impactTime = Time.time;
        entryPoint = diver.transform.position;
        showWave = true;
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