using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public enum PlataformEnum
{
    plataform1,
    plataform2,
    plataform3,
    plataform4
}

public class PlataformControll : MonoBehaviour
{
    [SerializeField] private Color[] colors = default;

    [SerializeField] private List<Color> countPlaysPlataform1 = default;
    [SerializeField] private List<Color> countPlaysPlataform2 = default;
    [SerializeField] private List<Color> countPlaysPlataform3 = default;
    [SerializeField] private List<Color> countPlaysPlataform4 = default;

    [SerializeField] private Plataform[] plataform = default;

    [SerializeField] private PlataformCell[] plataforms = default;

    [SerializeField] private EndGame endGame = default;

    [SerializeField] private TextMeshProUGUI levelText = default;

    public bool gameStarted;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Level")) PlayerPrefs.SetInt("Level", 1);
        countPlaysPlataform1 = new List<Color>();
        countPlaysPlataform2 = new List<Color>();
        countPlaysPlataform3 = new List<Color>();
        countPlaysPlataform4 = new List<Color>();

        StartGame(false);
    }

    private void Start()
    {
        gameStarted = false;
    }

    public void MatchColor(PlataformEnum @enum, Color cellColor)
    {
        MatchColorPlataform(@enum, cellColor);
    }

    private void MatchColorPlataform(PlataformEnum @enum, Color cellColor)
    {
        switch (@enum)
        {
            case PlataformEnum.plataform1: for (int i = 0; i < countPlaysPlataform1.Count; i++) if (cellColor == countPlaysPlataform1[i]) return; countPlaysPlataform1.Add(cellColor); break;
            case PlataformEnum.plataform2: for (int i = 0; i < countPlaysPlataform2.Count; i++) if (cellColor == countPlaysPlataform2[i]) return; countPlaysPlataform2.Add(cellColor); break;
            case PlataformEnum.plataform3: for (int i = 0; i < countPlaysPlataform3.Count; i++) if (cellColor == countPlaysPlataform3[i]) return; countPlaysPlataform3.Add(cellColor); break;
            case PlataformEnum.plataform4: for (int i = 0; i < countPlaysPlataform4.Count; i++) if (cellColor == countPlaysPlataform4[i]) return; countPlaysPlataform4.Add(cellColor); break;
            default: break;
        }

        CancelInvoke(nameof(CheckWinner));

        Invoke(nameof(CheckWinner), .5f);
    }

    public void StartGame(bool restartGame, bool victory = false)
    {
        if (restartGame)
        {
            int level = PlayerPrefs.GetInt("Level");

            PlayerPrefs.DeleteAll();

            if (victory) PlayerPrefs.SetInt("Level", level + 1);
            else PlayerPrefs.SetInt("Level", level);
        }

        levelText.text = "Level : " + PlayerPrefs.GetInt("Level");

        countPlaysPlataform1.Clear();
        countPlaysPlataform2.Clear();
        countPlaysPlataform3.Clear();
        countPlaysPlataform4.Clear();

        gameStarted = false;

        int colorId = 0;

        foreach (PlataformCell p in plataforms)
        {
            p.gameObject.SetActive(true);
            p.SetColor(colors[colorId], colorId);

            colorId++;

            if (colorId == colors.Length) colorId = 0;
        }
    }

    private void CheckWinner()
    {
        Debug.LogError("LIST 1 " + (countPlaysPlataform1.Count == 6) + " / " + (countPlaysPlataform2.Count == 6) + " / " + (countPlaysPlataform3.Count == 6) + " / " + (countPlaysPlataform4.Count == 6));

        if (countPlaysPlataform1.Count >= 6 && countPlaysPlataform2.Count >= 6 && countPlaysPlataform3.Count >= 6 && countPlaysPlataform4.Count >= 6)
        {
            Debug.LogError("VITORIA");
            endGame.ShowPanel(true);
            //StartGame(true, true);
            return;
        }
        else
        {
            if (countPlaysPlataform2.Count >= 6 && countPlaysPlataform3.Count >= 6)
            {
                if (countPlaysPlataform1.Count != 6 && countPlaysPlataform4.Count != 6)
                {
                    endGame.ShowPanel(false);
                    Debug.LogError("DERROTA 1");
                }
            }
            else if (countPlaysPlataform1.Count >= 6 && countPlaysPlataform4.Count >= 6)
            {
                if (countPlaysPlataform2.Count > countPlaysPlataform3.Count || countPlaysPlataform2.Count < countPlaysPlataform3.Count)
                {
                    endGame.ShowPanel(false);
                    Debug.LogError("DERROTA 4");
                }
                else
                {
                    List<Color> auxColors1 = colors.ToList();
                    List<Color> auxColors2 = colors.ToList();

                    for (int i = 0; i < countPlaysPlataform2.Count; i++)
                    {
                        int index = auxColors1.FindIndex(x => x == countPlaysPlataform2[i]);

                        if(index != -1)
                        {
                            auxColors1.RemoveAt(index);
                        }
                    }

                    for (int i = 0; i < countPlaysPlataform3.Count; i++)
                    {
                        int index = auxColors2.FindIndex(x => x == countPlaysPlataform3[i]);

                        if (index != -1)
                        {
                            auxColors2.RemoveAt(index);
                        }
                    }

                    if (auxColors1 != auxColors2) endGame.ShowPanel(false); Debug.LogError("DERROTA 5");
                }
            }
        }
    }
}
