using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable] //데이터 직렬화를 자동으로 해주면서 컴퓨터가 읽고 쓰기 쉽게 변경해주는 기능
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
    //변형 싱글톤
    private static LogicValue Inst = null;

    //static의 단점:엔진에서 원하는대로 고칠 수 없다.
    //우리가 맴버함수 안에서 맴버변수를 사용할 수 있는 이유 : this가 있어서
    //우리가 정적함수 안에서 맴버변수를 사용할 수 없는 이유 : this가 없어서
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
            //키가 존재하면 기존 데이터가 있다.
            

            m_ScoreArr = new List<ScoreData>();
            //시작하면 기존 데이터를 로드 해야한다.

            for (int i = 0; i < 5; i++)
            {
                //데이터를 로드하는 로직
                ScoreData NewScore = new ScoreData(PlayerPrefs.GetString("Name" + i), PlayerPrefs.GetInt("Score" + i));
                m_ScoreArr.Add(NewScore);
            }
            return;
        }

        m_ScoreArr = new List<ScoreData>();

        for (int i = 0; i < 5; i++)
        {
            //딕셔너리와 비슷하게 키와 값을 하나로 묶어서 파일 저장을 모든 플랫폼에 저장, 데이터를 만드는 로직
            //자동으로 우리 플랫폼 어딘가에 파일이든 뭐든 계속 남아있는 기록이 되어준다.
            //최초에 비어있는 데이터라도 항목 그자체를 만들기 위한 것.
            PlayerPrefs.SetString("Name" + i, "");
            PlayerPrefs.SetInt("Score" + i, 0);
            ScoreData NewScore = new ScoreData("", 0);
            m_ScoreArr.Add(NewScore);
        }


    }
    public static bool ScoreCheck()
    {
        //기록을 검사해서 만약 내 기록이 의미가 있으면 true를 리턴한다.
        for (int i = 0; i < ScoreArr.Count; i++)
        {
            if (m_Score > ScoreArr[i].Score)
            {
                Debug.Log("새로운 기록 true");
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
                //새로운 체크 데이터가 차지해버린것.
                ScoreArr[i] = CheckData;
                CheckData = TempScore;
            }
        }


        //끝나면 저장해야 한다. : 파일 저장

        for (int i = 0; i < 5; i++)
        {
            //진짜 새로운 데이터를 그곳에 덮어 씌우는 것.
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
        Inst = this; //이 코드는 무엇보다도 먼저 실행되어야 한다.
        //project settings 에서 설정, 기존 입력값에 의해 결정되는 상수와 같은 값도 여기서 계산 가능
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
