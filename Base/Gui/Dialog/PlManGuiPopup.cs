using SFML.System;
using SFML.Graphics;
using SFML.Window;
using System;
using System.IO;
namespace CityExtreme.Base.Gui.Dialog{
    public class PlayerManagerPopupDlg : Drawable
    {
        FloatRect bounds;
        Text? Title,Add,Remove,Close,Apply;
        Text[] Names = new Text[100];
        int namepgs=5,curnamepg=0;

        RectangleShape bg;
        bool visible = false;
        public bool Visible{
            get{
                return visible;

            }
            set{
                visible = value;
            }
        }
        public Vector2f Position{
            get{
                return new Vector2f(bounds.Left,bounds.Top);

            }
        }
        bool inMe = false;
        public FloatRect GlobalBounds{
            get{
                return bounds;
            }
        }
        public PlayerManagerPopupDlg(ContextSettings cs){
            bounds = new FloatRect();
            if(Support.b.w != null){
                bounds.Left = Support.b.w.Size.X*.35f;
                bounds.Top = Support.b.w.Size.Y*.25f;
                bounds.Width = Support.b.w.Size.X*.25f;
                bounds.Height = Support.b.w.Size.Y*.45f;
                bg = new RectangleShape();
                bg.Position = new Vector2f(bounds.Left,bounds.Top);
                bg.Size = new Vector2f(bounds.Width,bounds.Height);
                bg.FillColor = Color.White;
                if(Support.b.PlManType == "FullManager"){
                    Title = new Text("Manage Players",Support.b.defFont,45);
                    Title.Position= new Vector2f(bounds.Left+(bounds.Width*.25f),bounds.Top);
                    Title.FillColor = Color.Black;
                    Apply = new Text("Close", Support.b.defFont,25);
                    Apply.FillColor = Color.Black;
                    Apply.Position = new Vector2f(bounds.Left+bounds.Width - (Apply.GetGlobalBounds().Width*2),bounds.Top+bounds.Height- (Apply.GetGlobalBounds().Height*2));
                    for(int i =0;i<Names.Length;i++){
                        if(i==0 || i==20||i==40||i==60||i==80){
                            Names[i]= new Text("No Name",Support.b.defFont,19);
                            Names[i].Position = new Vector2f(bounds.Left+(bounds.Width*.15f),bounds.Top+Title.GetGlobalBounds().Height+(bounds.Height*.05f));
                            Names[i].FillColor = Color.Black;


                        }else{
                            Names[i]= new Text("No Name",Support.b.defFont,19);
                            Names[i].Position = new Vector2f(Names[i-1].Position.X,Names[i-1].Position.Y+Names[i-1].GetGlobalBounds().Height +(bounds.Height*.025f));
                            Names[i].FillColor = Color.Black;
                        }
                    }

                }

            }
        }
        public void MouseMove(object? sender, MouseMoveEventArgs e){
            if(GlobalBounds.Contains((float)e.X,(float)e.Y)){
                inMe = true;
                
            }

        }
        public void MouseClicked(object? sender, MouseButtonEventArgs e){
            if(inMe &&e.Button== Mouse.Button.Left){
                if(Support.b.PlManType=="FullManager" && Apply.GetGlobalBounds().Contains((float)e.X,(float)e.Y)){
                    visible = false;
                }
            }

        }
        public void TextEvent(object? sender, TextEventArgs e){
            if(inMe){
                
            }
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(bg);
            target.Draw(Title);
            if(Support.b.PlManType=="FullManager"){
                target.Draw(Apply);



            }
            


            for(int i=0;i<Names.Length;i++){
                if(Names[i]!=null){
                    for(int j=0;j<namepgs;j++){
                        if(j==curnamepg && (i>=0&&i<20)){
                            target.Draw(Names[i]);

                        }
                    }
                }
            }
        }
    }
}