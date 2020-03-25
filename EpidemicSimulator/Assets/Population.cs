using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    BallScript[] persons;

    public int numPersons;
    public int numInfected;
    public int numFrozen;
    public GameObject personPrefab;

    // Start is called before the first frame update
    void Start()
    {
        persons = new BallScript[numPersons];

        for (int i = 0; i < numPersons; i++){
            Vector3 position = new Vector3(1, -0.3f, 1);
            while(Physics.OverlapSphere(position, personPrefab.transform.localScale.x/2).Length > 0){
                position = new Vector3(Random.value * 20, 0, Random.value * 20);
            }
            GameObject personClone = Instantiate(personPrefab, position, Quaternion.identity);
            persons[i] = personClone.GetComponent<BallScript>();

            if (i < numInfected){
                persons[i].healthy = false;
                persons[i].infected = true;
            }
            else {
                persons[i].healthy = true;
                persons[i].infected = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
