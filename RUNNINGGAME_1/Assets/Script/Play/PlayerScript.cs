using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct MyVector3 //Right가 기본적으로 이런 형식으로 있다.
{
    static Vector3 m_Right = new Vector3(1.0f, 0.0f, 0.0f);
   public static Vector3 Right
    {
        get 
        {
            return m_Right;

        }
    }
}


public class PlayerScript : MonoBehaviour
{

    //정적 -> 값을 넘기는 가장 쉬운 방법, 객체가 다른 객체를 알게하기 가장 쉬운 방법
    //플레이어가 어차피 한명 만들어 질 것이다.
    private static Vector3 m_PlayerPos;

    public static Vector3 PlayerPos
    {
        get
        {
            return m_PlayerPos;
        }
    }

    private int m_JumpCount = 3;
    private Rigidbody m_Rigi = null;
    private Animator m_Ani = null;

    private static bool m_IsDeath;
    public static bool IsDeath
    {
        get
        {
            return m_IsDeath;
        }
    }

    


    private void Awake()
    {
        LogicValue.ScoreReset();
        m_Rigi = GetComponent<Rigidbody>();
        m_JumpCount = LogicValue.JumpCount;
        m_Ani = GetComponent<Animator>();
        if (null == m_Rigi)
        {
            //Debug.LogWarning("if (null == m_Rigi)"); 경고로 띄워준다.
            //Debug.LogError("if (null == m_Rigi)"); //에러로 띄워준다.
        }
    }

    void Start()
    {
        Transform MyTrans = GetComponent<Transform>();
    }


    private void FixedUpdate()
    {
        if (true == m_IsDeath)
        {
            PanjaMgr.PanjaReset();
            LogicValue.NameInst(LogicValue.BSPrefab);
            LogicValue.NameInst(LogicValue.BMPrefab);
            m_IsDeath = false;
        }
    }

    void Update()
    {
        //플레이어가 죽었을 때 로직
        if (transform.position.y <= -MoveCamera.CamCom.orthographicSize)
        {
            SceneManager.LoadScene(2);
            //플레이어를 처음으로 돌리고 
            //transform.position = Vector3.zero;
            //카메라도 맨 처음으로 돌리고
            //MoveCamera.CameraReset();
            //모든 판자도 다 지우고
            
            //m_IsDeath = true;

        }

        transform.position += MyVector3.Right * Time.deltaTime * LogicValue.MoveSpeed;
        m_PlayerPos = transform.position;

        //rigidbody는 강체라고 하는데 물리적 속성 전체에 관여한다고 보면 된다.

        //내가 점프를 누르면 일반적인 pc환경에서의 입력을 체크할 수 있다.
        if (true == Input.GetMouseButtonDown(0) && 0 < m_JumpCount)//이 버튼은 만약 멀티터치가 아니라면 터치 한번으로 인식된다.
        {
            //rigidbody를 받아온다. 알아서 계산하기 때문에 델타타임을 넣어줄 필요가 없다.

            m_Ani.SetTrigger("JUMP");

            m_Rigi.velocity = Vector3.zero;

            m_Rigi.AddForce(Vector3.up * LogicValue.JumpPower);
            --m_JumpCount;
        }

        

    }
    /*유니티에서 지원하는 충돌을 이용하려면 다음의 내용을 꼭 기억하라.
      1. 충돌해야하는 A와 B가 있다면 둘 중 하나는 rigidbody가 존재해야한다. 수가 적은 것에 넣어주는 것이 좋다.
      2. A와 B 둘다 collider가 존재해야 한다.
      3. 3D rigidbody라면 3D collider와만 충돌한다.
     */



    
    private void OnCollisionEnter(Collision collision)
    {
        m_Ani.SetTrigger("RUN");

        m_JumpCount = LogicValue.JumpCount;
        //rigidbody를 가진 것만 호출된다. 리지드바디와 컬라이더를 가진 어떤 오브젝트가
        //다른 컬라이더를 가진 오브젝트와 최초 충돌하는 순간
    }


}
