using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Security {




    public byte[] encode(byte[] dados)
    {

        
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
        string privateKey = rsa.ToXmlString(true);

        byte[] encryptedDados = rsa.Encrypt(dados, false);
        byte[] base64Dados = Encoding.UTF8.GetBytes(Convert.ToBase64String(encryptedDados));
        byte[] base64Key = Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes(privateKey)));
        FileStream file = File.Create(Application.persistentDataPath + "/Service.ide");
        file.Write(base64Key, 0, base64Key.Length);
        file.Close();

        return base64Dados;
    }

    public Stream decode(byte[] dados)
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
        FileStream file = File.OpenRead(Application.persistentDataPath + "/Service.ide");
        byte[] byteKey = new byte[file.Length];
        rsa.FromXmlString(Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(byteKey))));
        byte[] decodedDados = rsa.Decrypt(dados, false);

        file.Close();

        Stream memoryStream = new MemoryStream(decodedDados);
        return memoryStream;
    }



}
