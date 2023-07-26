using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canonshot : MonoBehaviour
{
    private float timeAfterSpawn;
    private ParticleSystem particleSystem = default;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0;
        particleSystem.Play();
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
       
       
    }
    
}
