using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas = default;
    [SerializeField] private GraphicRaycaster graphicRaycaster = default;

    [SerializeField] private PlataformControll plataformControll = default;

    [SerializeField] private TextMeshProUGUI matchResult = default;

    [SerializeField] private Button buttonExit = default;
    [SerializeField] private Button buttonContinue = default;
    [SerializeField] private Button buttonRetry = default;

    private void Start()
    {
        buttonExit.onClick.AddListener(Exit);
        buttonContinue.onClick.AddListener(Continue);
        buttonRetry.onClick.AddListener(Retry);
    }

    public void ShowPanel(bool win)
    {
        if(win)
        {
            matchResult.text = "Victory";
            buttonExit.gameObject.SetActive(true);
            buttonContinue.gameObject.SetActive(true);
            buttonRetry.gameObject.SetActive(false);
        }
        else
        {
            matchResult.text = "Defeat";
            buttonExit.gameObject.SetActive(true);
            buttonContinue.gameObject.SetActive(false);
            buttonRetry.gameObject.SetActive(true);
        }

        SetCanvas(true);
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void Continue()
    {
        plataformControll.StartGame(true, true);
        SetCanvas(false);
    }

    private void Retry()
    {
        plataformControll.StartGame(true, false);
        SetCanvas(false);
    }

    private void SetCanvas(bool active)
    {
        canvas.DOFade(active ? 1 : 0, active ? 0.30f : 0.25f);
        canvas.interactable = active;
        canvas.blocksRaycasts = active;

        graphicRaycaster.enabled = active;
    }
}
