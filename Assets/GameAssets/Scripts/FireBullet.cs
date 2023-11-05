using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("�e�̑��x")]
    private float bulletSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ������
        if(Input.GetKeyDown(KeyCode.C))
        {
            // �e�𔭎˂���
            LauncherShot();
        }
    }


    ///<summary>
    ///�e�̔���
    ///</summary>
    private void LauncherShot()
    {
        // �e�𔭎˂���ꏊ���擾
        Vector3 bulletPosition = firingPoint.transform.position;
        // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������
        GameObject newBullet = Instantiate(bullet, bulletPosition, transform.rotation);
        // �o��������Bullet��forword(z������)
        Vector3 direction = newBullet.transform.forward;
        // �e�̔��˕�����newBall��z����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
        newBullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);
        // �o���������{�[���̖��O��"Bullet"�ɕύX
        newBullet.name = bullet.name;
        // �o���������{�[����0.8�b��ɏ���
        Destroy(newBullet, 0.8f);
    }
}
