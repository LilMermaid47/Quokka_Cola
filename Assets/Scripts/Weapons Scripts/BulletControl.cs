using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField]
    int maxPierce = 1;

    Vector3 firingDirection;
    bool targetFound = false;
    int pierce = 0;

    void Update()
    {
        transform.Translate(firingDirection);
        if(pierce == maxPierce) { Destroy(gameObject); }
    }

    public void FindTarget(Vector3 relativeSpawnPoint)
    {
        firingDirection = (relativeSpawnPoint).normalized;
        targetFound = true;
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        pierce += 1;
        if (collision.collider.tag == "Ground")
            Destroy(gameObject);
    }
}
