using PwndaGames.PandaFoot.Database;
using PwndaGames.PandaFoot.Model.Abstract;
using PwndaGames.PandaFoot.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFDataEditor
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            Dados.me = new Dados();
        }




        private void campSelected(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                this.Invoke((MethodInvoker)delegate {
                    var rowsCount = leaguesGrid.SelectedRows.Count;
                    if (rowsCount == 0 || rowsCount > 1) return;
                    if (Dados.me.Times.Count == 0) return;
            
                    teams.DataSource = new BindingSource(new BindingList<Team>(Dados.me.Campeonatos[leaguesGrid.SelectedRows[0].Index].Participantes.Select(o => Dados.me.Times[o]).ToList()), null);
                });
            }).Start();
    }

        private void teamSelected(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                this.Invoke((MethodInvoker)delegate {
                    var rowsCount = teams.SelectedRows.Count;
                    if (rowsCount == 0 || rowsCount > 1) return;
                    if (Dados.me.Times.Count == 0) return;

                    var idTeam = teams[0, teams.SelectedRows[0].Index].Value;
                    players.DataSource = new BindingSource(new BindingList<Player>(Dados.me.Times[(int)idTeam].getPlayers()), null);
                });
            }).Start();
        }

        private void Novo_Click(object sender, EventArgs e)
        {
            Dados.me = new Dados();
            leaguesGrid.DataSource = null;
            leaguesGrid.Refresh();

            teams.DataSource = null;
            teams.Refresh();

            players.DataSource = null;
            players.Refresh();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            new Thread(() => ConvertDados.saveData(Dados.me.Campeonatos, Dados.me.Times) ).Start();
        }

        private void loadXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "XML files (*.xml, *.panda, *.bin) | *.xml; *.panda; *.bin";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    (Dados.me.Campeonatos, Dados.me.Times) = ConvertDados.openXMLFile(openFileDialog1.FileNames);
                    this.Invoke((MethodInvoker)delegate {
                        leaguesGrid.DataSource = new BindingSource(new BindingList<AbstractChampionship>(Dados.me.Campeonatos), null);
                        teams.DataSource = new BindingSource(new BindingList<Team>(Dados.me.Campeonatos[0].Participantes.Select(o => Dados.me.Times[o]).ToList()), null);
                    });
                }).Start();
            }            
        }
    }
}
