using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    GameObject target;
    Stack<GameObject> pool = new Stack<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // ユニティチャンをtargetする
        target = GameObject.FindGameObjectWithTag("Player");
        AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // エネミーを生成
    void AddEnemy()
    {

        if (pool.Count > 0)
        {
            // 再利用できるものがあれば利用する
            pool.Pop().SetActive(true);
        }
        else
        {
            // 再利用できるものがなければせいせいする
            // Enemyオブジェクトの生成
            var enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // Enemy C#Scriptをアタッチする
            var enemyScript = enemy.AddComponent<Enemy>();
            // target生成
            enemyScript.target = target;
            enemyScript.SetDisbleCallBack(EnemyDisable);
        }
        // ３秒後に再起呼び出しする
        Invoke("AddEnemy", 3);
    }

    private void EnemyDisable(GameObject enemy)
    {
        pool.Push(enemy);
    }
}
