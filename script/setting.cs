using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setting : MonoBehaviour
{

    public Sprite[] setting_btn = new Sprite[1];
    public GameObject exit_popup;
    public GameObject setting_popup;
    public GameObject help_popup;
    public GameObject select_popup;
    int i = 0, j = 0, k = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = setting_btn[0];

        setting_popup.SetActive(false);
        help_popup.SetActive(false);
        exit_popup.SetActive(false);
        select_popup.SetActive(false);
    }

    // Update is called once per frame
    public void select()
    {
        k = (++k) % 2;
        if (k == 1) { select_popup.SetActive(true); }
        else { select_popup.SetActive(false); }
    }

    public void Btn()
    {
        i = (++i) % 2;
        gameObject.GetComponent<Image>().sprite = setting_btn[i];
        if (i == 1) { setting_popup.SetActive(true); }
        else { setting_popup.SetActive(false); }
    }

    public void Btn_help()
    {
        j = (++j) % 2;
        if (j == 1) { help_popup.SetActive(true); }
        else { help_popup.SetActive(false); }
    }

    public void exit()
    {
        exit_popup.SetActive(true);
    }

    public void exit_y()
    {
        Application.Quit();
    }
    public void exit_n()
    {
        exit_popup.SetActive(false);
    }

    public void menu()
    {
        loading2.LoadScene2("menu");
    }

}
