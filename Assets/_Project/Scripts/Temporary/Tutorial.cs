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
                _text = "O <color=#00fc00>Tempo</color> corre enquanto voc� interage com o cl�, e quando terminar voc� ir� conversar com Kerak, o l�der do cl� Peridot. Use esse momento para conseguir informa��es e aumentar a <color=#ce07e8>Afinidade</color> entre os cl�s com suas a��es. Algumas intera��es s� podem acontecer em <color=#00fc00>Tempos</color> especficos. Intera��es ativas est�o <color=#fae100>Contornadas em Amarelo</color>";
                happenedStartScreen = true;
                break;
            case 2:
                if(happenedUnknownWord)
                {
                    return;
                }
                _text = "Parece que voc� encontrou uma <color=#fc0000>Palavra Desconhecida</color>, tente criar um significado baseado nos contextos em que voc� a encontra, isso pode ser util para o futuro. Voc� pode anotar suas observa��es no <color=#008ffc>Jornal</color> (Bot�o J como padr�o)";
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
