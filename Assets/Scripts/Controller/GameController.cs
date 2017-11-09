using PwndaGames.PandaFoot.Database;
using PwndaGames.PandaFoot.Model;
using PwndaGames.PandaFoot.Model.Abstract;
using PwndaGames.PandaFoot.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        //ProxPartida
        public Text proxPartidaCasaFora;
        public Text proxPartidaTipo;

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
            numJogadores.text = c.Time.getPlayers().Count + " Jogadores";
            dinheiro.text = "$ "+c.Time.Banco.Money;
            data.text = Dados.me.DiaAtual.ToShortDateString();

            proxPartidaCasaFora.text = "Próxima Partida (Fora)";
            proxPartidaTipo.text = "Amistoso";

            jNome.text = c.Time.getPlayers()[0].Nome;
            jForca.text = "Força: "+c.Time.getPlayers()[0].Forca; 
            jIdade.text = "Idade: "+c.Time.getPlayers()[0].Idade;
            jPosition.text = "Posição: " + c.Time.getPlayers()[0].Position;
            jSalario.text = "Passe: $"+c.Time.getPlayers()[0].Valor+ "   \nSalário: $" + c.Time.getPlayers()[0].Salario; 
            jJogos.text = "Jogos: 0     Gols: 0"; 
            jCarac.text = "Caracteristicas"; 


    }

    }
}
