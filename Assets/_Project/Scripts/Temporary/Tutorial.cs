using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public static Tutorial Instance;

    public GameObject panelTutorial;
    public GameObject panelTutorialKeywords;
    public GameObject panelTutorialCommands;
    public TextMeshProUGUI txtTutorial;
    public NPCsAndTimeManager startTimer;

    private bool happenedUnknownWord = false;
    private bool happenedStartScreen = false;
    private bool happenedCommandsScreen = false;

    private bool timerStarterd = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        panelTutorial.SetActive(false);
    }

    public void ReceiveTutorialAction(int number)
    {
        string _text = "";

        switch(number)
        {
            case 1:
                if(happenedStartScreen)
                {
                    return;
                }
                _text = "O <color=#00fc00>Tempo</color> corre enquanto você interage com o clã, e quando terminar você irá conversar com Kerak, o líder do clã Peridot. Use esse momento para conseguir informações e aumentar a <color=#ce07e8>Afinidade</color> entre os clãs com suas ações. Algumas interações só podem acontecer em <color=#00fc00>Tempos</color> especficos. Interações ativas estão <color=#fae100>Contornadas em Amarelo</color>";
                happenedStartScreen = true;
                break;
            case 2:
                if(happenedUnknownWord)
                {
                    return;
                }
                _text = "Parece que você encontrou uma <color=#fc0000>Palavra Desconhecida</color>, tente criar um significado baseado nos contextos em que você a encontra, isso pode ser util para o futuro. Você pode anotar suas observações no <color=#008ffc>Jornal</color> (Botão J como padrão)";
                happenedUnknownWord = true;
                break;
        }

        //GameStates.Instance.SetStateTutorial();

        txtTutorial.text = _text;
        panelTutorial.SetActive(true);
    }

    public void BtnCloseTutorial()
    {
        if (!happenedCommandsScreen)
        {
            happenedCommandsScreen = true;
            panelTutorialKeywords.SetActive(false);
            panelTutorialCommands.SetActive(true);
        }
        else
        {
            panelTutorialKeywords.SetActive(true);
            panelTutorialCommands.SetActive(false);
            panelTutorial.SetActive(false);

            if (!timerStarterd)
            {
                timerStarterd = true;
                startTimer.StartTimer();
                if (LightingManager.Instance != null)
                {
                    LightingManager.Instance.start = true;
                }
            }
        }
    }
}
