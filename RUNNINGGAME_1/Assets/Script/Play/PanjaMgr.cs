using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaMgr : MonoBehaviour
{
    //���� : ���ͷ� �ʱ�ȭ(null) -> ���� �ʱ�ȭ(pixel.png) -> �Լ� ���� PanjaSprite(���� �������� ��)
   // 2d �̹����� ��ǥ�ϴ� ����Ƽ���� �����ϴ� Ŭ�����̴�. �׸��� �̸� �������ؿ��� ���� �����ϴ� ���� �������ش�.
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
    private float LastCreatePosX = 0.0f; //���������� ������� ������ X��ġ
    [SerializeField]
    private float LastCreateScaleX = 0.0f; //���������� ������� ������ Xũ��

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
        //���ڰ� ����� ����.

        Vector3 CreatePos = new Vector3();

        //�ּ���
        CreatePos.x = LastCreatePosX + LastCreateScaleX + (NewFloorCount * 0.5F);
        CreatePos.x += UnityEngine.Random.Range(CreateRandomInterXStart, CreateRandomInterXEnd); ;

        CreatePos.y = UnityEngine.Random.Range(CreateRandomRangeYStart, CreateRandomRangeYEnd);
        CreatePos.z = 0.0f;


       
        //this.gameObject.AddComponent<SpriteRenderer>();
        NewPanja.transform.position = CreatePos;

        //�̹����� �������ش�.
        //AddComponent<Ŭ������>
        //SpriteRenderer NewSp = NewPanja.AddComponent<SpriteRenderer>();
        //���� ��������Ʈ�� �־���� ȭ�鿡 ���� ���̴�.
        //NewSp.sprite = PanjaSprite;
        //���� 0 ~ 255�� �ƴ϶� 0~1.0f �̴�.
        //NewSp.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

        PanjaScript PS = NewPanja.AddComponent<PanjaScript>();//�� ��ġ�� �ſ� �߿��ϴ�.
        PS.FloorCount = NewFloorCount;


        BoxCollider BC =  NewPanja.AddComponent<BoxCollider>();
        BC.size = new Vector3( NewFloorCount, 1, 1);
        BC.center = new Vector3(-0.5f, 0.18f, 0);

        //����
        LastCreatePosX = CreatePos.x;
        LastCreateScaleX = (PS.FloorCount * 0.5F);
        //Debug.Log("CreatePos : " + CreatePos);
        //Debug.Log(" NewPanja.transform.localScale. : " + NewPanja.transform.localScale);



       



        return true;
    }

    void CheckPanjaCreate()
    {
        while (NewPanjaLogic());//while�� ����
       
    }

    void Update()
    {
        CheckPanjaCreate();
        //0.0���ٴ� ������ ����� ���̴�. ���� : ��ŸŸ���� ���� ��Ȯ�� �� ����.
        //���� �����ӿ��� 0.1�� ������.
        //CreateTime -= Time.deltaTime;

        //�ð��� ������ �������� ������ �ƴϴ�.


    }
}
