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
        // ���j�e�B�`������target����
        target = GameObject.FindGameObjectWithTag("Player");
        AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // �G�l�~�[�𐶐�
    void AddEnemy()
    {

        if (pool.Count > 0)
        {
            // �ė��p�ł�����̂�����Η��p����
            pool.Pop().SetActive(true);
        }
        else
        {
            // �ė��p�ł�����̂��Ȃ���΂�����������
            // Enemy�I�u�W�F�N�g�̐���
            var enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // Enemy C#Script���A�^�b�`����
            var enemyScript = enemy.AddComponent<Enemy>();
            // target����
            enemyScript.target = target;
            enemyScript.SetDisbleCallBack(EnemyDisable);
        }
        // �R�b��ɍċN�Ăяo������
        Invoke("AddEnemy", 3);
    }

    private void EnemyDisable(GameObject enemy)
    {
        pool.Push(enemy);
    }
}
