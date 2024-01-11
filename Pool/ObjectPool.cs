using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : RecycleObject
{
    public GameObject originalPrefab;

    public int poolSize = 64;

    T[] pool;

    Queue<T> readyQueue;

    public void Initialize()
    {
        if (pool == null)   //pool이 아직 만들어지지 않은 경우
        {
            pool = new T[poolSize];                 //배열의 크기만큼 new
            readyQueue = new Queue<T>(poolSize);    //레디큐를 만들고 capacity를 poolsize로 지정(크기를 확실히 알면 성능적으로 좋아서 사용)

            GenerateObjects(0, poolSize, pool);
        }
        else  //pool이 이미 만들어져 있는 경우(ex:씬이 추가로 로딩 or 씬이 다시 시작)
        {
            foreach (T obj in pool) //foreach = 특정 컬랙션 안에 있는 모든 요소를 한번씩 처리할 일이 있을 대 사용
            {                       //지금 상황은 pool안에 있는 bullet 하나를 obj안에 넣고 { }안의 문장을 실행하는 것을 반복
                obj.gameObject.SetActive(false);
            }
        }
    }

    public T GetObject()
    {
        if (readyQueue.Count > 0)   //레디큐에 오브젝트가 남아있는지 확인
        {
            T comp = readyQueue.Dequeue();  //남아있으면 하나 꺼내고
            comp.gameObject.SetActive(true);    //활성화 시킨 다음
            return comp;    //리턴
        }
        else
        {   //레디큐가 비어있다 == 남아있는 오브젝트가 없다
            ExpandPool();   //풀을 2배로 확장하고
            return GetObject(); //새로 하나 꺼낸다
        }
    }

    void GenerateObjects(int start, int end, T[] results)
    {
        for (int i = start; i < end; i++)
        {
            GameObject obj = Instantiate(originalPrefab, transform);    //프리팹 생성해서
            obj.name = $"{originalPrefab.name}_{i}";    //이름 바꾸고

            T comp = obj.GetComponent<T>();
            comp.onDisable += () => readyQueue.Enqueue(comp);   //재활용 오브젝트가 비활성화되면 레디큐로 되돌려라
            //readyQueue.Enqueue(comp);   //레디큐에 추가하고(위의 델리게이트 등록한 것 때문에 안해도 됨)

            results[i] = comp;  //배열에 저장하고
            obj.SetActive(false);   //비활성화 시킨다

        }
    }

    void ExpandPool()
    {
        //최대한 일어나면 안되는 일이니까 경고 표시
        Debug.LogWarning($"{gameObject.name} 풀 사이즈 증가. {poolSize} -> {poolSize * 2}");
        int newSize = poolSize * 2;     //새로운 풀의 크기
        T[] newPool = new T[newSize];   //새로운 풀 생성
        for (int i = 0; i < poolSize; i++)   //이전 풀에 있던 내용을 새 풀에 복사
        {
            newPool[i] = pool[i];
        }

        GenerateObjects(poolSize, newSize, newPool);    //새 풀의 남은 부분에 오브젝트 생성해서 추가
        pool = newPool;         //새 풀 사이즈 지정
        poolSize = newSize;     //새 풀을 풀로 설정
    }

}