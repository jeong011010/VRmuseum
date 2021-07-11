using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] player = new GameObject[6];
    [SerializeField] private float speed;

    int num = model_select.num;
    private int rightFingerId;
    float halfScreenWidth;  //화면 절반만 터치하면 카메라 회전
    private Vector2 prevPoint;
    public Camera cam;
    private Vector3 Vec;

    private Vector3 originalPos; // 시점(yaw)을 원상태로 되돌리는 버튼

    public Transform cameraTransform;
    public float cameraSensitivity;

    private Vector2 lookInput;
    private float cameraPitch; //pitch 시점

    private int i = 0;

    void Start()
    {
        this.rightFingerId = -1;    //-1은 추적중이 아닌 손가락
        this.halfScreenWidth = Screen.width / 2;
        this.originalPos = new Vector3(0, 0, 0);
        this.cameraPitch = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, this.player[num].transform.position, this.speed);

        GetTouchInput();
    }

    private void GetTouchInput()
    {
        //몇개의 터치가 입력되는가
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            switch (t.phase)
            {
                case TouchPhase.Began:

                    if (t.position.x > this.halfScreenWidth && this.rightFingerId == -1)
                    {
                        this.rightFingerId = t.fingerId;
                        Debug.Log("오른쪽 손가락 입력");
                    }
                    break;

                case TouchPhase.Moved:

                    if (!EventSystem.current.IsPointerOverGameObject(i))
                    {
                        if (t.fingerId == this.rightFingerId)
                        {
                            //수평
                            this.prevPoint = t.position - t.deltaPosition;
                            this.transform.RotateAround(this.player[num].transform.position, Vector3.up, (t.position.x - this.prevPoint.x) * 0.2f);
                            this.prevPoint = t.position;

                            //수직
                            this.lookInput = t.deltaPosition * this.cameraSensitivity * Time.deltaTime;
                            this.cameraPitch = Mathf.Clamp(this.cameraPitch - this.lookInput.y, -15f, 25f);
                            this.cameraTransform.localRotation = Quaternion.Euler(this.cameraPitch, 0, 0);
                        }
                    }
                    break;

                case TouchPhase.Stationary:

                    if (t.fingerId == this.rightFingerId)
                    {
                        this.lookInput = Vector2.zero;

                    }
                    break;

                case TouchPhase.Ended:

                    if (t.fingerId == this.rightFingerId)
                    {
                        this.rightFingerId = -1;
                        Debug.Log("오른쪽 손가락 끝");

                    }
                    break;

                case TouchPhase.Canceled:

                    if (t.fingerId == this.rightFingerId)
                    {
                        this.rightFingerId = -1;
                        Debug.Log("오른쪽 손가락 끝");

                    }
                    break;
            }
        }
    }


}
