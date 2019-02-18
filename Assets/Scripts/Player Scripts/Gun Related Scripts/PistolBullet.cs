using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    [SerializeField]
    float firingSpeed = 50;

    Vector3 firingDirection;
    bool targetFound = false;
    // Update is called once per frame
    void Update()
    {
        if(targetFound)
        {
            Destroy(gameObject, 5);
            transform.Translate(firingDirection);
        }
    }

    public void FindTarget(Vector3 rotation, float firingOffset)
    {
        firingDirection.x = Mathf.Cos(rotation.normalized.y+firingOffset);
        firingDirection.z = Mathf.Sin(rotation.normalized.y);
        targetFound = true;
    }
}
