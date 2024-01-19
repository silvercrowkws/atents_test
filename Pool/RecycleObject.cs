using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleObject : MonoBehaviour
{
    //재활용 오브젝트가 비활성화 될 때 실행되는 델리게이트
    public Action onDisable;

    protected virtual void OnEnable()
    {
        transform.localPosition = Vector3.zero; //부모의 위치로 보내기
        transform.localRotation = Quaternion.identity; //부모의 회전과 같게 만들기

        StopAllCoroutines();    //리셋용도(없어도 됨)
    }

    protected virtual void OnDisable()
    {
        onDisable?.Invoke();    //비활성화 되었음을 알림(풀 만들때 코드가 할 일이 등록되어야 함)   
    }

    // 일정시간 후에 이 게임 오브젝트를 비활성화 시키는 코루틴
    protected IEnumerator LifeOver(float delay = 0.0f)
    {
        yield return new WaitForSeconds(delay); //delay만큼 기다리고
        gameObject.SetActive(false);    //비활성화
    }
}
