using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravGunControl : FireArmControl
{
    public override void Fire()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            
        }
    }

    public override void Reload()
    {
        if (AimingAtEnemy())
        {

        }
    }

    protected bool AimingAtEnemy()
    {
        
        return false;
    }
}
