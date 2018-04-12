using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CitizenStruct
{
    public int randomName;
    public int age;
}

public class Citizen : MonoBehaviour                                                                          //Esto es una clase que tiene algunas variables y un constructor.
{

    CitizenStruct citizenStruct;

    string[] names = new string[]                                                                               //Creo una matriz donde guardo en las próximas dos líneas 20 nombres para después acceder a ellos.
    {
        "Stubbs", "Rob", "Rodolfo", "Arnulfo", "Jesús", "Cristian", "Santiago", "Alonso", "Dios", "Samuel",     //En esta línea y la siguiente esta la lista de nombres que se utilizarón
        "Ricardo", "José", "Armando", "Luna", "María", "Mónica", "Manuela", "Cristobal", "Furgo", "Andrés"      //para darle nombres a los ciudadanos.
    };

    private void Start()
    {
        citizenStruct.randomName = Random.Range(0, 21);
        citizenStruct.age = Random.Range(15, 101);
        gameObject.tag = "Citizen";
        gameObject.name = names[citizenStruct.randomName];
    }
}
