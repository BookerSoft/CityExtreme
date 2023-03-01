using System;
namespace CityExtreme.Base{
    public class Player{
        public string Name,Type;
        public double Cash,Profit,AvgProfit,CumProfit,EmpireValue;

        public int id,Rosettes;


        public Player(string type,string name,double scash,int plid){
            Name = name;
            Type = type;
            Cash = scash;
            id = plid;
            
        }
        public Player(string type,string name,int plid){
            Name = name;
            id=plid;
            Cash = 0.00;
            Type = type;

        }

    }
}