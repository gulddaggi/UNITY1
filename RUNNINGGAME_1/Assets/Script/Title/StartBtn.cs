using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text�� Button���� UGUI�� ������Ʈ�� ����� �� �ִ�.
using UnityEngine.EventSystems;//ipointer �̺�Ʈ�� ���
using UnityEngine.SceneManagement; //�� �ѱ�� ���� ����


/*����Ƽ���� �����ϴ� UGUI�� �⺻�� UI���� ��Ҹ� �������ϰ� �� ����� �̿��ϱ� ���� ������Ʈ���� �����̴�.
���� �Ϲ�������UI�� ���鶧�� ������ü�� �����̳� ô���� �����ؼ� ���� ���� ����.
UI��ŭ�� ��ũ��ũ�⸦ �������� �� ���� ����. �������� �ػ󵵰� �޶����� ����ϰ� ������ �� ������ �����ϴ� ���� ĵ���� ������Ʈ�̴�.
��� UGUI�� ĵ���� ������Ʈ�� ���� ������Ʈ �Ʒ� �����ؾ߸� �� ����� �����Ѵ�.

ĵ���� : UGUI�� �⺻���� ����� �����Ѵ�.
ĵ���� �����Ϸ� : ĵ���� ������ ũ�⿡ ���ؼ� ����
ĵ���� ����ĳ��Ʈ : ĵ���� ������ �浹�� �̺�Ʈ�� ���ؼ� ����. ��ư, ��ũ�ѹٰ� �۵��ϵ��� �ϸ� �̺�Ʈ�ý����̶�� ������Ʈ�� ���� ������.

 
 
 */

public class StartBtn : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("PlayScene");
        //���� �ѱ�� �ʹ�.
        //Scene in build���� �̸� ����ؾ� �Ѵ�.

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void SceneChange()
    {
        Debug.Log("���� �ѱ�� ���� �غ��ڽ��ϴ�.");
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
