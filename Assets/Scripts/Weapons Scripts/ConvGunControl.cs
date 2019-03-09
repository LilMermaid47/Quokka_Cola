using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvGunControl : FireArmControl
{
    public override void Fire()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            instantiatedBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
            BulletControl bulletScript = instantiatedBullet.GetComponent<BulletControl>();
            bulletScript.findTarget(bulletSpawnPoint.localPosition);
            timer = 0;
        }
    }

    public override void Reload()
    {

    }
}
