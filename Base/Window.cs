using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
namespace CityExtreme.Base{
    public class Window:RenderWindow{
        public Window(VideoMode m):base(m,"City Extreme",SFML.Window.Styles.Fullscreen,new ContextSettings(32,32,2,3,1,ContextSettings.Attribute.Core,true)){
            MouseButtonPressed += MouseClick;
            MouseMoved += MouseMove;
        }

       public static void MouseMove(object? sender, MouseMoveEventArgs e){
        if(Support.b.state == 0 && Support.b.menu ==1 && Support.b.menupg ==0&& Support.b.curobjective == "Total Daily Profit"){
            foreach(Gui.DropDownMenu dd in Support.b.preLobby.menuDropDowns){
                if(dd!=null){
                    if(((IntRect)dd.selItemLabel.GetGlobalBounds()).Contains(e.X,e.Y)){
                        PreGame_Menu.PreLobby_FE.curddin = dd.id;
                        Console.WriteLine(PreGame_Menu.PreLobby_FE.curddin.ToString());
                        PreGame_Menu.PreLobby_FE.forlastddin[0] =true;
                        PreGame_Menu.PreLobby_FE.forlastddin[1] = true;
                        PreGame_Menu.PreLobby_FE.forlastddin[2] = false;
                        PreGame_Menu.PreLobby_FE.forlastddin[3] = false;
                        if(PreGame_Menu.PreLobby_FE.curddin != PreGame_Menu.PreLobby_FE.lastddin && PreGame_Menu.PreLobby_FE.curddin >=0){
                            PreGame_Menu.PreLobby_FE.lastddin = PreGame_Menu.PreLobby_FE.curddin;
                            Console.Write(PreGame_Menu.PreLobby_FE.lastddin);
                          PreGame_Menu.PreLobby_FE.forlastddin[0] =true;
                        PreGame_Menu.PreLobby_FE.forlastddin[1] = true;
                        PreGame_Menu.PreLobby_FE.forlastddin[2] = false;
                        PreGame_Menu.PreLobby_FE.forlastddin[3] = false;  
                        }
                    }
                }
            }
                
                        
                    
            
                        
            
            
        }
       }
        public static void MouseClick(object? sender, MouseButtonEventArgs e){
            if(Support.b.state == 0 && Support.b.menu ==0){
                if(Support.b.main != null){
                    PreGame_Menu.Main_FE.MouseClick(sender,e);
                }
            }else if(Support.b.state == 0 && Support.b.menu ==1 && Support.b.menupg == 0){
                if(Support.b.preLobby != null){
                    PreGame_Menu.PreLobby_FE.MouseClick(sender,e);
                    
                }
            }

        }
        public void render(){
            switch(Support.b.state){
                case 0:{
                    switch(Support.b.menu){
                        case 0:{
                            Draw(Support.b.main);
                            break;
                        }
                        case 1:{
                            if(Support.b.menupg==0){
                                Support.b.initMenus(Support.b.w.Settings);
                                if(Support.b.curobjective =="")
                                Draw(Support.b.preLobby);
                                else{
                                    switch(Support.b.curobjective){
                                        case "Total Daily Profit":{
                                            
                                                Draw(Support.b.preLobby);
                                            
                                            break;
                                        }
                                    }
                                }
                                

                            }
                            
                            break;
                        }
                    }
                    break;
                }
            }
        }
        public void run(){
            if(IsOpen){
                Base.running = true;

            }
            SetActive();
            while(Base.running){
                DispatchEvents();
                Clear();
                render();

                Display();

            }
        }
        

        

    }
}