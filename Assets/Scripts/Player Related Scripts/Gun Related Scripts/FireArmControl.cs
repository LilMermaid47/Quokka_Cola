using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArmControl : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawnPoint;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform playerCameraTr;
    [SerializeField]
    float fireRate;

    float timer = 1;
    GameObject instantiatedBullet;

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            timer += Time.deltaTime;
            if(timer >= fireRate)
            {
                instantiatedBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
                BulletControl bulletScript = instantiatedBullet.GetComponent<BulletControl>();
                bulletScript.findTarget(bulletSpawnPoint.localPosition);
                timer = 0;
            }
        }
    }
}
