using PwndaGames.PandaFoot.Database;
using PwndaGames.PandaFoot.Model;
using PwndaGames.PandaFoot.Model.Abstract;
using PwndaGames.PandaFoot.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PwndaGames.PandaFoot.Controller
{
    public class GameController : MonoBehaviour
    {

        //HUD
        public Text playerName;
        public Text numJogadores;
        public Text dinheiro;
        public Text data;
        public TableList tabelaTime;
        public Image logoTeam;
        public Text leagueBtn;

        //ProxPartida
        public Text proxPartidaCasaFora;
        public Text proxPartidaTipo;
        public Text proxPartidaData;
        public Image proxPartidaT1Image;
        public Image proxPartidaT2Image;

        //JogadorSelecionado
        public Text jNome;
        public Text jForca;
        public Text jIdade;
        public Text jPosition;
        public Text jSalario;
        public Text jJogos;
        public Text jCarac;
        //


        private GameControl state;

        void Start()
        {
            //DontDestroyOnLoad(this);
            inicializarDados();
            state = GameControl.Idle;
        }

        /*
        void Awake()
        {
            if (FindObjectsOfType(GetType()).Length > 1)
            {
                Destroy(gameObject);
            }
        }*/

        void Update()
        {
            switch (state)
            {
                case GameControl.Idle: break;
                case GameControl.Simulating: nextDay(); break;
            }    
        }

        public void avancarOuEscalarTime()
        {
            state = GameControl.Simulating;
        }
        
        
        private void nextDay()
        {
            if (Dados.me.Calendario.ContainsKey(Dados.me.DiaAtual))
            {
                Dia d = Dados.me.Calendario[Dados.me.DiaAtual];
                switch (d.Tipo)
                {
                    case DiaType.None: Dados.me.nextDay(); break;
                    case DiaType.Partida: handlePartidaDay(d); return;                        
                    case DiaType.Transferencia: Dados.me.nextDay(); break; // por enquanto
                }

            }
            else
            {
                Dados.me.nextDay();
            }
        }

        private void handlePartidaDay(Dia d)
        {
            bool b = false;
            foreach (Round r in d.Rounds)
            {
                 
            }
            b = true;

            if (b) //se tiver partida com o time do jogador
            {
                //mostrar tela de escalação do time
                SceneManager.LoadScene("GameLevel");//por enquanto
                state = GameControl.Idle;
            }
            else
            {
                //simular os jogos e mostrar na tela
            }


        }

        private void inicializarDados()
        {
            Coach c = Dados.me.getJogador();
            playerName.text = c.Nome;
            numJogadores.text = c.Time.Jogadores.Count + " Jogadores";
            dinheiro.text = "$ "+AbbrevationUtility.AbbreviateNumber(c.Time.Banco.Money);
            data.text = Dados.me.DiaAtual.ToShortDateString();
            logoTeam.sprite = Resources.Load<Sprite>("TeamIMG/"+ c.Time.Logo.Split('.')[0]);


            Match proxPartida = null;
            DateTime tmpProx = new DateTime();
            foreach (Dia d in Dados.me.Calendario.Values)
            {
                if (proxPartida != null)
                    break;
                if (d.Tipo == DiaType.Partida)
                {
                    foreach(Round r in d.Rounds)
                    {
                        if (r.Dia >= Dados.me.DiaAtual)
                        {
                            proxPartida = r.Matches.Where(t => t.containsTeam(c.Time.ID)).Single();
                            if (proxPartida != null)
                            {
                                tmpProx = r.Dia;
                                break;
                            }
                        }
                    }
                }
            }
            proxPartidaCasaFora.text = "Próxima Partida (Fora)";
            if (proxPartida.getTeamOne().ID == c.Time.ID)
                proxPartidaCasaFora.text = "Próxima Partida (Casa)";
            proxPartidaTipo.text = "Amistoso";
            proxPartidaData.text = tmpProx.ToShortDateString();
            proxPartidaT1Image.sprite = Resources.Load<Sprite>("TeamIMG/" + proxPartida.getTeamOne().Logo.Split('.')[0]);
            proxPartidaT2Image.sprite = Resources.Load<Sprite>("TeamIMG/" + proxPartida.getTeamTwo().Logo.Split('.')[0]);

            selectPlayer(c.Time.Jogadores[0]);
            tabelaTime.createLista(c.Time.Jogadores);


            Dados.me.Campeonatos.ForEach(ch => {
                if (ch.Participantes.Contains(c.Time.ID))
                {
                    leagueBtn.text = ch.Nome;
                    return;
                }
            });

        }

        public void selectPlayer(Player p)
        {
            jNome.text = p.Nome;
            jForca.text = "Força: " + p.Forca;
            jIdade.text = "Idade: " + p.Idade;
            jPosition.text = "Posição: " + p.Position;
            jSalario.text = "Passe: $" + AbbrevationUtility.AbbreviateNumber(p.Valor) + "   \nSalário: $" + AbbrevationUtility.AbbreviateNumber(p.Salario);
            jJogos.text = "Jogos: 0     Gols: 0";
            jCarac.text = "Caracteristicas";
            
        }

    }
}
