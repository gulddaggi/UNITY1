using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable] //������ ����ȭ�� �ڵ����� ���ָ鼭 ��ǻ�Ͱ� �а� ���� ���� �������ִ� ���
public class CameraAndPlayerData
{
    
    [SerializeField]
    public float m_MoveSpeed = 10.0f;
    [SerializeField]
    public float m_JumpPower = 10.0f;
    [SerializeField]
    public int m_JumpCount = 3;

}

public class LogicValue : MonoBehaviour
{
    //���� �̱���
    private static LogicValue Inst = null;

    //static�� ����:�������� ���ϴ´�� ��ĥ �� ����.
    //�츮�� �ɹ��Լ� �ȿ��� �ɹ������� ����� �� �ִ� ���� : this�� �־
    //�츮�� �����Լ� �ȿ��� �ɹ������� ����� �� ���� ���� : this�� ���
    [SerializeField]
    private CameraAndPlayerData m_CameraAndPlayerData = new CameraAndPlayerData();
    public static float MoveSpeed   
    {   
        get
        { 
            return Inst.m_CameraAndPlayerData.m_MoveSpeed; 
        }
    }
    public static float JumpPower 
    { 
        get
        { 
            return Inst.m_CameraAndPlayerData.m_JumpPower; 
        } 
    }

    public static int JumpCount
    {
        get
        {
            return Inst.m_CameraAndPlayerData.m_JumpCount;
        }
    }

    [SerializeField]
    private GameObject m_CoinPrefab;
    public static GameObject CoinPrefab{ get { return Inst.m_CoinPrefab; } }

    [SerializeField]
    private GameObject m_BSPrefab;
    public static GameObject BSPrefab { get { return Inst.m_BSPrefab; } }
    
    [SerializeField]
    private GameObject m_BMPrefab;
    public static GameObject BMPrefab { get { return Inst.m_BMPrefab; } }

    [SerializeField]
    private Sprite m_MainFloor;
    public static Sprite MainFloorSprite { get { return Inst.m_MainFloor; } }
    [SerializeField]
    private Sprite m_LeftFloor;
    public static Sprite LeftFloorSprite { get { return Inst.m_LeftFloor; } }
    [SerializeField]
    private Sprite m_RightFloor;
    public static Sprite RightFloorSprite{ get { return Inst.m_RightFloor; } }
    [SerializeField]
    private static int m_Score;
    public static int Score { get { return m_Score; } }

    public static void PlusScore(int _Score)
    {
        m_Score += _Score;
    }

    public class ScoreData
    {
        public string Name;
        public int Score;
        public ScoreData(string _Name, int _Score)
        {
            Name = _Name;
            Score = _Score;
        }
    }


    [SerializeField]
    private static List<ScoreData> m_ScoreArr;
    public static List<ScoreData> ScoreArr { get { return m_ScoreArr; } }


    public static void ScoreLoad()
    {
        if (true == PlayerPrefs.HasKey("Name0"))
        {
            //Ű�� �����ϸ� ���� �����Ͱ� �ִ�.
            

            m_ScoreArr = new List<ScoreData>();
            //�����ϸ� ���� �����͸� �ε� �ؾ��Ѵ�.

            for (int i = 0; i < 5; i++)
            {
                //�����͸� �ε��ϴ� ����
                ScoreData NewScore = new ScoreData(PlayerPrefs.GetString("Name" + i), PlayerPrefs.GetInt("Score" + i));
                m_ScoreArr.Add(NewScore);
            }
            return;
        }

        m_ScoreArr = new List<ScoreData>();

        for (int i = 0; i < 5; i++)
        {
            //��ųʸ��� ����ϰ� Ű�� ���� �ϳ��� ��� ���� ������ ��� �÷����� ����, �����͸� ����� ����
            //�ڵ����� �츮 �÷��� ��򰡿� �����̵� ���� ��� �����ִ� ����� �Ǿ��ش�.
            //���ʿ� ����ִ� �����Ͷ� �׸� ����ü�� ����� ���� ��.
            PlayerPrefs.SetString("Name" + i, "");
            PlayerPrefs.SetInt("Score" + i, 0);
            ScoreData NewScore = new ScoreData("", 0);
            m_ScoreArr.Add(NewScore);
        }


    }
    public static bool ScoreCheck()
    {
        //����� �˻��ؼ� ���� �� ����� �ǹ̰� ������ true�� �����Ѵ�.
        for (int i = 0; i < ScoreArr.Count; i++)
        {
            if (m_Score > ScoreArr[i].Score)
            {
                Debug.Log("���ο� ��� true");
                return true;
            }
        }

        return false;
    }

    

   public static void ScoreInput(string _Name)
    {
        ScoreData CheckData = new ScoreData(_Name, m_Score);
        m_Score = 0;

        for (int i = 0; i < ScoreArr.Count; i++)
        {
            if (CheckData.Score > ScoreArr[i].Score)
            {
                ScoreData TempScore = ScoreArr[i];
                //���ο� üũ �����Ͱ� �����ع�����.
                ScoreArr[i] = CheckData;
                CheckData = TempScore;
            }
        }


        //������ �����ؾ� �Ѵ�. : ���� ����

        for (int i = 0; i < 5; i++)
        {
            //��¥ ���ο� �����͸� �װ��� ���� ����� ��.
            PlayerPrefs.SetString("Name" + i, m_ScoreArr[i].Name);
            PlayerPrefs.SetInt("Score" + i, m_ScoreArr[i].Score);
        }
    }


    public static void ScoreReset()
    {
        m_Score = 0;
    }


    private void Awake()
    {
        Inst = this; //�� �ڵ�� �������ٵ� ���� ����Ǿ�� �Ѵ�.
        //project settings ���� ����, ���� �Է°��� ���� �����Ǵ� ����� ���� ���� ���⼭ ��� ����
    }






    void Update()
    {
        
    }

   public static GameObject NameInst(GameObject _NewObject)
    {
        GameObject NewObj = GameObject.Instantiate(_NewObject);
        NewObj.name = _NewObject.name;
        return NewObj;
    }
}
