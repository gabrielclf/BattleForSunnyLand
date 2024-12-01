using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingSpell : MonoBehaviour
{
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        //logica
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
