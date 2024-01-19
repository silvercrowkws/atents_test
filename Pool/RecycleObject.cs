using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleObject : MonoBehaviour
{
    //��Ȱ�� ������Ʈ�� ��Ȱ��ȭ �� �� ����Ǵ� ��������Ʈ
    public Action onDisable;

    protected virtual void OnEnable()
    {
        transform.localPosition = Vector3.zero; //�θ��� ��ġ�� ������
        transform.localRotation = Quaternion.identity; //�θ��� ȸ���� ���� �����

        StopAllCoroutines();    //���¿뵵(��� ��)
    }

    protected virtual void OnDisable()
    {
        onDisable?.Invoke();    //��Ȱ��ȭ �Ǿ����� �˸�(Ǯ ���鶧 �ڵ尡 �� ���� ��ϵǾ�� ��)   
    }

    // �����ð� �Ŀ� �� ���� ������Ʈ�� ��Ȱ��ȭ ��Ű�� �ڷ�ƾ
    protected IEnumerator LifeOver(float delay = 0.0f)
    {
        yield return new WaitForSeconds(delay); //delay��ŭ ��ٸ���
        gameObject.SetActive(false);    //��Ȱ��ȭ
    }
}
