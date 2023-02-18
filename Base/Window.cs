using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
namespace CityExtreme.Base{
    public class Window:RenderWindow{
        public Window(VideoMode m):base(m,"City Extreme",SFML.Window.Styles.Fullscreen,new ContextSettings(32,32,2,3,1,ContextSettings.Attribute.Core,true)){
            MouseButtonPressed += MouseClick;
        }

       
        public static void MouseClick(object? sender, MouseButtonEventArgs e){
            if(Support.b.state == 0 && Support.b.menu ==0){
                if(Support.b.main != null){
                    PreGame_Menu.Main_FE.MouseClick(sender,e);
                }
            }else if(Support.b.state == 0 && Support.b.menu ==1 && Support.b.menupg == 0){
                if(Support.b.preLobby != null){
                    PreGame_Menu.PreLobby_FE.MouseClick(sender,e);
                    Gui.DropDownMenu.MouseClick(sender,e);
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
                                            if(Support.b.preLobby.menuDropDowns !=null &&Support.b.preLobby.menuDropDowns[0].ddvisible == true ){
                                                Draw(Support.b.preLobby);

                                            }else if(Support.b.preLobby.menuDropDowns !=null && Support.b.preLobby.menuDropDowns[1].ddvisible == true){
                                                Draw(Support.b.preLobby);
                                            }else{
                                                Draw(Support.b.preLobby);
                                            }
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