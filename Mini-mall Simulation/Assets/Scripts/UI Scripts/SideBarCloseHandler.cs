using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBarCloseHandler : MonoBehaviour
{
    public Transform Sidebar;
    public void SetAsFirstSiblingInOneSecond()
    {
        StartCoroutine(CloseInOneSecond());
    }

    private IEnumerator CloseInOneSecond()
    {
        yield return new WaitForSeconds(1);
        Sidebar.SetAsFirstSibling();
    }
}
