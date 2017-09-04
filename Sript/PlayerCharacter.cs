using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {

    Rigidbody rigid;
    public float moveSpeed;
    public float turnSpeed;
    public Rigidbody buttle;
    public Transform buttleTransform;
    public float buttleSpeed;
    


    public float health;
    float healthMax;
    bool isAlive;

    public Slider healthSlider;
    public Image healthImage;
    public Color healthColorFull = Color.green;
    public Color healthColorNull = Color.red;

    void Start ()
    {
        rigid = GetComponent<Rigidbody>();
        healthMax = health;
        isAlive = true;
        RefresHealthHUD();
	}
	

    public void Move(float zDir)
    {
        if(!isAlive)
        {
            return;
        }
        Vector3 move = transform.forward * zDir * moveSpeed * Time.deltaTime;
        rigid.MovePosition(transform.position + move);
    }

    public void Roate(float yDir)
    {
        if(!isAlive)
        {
            return;
        }
        var trun = yDir * turnSpeed* Time.deltaTime;
        Quaternion roate = Quaternion.Euler(0, trun, 0);
        rigid.MoveRotation(rigid.rotation * roate);
    }

    public void Fire()
    {
        if(!isAlive)
        {
            return;
        }
        Rigidbody buttle1;
        buttle1 = Instantiate(buttle, buttleTransform.position, buttleTransform.rotation) as Rigidbody;
        buttle1.gameObject.SetActive(true);
        buttle1.AddForce(buttleTransform.forward * buttleSpeed);
        Destroy(buttle1.gameObject, 3);
    }

    public void Die()
    {
        isAlive = false;
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        RefresHealthHUD();
        if(health <= 0f && isAlive)
        {
            Die();
        }
        
    }

    public void RefresHealthHUD()
    {
        healthSlider.value = health;
        healthImage.color = Color.Lerp(healthColorFull, healthColorNull, health / healthMax);
    }


}
