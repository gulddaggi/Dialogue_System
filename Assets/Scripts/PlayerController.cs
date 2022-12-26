using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float walkSpeed;

    [SerializeField]
    float lookSensitivity;

    [SerializeField]
    float cameraRotationLimit;
    float currentCameraRotationX = 0;

    [SerializeField]
    Camera theCamera;
    [SerializeField]
    Rigidbody myRigid;

    [SerializeField]
    float range;

    [SerializeField]
    SceneManage sceneManage;

    RaycastHit hitInfo;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    GameObject cur_text_NPC = null;

    void Update()
    {
        Move();
        CameraRotation();
        CharacterRotation();
        NPC_Check();
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;

        myRigid.GetComponent<Rigidbody>().MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    private void CameraRotation()
    {//상하 카메라 회전
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _CharacterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_CharacterRotationY));
    }

    void NPC_Check()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            cur_text_NPC = hitInfo.transform.gameObject;
            if (!cur_text_NPC.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                cur_text_NPC.transform.GetChild(0).gameObject.SetActive(true);
                hitInfo.transform.GetComponentInChildren<NPCText>().TextAppear();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                sceneManage.LoadDialogueScene();
            }
        }
        else
        {
            if (cur_text_NPC.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                cur_text_NPC.GetComponentInChildren<NPCText>().TextDisappear();
            }
        }
    }

}

