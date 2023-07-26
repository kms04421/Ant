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
                // 마우스 버튼을 떼면 파티클 시스템을 정지합니다.
                if (particleSystem.isPlaying)
                {
                    particleSystem.Stop();
                }
            }
        
        
       
    }
    
}
