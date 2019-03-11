using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuilderScript : MonoBehaviour
{
    [SerializeField]
    float fleeDistance=10;

    [SerializeField]
    float fleeRandomMin = 10;
    [SerializeField]
    float fleeRandomMax = 20;

    [SerializeField]
    float randomMinTimeForNewBuilding = 10;
    [SerializeField]
    float randomMaxTimeForNewBuilding = 35;

    [SerializeField]
    float buildRayon=2;

    public UnityEngine.Object usine;

    private Transform playerTransform;
    private NavMeshAgent builderAgent;
    private Transform builderTransform;
    private Transform startingTransform;
    private bool canBuild = false;
    private float resetBuildingTime;
    private float time=0;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        builderAgent = this.GetComponent<NavMeshAgent>();
        builderTransform = this.GetComponent<Transform>();
        resetBuildingTime = UnityEngine.Random.Range(randomMinTimeForNewBuilding, randomMaxTimeForNewBuilding);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(playerTransform.position, builderTransform.position);
        if (distance <= fleeDistance)
        {
            Debug.Log("fleeing");
            flee();
        }
        else
        {
            if (canBuild)
            {
                canBuild = false;
                Build();
                RandomPositionMovement();
            }
            else
            {   
                time += Time.deltaTime;

                if (time >= resetBuildingTime)
                {
                    time = 0;
                    canBuild = true;
                }
            }
        }
    }
    /// <summary>
    /// Place un batiment où est situé le builder
    /// </summary>
    private void Build()
    {
        Instantiate(usine, transform.position, Quaternion.identity);
    }
    /// <summary>
    /// Génère une position au hasard pour éloigner le builder
    /// </summary>
    private void RandomPositionMovement()
    {
        float randomBuildX = UnityEngine.Random.Range(0, buildRayon);
        float randomBuildZ = UnityEngine.Random.Range(0, buildRayon);
        Vector3 randomPosition = (new Vector3(randomBuildX, randomBuildZ));
        builderAgent.SetDestination(this.transform.position + randomPosition);
    }
    /// <summary>
    /// Fait que le builder s'enfuit du joueur
    /// </summary>
    void flee()
    {
        startingTransform = transform;
        transform.rotation = Quaternion.LookRotation(transform.position - playerTransform.position);
        Vector3 fleePosition = transform.position + transform.forward * UnityEngine.Random.Range(fleeRandomMin,fleeRandomMax);
        NavMeshHit hit;

        NavMesh.SamplePosition(fleePosition, out hit, 5, 1 << NavMesh.GetAreaFromName("Walkable"));

        transform.position = startingTransform.position;
        transform.rotation = startingTransform.rotation;

        builderAgent.SetDestination(hit.position);
    }
}
