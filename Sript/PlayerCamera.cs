using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;

    public float height;
    public float distance;
    public float speed;

    Vector3 v;
    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
	}
	
	
	void Update ()
    {
        v = player.position + Vector3.up * height - player.forward * distance;
        transform.position = Vector3.Lerp(transform.position, v, speed * Time.deltaTime);
        transform.LookAt(player);
	}
}
