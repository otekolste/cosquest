// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Shooting : MonoBehaviour
// {
//     public GameObject shootingItem;
//     public Transform shootingPoint;
//     public bool canShoot = true;
//     public bool canShootDelay = true;

//     private void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.Return)){
//             Shoot();
//         }
//     }

//     void Shoot(){
//         if(!canShoot){
//             return;
//         }
//         GameObject si = Instantiate(shootingItem, shootingPoint);
//         si.transform.parent = null;
//     }

// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;
    public float shootDelay = 0.5f;
    public bool canShootDelay = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (canShoot && canShootDelay)
            {
                StartCoroutine(ShootWithDelay());
            }
        }
    }

    IEnumerator ShootWithDelay()
    {
        canShootDelay = false;
        Shoot();
        yield return new WaitForSeconds(shootDelay);
        canShootDelay = true;
    }

    void Shoot()
    {
        GameObject si = Instantiate(shootingItem, shootingPoint);
        si.transform.parent = null;
    }
}

