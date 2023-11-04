using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject target;
    Rigidbody rigidBody;
    int speed;
    MeshRenderer meshRenderer;
    Material material;
    Color normalColor = Color.black;
    Color catchColor = Color.red;
    Color touchColor = Color.gray;


    // Start is called before the first frame update
    void Start()
    {
        // ヒエラルキーで確認しやすいようにnameにする
        name = "Enemy";
        // 上空に設置
        transform.position = new Vector3(Random.Range(-4, 4), 10, 0);
        // 重力で落下
        rigidBody = gameObject.AddComponent<Rigidbody>();
        speed = Random.Range(1, 15);

        // 色変え
        material = gameObject.GetComponent<MeshRenderer>().material;
        SetColor(normalColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // fixed update
    private void FixedUpdate()
    {
        // targetが設定されて、stage上にいるときにtargetを追う
        if(target && transform.position.y > 0 && transform.position.y <1)
        {
            rigidBody.AddForce((target.transform.position - transform.position).normalized * speed);
        }
        
    }

    // 衝突
    private void OnCollisionEnter(Collision collision)
    {
        // Targetとそれ以外でColorを変える
        SetColor(collision.gameObject.name == target.name ? catchColor : touchColor);
        Invoke("Reset", 1);
    }

    private void Reset()
    {
        SetColor(normalColor);
    }

    void SetColor(Color color)
    {
        material.color = color;
    }

    public void SetDisbleCallBack(System.Action<GameObject> action)
    {
        disableAction = action;
    }
    System.Action<GameObject> disableAction;
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        if (disableAction != null)
        {
            disableAction(this.gameObject);
        }
    }
}
