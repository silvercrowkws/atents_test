using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum PoolObjectType
{
    Enemy,      // 적
    Shield,     // 쉴드 아이템
}

public class Factory : Singleton<Factory>
{
    // 오브젝트 풀들
    EnemyPool enemy;
    ShieldPool shield;

    protected override void OnInitialize()
    {
        base.OnInitialize();

        // GetComponentInChildren : 나와 내 자식 오브젝트에서 컴포넌트 찾음

        // 풀 컴포넌트 찾고, 찾으면 초기화하기
        enemy = GetComponentInChildren<EnemyPool>();
        if (enemy != null)
            enemy.Initialize();

        shield = GetComponentInChildren<ShieldPool>();
        if (shield != null)
            shield.Initialize();
    }

    //풀에 있는 게임 오브젝트 하나 가져오기
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

        // Enemy가 Pool에서 꺼내질 때마다 Initialize 메서드 호출
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
