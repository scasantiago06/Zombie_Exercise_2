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
    ZombieStruct zombieStruct;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            zombieStruct.randomPart = Random.Range(0, (int)BodyPart.length);
            zombieStruct.bodyPart = (BodyPart)zombieStruct.randomPart;
            print("Waaaarrrr i want to eat " + zombieStruct.bodyPart);
        }
        if (collision.gameObject.CompareTag("Citizen"))
        {

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