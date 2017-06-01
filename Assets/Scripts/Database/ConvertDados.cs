using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ConvertDados {

    public void ConvertToTeam(string diretory, string fileName)
    {
        List<Team> teams = new List<Team>();
        StreamReader reader;
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/"+diretory);

        foreach (FileInfo f in dir.GetFiles("*", SearchOption.AllDirectories))
        {

            string name = "";
            string mname = "";
            string nac = "";
            int level = 6;
            string coach = "";
            string color = "";
            Player p;
            List<Player> list = new List<Player>();

            string line;
            reader = new StreamReader(Application.persistentDataPath + "/module/" + f.Name);
            while ((line = reader.ReadLine()) != null)
            {
                if (!"ELIFOOT-TEAM".Equals(line))
                {
                    string[] tmp = line.Split(':');
                    switch (tmp[0])
                    {

                        case "NAME":
                            name = tmp[1];

                            break;
                        case "MINI_NAME":
                            mname = tmp[1];

                            break;
                        case "NAC":
                            nac = tmp[1];
                            break;
                        case "LEVEL":
                            level = Convert.ToInt32(tmp[1]);
                            break;
                        case "COACH":
                            coach = tmp[1];
                            break;
                        case "BACK_COLOR":
                            color = tmp[1];
                            break;
                        case "PLAYER":

                            string[] tmp3 = tmp[1].Split(';');
                            string pname = tmp3[0];
                            int idade = (int)UnityEngine.Random.Range(18, 34);
                            int forca = (int)UnityEngine.Random.Range(level - 5, level + 5);
                            if (pname.Contains("*"))
                            {
                                forca = (int)UnityEngine.Random.Range(level, level + 15);
                                pname.Replace("8", "");
                            }
                            string nation = tmp3[2];
                            int pos = Convert.ToInt32(tmp3[1]);

                            p = new Player(tmp3[0], idade, forca, forca, 100, nation, pos);
                            list.Add(p);
                            break;
                    }
                }
            }
            Team t = new Team(name, mname, list, new Bank(UnityEngine.Random.Range(level * 10000, level * 100000)), color, new Coach(), nac, level);
            teams.Add(t);
        }

        try
        {
            if (!Directory.Exists(Application.persistentDataPath + "/export"))
                Directory.CreateDirectory(Application.persistentDataPath + "/export");
            using (Stream stream = File.Open(Application.persistentDataPath + "/export/"+fileName, FileMode.CreateNew))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, teams);
            }
        }
        catch (IOException) { }
    }


}
