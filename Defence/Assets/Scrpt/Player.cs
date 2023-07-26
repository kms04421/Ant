using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    private CharacterController characterController;
    public static Player instance;  
    public float jumpHeight = 3f; // 점프 높이
    public float gravity = -9.81f; // 중력 가속도
    private Vector3 velocity; // 캐릭터 이동 속도
    public Camera subCamera;
    public Camera mainCamera;
    public GameObject Ui;
    public GameObject AimUi;
    private bool menu = false;
    private float timeAfterSpawn;
    public GameObject bellct = default;
    public float allbullet = 0f;
    public float reRoad = 0.5f;
    public TMP_Text tmpText = default;// 탄환
    public TMP_Text playHp = default; // Hp
   
  
    public float playerHp = 100f;
    //포탑 강화 
    private bool CanonUpChk = false;
    public int CanonLv = 0;
    public GameObject CanonUi;
    public GameObject CanonLv2;
    public GameObject CanonLv3;
    public GameObject CanonLv4;
    public GameObject Canonfalse;
    public Vector3 CanonTrans;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
       
        playerHp = 100f;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        if(playerHp  <= 0)
        {
            moveSpeed = 0;
        }

        playHp.text ="HP :"+ playerHp;
        if (Input.GetKeyDown(KeyCode.Tab) && menu == false)
        {
            
            Cursor.visible = true;

            subCamera.gameObject.SetActive(true);
            if (CanonUpChk == false)
            {
                Ui.gameObject.SetActive(true);
                AimUi.gameObject.SetActive(false);
            }
            else if (CanonUpChk == true)
            {
                CanonUi.SetActive(true);
                if (CanonLv == 1)
                {
                    CanonLv2.SetActive(true);
                }
                else if (CanonLv == 2)
                {
                    CanonLv3.SetActive(true);
                }
                else if (CanonLv == 3)
                {
                    CanonLv4.SetActive(true);
                }


            }

            menu = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && menu == true)
        {
            Cursor.visible = false;

                           
                
             Ui.gameObject.SetActive(false);

            CanonUi.SetActive(false);     
            
             CanonLv2.SetActive(false);
            CanonLv3.SetActive(false);
            CanonLv4.SetActive(false);
        
            subCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
            AimUi.gameObject.SetActive(true);
            menu = false;


        }
        timeAfterSpawn += Time.deltaTime;


        if (menu != true)
        {

            if (Input.GetMouseButton(0))
            {
                if (timeAfterSpawn >= reRoad)
                {
                    
                    Vector3 bulletVect = new Vector3(transform.position.x + 0.1f, transform.position.y + 0.5f, transform.position.z);
                    timeAfterSpawn = 0f;
                    Instantiate(bellct, bulletVect, transform.rotation);
                    allbullet++;

                    if (allbullet > 30)
                    {
                        allbullet = 0;
                        reRoad = 5f;
                    }
                    else
                    {
                        reRoad = 0.2f;
                    }

                    tmpText.text = (30 - allbullet) + " / 30";
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                allbullet = 0;
                reRoad = 5f;
                tmpText.text = (30 - allbullet) + " / 30";
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontalInput, 0f, verticalInput)) * moveSpeed * Time.deltaTime;

            characterController.Move(moveDirection);





            if (!characterController.isGrounded)
            {
                velocity.y += gravity * Time.deltaTime;
            }
            else
            {
                velocity.y = 0f; // 땅에 닿으면 수직 속도를 초기화
            }




            // 점프
            if (characterController.isGrounded && Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity + 1); // 점프 속도 계산
            }

            // 캐릭터 이동과 중력 적용
            characterController.Move((moveDirection + velocity) * Time.deltaTime);
            moveDirection = transform.TransformDirection(moveDirection);
        }



    }


    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Canon"))
        {
           

            CanonUpChk = true;

         
            if (other.name.Contains("lv1"))
            {
                CanonLv = 1;

            }
            else if (other.name.Contains("lv2"))
            {
                CanonLv = 2;

            }
            else if (other.name.Contains("lv3"))
            {
                CanonLv = 3;

            }
            if (other.name.Contains("lv4"))
            {

                CanonUpChk = false;

            }
            else
            {
                CanonTrans = other.transform.position;
                Canonfalse = other.transform.parent.gameObject;
            }

          

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Canon"))
        {
            CanonUpChk = false;
            CanonLv = 0;
        }
    }

    public void PlayerHpMinus(float number)
    {
        playerHp -= number;
    }
}
