using UnityEngine;
using System.Collections;
using System.IO;
using PwndaGames.PandaFoot.Database;
using System.Runtime.Serialization.Formatters.Binary;
using PwndaGames.PandaFoot.Model.Abstract;
using System.Collections.Generic;

namespace PwndaGames.PandaFoot.Util
{
    public class SaveGame
    {
        public static string title;

        public static bool  LoadSaveGame(bool newGame, string data)
        {
            if (newGame)
            {
                try
                {
                    
                    using (Stream stream = File.Open("Assets/Resources/Data/brazil.bin", FileMode.Open))
                    {
                        
                        BinaryFormatter bin = new BinaryFormatter();
                        object[] des = (object[])bin.Deserialize(stream);
                        Dados.me.Times = (Dictionary<int, Team>)des[0];
                        Dados.me.Campeonatos = (List<AbstractChampionship>)des[1];
                        Dados.me.setJogador(Dados.me.temporaryJogador);
                    }
                }
                catch (IOException e) { Debug.Log("Erro no metodo loadNewGame  -  " + e); return false; }

                Dados.me.gerarCalendario();
            }
            else
            {
                try
                {
                    using (Stream stream = File.Open(data, FileMode.Open))
                    {
                        //byte[] ecryptedDados = new byte[stream.Length];
                        //stream.Read(ecryptedDados, 0, ecryptedDados.Length);
                        //Security security = new Security();
                        BinaryFormatter bin = new BinaryFormatter();
                        //security.decode(ecryptedDados)
                        Dados.me = (Dados)bin.Deserialize(stream);
                    }
                }
                catch (IOException) { return LoadSaveGame(true, data); }
            }
            Dados.me.saveLocation = data;
            return true;
        }

        public static bool saveGameData()
        {
            try
            {
                if (!Directory.Exists(Application.persistentDataPath + "/save"))
                    Directory.CreateDirectory(Application.persistentDataPath + "/save");

                using (Stream stream = File.Open(Dados.me.saveLocation, FileMode.CreateNew))
                {
                    MemoryStream streamMemory = new MemoryStream();
                    //Security security = new Security();
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(streamMemory, Dados.me);
                    //security.encode(streamMemory.GetBuffer());
                    byte[] serialEncoded = streamMemory.GetBuffer();
                    stream.Write(serialEncoded, 0, serialEncoded.Length);
                    streamMemory.Close();
                }
            }
            catch (IOException) { return false; }
            return true;
        }

        public static object[] getMenuTeams()
        {
            try
            {
                using (Stream stream = File.Open("Assets/Resources/Data/PlayerTeams.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    return (object[])bin.Deserialize(stream);
                }
            }
            catch (IOException e) { Debug.Log("Erro no metodo getMenuTeams  -  " + e); return null; }
        }


    }

}
