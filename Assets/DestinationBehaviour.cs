﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestinationBehaviour : MonoBehaviour {

    public float radius = 0.0f;
    Vector3 point_wander;
    Vector3 target = Vector3.zero;
    public float min_update = 0.0f;
    public float max_update = 0.0f;
    NavMeshAgent agent;
    float timer_strike = 0.0f;

	// Use this for initialization
	void OnEnable () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 2;
        Wander();
	}
	
	// Update is called once per frame
	void Update () {
        if(timer_strike > 5)
        {
            Wander();
            timer_strike = 0;
        }

        timer_strike += Time.deltaTime;
	}

    void Wander()
    {
        point_wander = Random.insideUnitSphere;
        point_wander *= radius;
        point_wander += transform.position;

        agent.destination = point_wander;
    }
}
