using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Canon : MonoBehaviour
{
    private SphereCollider sphereCollider;


    private float timeAfterSpawn;
    private float AtkRateTime;
    private float AtkDamage;
    public GameObject impt;
    public GameObject impt2;
    void Start()
    {
        AtkRateTime = 3f;
        timeAfterSpawn = 0f;
        AtkDamage = 1f;
        sphereCollider = GetComponent<SphereCollider>();
        Debug.Log("gameObject.name :"+gameObject.name);
        if (gameObject.name.Contains("4"))
        {
           
            if (gameObject.name.Contains("1"))
            {
              
                AtkRateTime = 1.25f;
                AtkDamage = 15f;
            }
            else if (gameObject.name.Contains("2"))
            {
             
                AtkRateTime = 0.5f;
                AtkDamage = 8f;
            }

        }else if (gameObject.name.Contains("1"))
        {
            AtkRateTime = 3f;
            AtkDamage = 1f;
        }
        else if (gameObject.name.Contains("2"))
        {
            AtkRateTime = 3f;
            AtkDamage = 2f;
        }
        else if(gameObject.name.Contains("3")) 
        {
           
            AtkRateTime = 2f;
            AtkDamage = 4f;
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag.Equals("Zombie"))
        {
            
            transform.LookAt(other.transform.position);
            if(impt2 != null || impt2 != default)
            {
                impt2.SetActive(true);
            }
            impt.SetActive(true);
            if (timeAfterSpawn >= AtkRateTime)
            {
                timeAfterSpawn = 0f;
                ZombieAi zombieAi = other.GetComponent<ZombieAi>();
                
                zombieAi.hp = zombieAi.hp - AtkDamage;
         
            }

        }
       
    }

   
}
