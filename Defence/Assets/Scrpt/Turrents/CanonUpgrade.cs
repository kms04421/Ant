using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanonUpgrade : MonoBehaviour , IPointerDownHandler
{
    public GameObject CanonLv2;
    public GameObject CanonLv3;
    public GameObject CanonLv4_2;
    public GameObject CanonLv4_1;

    private GameObject turrentObj;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)//Å¬¸¯ ½Ã
    {
        
       
        Vector3 vector3 = Player.instance.CanonTrans;   
     
        Vector3 CanonVector3 = new Vector3(vector3.x, 2.1f, vector3.z);
      
        if (Player.instance.CanonLv == 1)
        {
            if (GameManager.Instance.gold < 51)
            {
                return;
            }
            Player.instance.Canonfalse.SetActive(false);
            turrentObj = Instantiate(CanonLv2, CanonVector3, Quaternion.identity);
            GameManager.Instance.BuyGold(50);
        }
        else if (Player.instance.CanonLv == 2)
        {
            if (GameManager.Instance.gold < 101)
            {
                return;
            }
            Player.instance.Canonfalse.SetActive(false);
            turrentObj = Instantiate(CanonLv3, CanonVector3, Quaternion.identity);
            GameManager.Instance.BuyGold(100);
        }
        else if (Player.instance.CanonLv == 3)
        {
          
            Player.instance.Canonfalse.SetActive(false);
            if (gameObject.name.Contains("Lv4_1"))
            {
                if (GameManager.Instance.gold < 251)
                {
                    return;
                }
                turrentObj = Instantiate(CanonLv4_2, CanonVector3, Quaternion.identity);
                GameManager.Instance.BuyGold(250);

            }
            else
            {
                if (GameManager.Instance.gold < 201)
                {
                    return;
                }
                turrentObj = Instantiate(CanonLv4_1, CanonVector3, Quaternion.identity);
                GameManager.Instance.BuyGold(200);
            }
        }

    }
}
