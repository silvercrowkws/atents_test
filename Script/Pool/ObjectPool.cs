using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : RecycleObject
{
    //Ǯ���� ������ ������Ʈ�� ������
    public GameObject originalPrefab;

    //Ǯ�� ũ��
    public int poolSize = 64;

    //TŸ������ ������ ������Ʈ�� �迭. ������ ��� ������Ʈ�� �ִ� �迭
    T[] pool;

    //���� ��� ������(��Ȱ��ȭ �Ǿ��ִ�) ������Ʈ���� �����ϴ� ť
    Queue<T> readyQueue;

    public void Initialize()
    {
        if (pool == null)  // Ǯ�� ���� ��������� ���� ���
        {
            pool = new T[poolSize];                 // �迭�� ũ�⸸ŭ new
            readyQueue = new Queue<T>(poolSize);    // ����ť�� ����� capacity�� poolSize�� ����

            GenerateObjects(0, poolSize, pool);
        }
        else
        {
            // Ǯ�� �̹� ������� �ִ� ���(ex:���� �߰��� �ε� or ���� �ٽ� ����)
            foreach (T obj in pool)    // foreach : Ư�� �÷��� �ȿ� �ִ� ��� ��Ҹ� �ѹ��� ó���ؾ� �� ���� ���� �� ���
            {
                obj.gameObject.SetActive(false);
            }
        }
    }

    //Ǯ���� ������� �ʴ� ������Ʈ�� �ϳ� ���� �� ���� �ϴ� �Լ�
    public T GetObject(Vector3? position = null, Vector3? eulerAngle = null)
    {
        if (readyQueue.Count > 0)          // ����ť�� ������Ʈ�� �����ִ��� Ȯ��
        {
            T comp = readyQueue.Dequeue();  // ���������� �ϳ� ������
            comp.gameObject.SetActive(true);// Ȱ��ȭ ��Ű��
            comp.transform.position = position.GetValueOrDefault(); // ������ ��ġ�� �̵�
            comp.transform.Rotate(eulerAngle.GetValueOrDefault());  // ������ ������ ȸ��
            OnGetObject(comp);              // ������Ʈ�� �߰� ó��
            return comp;                    // ����
        }
        else
        {
            // ����ť�� ����ִ� == �����ִ� ������Ʈ�� ����
            ExpandPool();           // Ǯ�� �ι�� Ȯ���Ѵ�.
            return GetObject(position, eulerAngle);     // ���� �ϳ� ������.
        }
    }

    //�� ������Ʈ ���� Ư���� ó���ؾ� �� ���� ���� ��� �����ϴ� �Լ�
    protected virtual void OnGetObject(T component)
    {

    }

    //Ǯ�� �� ��� Ȯ���Ű�� �Լ�
    void ExpandPool()
    {
        // �ִ��� �Ͼ�� �ȵǴ� ���̴ϱ� ��� ǥ��
        Debug.LogWarning($"{gameObject.name} Ǯ ������ ����. {poolSize} -> {poolSize * 2}");

        int newSize = poolSize * 2;         // ���ο� Ǯ�� ũ�� ����
        T[] newPool = new T[newSize];       // ���ο� Ǯ ����
        for (int i = 0; i < poolSize; i++)     // ���� Ǯ�� �ִ� ������ �� Ǯ�� ����
        {
            newPool[i] = pool[i];
        }

        GenerateObjects(poolSize, newSize, newPool);    // �� Ǯ�� ���� �κп� ������Ʈ �����ؼ� �߰�

        pool = newPool;         // �� Ǯ ������ ����
        poolSize = newSize;     // �� Ǯ�� Ǯ�� ����
    }

    //Ǯ���� ����� ������Ʈ�� �����ϴ� �Լ�
    void GenerateObjects(int start, int end, T[] results)
    {
        for (int i = start; i < end; i++)
        {
            GameObject obj = Instantiate(originalPrefab, transform);    // ������ �����ؼ�
            obj.name = $"{originalPrefab.name}_{i}";    // �̸��ٲٰ�

            T comp = obj.GetComponent<T>();
            comp.onDisable += () => readyQueue.Enqueue(comp);   // ��Ȱ�� ������Ʈ�� ��Ȱ��ȭ �Ǹ� ����ť�� �ǵ�����
            //readyQueue.Enqueue(comp);       // ����ť�� �߰��ϰ�(���� ��������Ʈ ����� �� ������ �Ʒ����� ��Ȱ��ȭ�ϸ� �ڵ����� ó��)

            results[i] = comp;      // �迭�� �����ϰ�
            obj.SetActive(false);   // ��Ȱ��ȭ ��Ų��.
        }
    }

}