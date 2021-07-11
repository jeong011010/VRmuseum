using UnityEngine;

public class Loading_menu : MonoBehaviour
{

    public void Btn_Entrance()
    {
        loading2.LoadScene2("Play");
    }
    public void Btn_closet()
    {
        loading2.LoadScene2("closet");
    }
    public void Btn_menu()
    {
        loading2.LoadScene2("menu");
    }
}
