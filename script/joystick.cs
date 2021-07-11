using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class joystick : MonoBehaviour{
    public float speed;
    int num = model_select.num;
    public Transform[] Player= new Transform[6];
    public Transform Stick;         // 조이스틱.
    public GameObject cam;

    // 비공개
    private Vector3 StickFirstPos;  // 조이스틱의 처음 위치.
    private Vector3 JoyVec;         // 조이스틱의 벡터(방향)
    private float Radius;
    public static bool MoveFlag;


    void Start()
    {

        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;

        // 캔버스 크기에대한 반지름 조절.
        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;

        MoveFlag = false;
    }

    void Update()
    {
        if (MoveFlag == true)
        {
            Player[num].transform.Translate(Vector3.forward * Time.smoothDeltaTime * speed);

        }
        else
        {
            Player[num].transform.localRotation = cam.transform.localRotation;
            StickFirstPos = Stick.transform.position;
        }
    }
    
    public void Drag(BaseEventData _Data)
    {
        MoveFlag = true;
        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;

        // 조이스틱을 이동시킬 방향을 구함.(오른쪽,왼쪽,위,아래)
        JoyVec = (Pos - StickFirstPos).normalized;

        // 조이스틱의 처음 위치와 현재 내가 터치하고있는 위치의 거리를 구한다.
        float Dis = Vector3.Distance(Pos, StickFirstPos);

        // 거리가 반지름보다 작으면 조이스틱을 현재 터치하고 있는곳으로 이동. 
        if (Dis < Radius)
            Stick.position = StickFirstPos + JoyVec * Dis;
        // 거리가 반지름보다 커지면 조이스틱을 반지름의 크기만큼만 이동.
        else
            Stick.position = StickFirstPos + JoyVec * Radius;
        //new Vector3(0, Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg, 0) +
        float angle = Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg;
        Player[num].transform.localRotation = Quaternion.Euler(0, angle+cam.transform.eulerAngles.y, 0);
        //Player.transform.localRotation = cam.transform.localRotation;
    }

    // 드래그 끝.
    public void DragEnd()
    {
        Stick.position = StickFirstPos; // 스틱을 원래의 위치로.
        JoyVec = Vector3.zero;          
        MoveFlag = false;
    }


}