using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringControl : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawnPoint;
    [SerializeField]
    GameObject bullet;

    public float firingOffset { get; set; }
    public float fireRate { get; set; }
    public float timer { get; set; }
    GameObject instantiatedBullet;
    private void Start()
    {
        firingOffset = 19.4f;
        fireRate = bullet.GetComponent<BulletControl>().firingSpeed;
        timer = 1;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(1))
        {
            if(timer > fireRate)
            {
                instantiatedBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
                BulletControl bulletScript = instantiatedBullet.GetComponent<BulletControl>();
                bulletScript.FindTarget(transform.eulerAngles, firingOffset);
                timer = 0;
            }
        }
    }
}
