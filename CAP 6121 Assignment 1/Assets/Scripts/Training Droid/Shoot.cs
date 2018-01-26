using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform laserSpawn;
    public int count = 0;
    public int countMax = 100;
    System.Random rnd = new System.Random();
    public int min = 100;
    public int max = 300;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (count >= countMax)
        {
            Fire();
            count = 0;
            countMax = rnd.Next(min, max);
        }
        count++;
    }

    void Fire()
    {
        var laser = GameObject.Instantiate(laserPrefab, laserSpawn.position, laserSpawn.rotation);

        laser.GetComponent<Rigidbody>().velocity = laser.transform.forward * 6;

        Destroy(laser, 2.0f);
    }


}
