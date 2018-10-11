using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingState : IEnemyState
{
    private readonly StatePatternEnemy enemy;

    public TrackingState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToAlertState()
    {

    }

    public void ToChaseState()
    {

    }

    public void ToPatrolState()
    {

    }

    public void ToTrackingState()
    {
        //Ei käytetä
    }

    public void UpdateState()
    {

    }
}
