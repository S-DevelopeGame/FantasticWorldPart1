using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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

    [SerializeField] private GameObject player1;

    [SerializeField] private Target[] targets;

    [SerializeField] private Target t;

    [SerializeField] private Image dialogImage1;
    [SerializeField] private Image dialogImage2;

    private Animator animator;
    private NavMeshAgent navMeshAgent;

    [Tooltip("the delay when you want to cut more time")] [SerializeField] float slow = 4f;
    private float currTime = 0f; // the current time

    [SerializeField] private float runSpeed;
    private const float EPSILON = 0.1f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = runSpeed;
        animator = GetComponent<Animator>();
        animator.SetFloat("MoveSpeed", runSpeed);

    }

    private void Update()
    {
        playerPosition = player.transform.position;
        float distanceToPlayer = Vector3.Distance(playerPosition, transform.position);

        if (dialogImage1.gameObject.activeSelf || dialogImage2.gameObject.activeSelf)
            navMeshAgent.speed = 0;
        else if(runSpeed != navMeshAgent.speed)
        {
            navMeshAgent.speed = runSpeed;
            animator.SetFloat("MoveSpeed", runSpeed);
        }
        //FacePlayer();
        /*
        if (navMeshAgent.speed != runSpeed)
        {
            navMeshAgent.speed = runSpeed;
            animator.SetFloat("MoveSpeed", runSpeed);
        }
            */
        
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
        float lastdistance = 0;
        Target ansTarget = targets[0];
        for(int i=0; i < targets.Length; i++)
        {
            distance = Vector3.Distance(playerPosition, targets[i].transform.position);
            
            if (distance > lastdistance && navMeshAgent.CalculatePath(targets[i].transform.position -new Vector3(1,0,1)* Mathf.Epsilon, navMeshAgent.path))
            {
                lastdistance = distance;
                ansTarget = targets[i];
            }

            

        }
        t = ansTarget;
        return ansTarget.transform.position;
    }





}
