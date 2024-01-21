using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum PoolObjectType
{
    Enemy,      // ��
    Shield,     // ���� ������
}

public class Factory : Singleton<Factory>
{
    // ������Ʈ Ǯ��
    EnemyPool enemy;
    ShieldPool shield;

    protected override void OnInitialize()
    {
        base.OnInitialize();

        // GetComponentInChildren : ���� �� �ڽ� ������Ʈ���� ������Ʈ ã��

        // Ǯ ������Ʈ ã��, ã���� �ʱ�ȭ�ϱ�
        enemy = GetComponentInChildren<EnemyPool>();
        if (enemy != null)
            enemy.Initialize();

        shield = GetComponentInChildren<ShieldPool>();
        if (shield != null)
            shield.Initialize();
    }

    //Ǯ�� �ִ� ���� ������Ʈ �ϳ� ��������
    public GameObject GetObject(PoolObjectType type, Vector3? position = null, Vector3? euler = null)
    {
        GameObject result = null;
        switch (type)
        {
            case PoolObjectType.Enemy:
                result = enemy.GetObject(position, euler).gameObject;

                if (result != null)
                {
                    Enemy enemyComponent = result.GetComponent<Enemy>();
                    if (enemyComponent != null)
                    {
                        enemyComponent.Initialize();
                    }
                }
                break;

            case PoolObjectType.Shield:
                result = shield.GetObject(position, euler).gameObject;
                break;
        }

        return result;
    }

    public Enemy GetEnemy(Vector3 position, float angle = 0.0f)
    {
        Enemy enemyObject = enemy.GetObject(position, angle * Vector3.forward);

        // Enemy�� Pool���� ������ ������ Initialize �޼��� ȣ��
        if (enemyObject != null)
        {
            enemyObject.Initialize();
        }

        return enemyObject;

        //return enemy.GetObject(position, angle * Vector3.forward);
    }

    /*public Enemy GetEnemy()
    {
        return enemy.GetObject();
    }

    public Enemy GetEnemy(Vector3 position, float angle = 0.0f)
    {
        return enemy.GetObject(position, angle * Vector3.forward);
    }*/

    public Shield GetShield()
    {
        return shield.GetObject();
    }

    public Shield GetShield(Vector3 position, float angle = 0.0f)
    {
        return shield.GetObject(position, angle * Vector3.forward);
    }

}
