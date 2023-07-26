using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAtk : MonoBehaviour
{
    CapsuleCollider capsule = default;

    public float ZombieAtkTime = 0;
   

    private bool zombieDeath = false;
    public Transform dieTarget = null;
    private bool zombieAtk = false;
    // Start is called before the first frame update
    void Start()
    {
        capsule = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(zombieAtk = true)
        {
            ZombieAtkTime += Time.deltaTime;
            if(ZombieAtkTime > 1.1f)
            {
                zombieAtk = false;
                ZombieAtkTime = 0f;
            }
        }

      

    }
    private void OnTriggerStay(Collider other)
    {

  

        if (other.tag.Equals("Player"))
        {
            zombieAtk = true;
            ZombieAtkTime += Time.deltaTime;
  
            if (ZombieAtkTime >1f)
            {

                if (zombieDeath == false)
                {
                    
                    zombieAtk = false;
                    ZombieAtkTime = 0f;
                  
                }
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        zombieAtk = false;
        ZombieAtkTime = 0;
    }
}
