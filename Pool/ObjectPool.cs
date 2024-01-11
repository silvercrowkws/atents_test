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
        if (pool == null)   //pool�� ���� ��������� ���� ���
        {
            pool = new T[poolSize];                 //�迭�� ũ�⸸ŭ new
            readyQueue = new Queue<T>(poolSize);    //����ť�� ����� capacity�� poolsize�� ����(ũ�⸦ Ȯ���� �˸� ���������� ���Ƽ� ���)

            GenerateObjects(0, poolSize, pool);
        }
        else  //pool�� �̹� ������� �ִ� ���(ex:���� �߰��� �ε� or ���� �ٽ� ����)
        {
            foreach (T obj in pool) //foreach = Ư�� �÷��� �ȿ� �ִ� ��� ��Ҹ� �ѹ��� ó���� ���� ���� �� ���
            {                       //���� ��Ȳ�� pool�ȿ� �ִ� bullet �ϳ��� obj�ȿ� �ְ� { }���� ������ �����ϴ� ���� �ݺ�
                obj.gameObject.SetActive(false);
            }
        }
    }

    public T GetObject()
    {
        if (readyQueue.Count > 0)   //����ť�� ������Ʈ�� �����ִ��� Ȯ��
        {
            T comp = readyQueue.Dequeue();  //���������� �ϳ� ������
            comp.gameObject.SetActive(true);    //Ȱ��ȭ ��Ų ����
            return comp;    //����
        }
        else
        {   //����ť�� ����ִ� == �����ִ� ������Ʈ�� ����
            ExpandPool();   //Ǯ�� 2��� Ȯ���ϰ�
            return GetObject(); //���� �ϳ� ������
        }
    }

    void GenerateObjects(int start, int end, T[] results)
    {
        for (int i = start; i < end; i++)
        {
            GameObject obj = Instantiate(originalPrefab, transform);    //������ �����ؼ�
            obj.name = $"{originalPrefab.name}_{i}";    //�̸� �ٲٰ�

            T comp = obj.GetComponent<T>();
            comp.onDisable += () => readyQueue.Enqueue(comp);   //��Ȱ�� ������Ʈ�� ��Ȱ��ȭ�Ǹ� ����ť�� �ǵ�����
            //readyQueue.Enqueue(comp);   //����ť�� �߰��ϰ�(���� ��������Ʈ ����� �� ������ ���ص� ��)

            results[i] = comp;  //�迭�� �����ϰ�
            obj.SetActive(false);   //��Ȱ��ȭ ��Ų��

        }
    }

    void ExpandPool()
    {
        //�ִ��� �Ͼ�� �ȵǴ� ���̴ϱ� ��� ǥ��
        Debug.LogWarning($"{gameObject.name} Ǯ ������ ����. {poolSize} -> {poolSize * 2}");
        int newSize = poolSize * 2;     //���ο� Ǯ�� ũ��
        T[] newPool = new T[newSize];   //���ο� Ǯ ����
        for (int i = 0; i < poolSize; i++)   //���� Ǯ�� �ִ� ������ �� Ǯ�� ����
        {
            newPool[i] = pool[i];
        }

        GenerateObjects(poolSize, newSize, newPool);    //�� Ǯ�� ���� �κп� ������Ʈ �����ؼ� �߰�
        pool = newPool;         //�� Ǯ ������ ����
        poolSize = newSize;     //�� Ǯ�� Ǯ�� ����
    }

}