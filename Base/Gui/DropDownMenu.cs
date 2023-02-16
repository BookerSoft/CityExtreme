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
        public bool ddvisible=false;
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
            id = ddid;
            ddItems = new Text[displayed.Length];
            for(int a=0;a<displayed.Length;a++){
                ddItems[a]=new Text(displayed[a],Support.b.defFont,35); 
            }
            ddbacking = new RectangleShape();
            ddbacking.Position = new Vector2f(selItemLabel.Position.X, selItemLabel.Position.Y+selItemLabel.GetGlobalBounds().Height);
            pgcnt = pages;
            perpg = ddItems.Length/pages;
            ddbacking.Size = new Vector2f(ddItems[0].GetGlobalBounds().Width+10,400);
            ddbacking.FillColor=Color.White;
            for(int a=0;a<ddItems.Length;a++){
                if(a==0||a==7){
                    ddItems[a].Position = new Vector2f(ddbacking.GetGlobalBounds().Left+1,ddbacking.GetGlobalBounds().Top+1);
                }else{
                    ddItems[a].Position = new Vector2f(ddItems[a-1].Position.X,ddItems[a-1].Position.Y+ddItems[a-1].GetGlobalBounds().Height);
                }
            }
            _self = this;


        }
        public static void MouseClick(object? sender,MouseButtonEventArgs e){
            switch(e.Button){
                case Mouse.Button.Left:{
                if(_self.selItemLabel !=null && _self.selItemLabel.GetGlobalBounds().Contains(e.X,e.Y)){
                    if(PreGame_Menu.PreLobby_FE.menuDDVisible[_self.id] == false)
                    {
                        PreGame_Menu.PreLobby_FE.menuDDVisible[_self.id] = true;
                        Console.Write(PreGame_Menu.PreLobby_FE.menuDDVisible[_self.id]);
                    }
                    else
                    PreGame_Menu.PreLobby_FE.menuDDVisible[_self.id] = false;
                }
                break;
            }
            }
        }
        public static void wheelMoved(object? sender, MouseWheelScrollEventArgs e){
            if(e.Wheel == Mouse.Wheel.VerticalWheel){
                if(e.Delta < 0 && _self.curpg>0 && _self.curpg<=_self.pgcnt-1){
                    _self.curpg--;
                }else if(e.Delta >0 && _self.curpg>=0 && _self.curpg<=_self.pgcnt-1){
                    _self.curpg++;
                }
                
            }
        } 
        public void Draw(RenderTarget target, RenderStates states)
        {
            DescLabel.Draw(target,states);
            selItemLabel.Draw(target,states);
            if(PreGame_Menu.PreLobby_FE.menuDDVisible[0] == true||PreGame_Menu.PreLobby_FE.menuDDVisible[1] == true){
                ddbacking.Draw(target,states);
                for(int a=0;a<pgcnt;a++){
                    if(curpg>=0){
                        for(int b=(a*perpg);b<(a+1)*perpg;b++){
                            ddItems[b].Draw(target,states);
                        }
                    }
                }


            }
        }
    }
}