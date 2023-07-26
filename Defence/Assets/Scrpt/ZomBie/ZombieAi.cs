using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAi : MonoBehaviour
{

    NavMeshAgent agent;
    private CapsuleCollider zombie;
    Transform target;
    public float hp = 5;
    private float savehp;

    public GameObject ZombieSp;
    private Animator animator;
    private Animation zombieAnimation = default;

    public float ZombieAtkTime =0;
  
    private float subTime = 0;
    public bool zombieDeath = false;
    public Transform dieTarget = null;
    private bool zombieAtk = false;

    // Start is called before the first frame update
    private void Awake()
    {
        zombieAnimation = GetComponent<Animation>();
    }
    void Start()
    {
        
        hp = 5;
        savehp = hp;
        zombie = GetComponent<CapsuleCollider>();     
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieAtk == true)
        {
            ZombieAtkTime += Time.deltaTime;
        }

        if (ZombieAtkTime > 1f && zombieAtk == true)
        {
           zombieAtk = false;
          ZombieAtkTime = 0;
          Player.instance.PlayerHpMinus( Random.Range(8, 12));
        }
        if (hp <= 0 || zombieDeath == true)
        {
            subTime += Time.deltaTime;
          
            if (zombieDeath == false)
            {
                GameManager.Instance.GoldAdd(10);
                agent.SetDestination(transform.position);
                zombieAnimation.Play("Death");
                zombieDeath = true;
                zombie.radius = 0f;
            }

            if (subTime > 1f)
            {
         
                zombieDeath = false;
                subTime = 0;
                Transform zombieResp = ZombieReSp();
                transform.position = new Vector3(zombieResp.transform.position.x, 2.1f, zombieResp.transform.position.z);
                zombie.radius = 0.9242868f;
                gameObject.SetActive(false);
                hp = 5;
            }
           

        }
        else
        {

            if (zombieDeath == false)
            {
                if(zombieAtk == false )
                {

                    zombieAnimation.Play("Run");
                }
              
                agent.SetDestination(target.position);
                gameObject.transform.LookAt(target);
             
            }
         
        
            
        }
      
      

    }

    

    private void OnTriggerStay(Collider other)
    {
         
        if (other.tag.Equals("Bullet"))
        {
            hp--;
        }

        if (other.tag.Equals("Player"))
        {
            if (zombieDeath == false)
            {
                zombieAtk = true;
                zombieAnimation.Play("Attack2");
            }
        }
        else
        {
            zombieAtk = false;
            ZombieAtkTime = 0;
        }
    }

    public Transform ZombieReSp()
    {
        int randNum = Random.Range(0, 10);
        Transform ZombieReSp = ZombieSp.transform.GetChild(randNum);
        return ZombieReSp;
    }


   



}
