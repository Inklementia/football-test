using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text goalsCountTextField;

    private int _goalsCount;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        _goalsCount = 0;
        goalsCountTextField.SetText(_goalsCount.ToString());
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _goalsCount++;
            goalsCountTextField.SetText(_goalsCount.ToString());
        }
      
    }
}
