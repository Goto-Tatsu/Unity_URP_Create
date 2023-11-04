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
        // �q�G�����L�[�Ŋm�F���₷���悤��name�ɂ���
        name = "Enemy";
        // ���ɐݒu
        transform.position = new Vector3(Random.Range(-4, 4), 10, 0);
        // �d�͂ŗ���
        rigidBody = gameObject.AddComponent<Rigidbody>();
        speed = Random.Range(1, 15);

        // �F�ς�
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
        // target���ݒ肳��āAstage��ɂ���Ƃ���target��ǂ�
        if(target && transform.position.y > 0 && transform.position.y <1)
        {
            rigidBody.AddForce((target.transform.position - transform.position).normalized * speed);
        }
        
    }

    // �Փ�
    private void OnCollisionEnter(Collision collision)
    {
        // Target�Ƃ���ȊO��Color��ς���
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
