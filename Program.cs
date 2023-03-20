using System;
using System.IO;
namespace CityExtreme{
    class MainClass{
        public static Base.Support s;
        public static string Approot = System.IO.Directory.GetCurrentDirectory();
        public static void Main(string[] args){
            s = new Base.Support();
            
            Base.Support.b.w.run();

        }
    }
}
