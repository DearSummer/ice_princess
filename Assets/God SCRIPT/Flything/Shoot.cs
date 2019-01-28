using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HyperbitArsenal;
public class Shoot : MonoBehaviour
{
    RaycastHit hit;
    public GameObject[] projectiles;
    public Transform spawnPosition;
    [HideInInspector]
    public int currentProjectile = 0;
    public float speed = 1000;

    public Camera ca;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            nextEffect();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            previousEffect();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shotable = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            shotable = false;
        }
        if(shotable == true)
        {
            createBullet();
        }
       
    }

    public void nextEffect()
    {
        if (currentProjectile < projectiles.Length - 1)
            currentProjectile++;
        else
            currentProjectile = 0;
    }

    public void previousEffect()
    {
        if (currentProjectile > 0)
            currentProjectile--;
        else
            currentProjectile = projectiles.Length - 1;
    }

    public void AdjustSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    //以下自己写的
    private bool shotable = false;
    private float delay = 0.5f;
    private void createBullet()
    {
        if((delay-=(Time.deltaTime*3))<0)
        {
            delay = 0.5f;
            GameObject projectile = Instantiate(projectiles[currentProjectile], spawnPosition.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody>().AddForce(this.transform.forward * speed);
        }
    }
}
