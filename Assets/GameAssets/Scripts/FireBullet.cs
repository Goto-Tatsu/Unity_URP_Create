using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("弾の速度")]
    private float bulletSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押されたか判定
        if(Input.GetKeyDown(KeyCode.C))
        {
            // 弾を発射する
            LauncherShot();
        }
    }


    ///<summary>
    ///弾の発射
    ///</summary>
    private void LauncherShot()
    {
        // 弾を発射する場所を取得
        Vector3 bulletPosition = firingPoint.transform.position;
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBullet = Instantiate(bullet, bulletPosition, transform.rotation);
        // 出現させたBulletのforword(z軸方向)
        Vector3 direction = newBullet.transform.forward;
        // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        newBullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);
        // 出現させたボールの名前を"Bullet"に変更
        newBullet.name = bullet.name;
        // 出現させたボールを0.8秒後に消す
        Destroy(newBullet, 0.8f);
    }
}
