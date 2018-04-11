using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassController : MonoBehaviour                                                                    //Esta clase se encarga de hacer las instancias.
{  
    int numberOfCubes;
    int randomComponent;
    bool HeroCreated;
    Vector3 randomPosition;
    Rigidbody rb;

    private void Start()
    {
        numberOfCubes = Random.Range(10, 21);

        for (int i = 0; i <= numberOfCubes; i++)
        {
            randomPosition = new Vector3(Random.Range(0, 30), 0, Random.Range(0, 30));

            if (HeroCreated == false)
            {
                randomComponent = Random.Range(0, 3);
            }
            else
            {
                randomComponent = Random.Range(1, 3);
            }

            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = randomPosition;

            if (randomComponent == 0 && HeroCreated == false)
            {
                go.AddComponent<Hero>();
                go.AddComponent<Rigidbody>();
                rb = go.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                HeroCreated = true;
            }
            else if (randomComponent == 1)
            {
                go.AddComponent<Zombie>();
            }
            else if (randomComponent == 2)
            {
                go.AddComponent<Citizen>();
                go.name = "Citizen";
            }
        }
    }
}