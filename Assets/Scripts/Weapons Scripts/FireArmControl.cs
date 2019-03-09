using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireArmControl : MonoBehaviour
{
    [SerializeField]
    public Transform bulletSpawnPoint;
    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    public float fireRate;

    public float timer { get; set; } = 1;
    protected GameObject instantiatedBullet;

    public virtual void Update()
    {
        if (Input.GetMouseButton(1)) { Fire(); }
        if (Input.GetKeyDown(KeyCode.E)) { Reload(); }
    }

    public abstract void Fire();
    public abstract void Reload();
}
