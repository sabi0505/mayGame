using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : Singleton<PopUpManager>
{
    private Dictionary<string, PopupObject> _canvasGroup = null;
    private Stack<string> _popUpList = null;

    private void Start()
    {
        _canvasGroup = new Dictionary<string, PopupObject>();
        _popUpList = new Stack<string>();

        for (int i = 0; i < transform.childCount; i++)
        {
            PopupObject c = transform.GetChild(i).GetComponent<PopupObject>();

            if (c == null)
                continue;

            _canvasGroup.Add(c.name, c);
            PopUpClose(c.name);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _popUpList.Count > 0)
        {
            string name = _popUpList.Peek();
            PopUpClose(name);
        }
    }

    public void PopUpOpen(string name)
    {
        PopupObject popUp = _canvasGroup[name];
        popUp.Open();
        _popUpList.Push(name);
    }

    public void PopUpClose(string name)
    {
        PopupObject popUp = _canvasGroup[name];
        popUp.Close();

        if (_popUpList.Count > 0)
            _popUpList.Pop();
    }
}
