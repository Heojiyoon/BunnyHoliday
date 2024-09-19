using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour

{
    
    public float moveSpeed = 20f;    // 이동 속도 변수
    public float rotationAmount = 90f;

     float disableTime = 0.3f;  //해당 시간동안 충돌x
    float moreDisableTime = 3f; //해당 시간동안 엔딩화면x

    private Quaternion originalRotation;
    private Collider playerCollider;

    public float jumpPower = 40f;   // 점프력 변수
    private bool isJumping;         // 중복점프 방지 변수

    // private bool isGrounded;        // 땅에 닿았는지 여부 확인 변수
    public LayerMask groundLayer;   // 지면 레이어 설정


    public AudioSource floorAudio; //구름 효과음
    public AudioSource boardAudio; //발판 효과음 

    //public GameObject endingImage; //성공화면 이미지


    private Rigidbody rb;
    private Animator an;



    // Start is called before the first frame update

    void Start()

    {
        //endingImage.SetActive(false);
        rb = GetComponent<Rigidbody>();
        an = GetComponentInChildren<Animator>();
        playerCollider = GetComponent<Collider>();

        //an = GetComponent<Animator>();


        originalRotation = transform.rotation;

    }


    // Update is called once per frame

    void Update()

    {
        MoveAndRotate(); //이동과 회전 고정 
        Jump();
         

    }



    void MoveAndRotate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool wDown = Input.GetButton("Walk"); //shift키 누르면 걸을 수 있도록 

        Vector3 moveDirection = new Vector3(0, 0, 0);

        if (wDown)
        {
            moveSpeed = 30;
        }
        if (!wDown)
        {
            moveSpeed = 20;
        }
        if (horizontal < 0) // 왼쪽 방향키를 눌렀을 때
        {
            RotateAndMove(Vector3.forward); // 90도 왼쪽으로 회전
            moveDirection = new Vector3(0, 0, horizontal);

        }
        else if (horizontal > 0) // 오른쪽 방향키를 눌렀을 때
        {
            RotateAndMove(Vector3.back); // 90도 오른쪽으로 회전
            moveDirection = new Vector3(0, 0, -horizontal);
        }



        an.SetBool("isRun", moveDirection != Vector3.zero);
        //an.SetBool("isWalk", wDown);
    }

    void RotateAndMove(Vector3 moveDirection)
    {
        Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        transform.rotation = toRotation;

        // 캐릭터를 이동
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void Jump()   // 점프
    {


        //   if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {

            rb.velocity = new Vector3(rb.velocity.x, 0, 0);

            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            an.SetBool("isJump", true);
            an.SetTrigger("doJump");
            isJumping = true;



        }
    }

    private void PlaySound(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            
            audioSource.Play();
        }
    }


    private void OnCollisionEnter(Collision collision)

    {
        string tagtag = collision.gameObject.tag;
        switch (tagtag)
        {
            case "Floor":
                
                PlaySound(floorAudio);
                break;
            case "Ground":
                PlaySound(boardAudio);
                break;
            default:
                break;
        }

        if (collision.gameObject.tag == "Floor")   //1. 구름에 충돌 시 
        {
      
            an.SetBool("isJump", false);
            isJumping = false;

        }
        if (collision.gameObject.tag == "Enemy")  //2. 새에 충돌 시 
        {
            // Rigidbody 컴포넌트 가져오기
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            // 현재 회전값 저장
            Vector3 currentRotation = rigidbody.rotation.eulerAngles;

            // Y축 회전을 고정
            rigidbody.freezeRotation = true;

            // 원하는 각도로 회전시키기 (예: Y축 회전을 유지하며 다른 축은 초기화)
            transform.rotation = Quaternion.Euler(0f, currentRotation.y, 0f);

        }
        if (collision.gameObject.tag == "Ground") //3. 발판에 충돌 시 
        {
            
            // Collider를 일시적으로 무력화
            StartCoroutine(DisableColliderForTime());
           
        }
        if (collision.gameObject.tag == "EndFloor") //4. 엔딩 바닥에 충돌 시 
        {
            transform.rotation = Quaternion.Euler(0f, 44f, 0f);
            StartCoroutine(DisableEndingForTime());

        }
        if (collision.gameObject.tag == "Wall") //5. 벽에 충돌 시 
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
 

        }

    }

    IEnumerator DisableColliderForTime()
    {
        // Collider를 무력화
        playerCollider.enabled = false;

        // 일정 시간 동안 대기
        yield return new WaitForSeconds(disableTime);

        // Collider를 다시 활성화
        playerCollider.enabled = true;
    }



    IEnumerator DisableEndingForTime()
    {

        
        yield return new WaitForSeconds(moreDisableTime);
        
        SceneManager.LoadScene("GameSuccessScene");

    }




}