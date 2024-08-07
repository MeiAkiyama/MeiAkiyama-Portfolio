using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Pray_Left : MonoBehaviour
{
    // Start is called before the first frame update

    // ����̃X�P���g��
    public OVRSkeleton skeleton;

    // ���W
    public Vector3 positionL;

    // �Q�Ƃ���X�N���v�g
    public RightHandInfo script;

    // �ĂԃX�N���v�g���A�^�b�`�����I�u�W�F�N�g
    //public GameObject RightHand;

    public GameObject dish;
    public Camera _camera;

    void Start()
    {
        // ����̃X�P���g�����擾
        //skeleton = GetComponent<OVRSkeleton>();

        //OVRHandPrefabRight�I�u�W�F�N�g�ɃA�^�b�`�����X�N���v�g���擾
        //script = RightHand.GetComponent<RightHandInfo>();

    }

    // Update is called once per frame
    void Update()
    {
        // ����̐e�w�̎w��̍��W���擾
        positionL = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;

        // �E��̏��(�e�w�̎w��̍��W)���擾
        Vector3 position_receiveR = script.positionR;

        // �������߂�
        Vector3 diff_position = positionL - position_receiveR;

        // ����x���W�����擾
        float x = diff_position.x;

        Vector3 dishPosition = dish.transform.position;
        Transform cam = _camera.transform;
        Vector3 localAngle = cam.localEulerAngles;
        
        //Vector3 cameraRotate = _camera.transform.rotation;

        // 0.01�ȉ��Ȃ�
        if (0 < x & x < 0.01)
        {
            DishPosition.setDishPosition(dishPosition);
            DishPosition.setCameraRotate(localAngle);
            SceneManager.LoadScene("SelectFoodScene");
        }
    }
}
