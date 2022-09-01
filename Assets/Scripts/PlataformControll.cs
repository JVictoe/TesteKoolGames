using System.Collections.Generic;
using UnityEngine;

public enum PlataformEnum
{
    plataform1,
    plataform2,
    plataform3,
    plataform4
}

public class PlataformControll : MonoBehaviour
{
    [SerializeField] private List<int> countPLaysPlataform1 = default;
    [SerializeField] private List<int> countPLaysPlataform2 = default;
    [SerializeField] private List<int> countPLaysPlataform3 = default;
    [SerializeField] private List<int> countPLaysPlataform4 = default;

    private void Start()
    {
        countPLaysPlataform1 = new List<int>();
        countPLaysPlataform2 = new List<int>();
        countPLaysPlataform3 = new List<int>();
        countPLaysPlataform4 = new List<int>();
    }

    public void MatchColor(PlataformEnum @enum, int cellId)
    {
        switch (@enum)
        {
            case PlataformEnum.plataform1: MatchColorPlataformOne(cellId); break;
            case PlataformEnum.plataform2: MatchColorPlataformTwo(cellId); break;
            case PlataformEnum.plataform3: MatchColorPlataformThree(cellId); break;
            case PlataformEnum.plataform4: MatchColorPlataformFour(cellId); break;
            default: break;
        }
    }

    private void MatchColorPlataformOne(int cellId)
    {
        countPLaysPlataform1.Add(cellId);
        CheckWinner();
    }

    private void MatchColorPlataformTwo(int cellId)
    {
        countPLaysPlataform2.Add(cellId);
        CheckWinner();
    }

    private void MatchColorPlataformThree(int cellId)
    {
        countPLaysPlataform3.Add(cellId);
        CheckWinner();
    }

    private void MatchColorPlataformFour(int cellId)
    {
        countPLaysPlataform4.Add(cellId);
        CheckWinner();
    }

    private void CheckWinner()
    {
        //Debug.LogError(countPLaysPlataform1.Count);
        //Debug.LogError(countPLaysPlataform2.Count);
        //Debug.LogError(countPLaysPlataform3.Count);
        //Debug.LogError(countPLaysPlataform4.Count);

        if (countPLaysPlataform1.Count == 6 && countPLaysPlataform2.Count == 6 && countPLaysPlataform3.Count == 6 && countPLaysPlataform4.Count == 6) Debug.LogError("VITORIA");
        else
        {
            if(countPLaysPlataform2.Count == 6 && countPLaysPlataform3.Count == 6)
            {
                if (countPLaysPlataform1.Count != 6 && countPLaysPlataform4.Count != 6) Debug.LogError("DERROTA");
                if (countPLaysPlataform1.Count == 5 && countPLaysPlataform4.Count == 5) Debug.LogError("DERROTA");
            }
            
        }
    }
}
