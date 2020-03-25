using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public bool healthy;
    public bool infected;
    public bool frozen;
    float timeToRecover = 8.0f;

    Vector3[] originalVertices;
    Vector3[] spikyVertices;

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    Rigidbody rbody;

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

        rbody = GetComponent<Rigidbody>();
        rbody.velocity = new Vector3(Random.value - 0.5f, 0, Random.value - 0.5f);
        transform.forward = rbody.velocity;
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
            timeToRecover -= Time.deltaTime;

            if (timeToRecover <= 0) 
            {
                infected = false;
            }
        }


        else {
            meshRenderer.material.color = new Color(0.3f, 1, 0.3f);
            meshFilter.mesh.vertices = originalVertices;

        }

        if (frozen) {
            rbody.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 newVector = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
        rbody.velocity = newVector;
        transform.forward = newVector.normalized;

        BallScript collisionBallScript = collision.gameObject.GetComponent<BallScript>();

        if (collisionBallScript.infected && this.healthy){
            healthy = false;
            infected = true;

        }
    }
}
