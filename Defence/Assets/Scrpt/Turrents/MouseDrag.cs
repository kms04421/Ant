using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDrag : MonoBehaviour,IPointerDownHandler, IDragHandler ,IPointerUpHandler
{
    public GameObject targetObj;
    private GameObject turrentObj;

    private Transform playerTrns;
    Vector3 mousePosition;
    Vector3 sumMousPosition;
    private RaycastHit hit;
    private Vector3 offset;
    // Start is called before the first frame update
    private void Awake()
    {
       
    }

    void Start()
    {
        offset = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        playerTrns = FindObjectOfType<Player>().transform;
        mousePosition = Input.mousePosition;
     
        
    }
    public void OnPointerUp(PointerEventData eventData)//Ŭ��������
    {
        Debug.Log("Image sd!");
    }

    public void OnPointerDown(PointerEventData eventData)//Ŭ�� ��
    {
        if(GameManager.Instance.gold < 99)
        {
            return;
        }
        turrentObj = Instantiate(targetObj, mousePosition, Quaternion.identity);
        GameManager.Instance.BuyGold(100);
    }
    public void OnDrag(PointerEventData eventData)//�巡�׽� 
    {
    
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        offset = Vector3.zero;
        if (Physics.Raycast(ray, out hit))
        {
            offset =new Vector3(hit.point.x,2.1f,hit.point.z) ;
            turrentObj.transform.position = offset;
        }
        
        // turrentObj.anchoredPosition += (eventData.delta / uiCannves.scaleFactor);
        Debug.LogFormat("������ ������ �غ� �Ϸ� ->", mousePosition.x);
    }
}
