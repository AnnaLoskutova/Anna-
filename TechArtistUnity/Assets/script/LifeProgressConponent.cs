using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeProgressConponent : MonoBehaviour
{
    [SerializeField] private GameObject[] Lifes;
    [SerializeField] private UnityEvent OnDie;

    private bool Die;
    private int CurrentLifeCount;
    private int MaxLife;

    public void Damage()
    {
        if (Die)
            return;

        CurrentLifeCount--;
        Lifes[CurrentLifeCount].SetActive(false);
        CheckDie();
    }

    public void Heel()
    {
        if (Die || CurrentLifeCount + 1 >= MaxLife)
            return;

        Lifes[CurrentLifeCount].SetActive(true);
        CurrentLifeCount++;
    }

    private void Awake()
    {
        MaxLife = CurrentLifeCount = Lifes.Length;
        CheckDie();
    }

    private void CheckDie()
    {
        if (CurrentLifeCount > 0)
            return;

        OnDie.Invoke();
        Die = true;
    }
}
