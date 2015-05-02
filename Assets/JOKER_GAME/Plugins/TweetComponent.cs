using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Novel {
    public class TweetComponent : AbstractComponent {

    	public TweetComponent()
        {
            //必須項目
            this.arrayVitalParam = new List<string> {
                "message"
            };
            
            this.originalParam = new Dictionary<string,string> () {
                {"message",""},
            };
        }

        public override void start()
        {
            string message = this.param["message"];
            UnityRoomTweet.Tweet (message);
        }
    }
}
