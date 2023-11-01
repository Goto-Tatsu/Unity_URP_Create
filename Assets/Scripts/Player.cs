using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    Animator animator;
    bool running;   // �t�B�[���h
    bool Running    // �v���p�e�B
    {
        get { return running; }
        set
        {   // �l���قȂ�Z�b�g���̂�animator.SetBool���ĂԂ悤�ɂ��܂�
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
        // ���������L�[
        float x = Input.GetAxis("Horizontal");
        // ���������L�[
        float z = Input.GetAxis("Vertical");
        // ����
        var direction = new Vector3(x, 0, z);
        // �ړ��p�L�[�͉�����ē����
        if(direction.magnitude > 0)
        {
            // ������ς���
            transform.rotation = Quaternion.LookRotation(direction);
            // �O�Ɉړ�����
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            Running = true;
        }else
        {
            Running = false;
        }
    }
}
