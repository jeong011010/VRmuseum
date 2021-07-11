using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.EventSystems;

public class movie_select : MonoBehaviour
{
    public GameObject[] poster = new GameObject[16];
    public GameObject inspector;
    public Camera getCamera;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        inspector.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < 16; i++)
                {
                    if (hit.collider.gameObject == poster[i])
                    {
                        Debug.Log(i+1);
                        inspector.GetComponent<inspector_script>().inspector_trans(i);
                        inspector.SetActive(true);
                    
                    }
                }
            }
        }
    }
    
}
