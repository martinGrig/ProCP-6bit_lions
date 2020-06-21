using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBarController : MonoBehaviour
{
    public GameObject Sidebar;

    public void OpenSidebar()
    {
        if (Sidebar == null)
        {
            Sidebar.SetActive(true);
            OpenSidebar();
        }
        else if (Sidebar != null)
        {
            Animator animator = Sidebar.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("Hide", true);
            }
        }
    }

    public void CloseSidebar()
    {
        if (Sidebar == null)
        {
            Debug.Log("There was an error, closing the sidebar. It hasn't been initialized yet!");
        }
        else if (Sidebar != null)
        {
            Animator animator = Sidebar.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("Hide", false);
            }
        }
    }
}
