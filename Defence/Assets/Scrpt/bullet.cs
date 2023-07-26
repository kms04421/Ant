using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;


    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 30f* Time.deltaTime);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Bullet") || other.tag.Equals("Canon") || other.tag.Equals("Player"))
        {
            
        }
        else
        {
            
            Destroy(gameObject);
        }
    }
}
