using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Youtube_auto_start : MonoBehaviour
{
	public Transform[] player = new Transform[6];
	int num = model_select.num;
	int i = 0;

	// Start is called before the first frame updat
	
    // Update is called once per frame
    void Update()
    {
		auto_start();
    }

	public void auto_start()

	{
		float distance = Vector3.Distance(player[num].position, transform.position);
		if (distance <= 4.5f)
		{
			if (i == 0)
			{
				gameObject.GetComponent<YoutubeSimplified>().Play();
				i = 1;
			}
		}

		else

		{
			i = 0;
			gameObject.SetActive(false);
			gameObject.SetActive(true);
		}

	}
}
