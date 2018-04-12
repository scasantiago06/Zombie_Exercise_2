using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public struct HeroStruct
    {
        public float speedHero;
        public Vector3 positionHero;
        public GameObject cam;
    }

    public HeroStruct heroStruct;
    public ZombieStruct zombieStruct_H;
    public CitizenStruct citizenStruct_H;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            zombieStruct_H.randomPart = Random.Range(0, (int)BodyPart.length);
            zombieStruct_H.bodyPart = (BodyPart)zombieStruct_H.randomPart;
            print("Waaaarrrr i want to eat " + zombieStruct_H.bodyPart);
        }
        if (collision.gameObject.CompareTag("Citizen"))
        {
            print("Hello, i am " + citizenStruct_H.randomName + " and i am " + citizenStruct_H.age + " years old.");
        }
    }

    void Start()
    {
        heroStruct.speedHero = Random.Range(0.02f, 0.1f);
        heroStruct.positionHero = gameObject.transform.position;

        heroStruct.cam = GameObject.FindGameObjectWithTag("MainCamera");
        heroStruct.cam.transform.position = new Vector3(heroStruct.positionHero.x, heroStruct.positionHero.y + 1, heroStruct.positionHero.z);
        heroStruct.cam.transform.SetParent(gameObject.transform);

        gameObject.name = "Hero";
        gameObject.tag = "Player";

        gameObject.AddComponent<FPSMove>().speed = heroStruct.speedHero;
        heroStruct.cam.AddComponent<FPSAim>();
    }
}