using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    Rigidbody rigid;
    //PlayerCharacter character;
	void Start ()
    {
        rigid = GetComponent<Rigidbody>();
	}
	


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            var player = collision.gameObject.GetComponent<PlayerCharacter>();
            player.TakeDamage(20);
            
        }
    }
}
