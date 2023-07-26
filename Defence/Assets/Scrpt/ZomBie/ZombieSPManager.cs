using UnityEngine;

public class ZombieSPManager : MonoBehaviour
{
    public GameObject ZomBie;

    public GameObject ZombieSp1;
    public GameObject ZombieSp2;
    public GameObject ZombieSp3;
    public GameObject ZombieSp4;
    public GameObject ZombieSp5;
    public GameObject ZombieSp6;
    public GameObject ZombieSp7;
    public GameObject ZombieSp8;
    public GameObject ZombieSp9;
    public GameObject ZombieSp10;
    
    public GameObject[] Zombies = new GameObject[500];
    private float timeAfterSpawn;   
    private Transform target;
    private Transform sptransform = default;

    private float stageNumber = 0;
    public float ZomBieMax;
    // Start is called before the first frame update
    void Start()
    {

        ZomBieMax = GameManager.Instance.wave*10;
        timeAfterSpawn = 0f;
        target = FindObjectOfType<Player>().transform;
        
        int randnumber = 0;

        for (int i = 0; i < Zombies.Length; i++)
        {


            randnumber = Random.Range(0, 10);
            

            switch (randnumber)
            {
                case 0:
                    
                    Zombies[i] = Instantiate(ZomBie, ZombieSp1.transform.position, ZombieSp1.transform.rotation);
                    Zombies[i].SetActive(false);
                    
                    break;
                case 1:
                   
                    Zombies[i] = Instantiate(ZomBie, ZombieSp2.transform.position, ZombieSp2.transform.rotation);
                    Zombies[i].SetActive(false);
                    break;
                case 2:
                   
                    Zombies[i] = Instantiate(ZomBie, ZombieSp3.transform.position, ZombieSp3.transform.rotation);
                    Zombies[i].SetActive(false);
                    break;
                case 3:
                   
                    Zombies[i] = Instantiate(ZomBie, ZombieSp4.transform.position, ZombieSp4.transform.rotation);
                    Zombies[i].SetActive(false);
                    break;
                case 4:
                   
                    Zombies[i] = Instantiate(ZomBie, ZombieSp5.transform.position, ZombieSp5.transform.rotation);
                    Zombies[i].SetActive(false);
                    break;
                case 5:
                  
                    Zombies[i] = Instantiate(ZomBie, ZombieSp6.transform.position, ZombieSp6.transform.rotation);
                    Zombies[i].SetActive(false);
                    break;
                case 6:
                  
                    Zombies[i] = Instantiate(ZomBie, ZombieSp7.transform.position, ZombieSp7.transform.rotation);
                    Zombies[i].SetActive(false);
                    break;
                case 7:
                  
                    Zombies[i] = Instantiate(ZomBie, ZombieSp8.transform.position, ZombieSp8.transform.rotation);
                    Zombies[i].SetActive(false);
                    break;
                case 8:
                    
                    Zombies[i] = Instantiate(ZomBie, ZombieSp9.transform.position, ZombieSp9.transform.rotation);
                    Zombies[i].SetActive(false);
                    break;
                case 9:
                    
                    Zombies[i] = Instantiate(ZomBie, ZombieSp10.transform.position, ZombieSp10.transform.rotation);
                    Zombies[i].SetActive(false);
                    break;
            }


        }

    }
    
    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
     
        if (timeAfterSpawn >= stageNumber)
        {
            stageNumber = 20f;
            timeAfterSpawn = 0;
            ZomBieMax = GameManager.Instance.wave * 10;
            Debug.Log("ZomBieMax" + ZomBieMax);
            for (int i = 0; i < ZomBieMax; i++)
            {             
                Zombies[i].SetActive(true);
               ;
            }
                
               

        }
    }

   
}
