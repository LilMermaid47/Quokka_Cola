using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField]
    float maxPiercing;
    [SerializeField]
    float vitesseProjectile;

    Vector3 firingDirection;
    bool targetFound = false;

    void Update()
    {
        if(targetFound)
        {
            Destroy(gameObject, 5);
            transform.Translate(firingDirection);
        }
    }

    public void findTarget(Vector3 gunPosition)
    {
        Debug.LogWarning("Firing doesn't yet work properly - PistolBullet.cs(24)");
        firingDirection = (transform.position - gunPosition).normalized;
        targetFound = true;
    }
}
