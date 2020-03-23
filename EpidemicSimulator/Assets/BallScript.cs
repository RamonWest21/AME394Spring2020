using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public bool healthy;
    public bool infected;
    public bool frozen;

    Vector3[] originalVertices;
    Vector3[] spikyVertices;

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        originalVertices = meshFilter.mesh.vertices;

        spikyVertices = new Vector3[originalVertices.Length];

        for (int i = 0; i < spikyVertices.Length; i++) {
            spikyVertices[i] = originalVertices[i] * Random.value;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (healthy) {
            meshRenderer.material.color = new Color(0.3f, 0.3f, 1);
            meshFilter.mesh.vertices = originalVertices;

        }

        else if (infected){
            meshRenderer.material.color = new Color(1, 0.3f, 0.3f);
            meshFilter.mesh.vertices = spikyVertices;

        }

        else {
            meshRenderer.material.color = new Color(0.3f, 1, 0.3f);
            meshFilter.mesh.vertices = originalVertices;

        }
    }
}
