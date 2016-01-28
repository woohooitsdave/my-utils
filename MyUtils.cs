using System;

namespace MyUtils
{
    public struct Config
    {
        private string cfgID, cfgValue;
        
        public Config(string i, string v) { cfgID = i; cfgValue = v; }
        public string Value() { return cfgValue; }
        public string Name() { return cfgID; }
        public void Set(string newVal){ cfgValue = newVal; }
    }
    
    public class Display
    {
        
        
        
        
    }
    
    
    
    public class Security
    {
        private System.IO.StreamReader inpFile;
        private System.IO.StreamWriter outFile;
        private char[] delimiters = new char[] { 'a', 'b', 'c', 'd', '\n' };
        
        public Security() { }
        
        public Security(char[] delims) { delimiters = delims; }
        
        public void EncryptFile(string inpfname, string outfname)
        {
            inpFile = new System.IO.StreamReader(inpfname);
            outFile = new System.IO.StreamWriter(outfname);
            Random randomSeed = new Random();

            string confs = inpFile.ReadToEnd();
            char[] charArr = confs.ToCharArray();            
            
            foreach (char ch in charArr)
            {
                int encrypt = ch*2;
                int rndm = randomSeed.Next(0, delimiters.Length);
                char bumper = delimiters[rndm];
                outFile.Write(encrypt+""+ bumper);
            } 
            Console.WriteLine("Encryption done");
            inpFile.Close();    
            outFile.Close();
        }
        
        
        public void DecryptFile(string inpfname, string outfname)
        {
            inpFile = new System.IO.StreamReader(inpfname);
            outFile = new System.IO.StreamWriter(outfname);
            
            string[] confsArr = inpFile.ReadToEnd().Split(delimiters,
				     StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string conf in confsArr)
            {
                int decrypt = 0;
                if(conf != ""){
                    try {
                        decrypt = Int32.Parse(conf)/2;
                        outFile.Write((char)decrypt);
                    } catch { Console.WriteLine("\nerror: " + conf);}
                }
            }
            Console.WriteLine("Decryption done");
            inpFile.Close();    
            outFile.Close();
        }
        
    }//class: Security
    
    
    public struct ConsoleSettings
    {
        public int W, H;        
        public ConsoleColor BG, FG;
        public ConsoleSettings(int w, int h, ConsoleColor b, ConsoleColor f){
            W = w; H = h; BG = b; FG = f;}
    }
    
    
    public static class MyExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, 
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
