using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkoPolo : MonoBehaviour
{
    public GameObject showNumbers;
    public Text markoPolo;
    public string[] numbers;
    void Start()
    {
        for(int i = 1; i < 101; i++)
        {
            if(i % 3 == 0 && i % 5 == 0)
            {
                numbers[i] = i.ToString() + "(MarkoPolo)";
            }
            else if(i % 3 == 0)
            {
                numbers[i] = i.ToString() + "(Marko)";
            }
            else if(i % 5 == 0)
            {
                numbers[i] = i.ToString() + "(Polo)";
            }
            else
            {
                numbers[i] = i.ToString();
            }
        }
        for(int i = 1; i < numbers.Length; i++)
        {
            markoPolo.text = markoPolo.text + " | " + numbers[i];
        }
    }
    public void OpenMarkoPolo()
    {
        showNumbers.SetActive(true);
    }
}
