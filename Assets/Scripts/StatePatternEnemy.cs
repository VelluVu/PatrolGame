﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatternEnemy : MonoBehaviour {

    /// <summary>
    /// Tee neljäs tila TrackingState
    /// Kun enemy kadottaa pelaajan ei mene alert vaan
    /// siirry viimeisimpään pelaajan tiedossa olevaan locaatioon
    /// jossa käynnistää alertstate
    /// </summary>
    /// 
    float searchingTurnSpeed;
    float searchingDuration;
    float sightRange;

    public Transform[] wayPoints;
    public Transform eyes;
    public MeshRenderer indicator;

    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public IEnemyState currentState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public ChaseState chaseState;
    [HideInInspector]
    public TrackingState trackingState;
    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    private void Awake()
    {
        patrolState = new PatrolState(this);
        alertState = new AlertState(this);
        chaseState = new ChaseState(this);
        trackingState = new TrackingState(this);
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Start()
    {
        currentState = patrolState;
        searchingTurnSpeed = 120f;
        searchingDuration = 6f;
        sightRange = 15f;

    }

    public float GetSightRange()
    {
        return sightRange;
    }

    public float GetSearchingDuration()
    {
        return searchingDuration;
    }

    public float GetSearchingTurnSpeed()
    {
        return searchingTurnSpeed;
    }

    private void Update()
    {
        currentState.UpdateState();

    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

}
