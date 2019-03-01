using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject player;
    Vector3 position;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        position = player.transform.position;
        navMeshAgent.SetDestination(position);
    }
}
