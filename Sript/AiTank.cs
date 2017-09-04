using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AiTank : MonoBehaviour {

    PlayerCharacter character;
    Transform target;

    NavMeshAgent agent;

    void Start ()
    {
        character = GetComponent<PlayerCharacter>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("FireControl", 1, 1);
    }
	
    void FireControl()
    {
        character.Fire();
    }
	
	void Update ()
    {
        agent.destination = target.position;
        transform.LookAt(target);
	}


}
