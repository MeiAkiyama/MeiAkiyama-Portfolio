using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Pray_Left : MonoBehaviour
{
    // Start is called before the first frame update

    // 左手のスケルトン
    public OVRSkeleton skeleton;

    // 座標
    public Vector3 positionL;

    // 参照するスクリプト
    public RightHandInfo script;

    // 呼ぶスクリプトをアタッチしたオブジェクト
    //public GameObject RightHand;

    public GameObject dish;
    public Camera _camera;

    void Start()
    {
        // 左手のスケルトンを取得
        //skeleton = GetComponent<OVRSkeleton>();

        //OVRHandPrefabRightオブジェクトにアタッチしたスクリプトを取得
        //script = RightHand.GetComponent<RightHandInfo>();

    }

    // Update is called once per frame
    void Update()
    {
        // 左手の親指の指先の座標を取得
        positionL = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;

        // 右手の情報(親指の指先の座標)を取得
        Vector3 position_receiveR = script.positionR;

        // 差を求める
        Vector3 diff_position = positionL - position_receiveR;

        // 差のx座標だけ取得
        float x = diff_position.x;

        Vector3 dishPosition = dish.transform.position;
        Transform cam = _camera.transform;
        Vector3 localAngle = cam.localEulerAngles;
        
        //Vector3 cameraRotate = _camera.transform.rotation;

        // 0.01以下なら
        if (0 < x & x < 0.01)
        {
            DishPosition.setDishPosition(dishPosition);
            DishPosition.setCameraRotate(localAngle);
            SceneManager.LoadScene("SelectFoodScene");
        }
    }
}
