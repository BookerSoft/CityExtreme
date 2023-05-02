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
        public Gui.NumTicker[]  menuNumtickers =new Gui.NumTicker[2];
        public static bool[] menuDDVisible;
        public static bool[][] forddin = new bool[10][],issilclicked = new bool[10][];
        public static string[] numTickerNLDS = new string[2]; 
        public static int lastddin =-1,curddin=-1,ddlastpg=0;
        public static int[] laststepforTicker = new int[2];
        public Gui.TextField SessionName;
        static PreLobby_FE _self;
        public PreLobby_FE(string type, ContextSettings? cs){
            //Global Titles for Sections
            objTitle = new Text("Select Objective",Support.b.defFont,45);
            gameSetTitle = new Text("Configure Session Settings",Support.b.defFont,45);
            selMapTitle = new Text("Select Game Map",Support.b.defFont, 45);
            ScenDescTitle = new Text("Objective Description",Support.b.defFont,45);
            objTitle.FillColor = Color.White;
            gameSetTitle.FillColor = Color.White;
            selMapTitle.FillColor = Color.White;
            ScenDescTitle.FillColor = Color.White;
            for(int i=0;i<Support.b.objective.Length;i++){
                objButton[i] = new Text(Support.b.objective[i],Support.b.defFont,25);
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
                    Title = new Text(" Configure Local Session",Support.b.defFont,65);
                    sessNameLabel = new Text("Session Name: ",Support.b.defFont,30);
                    

                    Title.FillColor = Color.White;
                    if(Support.b.w != null){
                        Title.Position = new Vector2f(Support.b.w.Size.X/(float)3.75,0);
                        objTitle.Position = new Vector2f(10,Title.Position.Y + Title.GetGlobalBounds().Height +10);
                        gameSetTitle.Position = new Vector2f(Support.b.w.Size.X - (gameSetTitle.GetGlobalBounds().Width*2)+100,Title.GetGlobalBounds().Height+10);
                        SessionName = new Gui.TextField("Session Name",new Vector2f(gameSetTitle.Position.X,gameSetTitle.Position.Y + gameSetTitle.GetGlobalBounds().Height+10));
                        SessionName.SetInputDisplayedStr("New Game");
                        SessionName.SetCharSize(65);
                        SessionName.SetInputFieldPos();
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
            if(Support.b.curobjective == "Total Daily Profit" && Support.b.curobjective!=Support.b.lastobjective){
                
                string[] tmp = new string[Support.b.ddItemStrings.GetLongLength(1)];
                        for(int i=0;i<Support.b.ddItemStrings.GetLongLength(1);i++){
                            tmp[i] = Support.b.ddItemStrings[0,i];

                        }
                        menuDropDowns[0] = new Gui.DropDownMenu(2,new Vector2f(100,100),new Vector2f(SessionName.Position.X,SessionName.Position.Y+SessionName.GlobalBounds.Height+sessNameText.GetGlobalBounds().Height+40),Support.b.objSettings[0,0,0],tmp,0);
                        if(Support.b.plDDSilClicked[0] == null || Support.b.plForDDin[0] ==null)
                        menuDropDowns[0].setNoOfBools();

                        
                        tmp = new string[Support.b.ddItemStrings.GetLongLength(1)];
                        for(int i=0;i<Support.b.ddItemStrings.GetLongLength(1);i++){
                            tmp[i] = Support.b.ddItemStrings[1,i];

                        }
                        
                         
                        menuDropDowns[1] = new Gui.DropDownMenu(2,new Vector2f(100,100),new Vector2f(sessNameLabel.Position.X,menuDropDowns[0].backing.Position.Y+menuDropDowns[0].backing.GetGlobalBounds().Height+10),Support.b.objSettings[0,1,0],tmp,1);
                        int m =int.Parse(Support.b.objSettings[0,2,1]);
                                              menuNumtickers[0] = new Gui.NumTicker(new Vector2f(menuDropDowns[0].backing.Position.X,menuDropDowns[0].backing.Position.Y +menuDropDowns[0].backing.GetGlobalBounds().Height+100),m,30000,1000,Support.b.objSettings[0,2,0],0);
                        if(Support.b.plDDSilClicked[1] == null || Support.b.plForDDin[1] ==null)
                        menuDropDowns[1].setNoOfBools(); 
                        for(int a =0;a<menuDropDowns.Length;a++){
                            if((a==lastddin && menuDropDowns[a]!=null)||menuDropDowns[a]!=null){
                                if(Support.b.plDDSilClicked[a][0] == true){
                                    
                                    for(int b=0;b<Support.b.plForDDin[a].Length;b++){
                                        if(b<2 && lastddin == a){
                                            Support.b.plForDDin[a][b] = true;
                                        
                                        }else if(lastddin == a){
                                            Support.b.plForDDin[a][b] = false;

                                        }                                       
                                        else if(b<2){
                                            Support.b.plForDDin[a][b] = false;
                                            
                                        }else{
                                            Support.b.plForDDin[a][b] = false;
                                        }
                                    }
                                    if(a==lastddin)
                                    {
                                        menuDropDowns[a].isvisible =true;
                                        if(ddlastpg != menuDropDowns[a].curpg)
                                        menuDropDowns[a].curpg = ddlastpg;
                                    }
                                    else
                                    menuDropDowns[a].isvisible =false;
                                }
                            }

                            
                        }
                        


            }else if(Support.b.curobjective == "Average Daily Profit" && Support.b.curobjective != Support.b.lastobjective){
                string[] tmp = new string[Support.b.ddItemStrings.GetLongLength(1)];
                for(int i=0;i<Support.b.ddItemStrings.GetLongLength(1);i++){
                            tmp[i] = Support.b.ddItemStrings[0,i];

                        }
                        menuDropDowns[0] = new Gui.DropDownMenu(2,new Vector2f(100,100),new Vector2f(SessionName.Position.X,SessionName.Position.Y+SessionName.GlobalBounds.Height+sessNameText.GetGlobalBounds().Height+40),Support.b.objSettings[1,0,0],tmp,0);
                        if(Support.b.plDDSilClicked[0] == null || Support.b.plForDDin[0] ==null)
                        menuDropDowns[0].setNoOfBools();

                        
                        tmp = new string[Support.b.ddItemStrings.GetLongLength(1)];
                        for(int i=0;i<Support.b.ddItemStrings.GetLongLength(1);i++){
                            tmp[i] = Support.b.ddItemStrings[1,i];

                        }
                        
                         
                        menuDropDowns[1] = new Gui.DropDownMenu(2,new Vector2f(100,100),new Vector2f(sessNameLabel.Position.X,menuDropDowns[0].backing.Position.Y+menuDropDowns[0].backing.GetGlobalBounds().Height+10),Support.b.objSettings[1,1,0],tmp,1);
                        int m =int.Parse(Support.b.objSettings[1,2,1]);
                                              menuNumtickers[0] = new Gui.NumTicker(new Vector2f(menuDropDowns[0].backing.Position.X,menuDropDowns[0].backing.Position.Y +menuDropDowns[0].backing.GetGlobalBounds().Height+100),m,30000,1000,Support.b.objSettings[1,2,0],0);
                        if(Support.b.plDDSilClicked[1] == null || Support.b.plForDDin[1] ==null)
                        menuDropDowns[1].setNoOfBools(); 
                        for(int a =0;a<menuDropDowns.Length;a++){
                            if((a==lastddin && menuDropDowns[a]!=null)||menuDropDowns[a]!=null){
                                if(Support.b.plDDSilClicked[a][0] == true){
                                    
                                    for(int b=0;b<Support.b.plForDDin[a].Length;b++){
                                        if(b<2 && lastddin == a){
                                            Support.b.plForDDin[a][b] = true;
                                        
                                        }else if(lastddin == a){
                                            Support.b.plForDDin[a][b] = false;

                                        }                                       
                                        else if(b<2){
                                            Support.b.plForDDin[a][b] = false;
                                            
                                        }else{
                                            Support.b.plForDDin[a][b] = false;
                                        }
                                    }
                                    if(a==lastddin)
                                    {
                                        menuDropDowns[a].isvisible =true;
                                        if(ddlastpg != menuDropDowns[a].curpg)
                                        menuDropDowns[a].curpg = ddlastpg;
                                    }
                                    else
                                    menuDropDowns[a].isvisible =false;
                                }
                            }

                            
                        }
                        


            }
        }

        static void objsel(){
            for(int i =0;i<_self.objButton.Length;i++){
                        if(_self.objButton[i].GetGlobalBounds().Contains(Mouse.GetPosition().X,Mouse.GetPosition().Y)){
                            _self.objButton[i].FillColor = Color.Green;
                            Support.b.lastobjective = Support.b.curobjective;
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
        public void MouseWheelScrolled(object? sender,MouseWheelScrollEventArgs e){
            if(menuDropDowns!=null){
                
                    if(lastddin >= 0 && menuDropDowns[lastddin] != null ){
                        menuDropDowns[lastddin].wheelMoved(sender,e);
                    }
                
            }
        }
        public static void MouseClick(object? sender, MouseButtonEventArgs e){
            switch(e.Button){
                case Mouse.Button.Left:{
                    if(Support.b.curobjective == "Total Daily Profit"){
                        
                        objsel();
                        goto executeactions;
                    }else if(Support.b.curobjective == "Average Daily Profit"){
                        
                        objsel();
                        goto executeactions;
                        }   
                    break;
                    

                    
                }
            }
        executeactions:{
           //Support.b.lastobjective = Support.b.curobjective;
            if(_self.menuNumtickers!=null){
                            foreach(Gui.NumTicker nt in _self.menuNumtickers){
                                if(nt!=null){
                                    nt.Click(sender,e);
                                }
                            }
                        }
                        bool ib,insil;
                        int l_id;
                        
                        if(lastddin>=0){
                        l_id =lastddin;

                            if( _self.menuDropDowns[l_id] !=null){
                                
                            ib = Support.b.plForDDin[l_id][0];
                            insil = Support.b.plForDDin[l_id][1];
                            if(lastddin == _self.menuDropDowns[l_id].id && ib && insil ){
                                
                                
                                    if(_self.menuDropDowns[l_id] != null){
                                        
                                            Support.b.plDDSilClicked[l_id][0] = true;
                                            
                                            if(Support.b.plForDDin[l_id][0] && Support.b.plDDSilClicked[l_id][0]){
                                                if(!_self.menuDropDowns[l_id].isvisible)
                                                Support.b.plDDSilClicked[l_id][0] = true;
                                                else{
                                                    Support.b.plDDSilClicked[l_id][0] = false;
                                                }

                                            }
                                        

                                    }
                                    
                                
                                
                                     
                                    Console.Write(_self.menuDropDowns[lastddin].getsilclicked().ToString() + _self.menuDropDowns[1].getsilclicked()+Environment.NewLine);
                                    objsel();
                                }else{
                                foreach(Gui.DropDownMenu dd in _self.menuDropDowns){
                                    if(dd != null)
                                    switch(dd.id){
                                        case 0:{
                                            
                                            _self.menuDropDowns[0].setsilclicked(false);
                                            Support.b.plForDDin[0][0] =false;
                                            Support.b.plForDDin[0][1] = false;
                                            Support.b.plDDSilClicked [0][0]= false;

                                            break;
                                        }
                                        case 1:{
                                            _self.menuDropDowns[1].setsilclicked(false);
                                            Support.b.plDDSilClicked[1][0]=false;

                                            break;

                                        }
                                    }
                                }
                                objsel();
                            }
                            }else{
                                objsel();
                            }
                                


                            
                        }else{
                            
                            objsel();
                        }
                        Support.b.lastobjective = Support.b.curobjective;
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
              
             goto displaysettings;
                

                

            }else if(Support.b.curobjective == "Average Daily Profit"){
                goto displaysettings;

            }
            displaysettings:{

                if(menuNumtickers!=null){
                    foreach(Gui.NumTicker nt in menuNumtickers){
                        if(nt!=null){
                            if(Gui.NumTicker.numlblupdneeded){
                                target.Draw(nt);
                            }else{
                                target.Draw(nt);
                            }
                        }
                    }
                }
            
                if(menuDropDowns !=null){
                   
                            
                                for(int i=0;i<_self.menuDropDowns.Length;i++){
                                    if(_self.menuDropDowns[i] != null){
                                        if(_self.menuDropDowns[i].isvisible && Support.b.plDDSilClicked[i][0])
                                        _self.menuDropDowns[i].Draw(target,states);
                                        else
                                        _self.menuDropDowns[i].Draw(target,states);
                                    }

                                }
                            
                            
                }
            }        
                
            
            selMapTitle.Draw(target,states);
            gameSetTitle.Draw(target,states);
            //sessNameLabel.Draw(target,states);
            //sessNameText.Draw(target,states);
            target.Draw(SessionName);
            
        }
    }
}
