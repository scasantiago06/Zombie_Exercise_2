using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour                                                                               //La clase "Zombie" que contiene unas variables y el constructor.
{
    public ZombieStruct zombieStruct;

    void Start()
    {
        gameObject.name = "Zombie";
        gameObject.tag = "Zombie";

        zombieStruct.timeBehaviourChange = new WaitForSeconds(5f);
        zombieStruct.randomColor = Random.Range(0, 3);
        zombieStruct.randomPart = Random.Range(0,(int)BodyPart.length);
        zombieStruct.bodyPart = (BodyPart)zombieStruct.randomPart;
        ChangeColor(zombieStruct);
        StartCoroutine("ChangeBehaviour", zombieStruct);
    }

    void Update()
    {
        switch (zombieStruct.zombieBehaviour)
        {
            case Zombiebehaviour.Idle:
                transform.position = transform.position;
                break;
            case Zombiebehaviour.Moving:
                switch (zombieStruct.randomDirection)
                {
                    case 0:
                        transform.position += (transform.forward * 1f) * Time.deltaTime;
                        break;
                    case 1:
                        transform.position -= (transform.forward * 1f) * Time.deltaTime;
                        break;
                    case 2:
                        transform.position += (transform.right * 1f) * Time.deltaTime;
                        break;
                    case 3:
                        transform.position -= (transform.right * 1f) * Time.deltaTime;
                        break;
                }
                break;
        }    
    }

    void ChangeColor(ZombieStruct zom)
    {
        switch (zom.randomColor)
        {
            case 0:
                gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                break;
            case 1:
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 2:
                gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                break;
        }
    }

    void ChooseBehaviour()
    {
        zombieStruct.randomDirection = Random.Range(0, 4);
        zombieStruct.randomBehaviour = Random.Range(0, 2);
        zombieStruct.zombieBehaviour = (Zombiebehaviour)zombieStruct.randomBehaviour;
    }

    IEnumerator ChangeBehaviour()
    {
        ChooseBehaviour();
        yield return zombieStruct.timeBehaviourChange;
        StartCoroutine("ChangeBehaviour");
    }
}

public struct ZombieStruct
{
    public WaitForSeconds timeBehaviourChange;
    public int randomPart;
    public int randomColor;
    public int randomBehaviour;
    public int randomDirection;
    public Color zombieColor;
    public Zombiebehaviour zombieBehaviour;
    public BodyPart bodyPart;
}

public enum Zombiebehaviour
{
    Idle, Moving
}

public enum BodyPart
{
    Brain, Eyes, Legs, Fingers, neck, length
}