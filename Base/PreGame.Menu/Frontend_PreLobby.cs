using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace CityExtreme.Base.PreGame_Menu{
    public class PreLobby_FE : Drawable
    {
        public Text Title,objTitle,gameSetTitle,selMapTitle,ScenDescTitle,sessNameLabel,sessNameText;
        public Text[] objButton = new Text[Support.b.objective.Length];
        public Gui.DropDownMenu[] menuDropDowns; 
        public static bool[] menuDDVisible;
        public static bool[] forlastddin = new bool[4];
        
        public static int lastddin =-1,curddin=-1;
        static PreLobby_FE _self;
        public PreLobby_FE(string type, ContextSettings? cs){
            //Global Titles for Sections
            objTitle = new Text("Select Objective",Support.b.defFont,65);
            gameSetTitle = new Text("Configure Session Settings",Support.b.defFont,65);
            selMapTitle = new Text("Select Game Map",Support.b.defFont, 65);
            ScenDescTitle = new Text("Objective Description",Support.b.defFont,65);
            objTitle.FillColor = Color.White;
            gameSetTitle.FillColor = Color.White;
            selMapTitle.FillColor = Color.White;
            ScenDescTitle.FillColor = Color.White;
            for(int i=0;i<Support.b.objective.Length;i++){
                objButton[i] = new Text(Support.b.objective[i],Support.b.defFont,45);
                objButton[i].FillColor = Color.White;
             }
             sessNameLabel = new Text("Session Name",Support.b.defFont,30);
             sessNameLabel.FillColor = Color.White;
             sessNameText = new Text(Support.b.curplayer,Support.b.defFont,30);
             sessNameText.DisplayedString = "New Game";
             sessNameText.FillColor = Color.White;
             
            //End Section
            switch(type){
                case "local":{
                    Title = new Text(" Configure Local Session",Support.b.defFont,85);
                    sessNameLabel = new Text("Session Name: ",Support.b.defFont,30);

                    Title.FillColor = Color.White;
                    if(Support.b.w != null){
                        Title.Position = new Vector2f(Support.b.w.Size.X/(float)3.75,0);
                        objTitle.Position = new Vector2f(10,Title.Position.Y + Title.GetGlobalBounds().Height +10);
                        gameSetTitle.Position = new Vector2f(Support.b.w.Size.X - (gameSetTitle.GetGlobalBounds().Width*2)+100,Title.GetGlobalBounds().Height+10);
                        sessNameLabel.Position = new Vector2f(gameSetTitle.Position.X,gameSetTitle.Position.Y + gameSetTitle.GetGlobalBounds().Height+10);
                        sessNameText.Position = new Vector2f(sessNameLabel.Position.X + sessNameLabel.GetGlobalBounds().Width + 10,sessNameLabel.Position.Y+sessNameLabel.GetGlobalBounds().Height+10);
                        menuDropDowns = new Gui.DropDownMenu[Support.b.ddItemStrings.GetLongLength(0)];
                        menuDDVisible = new bool[menuDropDowns.Length];
                        for(int i=0;i<menuDDVisible.Length;i++){
                            menuDDVisible[i]=false;
                        }
                        for(int i=0;i<objButton.Length;i++){
                            if(i==0){
                                objButton[i].Position = new Vector2f(objTitle.Position.X,objTitle.Position.Y+objTitle.GetGlobalBounds().Height+10);

                            }else{
                                objButton[i].Position = new Vector2f(objButton[i-1].Position.X,objButton[i-1].Position.Y+objButton[i-1].GetGlobalBounds().Height +5);
                            }
                        
                        }
                        selMapTitle.Position = new Vector2f(0,Support.b.w.Size.Y*.575f);


                    }
                    _self =this;







                    break;
                }
                case "Network":{
                    
                    break;
                }
            }
        }
        public void initandPositionDropdowns(){
            for(int i=0;i<Support.b.objSelected.Length;i++){
                    if(Support.b.objSelected[i]){
                        objButton[i].FillColor = Color.Green;
                    }else{
                        objButton[i].FillColor = Color.White;
                    }
                }
            if(Support.b.curobjective == "Total Daily Profit"){
                
                string[] tmp = new string[Support.b.ddItemStrings.GetLongLength(1)];
                        for(int i=0;i<Support.b.ddItemStrings.GetLongLength(1);i++){
                            tmp[i] = Support.b.ddItemStrings[0,i];

                        }
                        menuDropDowns[0] = new Gui.DropDownMenu(2,new Vector2f(100,100),new Vector2f(sessNameLabel.Position.X,sessNameLabel.Position.Y+sessNameLabel.GetGlobalBounds().Height+sessNameText.GetGlobalBounds().Height+10),Support.b.objSettings[0,0,0],tmp,0);
                        tmp = new string[Support.b.ddItemStrings.GetLongLength(1)];
                        for(int i=0;i<Support.b.ddItemStrings.GetLongLength(1);i++){
                            tmp[i] = Support.b.ddItemStrings[1,i];

                        }
                        menuDropDowns[1] = new Gui.DropDownMenu(2,new Vector2f(100,100),new Vector2f(sessNameLabel.Position.X,menuDropDowns[0].backing.Position.Y+menuDropDowns[0].backing.GetGlobalBounds().Height+10),Support.b.objSettings[0,1,0],tmp,1);


            }
        }
        static void objsel(){
            for(int i =0;i<_self.objButton.Length;i++){
                        if(_self.objButton[i].GetGlobalBounds().Contains(Mouse.GetPosition().X,Mouse.GetPosition().Y)){
                            _self.objButton[i].FillColor = Color.Green;
                            Support.b.curobjective = _self.objButton[i].DisplayedString;
                            Support.b.objSelected[i] = true;
                            _self.initandPositionDropdowns();
                        }else if(Support.b.curobjective == _self.objButton[i].DisplayedString){
                            Support.b.objSelected[i] = true;
                        }else{
                            Support.b.objSelected[i] = false;
                        }

                    }
        }
        public static void MouseClick(object? sender, MouseButtonEventArgs e){
            switch(e.Button){
                case Mouse.Button.Left:{
                    
                    if(Support.b.curobjective == "Total Daily Profit"){
                        objsel();
                        bool ib,insil;
                        if(lastddin == _self.menuDropDowns[lastddin].id&&_self.menuDropDowns[lastddin] !=null ){
                            ib = forlastddin[0];
                            insil = forlastddin[1];
                            if(ib && insil && _self.menuDropDowns[lastddin].isvisible == false){
                                    _self.menuDropDowns[lastddin].isvisible = true;
                                    Console.Write(_self.menuDropDowns[lastddin].isvisible.ToString()+Environment.NewLine);
                                    objsel();
                            }else{
                                _self.menuDropDowns[lastddin].isvisible = false;
                            }
                                
                            
                        }else if(_self.menuDropDowns[1].backing.GetGlobalBounds().Contains(e.X,e.Y)){
                            Gui.DropDownMenu.MouseClick(sender,e);
                        }
                    }else{
                        objsel();
                    }
                    break;
                }
            }
        }
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            initandPositionDropdowns(); 
            Title.Draw(target,states);
            if(objTitle!=null)
            objTitle.Draw(target,states);
            if(objButton !=null)
            foreach(Text ob in objButton){
                if(ob !=null){
                    
                        ob.Draw(target,states);
                    
                }

            }
            if(Support.b.curobjective == "Total Daily Profit"){
              
             
            
                if(menuDropDowns !=null){
                    foreach(Gui.DropDownMenu dd in menuDropDowns){
                        if(dd != null ){
                            Console.WriteLine(Gui.DropDownMenu.ddvisible.ToString());
                            if(dd.id == lastddin && dd.isvisible == true )
                            {
                                dd.Draw(target,states);
                            }
                            else
                            dd.Draw(target,states);
                        }
                    }
                }
            }
            selMapTitle.Draw(target,states);
            gameSetTitle.Draw(target,states);
            sessNameLabel.Draw(target,states);
            sessNameText.Draw(target,states);
        }
    }
}
