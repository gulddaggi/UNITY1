using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private static Vector3 StartPos = Vector3.zero;
    private static MoveCamera GameCamera = null;
    public static Camera CamCom;
    public static void CameraReset()
    {
        GameCamera.transform.position = StartPos;
    }
   

    private void Awake()
    {
        CamCom = GetComponent<Camera>();
        StartPos = transform.position;
        GameCamera = this;
       

    }

    private void Update()
    {
        //this�� �����Ѵٴ� ���� ������ �ȵȴ�.
        this.transform.position += MyVector3.Right * Time.deltaTime * LogicValue.MoveSpeed;
    }

}
