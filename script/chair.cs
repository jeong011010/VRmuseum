using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.EventSystems;

public class chair : MonoBehaviour
{
    public Camera getCamera;
    private RaycastHit hit;
    public GameObject[] model = new GameObject[4];
    public GameObject Joystick;
    public GameObject camera;
    public GameObject inspector;
    public GameObject btn_exit;

    int num = model_select.num;
    public static bool sit;
    // Start is called before the first frame update
    void Start()
    {
        sit = false;
    }

    public void movie_stop()
    {
        Joystick.SetActive(true);
        btn_exit.SetActive(false);
        //videos.SetActive(true);
        sit = false;
        inspector.GetComponent<inspector_script>().standup();
    }
    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {

                    btn_exit.SetActive(true);
                    Joystick.SetActive(false);
                    sit = true;
                    //���ڿ��� �Ͼ�� ��ư ���̱�, Ŭ���� ���� ������ ĳ���� �̵� �Լ� �߰�
                    model[num].transform.position = gameObject.transform.position + new Vector3(0.5f, 1, 0.5f);
                    camera.transform.rotation = Quaternion.Euler(0, 90, 0);
                    model[num].transform.rotation = Quaternion.Euler(0, 90, 0);
                    camera.transform.position = new Vector3(0,1,0);
                    inspector.GetComponent<inspector_script>().movie_play();
                }
            }
        }
    }
}
