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
    [SerializeField]
    GameObject LanceDisque;
    [SerializeField]
    GameObject Weapon5;
    [SerializeField]
    GameObject Weapon6;
    [SerializeField]
    GameObject Weapon7;
    [SerializeField]
    GameObject Weapon8;
    [SerializeField]
    GameObject Weapon9;

    [Header("Required Fields")]
    [SerializeField]
    Transform weaponSpawnPoint;
    [SerializeField]
    Transform playerCamera;

    GameObject spawnedWeapon;
    bool hasGun = false;

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
            case 4:
                spawnedWeapon = Instantiate(LanceDisque, weaponSpawnPoint.position, transform.rotation);
                spawnedWeapon.transform.SetParent(transform, true);
                break;
            case 5:
                spawnedWeapon = Instantiate(Weapon5, weaponSpawnPoint.position, transform.rotation);
                spawnedWeapon.transform.SetParent(transform, true);
                break;
            case 6:
                spawnedWeapon = Instantiate(Weapon6, weaponSpawnPoint.position, transform.rotation);
                spawnedWeapon.transform.SetParent(transform, true);
                break;
            case 7:
                spawnedWeapon = Instantiate(Weapon7, weaponSpawnPoint.position, transform.rotation);
                spawnedWeapon.transform.SetParent(transform, true);
                break;
            case 8:
                spawnedWeapon = Instantiate(Weapon8, weaponSpawnPoint.position, transform.rotation);
                spawnedWeapon.transform.SetParent(transform, true);
                break;
            case 9:
                spawnedWeapon = Instantiate(Weapon9, weaponSpawnPoint.position, transform.rotation);
                spawnedWeapon.transform.SetParent(transform, true);
                break;
            case 0:
                Destroy(spawnedWeapon);
                hasGun = false;
                break;
        }
    }
}
