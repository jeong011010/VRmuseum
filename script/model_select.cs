using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class model_select : MonoBehaviour
{
    public Image gen_img;
    public Sprite[] gen_sprite = new Sprite[2];
    // Start is called before the first frame update
    public GameObject[] model = new GameObject[4];
    public static int num = 2;
    int gen = 1;

    public GameObject uniform_;
    public GameObject daily_;
    //public GameObject suit_;
    public Sprite[] uniform = new Sprite[1];
    public Sprite[] daily = new Sprite[1];
    //public Sprite[] suit = new Sprite[1];

    void Start()
    {
        model[num].SetActive(true);
        gen = 1;
    }

    void activef()
    {
        for (int i = 0; i < 4; i++)
            model[i].SetActive(false);
    }
    public void select(GameObject model)
    {
        activef();
        model.SetActive(true);
    }

    public void btn_gen() { if (gen == 2) male(); else female();
        uniform_.GetComponent<Image>().sprite = uniform[gen-1];
        daily_.GetComponent<Image>().sprite = daily[gen-1];
        //suit_.GetComponent<Image>().sprite = suit[gen-1];
    }

    public void male() { select(model[num=2]); gen = 1; gen_img.sprite = gen_sprite[0]; }
    public void female() { select(model[num=0]); gen = 2; gen_img.sprite = gen_sprite[1]; }

    public void btn_daily() { select(gen == 2 ? model[num=0] : model[num = 2]); }
    public void btn_uniform() { select(gen == 2 ? model[num = 1] : model[num = 3]); }
    //public void btn_suit() { select(gen == 2 ? model[num = 2] : model[num = 5]); }
}