using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct MyVector3 //Right�� �⺻������ �̷� �������� �ִ�.
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

    //���� -> ���� �ѱ�� ���� ���� ���, ��ü�� �ٸ� ��ü�� �˰��ϱ� ���� ���� ���
    //�÷��̾ ������ �Ѹ� ����� �� ���̴�.
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
            //Debug.LogWarning("if (null == m_Rigi)"); ���� ����ش�.
            //Debug.LogError("if (null == m_Rigi)"); //������ ����ش�.
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
        //�÷��̾ �׾��� �� ����
        if (transform.position.y <= -MoveCamera.CamCom.orthographicSize)
        {
            SceneManager.LoadScene(2);
            //�÷��̾ ó������ ������ 
            //transform.position = Vector3.zero;
            //ī�޶� �� ó������ ������
            //MoveCamera.CameraReset();
            //��� ���ڵ� �� �����
            
            //m_IsDeath = true;

        }

        transform.position += MyVector3.Right * Time.deltaTime * LogicValue.MoveSpeed;
        m_PlayerPos = transform.position;

        //rigidbody�� ��ü��� �ϴµ� ������ �Ӽ� ��ü�� �����Ѵٰ� ���� �ȴ�.

        //���� ������ ������ �Ϲ����� pcȯ�濡���� �Է��� üũ�� �� �ִ�.
        if (true == Input.GetMouseButtonDown(0) && 0 < m_JumpCount)//�� ��ư�� ���� ��Ƽ��ġ�� �ƴ϶�� ��ġ �ѹ����� �νĵȴ�.
        {
            //rigidbody�� �޾ƿ´�. �˾Ƽ� ����ϱ� ������ ��ŸŸ���� �־��� �ʿ䰡 ����.

            m_Ani.SetTrigger("JUMP");

            m_Rigi.velocity = Vector3.zero;

            m_Rigi.AddForce(Vector3.up * LogicValue.JumpPower);
            --m_JumpCount;
        }

        

    }
    /*����Ƽ���� �����ϴ� �浹�� �̿��Ϸ��� ������ ������ �� ����϶�.
      1. �浹�ؾ��ϴ� A�� B�� �ִٸ� �� �� �ϳ��� rigidbody�� �����ؾ��Ѵ�. ���� ���� �Ϳ� �־��ִ� ���� ����.
      2. A�� B �Ѵ� collider�� �����ؾ� �Ѵ�.
      3. 3D rigidbody��� 3D collider�͸� �浹�Ѵ�.
     */



    
    private void OnCollisionEnter(Collision collision)
    {
        m_Ani.SetTrigger("RUN");

        m_JumpCount = LogicValue.JumpCount;
        //rigidbody�� ���� �͸� ȣ��ȴ�. ������ٵ�� �ö��̴��� ���� � ������Ʈ��
        //�ٸ� �ö��̴��� ���� ������Ʈ�� ���� �浹�ϴ� ����
    }


}
