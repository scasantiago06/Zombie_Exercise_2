using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour                                                   //La clase "Hero", que contiene el constructor.
{
    /*
    public Hero()                                                           //Este es el contructor de "Hero" en donde se ponen los atributos.
    {
        GameObject he = GameObject.CreatePrimitive(PrimitiveType.Cube);     //Esta línea se encarga de generar un cubo y guardarlo en la variable "he".
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");    //Aquí vamos a encontrar un objeto que tenga el tag de "MainCamera", en ese momento se guarda ese objeto encontrado en "cam".

        he.AddComponent<FPSMove>();                                         //Al "he" le añadimos el script "FPSMove" para poder mover al cubo almacenado en "he".
        cam.AddComponent<FPSAim>();                                         //A la cámara guardada en "cam" le agregamos el componente "FPSAim" para mover la cámara.

        cam.transform.position = new Vector3(0,1,0);                        //Le damos ubicación a "cam" con el "Vector3".
        cam.transform.SetParent(he.transform);                              //Y por último la cámara la hacemos hija del cubo en "he" para que se mueva junto con el este.
    }
    */
    public struct HeroStruct
    {
        public float speedHero;
        public Vector3 positionHero;
        public GameObject cam;
    }

    public HeroStruct heroStruct;
    Zombie zo = new Zombie();

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            zo.zombieStruct.randomPart = Random.Range(0, (int)Zombie.BodyPart.length);
            zo.zombieStruct.bodyPart = (Zombie.BodyPart)zo.zombieStruct.randomPart;
            print("Waaaarrrr i want to eat " + zo.zombieStruct.bodyPart);
        }
        if (collision.gameObject.CompareTag("Citizen"))
        {

        }
    }

    void Start()
    {
        heroStruct.speedHero = Random.Range(1, 5);
        heroStruct.positionHero = gameObject.transform.position;

        heroStruct.cam = GameObject.FindGameObjectWithTag("MainCamera");
        heroStruct.cam.transform.position = new Vector3(heroStruct.positionHero.x, heroStruct.positionHero.y + 1, heroStruct.positionHero.z);
        heroStruct.cam.transform.SetParent(gameObject.transform);

        gameObject.name = "Hero";
        gameObject.tag = "Player";

        gameObject.AddComponent<FPSMove>();
        heroStruct.cam.AddComponent<FPSAim>();
    }
}