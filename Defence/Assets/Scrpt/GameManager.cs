using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float timeAfterSpawn;
    public TMP_Text textGold;
    public float wave = 1f;
    public float gold = 500f;

    private void Awake()
    {
       
        if(Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gold = 500;
        wave = 1;
    }

    
    void Update()
    {
        textGold.text = "Gold :" + gold;    
        timeAfterSpawn += Time.deltaTime;
        
        if(timeAfterSpawn > 20f) 
        {
            wave++;
        }
    }


    public void GoldAdd(float AddGold)
    {
        gold += AddGold;
    }
    public void BuyGold(float BuyGold)
    {
        gold -= BuyGold;
    }



}
