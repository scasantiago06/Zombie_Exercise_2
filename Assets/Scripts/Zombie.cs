using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ZombieStruct                                                                                      //Creo la estructura para almacenar las variables del Zombie.
{
    public WaitForSeconds timeBehaviourChange;                                                                  //Creo una variable de tipo "WaitForSeconds" para utilizarlo en la corrutina como el tiempo de espera.
    public int randomColor;                                                                                     //Creo una variable de tipo "int" para determinar según el número, que color será asignado.
    public int randomDirection;                                                                                 //Creo una variable de tipo "int" para determinar según el número que dirección tendrá el zombie.
    public Zombiebehaviour zombieBehaviour;
    public BodyPart bodyPart;
}

public enum Zombiebehaviour
{
    Idle, Moving
}

public enum BodyPart
{
    Brain, Eyes, Legs, Fingers, neck
}

public class Zombie : MonoBehaviour                                                                              
{
    public ZombieStruct zombieStruct_Z;

    /********************************************************************************************************************************Funcion "Start"********************************************************************************************************************************/
    void Start()
    {
        gameObject.name = "Zombie";
        gameObject.tag = "Zombie";

        zombieStruct_Z.timeBehaviourChange = new WaitForSeconds(5f);
        zombieStruct_Z.randomColor = Random.Range(0, 3);
        zombieStruct_Z.bodyPart = (BodyPart)Random.Range(0, 5);
        ChangeColor();
        StartCoroutine("ChangeBehaviour", zombieStruct_Z);
    }

    /*******************************************************************************************************************************Funcion "Update"*******************************************************************************************************************************/
    void Update()
    {
        switch (zombieStruct_Z.zombieBehaviour)
        {
            case Zombiebehaviour.Idle:
                transform.position = transform.position;
                break;

            case Zombiebehaviour.Moving:
                switch (zombieStruct_Z.randomDirection)
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

    /****************************************************************************************************************************Funcion "ChageColor"****************************************************************************************************************************/
    void ChangeColor()
    {
        switch (zombieStruct_Z.randomColor)
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

    /*************************************************************************************************************************Funcion "ChooseBehaviour"*************************************************************************************************************************/
    void ChooseBehaviour()
    {
        zombieStruct_Z.randomDirection = Random.Range(0, 4);
        zombieStruct_Z.zombieBehaviour = (Zombiebehaviour)Random.Range(0, 2);
    }

    public ZombieStruct ZombieMessage()
    {
        return zombieStruct_Z;
    }

    /************************************************************************************************************************Corrutina "ChangeBehaviour"************************************************************************************************************************/
    IEnumerator ChangeBehaviour()
    {
        ChooseBehaviour();
        yield return zombieStruct_Z.timeBehaviourChange;
        StartCoroutine("ChangeBehaviour");
    }
}