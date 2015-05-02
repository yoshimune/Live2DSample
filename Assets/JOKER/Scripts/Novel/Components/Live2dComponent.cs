﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Novel
{

    /*			
--------------

[doc]
tag=live2d_new
group=Live2D関連
title=Live2Dモデル定義

[desc]
Live2Dモデルを新しく定義します。

[sample]

;Live2Dモデルの定義
[live2d_new name="モデルID" storage="Hal_prefab" x=1 y=2 scale=6]

[param]

name=識別するための名前を指定します
storage=表示させるモデルのprefabを指定します
tag=タグ名を指定できます
layer=表示させるレイヤを指定します。画面の背面から順に、background,Default,character,message,front が指定できます。デフォルトはDefaultが指定されます
sort=同一レイヤ内の表示順を整数で指定してください
x=中心からのx位置を指定します
y=中心からのy位置を指定します
z=中心からのz位置を指定します
scale=Live2Dモデルの表示サイズを指定できます。つまり2と指定すると大きさが２倍になります


[_doc]
      --------------------
      */

    public class Live2d_newComponent:AbstractComponent
	{
		//protected string imagePath = "";

		public Live2d_newComponent ()
		{


			//必須項目
			this.arrayVitalParam = new List<string> {
				"name",
				"storage" 
			};

			this.originalParam = new Dictionary<string,string> () {

				{ "name","" },
				{ "storage","" },
				{ "tag","" },
				{ "layer","Default" },
				{ "sort","0" },
				{ "x","0" },
				{ "y","0" },
				{ "z","-3.2" },
				{ "scale","3" },
				{ "rot_x","0" },
				{ "rot_y","0" },
				{ "rot_z","0" },


			};

		}

		public override void start ()
		{

			//			string name = this.param ["name"];
			//			string tag = this.param ["tag"];

			this.param ["className"] = "Live2d";

			this.param ["scale_x"] = this.param ["scale"];
			this.param ["scale_y"] = this.param ["scale"];
			this.param ["scale_z"] = this.param ["scale"];

			Image image = new Image (this.param);
			this.gameManager.imageManager.addImage (image);

			this.gameManager.nextOrder ();

			//this.gameManager.scene.MessageSpeed = 0.02f;
			//this.gameManager.scene.coroutineShowMessage (message);

		}
	}

    /*			
--------------

[doc]
tag=live2d_pos
group=Live2D関連
title=Live2Dモデルの表示位置設定

[desc]
live2d_newで定義したLive2Dモデルの表示位置を指定することができます。

[sample]
[live2d_pos name="hal" x=0 y=0.5 ]

[param]
name=識別するための名前を指定します
x=中心からのx位置を指定します
y=中心からのy位置を指定します

[_doc]
--------------------
 */

    //キャラのポジションを変更する
	public class Live2d_posComponent:Image_posComponent
	{
		public Live2d_posComponent () : base ()
		{


		}

		public override void start ()
		{
			base.start ();
		}
	}

    /*			
--------------

[doc]
tag=live2d_show
group=Live2D関連
title=Live2Dモデルを表示します。

[desc]
live2d_newで定義したLive2Dモデルを表示します

[sample]

;ロゴを表示
[live2d_show name=logo ]

;tagを指定して複数画像を一斉に表示することも可能
[live2d_show name="モデルID"]

[param]
name=識別するための名前を指定します
tag=識別するためのタグを指定します
x=中心からのx位置を指定します
y=中心からのy位置を指定します
z=中心からのz位置を指定します

[_doc]

--------------------
 */


    public class Live2d_showComponent:Image_showComponent
	{
		public Live2d_showComponent () : base ()
		{

		}

		public override void start ()
		{
			base.start ();
			this.gameManager.nextOrder ();

		}
	}

    /*			
--------------

[doc]
tag=live2d_hide
group=Live2D関連
title=Live2Dモデルを非表示にします

[desc]
live2d_newで定義したLive2Dモデルを非表示にします。

[sample]
[live2d_remove name="モデルID"]

[param]
name=識別するための名前を指定します
tag=識別するためのタグを指定します

[_doc]
--------------------
 */

    public class Live2d_hideComponent:Image_hideComponent
	{
		public Live2d_hideComponent () : base ()
		{

		}

		public override void start ()
		{

			base.start ();
			this.gameManager.nextOrder ();

		}
	}


    

    /*				
--------------

[doc]
tag=live2d_remove
group=Live2D関連
title=Live2Dモデルの削除

[desc]
live2d_newで定義したLive2Dモデルを削除します。

[sample]
[live2d_remove name="hal"]

[param]
name=削除するテキストオブジェクト名 all と入力することですべてのキャラクターを削除することができます。



[_doc]
--------------------
 */
    //IComponentTextはテキストを流すための機能を保持するためのインターフェース
	public class Live2d_removeComponent:Image_removeComponent
	{
		public Live2d_removeComponent ()
		{

			//必須項目
			this.arrayVitalParam = new List<string> {
				"name"
			};

			this.originalParam = new Dictionary<string,string> () {
				{ "name","" },
			};

		}

		public override void start ()
		{

			string name = this.param ["name"];

			this.gameManager.imageManager.removeImage (name);

			this.gameManager.nextOrder ();


		}
	}

    /*				
--------------

[doc]
tag=live2d_motion
group=Live2D関連
title=Live2Dモデルのモーション再生

[desc]
Live2Dモデルのモーションを再生します。

[sample]
[live2d_motion name="モデルID" storage="haru_m_02.mtn"]

[param]
name=モーションを適用したいオブジェクト名を指定します。all と入力することですべてのキャラクターをモーションすることができます。
storage=モーションファイル名を指定してください 


[_doc]
--------------------
 */
    //IComponentTextはテキストを流すための機能を保持するためのインターフェース
    public class Live2d_motionComponent:AbstractComponent 
    {
        public Live2d_motionComponent()
        {

            //必須項目
            this.arrayVitalParam = new List<string> {
				"name",
				"storage"
			};

            this.originalParam = new Dictionary<string, string>() {
                { "name","" },
                { "tag",""},
                { "storage",""},
				{ "idel", ""}
			};

        }

        public override void start()
        {

            string name = this.param["name"];
            string tag = this.param["tag"];
			string storage = this.param["storage"];
			string idle = this.param["idel"];
            List<string> images = new List<string>();
            if (tag != "")
            {
                images = this.gameManager.imageManager.getImageNameByTag(tag);
            }
            else
            {
                images.Add(name);
            }

            foreach (string image_name in images)
            {
                Image image = this.gameManager.imageManager.getImage(image_name);
				image.getObject().setMotion(storage, idle);
            }
            this.gameManager.nextOrder();
        }
    }
}

