using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField]
    GameObject pistol;

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
                spawnedWeapon = Instantiate(pistol, weaponSpawnPoint.position, transform.rotation);
                spawnedWeapon.transform.SetParent(transform, true);
                break;
            case 2:
                break;
            case 4:
                break;
            case 5:
                break;//La ou il faudra mettre les prochaines armes
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 0:
                Destroy(spawnedWeapon);
                hasGun = false;
                break;
        }
    }
}
