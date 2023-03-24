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
        //���� ui�� ����
        if (uiIndex.Count > 0)
        {
            UISet[uiIndex.Peek()].SetActive(false);
        }
        //���� ui�ε����� ã�Ƽ� �ְ�
        for (int i = 0; i < UISet.Length; i++)
        {
            if (UISet[i] == nextUI)
                uiIndex.Push(i);
        }
        //�� ui�� ã�� �ִ´�
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
