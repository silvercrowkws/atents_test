using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleObject : MonoBehaviour
{
    /// <summary>
    /// ��Ȱ�� ������Ʈ�� ��Ȱ��ȭ �� �� ����Ǵ� ��������Ʈ
    /// </summary>
    public Action onDisable;

    protected virtual void OnEnable()
    {        

    }

    protected virtual void OnDisable()
    {
        onDisable?.Invoke();    //��Ȱ��ȭ �Ǿ����� �˸�(Ǯ ���鶧 �ڵ尡 �� ���� ��ϵǾ�� ��)   
    }

    /// <summary>
    /// �����ð� �Ŀ� �� ���� ������Ʈ�� ��Ȱ��ȭ ��Ű�� �ڷ�ƾ
    /// </summary>
    /// <param name="delay">��Ȱ��ȭ �� ������ �ɸ��� �ð�</param>
    /// <returns></returns>
    protected IEnumerator LifeOver(float delay = 0.0f)
    {
        yield return new WaitForSeconds(delay); //delay��ŭ ��ٸ���
        gameObject.SetActive(false);    //��Ȱ��ȭ
    }
}
