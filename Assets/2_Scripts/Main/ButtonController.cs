using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject BaseUI;
    [SerializeField] private GameObject[] UISet;
    private Stack<int> uiIndex = new Stack<int>();

    private void Start()
    {
        foreach (var ui in UISet)
        {
            ui.SetActive(false);
        }
        BaseUI.SetActive(true);
        uiIndex.Push(0);
    }

    public void OnNextUI(GameObject nextUI)
    {
        //현재 ui를 끄고
        if (uiIndex.Count > 0)
        {
            UISet[uiIndex.Peek()].SetActive(false);
        }
        //다음 ui인덱스를 찾아서 넣고
        for (int i = 0; i < UISet.Length; i++)
        {
            if (UISet[i] == nextUI)
                uiIndex.Push(i);
        }
        //그 ui를 찾아 넣는다
        nextUI.SetActive(true);
    }

    public void OnBackUI()
    {
        if (uiIndex.Count > 0)
        {
            UISet[uiIndex.Pop()].SetActive(false);
        }
        UISet[uiIndex.Peek()].SetActive(true);
    }

    public void OffCanvas(GameObject canvas)
    {
        canvas.SetActive(false);
    }

    public void OnCanvasAgain(GameObject canvas)
    {
        canvas.SetActive(true);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void LeftHand()
    {
        GameManager.instance.HandVersion = false;
    }

    public void RightHand()
    {
        GameManager.instance.HandVersion = true;    
    }


}
