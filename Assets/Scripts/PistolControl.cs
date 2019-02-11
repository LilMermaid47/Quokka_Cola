using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolControl : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawnPoint;
    [SerializeField]
    GameObject bullet;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Instantiate(bullet, bulletSpawnPoint.transform);
        }
    }
}
