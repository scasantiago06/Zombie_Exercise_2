using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour                                                                               //La clase "Zombie" que contiene unas variables y el constructor.
{
    public struct ZombieStruct
    {
        public WaitForSeconds timeBehaviourChange;
        public int randomPart;
        public int randomColor;
        public int randomBehaviour;
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

    public ZombieStruct zombieStruct;

    private void Start()
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

    IEnumerator ChangeBehaviour(ZombieStruct zom)
    {
        zom.randomBehaviour = Random.Range(0, 2);
        zom.zombieBehaviour = (Zombiebehaviour)zom.randomBehaviour;
  
        if (zom.zombieBehaviour == Zombiebehaviour.Idle)
        {
            print("Quieto");
        }
        else if (zom.zombieBehaviour == Zombiebehaviour.Moving)
        {
            print("Me muevo");
        }
        yield return zom.timeBehaviourChange;
        StartCoroutine("ChangeBehaviour", zom);
    }
}