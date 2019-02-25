using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField]
    GameObject Pistol;
    [SerializeField]
    GameObject Rifle;
    [SerializeField]
    GameObject Sniper;

    [Header("Required Fields")]
    [SerializeField]
    Transform weaponSpawnPoint;
    [SerializeField]
    Transform playerCamera;

    GameObject spawnedWeapon;
    bool hasGun = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SpawnWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SpawnWeapon(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SpawnWeapon(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SpawnWeapon(4);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SpawnWeapon(5);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SpawnWeapon(6);
        if (Input.GetKeyDown(KeyCode.Alpha7)) SpawnWeapon(7);
        if (Input.GetKeyDown(KeyCode.Alpha8)) SpawnWeapon(8);
        if (Input.GetKeyDown(KeyCode.Alpha9)) SpawnWeapon(9);
        if (Input.GetKeyDown(KeyCode.Alpha0)) SpawnWeapon(0);
    }

    void SpawnWeapon(int keyPressed)
    {
        if(hasGun)
        {
            Destroy(spawnedWeapon);
            InstantiateWeapon(keyPressed);
        }
        else
        {
            InstantiateWeapon(keyPressed);
            hasGun = true;
        }
    }
    void InstantiateWeapon(int keyPressed)
    {
        switch(keyPressed)
        {
            case 1:
                spawnedWeapon = Instantiate(Pistol, weaponSpawnPoint.position, transform.rotation);
                spawnedWeapon.transform.SetParent(transform, true);
                break;
            case 2:
                spawnedWeapon = Instantiate(Rifle, weaponSpawnPoint.position, transform.rotation);
                spawnedWeapon.transform.SetParent(transform, true);
                break;
            case 3:
                spawnedWeapon = Instantiate(Sniper, weaponSpawnPoint.position, transform.rotation);
                spawnedWeapon.transform.SetParent(transform, true);
                break;
            case 0:
                Destroy(spawnedWeapon);
                hasGun = false;
                break;
        }
    }
}
