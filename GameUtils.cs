using System;


namespace GameUtils
{
    public class Display
    {
        public string feedback = "";
        public bool showinv = true;
        private int cursorstart = 1;
        public string title;
        
        public Display(){   }
        
        public void Configure(string t)
        {
                title = Console.Title = t;
                Console.SetWindowSize(100, 50);
                Console.ResetColor();
                Wipe();
        }
        
        public void ResetCursor(){ Console.CursorTop=cursorstart; Console.CursorLeft=0; }
        public void Wipe(){Console.Clear(); ResetCursor();} 
        
        public void WriteHelp(){
            Console.WriteLine("Available commands:          [alternative]");
            Console.WriteLine("  exit [quit] - quit game");
            Console.WriteLine("  gui - toggle size of GUI");
            Console.WriteLine("  inv - show/hide inventory");
            Console.WriteLine("  help - show this list");
            Console.WriteLine("  examine xx [ex xx] - examine something");
        }
        
        public void WriteLeft(string msg)
        {
            try{
                Console.CursorLeft = 0;
                Console.WriteLine(msg);
            }
            catch(System.Exception){Console.WriteLine(msg);} 
        }
        
        public void WriteCentralLeft(string msg, int margin)
        {
            try{
                Console.CursorLeft = margin;
                Console.WriteLine(msg);
                Console.CursorLeft = 0;
            }
            catch(System.Exception){Console.WriteLine(msg);}    
        }
        
        public void WriteLeftRightSplit(string l, string r)
        {
            string s = "";
            for (int i = 1; i <= (Console.WindowWidth-l.Length-r.Length); i++) s += " ";
            s = l + s + r;
            Console.WriteLine(s);
        }
        
        public void WriteCentral(string msg)
        {
            try{
                Console.CursorLeft = (Console.WindowWidth/2)-(msg.Length/2);
                Console.WriteLine(msg);
                Console.CursorLeft = 0;
            }
            catch(System.Exception){Console.WriteLine(msg);}              
        }
        
        public void FullLine(char c)
        {
            for (int i = 1; i <= Console.WindowWidth; i++) { Console.Write(c); }
            Console.CursorLeft = 0;
        }
        
        public void Inc() { Console.CursorTop++; }
        public void Inc(int i) { Console.CursorTop+=i; }
        
        public string UserPrompt() {
            Console.Write("?> ");
            return Console.ReadLine();
        }
        
    }
}
