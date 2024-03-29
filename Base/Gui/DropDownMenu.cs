using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
namespace CityExtreme.Base.Gui{
    public class DropDownMenu : Drawable
    {
        public Text DescLabel,selItemLabel;
        public Text[] ddItems;
        public int pgcnt=0,perpg=0,id,curpg=0;

        public static bool ddvisible=false,inbacking =false,inselitemlabel=false,silclicked=false;
        public bool isvisible{
            get{
                return ddvisible;

            }
            set{
                ddvisible =value;
            }
        }
        
        public RectangleShape backing;
        public RectangleShape ddbacking;
        public VertexArray[] arrow = new VertexArray[2];
        public CircleShape slider =new CircleShape(1,10);
        static DropDownMenu _self;
        public DropDownMenu(int pages,Vector2f size,Vector2f pos,string Desc,string[] displayed,int ddid){
            backing = new RectangleShape(size);
            
            backing.Position = pos;
            DescLabel = new Text(Desc,Support.b.defFont,35);
            DescLabel.Position = new Vector2f(backing.GetGlobalBounds().Left,backing.GetGlobalBounds().Top);
            DescLabel.FillColor =Color.White;
            selItemLabel = new Text("Select "+DescLabel.DisplayedString, Support.b.defFont,35);
            selItemLabel.FillColor = Color.White;
            selItemLabel.Position = new Vector2f(DescLabel.Position.X+DescLabel.GetGlobalBounds().Width +10, DescLabel.Position.Y);
            Vector2f tmp_sz= backing.Size;
            backing.Size = new Vector2f(DescLabel.GetGlobalBounds().Width+10+selItemLabel.GetGlobalBounds().Width,DescLabel.GetGlobalBounds().Height+10);
            id = ddid;
            ddItems = new Text[displayed.Length];
            for(int a=0;a<displayed.Length;a++){
                ddItems[a]=new Text(displayed[a],Support.b.defFont,35); 
                ddItems[a].FillColor =Color.Black;
            }
            ddbacking = new RectangleShape();
            ddbacking.Position = new Vector2f(selItemLabel.Position.X + selItemLabel.GetGlobalBounds().Width +10, selItemLabel.Position.Y+selItemLabel.GetGlobalBounds().Height);
            
            pgcnt = pages;
            perpg = ddItems.Length/pages;
            ddbacking.Size = new Vector2f(ddItems[0].GetGlobalBounds().Width+100,400);
            ddbacking.FillColor=Color.White;
            for(int a=0;a<ddItems.Length;a++){
                if(a==0||a==7){
                    ddItems[a].Position = new Vector2f(ddbacking.GetGlobalBounds().Left+1,ddbacking.GetGlobalBounds().Top+1);
                }else{
                    ddItems[a].Position = new Vector2f(ddItems[a-1].Position.X,ddItems[a-1].Position.Y+ddItems[a-1].GetGlobalBounds().Height);
                }
            }
            _self = this;
            isvisible = false;


        }
        public void setsilclicked(bool v){
            silclicked = v;
        }
        
        public bool getsilclicked(){
            return silclicked;
        }
        public static bool[] MouseMoved(object sender, MouseMoveEventArgs e){
            bool[] _in= new bool[2];
            if(((IntRect)_self.backing.GetLocalBounds()).Contains(e.X,e.Y)){
                PreGame_Menu.PreLobby_FE.curddin = _self.id;
                _in[0] = true;
                _in[1] = false;
            
                Console.WriteLine(_in[0].ToString());
                
                
                
                
                //System.IO.File.AppendAllText("dd_mmlog.txt", _self.inbacking.ToString()+"  "+_self.inselitemlabel.ToString()+Environment.NewLine);
                return _in;
            }else if(((IntRect)_self.selItemLabel.GetGlobalBounds()).Contains(e.X,e.Y)){
                    _in[0] = true;
                    _in[1] =true;
                    PreGame_Menu.PreLobby_FE.curddin = _self.id;

                    return _in;
                }else{
                _in[0] = false;
                PreGame_Menu.PreLobby_FE.lastddin = PreGame_Menu.PreLobby_FE.curddin;
                PreGame_Menu.PreLobby_FE.curddin = -1;
                _in[1] = false;
                return _in;
            }
        }
        public void setNoOfBools(){
            if(Support.b.plForDDin[_self.id] == null || Support.b.plForDDin[_self.id].Length > (3+_self.ddItems.Length)){
                Support.b.plForDDin[_self.id] = new bool[3+_self.ddItems.Length];

                for(int a=0;a<Support.b.plForDDin.Length;a++){
                    Support.b.plForDDin[_self.id][a] = false;
                }
                
            }else if(Support.b.plDDSilClicked[_self.id] == null){
                
                
            }
        }
        public static int MouseInDDId(object sender,MouseMoveEventArgs e){
            if(((IntRect)_self.selItemLabel.GetGlobalBounds()).Contains(e.X,e.Y)){
                return _self.id;
            }else{
                if(PreGame_Menu.PreLobby_FE.lastddin != PreGame_Menu.PreLobby_FE.curddin){
                    PreGame_Menu.PreLobby_FE.lastddin = PreGame_Menu.PreLobby_FE.curddin;
                    return -1;

                }else{
                    return -1;
                }
                
            }
        }
        public static void MouseClick(object? sender,MouseButtonEventArgs e){
            switch(e.Button){
                case Mouse.Button.Left:{
                if(inbacking == true && inselitemlabel == true){
                    if(ddvisible == false)
                    {
                        ddvisible = true;
                        Console.Write(ddvisible.ToString());
                    }
                    else
                        ddvisible = false;
                }
                break;
                }
            
            }
        }
        
        public void wheelMoved(object? sender, MouseWheelScrollEventArgs e){
            int l_curpg = PreGame_Menu.PreLobby_FE.ddlastpg;
            int l_pgcnt = ddItems.Length/perpg;
            Support.b.plForDDin[id][2] =true;

            if( Support.b.plForDDin[id][2] ==true && Support.b.plDDSilClicked[id][0]){
                if((l_curpg>=0 && l_curpg<=(l_pgcnt-1)) && e.Delta <0){
                   if(l_curpg==(l_pgcnt-1)){

                   }else
                   l_curpg++;
                    System.IO.File.AppendAllText(MainClass.Approot+"\\dd_curpg.log",l_curpg.ToString()+Environment.NewLine);
                }
                else if((l_curpg>0 && l_curpg<=l_pgcnt-1) && e.Delta > 0){
                    l_curpg--;
                    System.IO.File.AppendAllText(MainClass.Approot+"\\dd_curpg.log",l_curpg.ToString()+Environment.NewLine);
                }
                
            }
            curpg = l_curpg;
            PreGame_Menu.PreLobby_FE.ddlastpg = curpg;
        } 
        public void Draw(RenderTarget target, RenderStates states)
        {
            DescLabel.Draw(target,states);
            selItemLabel.Draw(target,states);
            Console.Write(isvisible.ToString());
            if(isvisible == true){
                Console.Write(Support.b.plDDSilClicked[id][0].ToString()+" "+Support.b.plForDDin[id][0].ToString()+Environment.NewLine);
               switch(Support.b.plDDSilClicked[id][0] && Support.b.plForDDin[id][0]&&Support.b.plForDDin[id][1]){
                case true:{
                    ddbacking.Draw(target,states);
                
                    if(PreGame_Menu.PreLobby_FE.ddlastpg>=0){
                        for(int b=(PreGame_Menu.PreLobby_FE.ddlastpg*perpg);b<((PreGame_Menu.PreLobby_FE.ddlastpg+1)*perpg);b++){
                            if(PreGame_Menu.PreLobby_FE.lastddin==id)
                            Support.b.plForDDin[id][2] =true;
                            
                            
                            if(Support.b.plForDDin[id][2] && b<ddItems.Length)
                            ddItems[b].Draw(target,states);
                            else if(b<ddItems.Length)
                            ddItems[b].Draw(target,states);
                        }
                    }
                
                    break;
                }


               }


            }
        }
    }
}