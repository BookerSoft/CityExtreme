using System;
using System.Collections.Generic;
using System.Data;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
namespace CityExtreme.Base{
    public class Base{
        public int state=0,menu=0,menupg=0,res_w=0,res_h=0,maxplayers=6;
        public Window w;
        public string curplayer="",curobjective="";
        public string[] objective = new string[8];
        public bool[] objSelected = new bool[8];
        public string[,,] objSettings = new string[8,10,2];
        public string[,] ddItemStrings;
        public string[,,] sessDetails = new string[1,10,2];

        public Player[] AiPlayers = new Player[10];
        public static bool running=false;
        public bool[][] plForDDin=new bool[10][],plDDSilClicked=new bool[10][];
        public Font defFont;
        public PreGame_Menu.Main_FE main;
        public PreGame_Menu.PreLobby_FE preLobby;
        public VideoMode defMode;
        public Base(){
            defFont = new Font("C:\\Windows\\Fonts\\Arial.ttf");
            objective[0] = "Total Daily Profit";
            objective[1] = "Average Daily Profit";
            objective[3] = "Highest Cumulative Profit";
            objective[4] = "Largest Empire Value";
            objective[5] = "First to be Mayor";
            objective[6] = "Largest Empire Value by";
            objective[7] = "Last Player Standing";
        
            for(int a=0;a<10;a++){
                plDDSilClicked[a] = new bool[1];
                plDDSilClicked[a][0] = false;
            }
            for(int a=0;a<10;a++){
                plForDDin[a] =new bool[20];
                for(int b=0;b<plForDDin[a].Length;b++){
                    plForDDin[a][b]=false;
                }
            }
            AiPlayers[0] = new Player("AI","Jane",0);
            AiPlayers[1] = new Player("AI","John",1);
            AiPlayers[2] = new Player("AI","Sue",2);
            AiPlayers[3] = new Player("AI","Dan",3);
            AiPlayers[4] = new Player("AI","George",4);
            AiPlayers[5] = new Player("AI","Fred",5);
            AiPlayers[6] = new Player("AI","Fran",6);
            AiPlayers[7] = new Player("AI","Dee",7);
            AiPlayers[8] = new Player("AI","Sean",8);
            AiPlayers[9] = new Player("AI","Sally",9);
            for(int a=0;a<=objSettings.GetLongLength(0)-1;a++){
                for(int b=0;b<=objSettings.GetLongLength(1)-1;b++){
                    for(int c=0;c<=objSettings.GetLongLength(2)-1;c++){
                        if(b==0&&c==0){
                            objSettings[a,b,c] = "Start Year";
                        }else if(b==0&&c==1){
                            objSettings[a,b,c] = "1930"; //Default Value
                        }else if(b==1&&c==0){
                            //Last Year in simulation
                            objSettings[a,b,c] = "End Year";

                        }else if(b==1&&c==1){
                            objSettings[a,b,c] = "unspecified"; //Default Value
                        }else if((a>=0&&a<3)&& b==2&&c==0){
                            objSettings[a,b,c] = "Target Daily Profit";

                        }else if((a>=0&&a<3) && b==2 && c==1){
                            objSettings[a,b,c] = "5000";
                        }else if((a>=1&&a<3)&&b==3&&c==0){
                            objSettings[a,b,c] = "periods in cycle";

                        }else if((a>=1&&a<3)&&b==3&&c==1){
                            objSettings[a,b,c] = "3";
                        }else if((a>=1&&a<3)&&b==4&&c==0){
                            objSettings[a,b,c] = "cycle length";

                        }else if((a>=1&&a<3)&&b==4&&c==1){
                            objSettings[a,b,c] = "24";
                        }
                    }
                }
            }
            ddItemStrings = new string[10,14];
            //ddMenuItems - Start Year and End Year
            for(int a=0;a<14;a++){
                
                
            if(a<13)    {
                ddItemStrings[0,a] = (1930+(a*5)).ToString();
                ddItemStrings[1,a] = (1930+((a+1)*5)).ToString(); //Last Year for new buildings
            }else{
                ddItemStrings[0,a] = "random";
                ddItemStrings[1,a] = "unspecified";
            }
            }
            if(res_w==0 && res_h==0){
                res_h = (int)VideoMode.DesktopMode.Height;
                res_w = (int)VideoMode.DesktopMode.Width;
                defMode = new VideoMode((uint) res_w,(uint)res_h,32);
                w=new Window(defMode);
                
                
            }else{
                w=new Window(VideoMode.DesktopMode);
            }




        }
        public void initMenus(ContextSettings cs){
            main = new PreGame_Menu.Main_FE(cs);
            if(menu == 1 && menupg ==0){
                preLobby = new PreGame_Menu.PreLobby_FE("local",w.Settings);

            }else if(menu ==2 && menupg==1){
                preLobby = new PreGame_Menu.PreLobby_FE("Network",w.Settings);
                
            }
        }

    }
}