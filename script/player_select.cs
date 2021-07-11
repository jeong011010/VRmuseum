using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_select : MonoBehaviour
{
    public GameObject[] player = new GameObject[4];
    int num = model_select.num;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == num)
                player[i].SetActive(true);
            else
                player[i].SetActive(false);
        }

    }


}
