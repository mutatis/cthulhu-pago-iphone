#pragma strict
#pragma downcast
class AnyResSetup extends EditorWindow {
	var androidRes : String[] = ["480x320", "800x480", "854x480","1024x600","1280x720","iPhone3GS","iPhone4","iPhone5","iPad","iPad3+","iPad Mini","Custom..."];
    var index : int = 0;
    var canAdd : boolean;
    var canAdd2 : boolean;
    var scale : int;
    var custom : Vector2;
    @MenuItem ("Window/AnyRes Setup")
    static function ShowWindow () {
        EditorWindow.GetWindow (AnyResSetup);
    }
    function OnInspectorUpdate() {
        Repaint();
    }
    function OnGUI () {
        index = EditorGUILayout.Popup("Your screen size:",index, androidRes);
        if(GUILayout.Button("Update resolution")){
        	var objects = GameObject.FindSceneObjectsOfType(GameObject);
        	for(var game : GameObject in objects){
        		if(!game.GetComponent(AnyResGUITexture)){}
        		else{
        			var gg = game.GetComponent(AnyResGUITexture);
	        		if(index == 0){ gg.res = Vector2(480,320);}
	        		if(index == 1){ gg.res = Vector2(800,480);}
	        		if(index == 2){ gg.res = Vector2(854,480);}
	        		if(index == 3){ gg.res = Vector2(1024,600);}
	        		if(index == 4){ gg.res = Vector2(1280,720);}
	        		if(index == 5){ gg.res = Vector2(480,320);}
	        		if(index == 6){ gg.res = Vector2(960,640);}
	        		if(index == 7){ gg.res = Vector2(1136,640);}
	        		if(index == 8){ gg.res = Vector2(1024,768);}
	        		if(index == 9){ gg.res = Vector2(2048,1536);}
	        		if(index == 10){ gg.res = Vector2(1024,768);}
	        		if(index == 11){ gg.res = custom;}
        		}
        		if(!game.GetComponent(AnyResGUIText)){}
        		else{
        			var gg2 = game.GetComponent(AnyResGUIText);
	        		if(index == 0){ gg2.res = Vector2(480,320);}
	        		if(index == 1){ gg2.res = Vector2(800,480);}
	        		if(index == 2){ gg2.res = Vector2(854,480);}
	        		if(index == 3){ gg2.res = Vector2(1024,600);}
	        		if(index == 4){ gg2.res = Vector2(1280,720);}
	        		if(index == 5){ gg2.res = Vector2(480,320);}
	        		if(index == 6){ gg2.res = Vector2(960,640);}
	        		if(index == 7){ gg2.res = Vector2(1136,640);}
	        		if(index == 8){ gg2.res = Vector2(1024,768);}
	        		if(index == 9){ gg2.res = Vector2(2048,1536);}
	        		if(index == 10){ gg2.res = Vector2(1024,768);}
	        		if(index == 11){ gg2.res = custom;}        			
        		}
        	}
        }
        if(index == 11){
        	custom = EditorGUILayout.Vector2Field("Width & Height",custom);
        }
        EditorGUILayout.HelpBox("Choose the resolution/iDevice that you will use inside Unity 3D",MessageType.Info);

		EditorGUI.BeginDisabledGroup(canAdd == false);
			if(GUILayout.Button("Add AnyResGUITexture")){
		       	if(!Selection.activeGameObject)
		       		return;
		       	for(var go : GameObject in Selection.gameObjects){
		       		if(!go.GetComponent(GUITexture)){
		       			Debug.LogWarning("Please select a GUITexture object");
		       			return;
		       		}
		       		var i : AnyResGUITexture = go.AddComponent(AnyResGUITexture);
		       		if(index == 0){ i.res = Vector2(480,320);}
		       		if(index == 1){ i.res = Vector2(800,480);}
		       		if(index == 2){ i.res = Vector2(854,480);}
		       		if(index == 3){ i.res = Vector2(1024,600);}
		       		if(index == 4){ i.res = Vector2(1280,720);}
		       		if(index == 5){ i.res = Vector2(480,320);}
		       		if(index == 6){ i.res = Vector2(960,640);}
		       		if(index == 7){ i.res = Vector2(1136,640);}
		       		if(index == 8){ i.res = Vector2(1024,768);}
		       		if(index == 9){ i.res = Vector2(2048,1536);}
		       		if(index == 10){ i.res = Vector2(1024,768);}
		       		if(index == 11){ i.res = custom;}
		       	}
			}
		EditorGUI.EndDisabledGroup();
        	EditorGUI.BeginDisabledGroup(canAdd2 == false);
       		if(GUILayout.Button("Add AnyResGUIText")){
        		if(!Selection.activeGameObject)
		        		return;
		        	for(var go : GameObject in Selection.gameObjects){
		        		if(!go.GetComponent(GUIText)){
		        			Debug.LogWarning("Please select a GUIText object");
		        			return;
		        		}
		        		var i2 : AnyResGUIText = go.AddComponent(AnyResGUIText);
		        		if(index == 0){ i2.res = Vector2(480,320);}
		        		if(index == 1){ i2.res = Vector2(800,480);}
		        		if(index == 2){ i2.res = Vector2(854,480);}
		        		if(index == 3){ i2.res = Vector2(1024,600);}
		        		if(index == 4){ i2.res = Vector2(1280,720);}
		        		if(index == 5){ i2.res = Vector2(480,320);}
		        		if(index == 6){ i2.res = Vector2(960,640);}
		        		if(index == 7){ i2.res = Vector2(1136,640);}
		        		if(index == 8){ i2.res = Vector2(1024,768);}
		        		if(index == 9){ i2.res = Vector2(2048,1536);}
		        		if(index == 10){ i2.res = Vector2(1024,768);}
		        		if(index == 11){ i2.res = custom;}
		        	}	
       		}
       	EditorGUI.EndDisabledGroup();

		for(var g : GameObject in Selection.gameObjects){	
			GUILayout.Label(g.name);
			if(g.GetComponent(GUITexture)){
				canAdd=true; canAdd2 = false;
			}
			else if(g.GetComponent(GUIText)){
				canAdd2 = true; canAdd = false;
			}
			if(g.GetComponent(AnyResGUITexture)){ 
				g.guiTexture.pixelInset.x = EditorGUILayout.IntField("X",g.guiTexture.pixelInset.x);
				g.guiTexture.pixelInset.y = EditorGUILayout.IntField("Y",g.guiTexture.pixelInset.y);
				scale = EditorGUILayout.IntField("Scale",g.guiTexture.pixelInset.width);
				g.guiTexture.pixelInset.width = scale;
				g.guiTexture.pixelInset.height = scale;
				canAdd = false;
			}
			else if(g.GetComponent(AnyResGUIText)){
				g.guiText.pixelOffset.x = EditorGUILayout.IntField("X",g.guiText.pixelOffset.x);
				g.guiText.pixelOffset.y = EditorGUILayout.IntField("Y",g.guiText.pixelOffset.y);
				g.guiText.fontSize = EditorGUILayout.IntField("Font Size",g.guiText.fontSize);	
				g.guiText.text = EditorGUILayout.TextField("Text",g.guiText.text);
				canAdd2 = false;			
			}
		}			

        
    }
}