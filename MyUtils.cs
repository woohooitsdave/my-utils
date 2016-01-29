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
        public Display() {}
        
        public void ConfigureConsole(ConsoleSettings cs){
            Console.SetWindowSize(cs.W, cs.H);
            Console.BufferWidth = cs.W;
            Console.BufferHeight = cs.H;
            Console.BackgroundColor = cs.BG;
            Console.ForegroundColor = cs.FG;
            Console.Clear();           
        }
        
        public void Write(string s){
            Console.Write(s);            
        }
        public void Write(char c){
            Console.Write(c);            
        }
        public void WriteLine(string s){
            Console.WriteLine(s);            
        }
        public void WriteLines(string[] strings){
            foreach(string s in strings) WriteLine(s);            
        }
    }
    
    
    
    public class Security
    {
        //private System.IO.StreamReader inpFile;
        //private System.IO.StreamWriter outFile;
        private char[] delimiters = new char[] { 'a', 'b', 'c', 'd', '\n' };
        
        public Security() { }
        
        public Security(char[] delims) { delimiters = delims; }
        
        public string Encrypt(string input)
        {
            return Encrypt(input.ToCharArray());
        }
            
        public string Encrypt(char[] input)
        {
            //inpFile = new System.IO.StreamReader(inpfname);
            //outFile = new System.IO.StreamWriter(outfname);
            Random randomSeed = new Random();          
            string output = "";
            foreach (char ch in input)
            {
                int encrypt = ch*2;
                int rndm = randomSeed.Next(0, delimiters.Length);
                char bumper = delimiters[rndm];
                output += (encrypt+""+ bumper);
            } 
            return output;
        }
        
        
        public string Decrypt(string input)
        {
            return Decrypt(input.Split(delimiters,
				     StringSplitOptions.RemoveEmptyEntries));
        }
        
        public string Decrypt(string[] input)
        {
            //inpFile = new System.IO.StreamReader(inpfname);
            //outFile = new System.IO.StreamWriter(outfname);
            
            string output = "";
            foreach (string conf in input)
            {
                int decrypt = 0;
                if(conf != ""){
                    try {
                        decrypt = Int32.Parse(conf)/2;
                        output += ((char)decrypt);
                    } catch { }
                }
            }
            return output;
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
