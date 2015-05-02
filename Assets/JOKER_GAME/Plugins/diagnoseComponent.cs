using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Novel{
    public class DiagnoseComponent : AbstractComponent {

        private Dictionary<string, int> nameMap;
        public DiagnoseComponent ()
        {
            //必須項目
            this.arrayVitalParam = new List<string> {
                "var","ans1","ans2","ans3","ans4","ans5"
            };
            
            this.originalParam = new Dictionary<string,string> () {
                {"var",""},
                {"ans1",""},
                {"ans2",""},
                {"ans3",""},
                {"ans4",""},
                {"ans5",""},
            };
            
            this.nameMap = new Dictionary<string, int> () {
                {"nozomi",1},
                {"rin",2},
                {"urara",3},
                {"komachi",4},
                {"karen",5},
            };
        }
        
        
        public override void start ()
        {
            string var_name = this.param ["var"];
            
            List<int> answers = new List<int> () {
                Int32.Parse(this.param ["ans1"]),
                Int32.Parse(this.param ["ans2"]),
                Int32.Parse(this.param ["ans3"]),
                Int32.Parse(this.param ["ans4"]),
                Int32.Parse(this.param ["ans5"]),
            };
            
            Dictionary<int,int> ansValue = new Dictionary<int, int> (){
                {1, answers.FindAll(a => a == 1).Count},
                {2, answers.FindAll(a => a == 2).Count},
                {3, answers.FindAll(a => a == 3).Count},
            };
            
            //変数に結果を格納
            StatusManager.variable.set (var_name, diagnose(ansValue));
            
            //次のシナリオに進む処理
            this.gameManager.nextOrder ();
        }

        private string diagnose(Dictionary<int,int> ansValue) {
            if (ansValue [1] >= 3) return "nozomi";
            else if (ansValue [1] >= 2 && ansValue [2] >= 2) return "urara";
            else if (ansValue [2] >= 2 && ansValue [3] >= 2) return "komachi";
            else if (ansValue [3] >= 3) return "karen";
            else return "rin";
        }
    }
}
