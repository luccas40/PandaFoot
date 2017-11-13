using PwndaGames.PandaFoot.Model;
using PwndaGames.PandaFoot.Model.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PwndaGames.PandaFoot.Util
{
    public class ConvertDados
    {
        private static string dataPath = Path.GetDirectoryName(Application.ExecutablePath);



        public static bool saveData(List<AbstractChampionship> camps, Dictionary<int, Team> times)
        {
            try
            {
                using (Stream stream = File.Open(@dataPath + "/data/Brazil.bin", FileMode.OpenOrCreate))
                {
                    MemoryStream streamMemory = new MemoryStream();
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(streamMemory, new object[] { times, camps });
                    byte[] serialEncoded = streamMemory.GetBuffer();
                    stream.Write(serialEncoded, 0, serialEncoded.Length);
                    streamMemory.Close();
                }

                using (Stream stream = File.Open(@dataPath + "/data/PlayerTeams.bin", FileMode.OpenOrCreate))
                {
                    object[] obj = new object[camps.Count];
                    int inc = 0;
                    foreach (AbstractChampionship c in camps)
                    {
                        List<object[]> t = new List<object[]>();
                        foreach (int i in c.Participantes)
                        {
                            t.Add(new object[] { i, times[i].Nome });
                        }
                        obj[inc] = new object[] { c.Nome, t };
                        inc++;
                    }

                    MemoryStream streamMemory = new MemoryStream();
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(streamMemory, obj);
                    byte[] serialEncoded = streamMemory.GetBuffer();
                    stream.Write(serialEncoded, 0, serialEncoded.Length);
                    streamMemory.Close();
                }
                return true;
            }
            catch (IOException e) { return false; }
        }


        public static (List<AbstractChampionship>, Dictionary<int, Team>) openXMLFile(string [] xmls)
        {
            List<AbstractChampionship> camps = new List<AbstractChampionship>();
            Dictionary<int, Team> times = new Dictionary<int, Team>();

            try
            {
                foreach(string camp in xmls) handleXML(XElement.Load(camp).Elements("campeonato"), ref times, ref camps);

                Console.WriteLine(camps.Count);
                return ( camps, times );
            }
            catch (IOException e) { Console.WriteLine("Erro no - "+e.Message); return (null, null); }
        }

        private static void handleXML(IEnumerable<XElement> elements, ref Dictionary<int, Team> times, ref List<AbstractChampionship> series)
        {
            foreach (XElement camp in elements)
            {
                AbstractChampionship serie = new League(camp.Element("nome").Value, DateTime.Parse(camp.Element("dataInicio").Value)); // 7 de maio
                List<int> sp = new List<int>();
                
                foreach (XElement time in camp.Elements("times").Elements("time"))
                {
                    List<Player> jogadores = new List<Player>();
                    List<Player> academia = new List<Player>();

                    foreach (XElement jogador in time.Element("jogadores").Elements("jogador"))
                    {
                        Player p = new Player(jogador.Element("nome").Value,
                                                int.Parse(jogador.Element("ano").Value),
                                                (int)Math.Ceiling(double.Parse(jogador.Element("power").Value.Replace('.', ','))),
                                                (int)Math.Ceiling(double.Parse(jogador.Element("pot").Value.Replace('.', ','))),
                                                100,
                                                jogador.Element("nacionalidade").Value,
                                                convertPlayerPosition(jogador.Element("posicao").Value),
                                                DateTime.ParseExact(jogador.Element("contrato").Value, "d-M-yyyy", CultureInfo.InvariantCulture),
                                                convertToDouble(jogador.Element("valor").Value),
                                                convertToDouble(jogador.Element("custo").Value)
                        );
                        if (jogador.Element("academia") != null)
                            academia.Add(p);
                        else
                            jogadores.Add(p);
                    }

                    Team t = new Team(int.Parse(time.Element("id").Value),
                                        time.Element("nome").Value,
                                        time.Element("sigla").Value,
                                        jogadores,
                                        academia,
                                        new Bank(convertToDouble(time.Element("dinheiro").Value)),
                                        "", //Cor
                                        new Coach("", int.Parse(time.Element("id").Value), -1),
                                        time.Element("nation").Value,
                                        double.Parse(time.Element("reputacao").Value),
                                        time.Element("img").Value
                        );
                    sp.Add(t.ID);
                    times.Add(t.ID, t);
                }
                serie.setParticipantes(sp);
                series.Add(serie);
            }
        }

        private static double convertToDouble(string g)
        {
            char last = g[g.Length - 1];
            if (Char.IsNumber(last))
                return double.Parse(g);


            double n = double.Parse(g.Remove(g.Length - 1));

            last = Char.ToLower(last);

            if (last == 'k')
                n *= 1000;

            if (last == 'm')
                n *= 1000000;
            if (n < 0)
                n *= -1;
            return n;
        }

        private static PlayerPosition convertPlayerPosition(string st)
        {
            string s = st.Replace('/', ' ');
            if (s.Contains("GK"))
                return PlayerPosition.GK;
            else if (s.Contains("D ") && s.Contains(" L"))
                return PlayerPosition.LE;
            else if (s.Contains("D ") && s.Contains(" C"))
                return PlayerPosition.ZG;
            else if (s.Contains("SW"))
                return PlayerPosition.ZG;
            else if (s.Contains("D ") && ( s.Contains("RC") || s.Contains("R") ))
                return PlayerPosition.LD;
            else if (s.Contains("DM"))
                return PlayerPosition.VOL;
            else if ((s.Contains("AM") || s.Contains("M")) && s.Contains(" L"))
                return PlayerPosition.ME;
            else if ((s.Contains("AM") || s.Contains("M")) && ( s.Contains("RC") || s.Contains("R") ))
                return PlayerPosition.MD;
            else if ((s.Contains("AM") || s.Contains("M")) && ( s.Contains(" C") || s.Contains(" F"))) 
                return PlayerPosition.MO;
            else if (s.Contains("ST"))
                return PlayerPosition.CA;
            return PlayerPosition.None;
        }


    }
}
