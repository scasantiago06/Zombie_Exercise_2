using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour                                                                          //Esto es una clase que tiene algunas variables y un constructor.
{
    public struct CitizenStruct
    {
        public string randomName;
        public int age;
    }

    private void Start()
    {
        gameObject.tag = "Citizen";
    }
}
