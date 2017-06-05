using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Security {




    private void encodeSimetricKey(byte[] dados)
    {        
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
        byte[] privateKey = Encoding.UTF8.GetBytes(rsa.ToXmlString(true));
        byte[] encryptedDados = rsa.Encrypt(dados, false);

        FileStream chaveAssimetrica = File.Create(Application.persistentDataPath + "/Service.ide");
        chaveAssimetrica.Write(privateKey, 0, privateKey.Length);
        chaveAssimetrica.Close();

        FileStream chaveSimetrica = File.Create(Application.persistentDataPath + "/Service.key");
        chaveSimetrica.Write(encryptedDados, 0, encryptedDados.Length);
        chaveSimetrica.Close();
    }

    private byte[] decodeSimetricKey()
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);

        FileStream chaveAssimetrica = File.OpenRead(Application.persistentDataPath + "/Service.ide");
        byte[] byteAssimetricKey = new byte[chaveAssimetrica.Length];
        chaveAssimetrica.Read(byteAssimetricKey, 0, byteAssimetricKey.Length);
        chaveAssimetrica.Close();
        rsa.FromXmlString(Encoding.UTF8.GetString(byteAssimetricKey));

        FileStream chaveSimetrica = File.OpenRead(Application.persistentDataPath + "/Service.key");
        byte[] byteSimetricKey = new byte[chaveSimetrica.Length];
        chaveSimetrica.Read(byteSimetricKey, 0, byteSimetricKey.Length);
        chaveSimetrica.Close();

        byte[] decodedDados = rsa.Decrypt(byteSimetricKey, false);
        return decodedDados;
    }


    public byte[] encode(byte[] dados)
    {
        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.GenerateIV();
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;
        tdes.GenerateKey();

        encodeSimetricKey(tdes.Key);

        ICryptoTransform transform = tdes.CreateEncryptor(tdes.Key, tdes.IV);
        return transform.TransformFinalBlock(dados, 0, dados.Length);
    }


    public Stream decode(byte[] dados)
    {
        byte[] decodedSimetricKey = decodeSimetricKey();

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.GenerateIV();
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;
        tdes.Key = decodedSimetricKey;

        ICryptoTransform transform = tdes.CreateDecryptor(tdes.Key, tdes.IV);
        MemoryStream memory = new MemoryStream(transform.TransformFinalBlock(dados, 0, dados.Length));
        return memory;
    }



}
