using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    Camera camera;

    [Header("Wave information")]
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    int amountPerWave = 5;
    [SerializeField]
    int xBorder = 5;
    [SerializeField]
    int zBorder = 5;

    RaycastHit hit;

    /// <summary>
    /// Lorsque le joueur fait un clic gauche, un ray est envoyé dans la direction du curseur, is quelque chose est touché,
    /// la méthode SpawnWave est appelée.
    /// </summary>
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0)) // clic gauche
        {
            if (amountPerWave > xBorder * zBorder)
            {
                Debug.LogError("Can't spawn that many objects in that perimeter");
                return;
            }
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                SpawnWave();
                //Instantiate(enemyPrefab, hit.point + ((camera.transform.position - hit.point).normalized * 2), Quaternion.identity);
            }
        }

    }

    /// <summary>
    /// Crée une liste de toute les positions possibles pour faire apparaitre un objet, puis choisi aléatoirement une position
    /// pour chacun des objets, qui est ensuite envoyée à la méthode SpawnEnemy()
    /// </summary>
    public void SpawnWave()
    {
        int spawnLocation;
        List<Vector3> availableSpawnPoints = new List<Vector3>(xBorder * zBorder);
        for (int i = 0; i < xBorder; i++)
        {
            for (int j = 0; j < zBorder; j++)   
            {
                availableSpawnPoints.Add(new Vector3(i, 0, j));
            }
        }
        for (int i = 0; i < amountPerWave; i++)
        {
            spawnLocation = Random.Range(0, availableSpawnPoints.Count);
            SpawnEnemy(availableSpawnPoints[spawnLocation]);
            availableSpawnPoints.RemoveAt(spawnLocation);
        }
    }

    /// <summary>
    /// Modifie la position pour la centrer, puis tire un ray pour déterminer si l'objet va apparaitre dans un objet déjà existant,
    /// si c'est le cas, augmente la position en Y (hauteur) du cube jusqu'à ne plus être en conflit avec les objets de la scène.
    /// </summary>
    /// <param name="position">position brute du cube, sans prendre en compte la position du curseur ni le terrain</param>
    public void SpawnEnemy(Vector3 position)
    {
        bool rayCollidedWithSomething = true;
        Vector3 borderOffset = new Vector3(-xBorder / 2, 2, -zBorder / 2);
        Vector3 spawnPosition = borderOffset + position;

        RaycastHit localHit;
        Ray ray = new Ray(spawnPosition + new Vector3(0, 2, 0), Vector3.down);
        while (rayCollidedWithSomething)
        {
            if (Physics.Raycast(ray, out localHit, 4))
            {
                spawnPosition += new Vector3(0, 2, 0);
            }
            else
                rayCollidedWithSomething = false;
            ray = new Ray(spawnPosition + new Vector3(0, 2, 0), Vector3.down);
        }
        Instantiate(enemyPrefab, spawnPosition + hit.point, Quaternion.identity);
    }
}
