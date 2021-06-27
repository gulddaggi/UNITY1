using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaMgr : MonoBehaviour
{
    //순서 : 리터럴 초기화(null) -> 엔진 초기화(pixel.png) -> 함수 대입 PanjaSprite(내가 대입해준 값)
   // 2d 이미지를 대표하는 유니티에서 제공하는 클래스이다. 그리고 이를 엔진수준에서 쉽게 세팅하는 법을 지원해준다.
    [SerializeField]
    Sprite PanjaSprite = null;


    [SerializeField]
    private float CreateRandomRangeYStart = -2.0f;
    [SerializeField]
    private float CreateRandomRangeYEnd = 2.0f;

    [SerializeField]
    private int CreateRandomScaleXStart = 5;
    [SerializeField]
    private int CreateRandomScaleXEnd = 10;
    [SerializeField]
    private float CreateRandomInterXStart = 5.0f;
    [SerializeField]
    private float CreateRandomInterXEnd = 10.0f;
    [SerializeField]
    private float CreateRange = 20.0f;
    [SerializeField]
    private float LastCreatePosX = 0.0f; //마지막으로 만들어진 판자의 X위치
    [SerializeField]
    private float LastCreateScaleX = 0.0f; //마지막으로 만들어진 판자의 X크기

    private float ResetLastCreatePosX = 0.0f;
    private float ResetLastCreateScaleX = 0.0f;

    public static PanjaMgr MainPanjaMgr;
    

    private void Awake()
    {
        ResetLastCreatePosX = LastCreatePosX;
        ResetLastCreateScaleX = LastCreateScaleX;

        MainPanjaMgr = this;

        CheckPanjaCreate();
    }
    public static void PanjaReset()
    {
        MainPanjaMgr.ResetData();
    }
    public void ResetData()
    {
        LastCreatePosX = ResetLastCreatePosX;
        LastCreateScaleX = ResetLastCreateScaleX;

        CheckPanjaCreate();
    }



    bool NewPanjaLogic()
    {

        if (LastCreatePosX >= PlayerScript.PlayerPos.x + CreateRange)
        {
            return false;
        }

        int NewFloorCount = UnityEngine.Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd + 1);

        GameObject NewPanja = new GameObject("Panja");
        //NewPanja.transform.localScale = new Vector3(UnityEngine.Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd), 1.0f, 1.0f);
        //판자가 만들어 졌다.

        Vector3 CreatePos = new Vector3();

        //최소한
        CreatePos.x = LastCreatePosX + LastCreateScaleX + (NewFloorCount * 0.5F);
        CreatePos.x += UnityEngine.Random.Range(CreateRandomInterXStart, CreateRandomInterXEnd); ;

        CreatePos.y = UnityEngine.Random.Range(CreateRandomRangeYStart, CreateRandomRangeYEnd);
        CreatePos.z = 0.0f;


       
        //this.gameObject.AddComponent<SpriteRenderer>();
        NewPanja.transform.position = CreatePos;

        //이미지를 세팅해준다.
        //AddComponent<클래스명>
        //SpriteRenderer NewSp = NewPanja.AddComponent<SpriteRenderer>();
        //뭔가 스프라이트를 넣어줘야 화면에 나올 것이다.
        //NewSp.sprite = PanjaSprite;
        //색은 0 ~ 255가 아니라 0~1.0f 이다.
        //NewSp.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

        PanjaScript PS = NewPanja.AddComponent<PanjaScript>();//이 위치가 매우 중요하다.
        PS.FloorCount = NewFloorCount;


        BoxCollider BC =  NewPanja.AddComponent<BoxCollider>();
        BC.size = new Vector3( NewFloorCount, 1, 1);
        BC.center = new Vector3(-0.5f, 0.18f, 0);

        //갱신
        LastCreatePosX = CreatePos.x;
        LastCreateScaleX = (PS.FloorCount * 0.5F);
        //Debug.Log("CreatePos : " + CreatePos);
        //Debug.Log(" NewPanja.transform.localScale. : " + NewPanja.transform.localScale);



       



        return true;
    }

    void CheckPanjaCreate()
    {
        while (NewPanjaLogic());//while문 응용
       
    }

    void Update()
    {
        CheckPanjaCreate();
        //0.0보다는 작지만 가까운 값이다. 이유 : 델타타임은 절대 정확할 수 없다.
        //이전 프레임에서 0.1초 지났다.
        //CreateTime -= Time.deltaTime;

        //시간에 의존한 막무가네 로직이 아니다.


    }
}
