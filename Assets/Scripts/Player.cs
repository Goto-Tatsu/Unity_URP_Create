using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    Animator animator;
    bool running;   // フィールド
    bool Running    // プロパティ
    {
        get { return running; }
        set
        {   // 値が異なるセット時のみanimator.SetBoolを呼ぶようにします
            if(value != running)
            {
                running = value;
                animator.SetBool("Running", running);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 水平方向キー
        float x = Input.GetAxis("Horizontal");
        // 垂直方向キー
        float z = Input.GetAxis("Vertical");
        // 方向
        var direction = new Vector3(x, 0, z);
        // 移動用キーは押されて入れば
        if(direction.magnitude > 0)
        {
            // 向きを変える
            transform.rotation = Quaternion.LookRotation(direction);
            // 前に移動する
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            Running = true;
        }else
        {
            Running = false;
        }
    }
}
