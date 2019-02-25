using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolControl : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawnPoint;
    [SerializeField]
    GameObject bullet;

    float firingOffset = 19.4f;
    float fireRate = 0.25f; 
    float timer = 1;
    GameObject instantiatedBullet;

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            timer += Time.deltaTime;
            if(timer > fireRate)
            {
                instantiatedBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
                PistolBullet bulletScript = instantiatedBullet.GetComponent<PistolBullet>();
                bulletScript.FindTarget(transform.eulerAngles, firingOffset);
                timer = 0;
            }
        }
    }
}
