using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.EventSystems;

public class inspector_script : MonoBehaviour
{
    int n = -1;
    private int movie_num = 16;
    public Sprite[] inspector_pic = new Sprite[16];
    public string[] movie_name = new string[16];
    public Text movie;
    public GameObject panel;

    public GameObject poster;
    public GameObject Youtube;
    public GameObject video;
    public GameObject light;

    void Start()
    {
        gameObject.GetComponent<Image>().sprite = inspector_pic[n];

        video.SetActive(false);
    }

    public void inspector_trans(int i)
    {
        n = i;
        gameObject.GetComponent<Image>().sprite = inspector_pic[n];
    }

    public void Btn_close()
    {
        poster.SetActive(false);
    }

    public void movie_select()
    {
        movie_num = n;
        panel.SetActive(true);
        movie.text = movie_name[movie_num];
    }
    public void movie_play()
    {
        if (n != -1)
        {
            light.SetActive(false);
            video.SetActive(true);
            panel.SetActive(false);
            Youtube.GetComponent<YoutubeSimplified_movie>().Play(movie_num);
        }
    }
    public void standup()
    {
        light.SetActive(true);
        video.SetActive(false);
    }
}
