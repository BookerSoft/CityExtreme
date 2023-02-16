using System;
using SFML.Graphics;
using SFML.Window;
namespace CityExtreme.Base.PreGame_Menu{
    public class Main_FE : Drawable
    {
        public Text Title, Single,Multi,Options,Player,Exit;
        static Main_FE _self;
        public Main_FE(ContextSettings? cs){
            Title = new Text("City Extreme",Support.b.defFont,50);
            Title.FillColor = Color.White;
            Player = new Text("Select Player",Support.b.defFont,30);
            Player.FillColor = Color.White;
            Single = new Text("Skirmish",Support.b.defFont,30);
            Single.FillColor = Color.White;
            Multi = new Text("Network  Game", Support.b.defFont,30);
            Multi.FillColor = Color.White;
            Options = new Text("Game Options",Support.b.defFont,30);
            Options.FillColor = Color.White;
            Exit = new Text("Exit Game",Support.b.defFont,30);
            Exit.FillColor = Color.White;



            if(Support.b.w != null){
                Title.Position = new SFML.System.Vector2f((Support.b.w.Size.X/3),0);
                Player.Position = new SFML.System.Vector2f(Title.Position.X +30,Title.Position.Y+Title.GetGlobalBounds().Height+175);
                Single.Position = new SFML.System.Vector2f(Title.Position.X+30, Title.Position.Y+Title.GetGlobalBounds().Height+225);
                Multi.Position = new SFML.System.Vector2f(Single.Position.X-30,Single.Position.Y+Single.GetGlobalBounds().Height+100);
                Options.Position = new SFML.System.Vector2f(Multi.Position.X,Multi.Position.Y+Multi.GetGlobalBounds().Height+25);
                Exit.Position = new SFML.System.Vector2f(Options.Position.X,Options.Position.Y+Options.GetGlobalBounds().Height+10);
            }
            _self = this;
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            Title.Draw(target,states);
            Player.Draw(target,states);
            Single.Draw(target,states);
            Multi.Draw(target,states);
            Options.Draw(target,states);
            Exit.Draw(target,states);

        }
        public static void MouseClick(object? sender,MouseButtonEventArgs e){
            switch(e.Button){
                case Mouse.Button.Left:{
                    if(_self.Exit.GetGlobalBounds().Contains(e.X,e.Y)){
                        Base.running = false;
                    }else if(_self.Single.GetGlobalBounds().Contains(e.X,e.Y)){
                        Support.b.menu =1;
                        Support.b.menupg = 0;
                    }



                    break;
                }
                case Mouse.Button.Right:{
                    break;
                }
            }
        }
    }
}