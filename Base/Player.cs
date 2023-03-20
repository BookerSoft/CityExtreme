using System;
namespace CityExtreme.Base{
    public class Player{
        public string Name,Type;
        public double Cash,Profit,AvgProfit,CumProfit,EmpireValue;
        public SFML.Graphics.Image picture;
        public SFML.Audio.Sound winAuction,looseauction;

        public int id,Rosettes;


        public Player(string type,string name,double scash,int plid){
            Name = name;
            Type = type;
            Cash = scash;
            id = plid;
            if(System.IO.File.Exists("C:\\Users\\"+Environment.UserName+"\\Games\\CityExtreme\\Profiles\\"+Name+"\\headshot.jpg")){
                picture = new SFML.Graphics.Image("C:\\Users\\"+Environment.UserName+"\\Games\\CityExtreme\\Profiles\\"+Name+"\\headshot.jpg");
            }

            if(System.IO.File.Exists("C:\\Users\\"+Environment.UserName+"\\Games\\CityExtreme\\Profiles\\"+Name+"\\winauction.wav")){
                winAuction = new SFML.Audio.Sound(new SFML.Audio.SoundBuffer("C:\\Users\\"+Environment.UserName+"\\Games\\CityExtreme\\Profiles\\"+Name+"\\winauction.wav"));
                
            }
            if(System.IO.File.Exists("C:\\Users\\"+Environment.UserName+"\\Games\\CityExtreme\\Profiles\\"+Name+"\\looseauction.wav")){
                looseauction = new SFML.Audio.Sound(new SFML.Audio.SoundBuffer("C:\\Users\\"+Environment.UserName+"\\Games\\CityExtreme\\Profiles\\"+Name+"\\looseauction.wav"));
                
            }

            
        }
        public Player(string type,string name,int plid){
            Name = name;
            id=plid;
            Cash = 0.00;
            Type = type;
            if(type=="AI"){
                if(System.IO.File.Exists(MainClass.Approot+"\\images\\pclg.png")){
                    picture = new SFML.Graphics.Image(MainClass.Approot+"\\images\\pclg.png");
                }else{

                }
            }

        }

    }
}