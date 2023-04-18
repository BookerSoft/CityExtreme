using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
namespace CityExtreme.Base{
    public class Window:RenderWindow{
        public Window(VideoMode m):base(m,"City Extreme",SFML.Window.Styles.Fullscreen,new ContextSettings(32,32,2,3,1,ContextSettings.Attribute.Core,true)){
            MouseButtonPressed += MouseClick;
            MouseMoved += MouseMove;
            KeyPressed += KeyPress;
            MouseWheelScrolled += MouseWheelScroll;

        }

       public static void MouseMove(object? sender, MouseMoveEventArgs e){
        if(Support.b.PlayerManDlg !=null && Support.b.state == 0 && Support.b.PlayerManDlg.Visible){
            Support.b.PlayerManDlg.MouseMove(sender,e);
        }
        if(Support.b.state == 0 && Support.b.menu ==1 && Support.b.menupg ==0&& Support.b.curobjective == "Total Daily Profit" && Support.b.preLobby.menuDropDowns!=null){
            foreach(Gui.DropDownMenu dd in Support.b.preLobby.menuDropDowns){
                if(dd!=null ){
                    if( !((IntRect)dd.backing.GetGlobalBounds()).Contains(e.X,e.Y) && !((IntRect)dd.selItemLabel.GetGlobalBounds()).Contains(e.X,e.Y) && !((IntRect)dd.ddbacking.GetGlobalBounds()).Contains(e.X,e.Y)){
                            for(int i =0;i<Support.b.plForDDin[dd.id].Length;i++){
                            if(i<2)
                            Support.b.plForDDin[dd.id][i]=false;
                            else{
                                Support.b.plForDDin[dd.id][i] =false;
                            }
                            }
                            
                        }
                        else if( ((IntRect)dd.backing.GetGlobalBounds()).Contains(e.X,e.Y) && ((IntRect)dd.selItemLabel.GetGlobalBounds()).Contains(e.X,e.Y) && !((IntRect)dd.ddbacking.GetGlobalBounds()).Contains(e.X,e.Y)){
                        PreGame_Menu.PreLobby_FE.curddin = dd.id;
                        Console.WriteLine(PreGame_Menu.PreLobby_FE.curddin.ToString());
                        
                        for(int i =0;i<Support.b.plForDDin[PreGame_Menu.PreLobby_FE.curddin].Length;i++){
                            if(dd.id == PreGame_Menu.PreLobby_FE.curddin&&i<2)
                            {
                                Support.b.plForDDin[PreGame_Menu.PreLobby_FE.curddin][i]=true;
                                
                                }
                            else if(i>=2){
                                if(dd.id == PreGame_Menu.PreLobby_FE.curddin && i>=2)
                                Support.b.plForDDin[dd.id][i] =false;
                                else
                                Support.b.plForDDin[dd.id][i] = false;
                            }
                        }
                        
                        if(PreGame_Menu.PreLobby_FE.curddin != PreGame_Menu.PreLobby_FE.lastddin && PreGame_Menu.PreLobby_FE.curddin >=0){
                            PreGame_Menu.PreLobby_FE.lastddin = PreGame_Menu.PreLobby_FE.curddin;
                            Console.Write(PreGame_Menu.PreLobby_FE.lastddin);
                           
                        }  
                            
                        }else if(((IntRect)dd.ddbacking.GetGlobalBounds()).Contains(e.X,e.Y)){
                            PreGame_Menu.PreLobby_FE.curddin =dd.id;
                            if()
                            for(int i =0;i<Support.b.plForDDin[PreGame_Menu.PreLobby_FE.lastddin].Length;i++){
                                if(dd.id == PreGame_Menu.PreLobby_FE.lastddin &&i<3){
                                    
                                    Support.b.plForDDin[dd.id][i] =true;
                                }else{
                                    Support.b.plForDDin[dd.id][i] = false;
                                }
                            }
                            }
                        
                    }else{
                         
                    }
                }
                     
                        
                
            
                
                        
                    
            
        }            
            
            
       }
       public void MouseWheelScroll(object? sender, MouseWheelScrollEventArgs e){
        if(Support.b.state == 0){
            if(Support.b.PlayerManDlg != null){
                if(Support.b.PlayerManDlg.Visible){
                    Support.b.PlayerManDlg.MouseWheelScrolled(sender,e);
                }
            }if(Support.b.preLobby !=null && ((Support.b.menu ==1&&Support.b.menupg ==0) || (Support.b.menu ==2&&Support.b.menupg==1))){
                Support.b.preLobby.MouseWheelScrolled(sender,e);

            }
        }

       }
        public static void KeyPress(object? sender, KeyEventArgs e){    
            if(Support.b.state == 0){
                if(e.Control && e.Code == Keyboard.Key.P){
                    if(Support.b.PlayerManDlg!=null){
                        if(Support.b.PlayerManDlg.Visible){
                            Support.b.PlayerManDlg.Visible = false;

                        }else{
                            Support.b.PlayerManDlg.Visible =true;
                        }
                    }
                }
            }

        }
        public static void MouseClick(object? sender, MouseButtonEventArgs e){
            if(Support.b.state == 0 && Support.b.menu ==0){
                if(Support.b.main != null){
                    PreGame_Menu.Main_FE.MouseClick(sender,e);
                    if(Support.b.PlayerManDlg!=null&&Support.b.PlayerManDlg.Visible){
                        Support.b.PlayerManDlg.MouseClicked(sender,e);
                    }
                }
            }else if(Support.b.state == 0 && Support.b.menu ==1 && Support.b.menupg == 0){
                if(Support.b.preLobby != null){
                    PreGame_Menu.PreLobby_FE.MouseClick(sender,e);
                    
                }
            }else if(Support.b.state ==0 && Support.b.menu ==1 && Support.b.menupg ==1){
                if(Support.b.lobby != null){
                    Support.b.lobby.MouseClick(sender,e);
                }
            }

        }
        public void render(){
            switch(Support.b.state){
                case 0:{
                    switch(Support.b.menu){
                        case 0:{
                            Draw(Support.b.main);
                            if(Support.b.PlayerManDlg.Visible){
                                Draw(Support.b.PlayerManDlg);
                            }
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
                                            if(Support.b.preLobby.menuDropDowns !=null && PreGame_Menu.PreLobby_FE.curddin>=0 &&Support.b.plForDDin[PreGame_Menu.PreLobby_FE.curddin][2])
                                                Draw(Support.b.preLobby);
                                            else
                                            Draw(Support.b.preLobby);    
                                            
                                            break;
                                        }
                                    }
                                }
                                

                            }else if(Support.b.menupg ==1){
                                Draw(Support.b.lobby);
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