using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


/**
 * This component represents an enemy NPC that chases the player.
 */
[RequireComponent(typeof(NavMeshAgent))]
public class Chaser : MonoBehaviour
{

    [Tooltip("The object that this enemy chases after")]
    [SerializeField]
    GameObject player = null;

    [Header("These fields are for display only")]
    [SerializeField] private Vector3 playerPosition;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Target[] targets;

    [SerializeField] private Target t;
    [Tooltip("the delay when you want to cut more time")] [SerializeField] float slow = 4f;
    private float currTime = 0f; // the current time
    [SerializeField] private GameObject player1;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        playerPosition = player.transform.position;
        float distanceToPlayer = Vector3.Distance(playerPosition, transform.position);
        //FacePlayer();
        
        
        if (Time.time > currTime + slow)
        {
            currTime = Time.time;
            navMeshAgent.SetDestination(runAwayAlgorithm(player1.transform.position));
        }
    }

    private void FacePlayer()
    {
        Vector3 direction = (playerPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    internal Vector3 TargetObjectPosition()
    {
        return player.transform.position;
    }

    private void FaceDirection()
    {
        Vector3 direction = (navMeshAgent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    private Vector3 runAwayAlgorithm(Vector3 playerPosition)
    {
        float distance = 0;
        float distance1 = 0;
        float distance2 = 0;
        float lastdistance = 0;
        Target ansTarget = targets[0];
        for(int i=0; i < targets.Length; i++)
        {
            distance = Vector3.Distance(playerPosition, targets[i].transform.position);
            
            if (distance > lastdistance && navMeshAgent.CalculatePath(targets[i].transform.position, navMeshAgent.path))
            {
                lastdistance = distance;
                ansTarget = targets[i];
            }

            

        }
        t = ansTarget;
        return ansTarget.transform.position;
    }

    private IEnumerator SpawnRoutine()
    {
        
            
            yield return new WaitForSeconds(3);
            navMeshAgent.SetDestination(runAwayAlgorithm(playerPosition));

        
    }

}
