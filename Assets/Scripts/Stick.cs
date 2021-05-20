using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public StickObject[] StuckObjectTags;
    private void OnCollisionEnter(Collision collision)
    {
        foreach (var item in StuckObjectTags)
        {
            if (collision.gameObject.CompareTag(item.Tag))
            {
                GetComponent<Rigidbody>().isKinematic = true;

                if (item.ShouldRestartLevel)
                {
                    LevelManager.instance._shouldRestart = true;
                }else if (item.ShouldStartNextLevel)
                {
                    LevelManager.instance._shouldStartNextlevel = true;
                }
            }
        }
       
    }
}
