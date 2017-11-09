using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PwndaGames.PandaFoot.Util;
using PwndaGames.PandaFoot.Database;
using UnityEngine.SceneManagement;
using System.Linq;

namespace Pwnda.Controller {
    public class RoundController : MonoBehaviour {

        public Text globalRoundMinute;


        private int actualMinute;
        private RoundState state;
        private MatchTempo tempo;

        private float deltaTime;

        private List<Round> RoundsToday;

        void Start() {
            RoundsToday = Dados.me.getRounds();
            actualMinute = 0;
            deltaTime = 0;
            state = RoundState.None;
            tempo = MatchTempo.Tempo_1;
        }

        void Update() {
            switch (state)
            {
                case RoundState.None: constructRounds(); break;
                case RoundState.Idle: break;
                case RoundState.Running: running(); break;
                case RoundState.Ended: endRounds(); break;
            }
        }

        private void endRounds()
        {
            state = RoundState.Idle;
            Dados.me.nextDay();
            SceneManager.LoadScene("TeamLevel");
        }

        private void constructRounds()
        {
            state = RoundState.Idle;
            foreach(Round r in RoundsToday)
            {
                GameObject parent = Instantiate(Resources.Load("Prefabs/Championship"), new Vector3(0, 0, 0), new Quaternion()) as GameObject;
                parent.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas/Panel/Scroll/Viewport/Content").GetComponent<RectTransform>(), false);
                parent.GetComponentInChildren<Text>().text = r.title;

                float YPOS = -90f;
                foreach (Match m in r.Matches)
                {
                    GameObject partidaObj = Instantiate(Resources.Load("Prefabs/Match"), new Vector3(0, YPOS, 0), new Quaternion()) as GameObject;
                    partidaObj.transform.SetParent(parent.GetComponent<RectTransform>(), false);
                    YPOS -= 35;
                    m.setMatchObj(partidaObj);
                }

                parent.GetComponent<RectTransform>().sizeDelta = new Vector2(parent.GetComponent<RectTransform>().sizeDelta.x, Mathf.Abs(YPOS) + 35);
            }
            GameObject.Find("Canvas/Panel/Scroll").GetComponent<ScrollRect>().velocity = new Vector2(0f, -1000f);
            state = RoundState.Running;
        }

        private void running()
        {
            deltaTime += Time.fixedDeltaTime * Const.Speed;
            if(deltaTime >= 1f) //Contagem de milisegundos para executar ações das partidas||
            {
                deltaTime = 0;
                if((actualMinute != 45 || tempo != MatchTempo.Tempo_1) && (actualMinute != 90 || tempo != MatchTempo.Tempo_2))
                    actualMinute++;
                globalRoundMinute.text = "Tempo: " + actualMinute;
                RoundsToday.ForEach(o => o.actMinute(actualMinute));


            }

            if (RoundsToday.All(o => o.isPaused()))
            {   //se todas as partidas esstiverem pausadas para intervalo // abrir uma janela mostrando minha equipe
                //porem por enquanto vamos só continuar a partida
                if (tempo == MatchTempo.Tempo_1)
                {   //se primeiro tempo
                    RoundsToday.ForEach(o => o.proximoTempo());
                    tempo = MatchTempo.Tempo_2;
                }
            }

            if(RoundsToday.All(o => o.isEnded()))
            {   //se acabou o jogo
                state = RoundState.Ended;
            }

        }








    }
}
