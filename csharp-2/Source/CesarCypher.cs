using System;
using System.Linq;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public static readonly string alfabeto = "abcdefghijklmnopqrstuvwxyz";
        public static readonly int chave = 3;

        public string ProMsg (string msg, bool Cifrada){
            if (msg is null) {
                throw new ArgumentNullException(nameof(msg));
            }

            int Inicio, Result, Cont;
            string Decifrado = "";

            msg = msg.ToLower();

            for (int i = 0; i < msg.Length; i++){
                
                char ch = msg[i];
                char chResult;

                if (!alfabeto.Contains(ch)){
                    if (char.IsWhiteSpace(ch) || char.IsNumber(ch)){
                        Decifrado += ch;
                    }
                    else{
                        throw new ArgumentOutOfRangeException();
                    }
                }
                else {
                    Inicio = alfabeto.IndexOf(ch);

                    Cont = !Cifrada ? Inicio + chave : Inicio - chave;

                    if (Cont >= 0 && Cont < alfabeto.Length){
                        chResult = alfabeto[Cont]; 
                    }
                    else {
                        Result = !Cifrada ? Cont - alfabeto.Length : alfabeto.Length + Cont;
                        chResult = alfabeto [Result];
                    }

                    Decifrado += chResult;
                }
            }
            return Decifrado;
        }

        public string Crypt(string message)
        {
            return ProMsg(message, false);
        }

        public string Decrypt(string cryptedMessage)
        {
            return ProMsg(cryptedMessage, true);
        }
    }
}
