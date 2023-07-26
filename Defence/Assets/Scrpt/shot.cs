using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    private float timeAfterSpawn;
    private ParticleSystem particleSystem = default;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0;
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
       
 

        
            if (Input.GetMouseButton(0))
            {
                if (!particleSystem.isPlaying)
                {
                    particleSystem.Play();
                }
            }
            else
            {
                // ���콺 ��ư�� ���� ��ƼŬ �ý����� �����մϴ�.
                if (particleSystem.isPlaying)
                {
                    particleSystem.Stop();
                }
            }
        
        
       
    }
    
}
