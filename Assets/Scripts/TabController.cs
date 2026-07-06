using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image[] tabImages;
    public GameObject[] pages;
    void Start()
    {
        OpenTab(0);
    }

    public void OpenTab(int tabNo)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.gray;
        }
        pages[tabNo].SetActive(true);
        tabImages[tabNo].color = Color.green;
    }
}
