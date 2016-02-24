Shader "World Political Map/Unlit Country Frontiers Order 3" {
 
Properties {
    _Color ("Color", Color) = (0,1,0,1)
    _OuterColor("Outer Color", Color) = (0,0.8,0,0.8)
}
 
SubShader {
	LOD 300
    Tags {
        "Queue"="Geometry+300"
        "RenderType"="Opaque"
    	}
    Pass {
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _Color;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.001;
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _Color;					
		}
		ENDCG
		
    }
}

SubShader {
	LOD 200
    Tags {
        "Queue"="Geometry+300"
        "RenderType"="Opaque"
    	}
    Blend SrcAlpha OneMinusSrcAlpha
    Pass {
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _Color;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.002;
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _Color;					
		}
		ENDCG
		
    }    
    
    Pass { // (+1,0)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _OuterColor, _Color;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[1][1];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumHeight = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumHeight/_ScreenParams.y;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.x += metersPerPixel;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.001;		}
		
		fixed4 frag(AppData i) : COLOR {
			return _Color * 0.5 + _OuterColor * 0.5;					
		}
		ENDCG
		
    }
   Pass { // (-1,0)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _OuterColor, _Color;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[1][1];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumHeight = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumHeight/_ScreenParams.y;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.x -= metersPerPixel;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.001;		
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _Color * 0.5 + _OuterColor * 0.5;					
		}
		ENDCG
		
    }    
  Pass { // (0,-1)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _OuterColor, _Color;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[0][0];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumHeight = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumHeight/_ScreenParams.y;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.y -= metersPerPixel;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.001;		
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _Color * 0.5 + _OuterColor * 0.5;					
		}
		ENDCG
    } 
           
    Pass { // (0, +1)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _OuterColor, _Color;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[0][0];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumWidth = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumWidth/_ScreenParams.x;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.y += metersPerPixel * 2;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.001;		
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _Color * 0.5 + _OuterColor * 0.5;					
		}
		ENDCG
		
    }    
}

SubShader {
	LOD 100
    Tags {
        "Queue"="Geometry+300"
        "RenderType"="Opaque"
    	}
    Blend SrcAlpha OneMinusSrcAlpha
    Pass {
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _Color;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.002;
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _Color;					
		}
		ENDCG
		
    }    
    
    Pass { // (+1,0)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _Color;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[1][1];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumHeight = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumHeight/_ScreenParams.y;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.x += metersPerPixel;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.002;		}
		
		fixed4 frag(AppData i) : COLOR {
			return _Color;					
		}
		ENDCG
		
    }
    
        
    Pass { // (+2,0)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _OuterColor;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[1][1];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumHeight = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumHeight/_ScreenParams.y;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.x += metersPerPixel * 2;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.001;		}
		
		fixed4 frag(AppData i) : COLOR {
			return _OuterColor;					
		}
		ENDCG
		
    }
    
    
   Pass { // (-1,0)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _Color;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[1][1];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumHeight = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumHeight/_ScreenParams.y;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.x -= metersPerPixel;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.002;		
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _Color;					
		}
		ENDCG
		
    }   
    
   Pass { // (-2,0)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _OuterColor;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[1][1];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumHeight = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumHeight/_ScreenParams.y;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.x -= metersPerPixel * 2;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.001;		
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _OuterColor;					
		}
		ENDCG
		
    }         
       
  Pass { // (0,-1)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _Color;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[0][0];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumHeight = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumHeight/_ScreenParams.y;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.y -= metersPerPixel;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.002;		
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _Color;					
		}
		ENDCG
    } 
    
  Pass { // (0,-2)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _OuterColor;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[0][0];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumHeight = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumHeight/_ScreenParams.y;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.y -= metersPerPixel * 2;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.001;		
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _OuterColor;					
		}
		ENDCG
    }            
                  
                                
     Pass { // (0,+1)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _Color;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[0][0];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumWidth = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumWidth/_ScreenParams.x;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.y += metersPerPixel * 2;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.002;		
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _Color;					
		}
		ENDCG
    }    
    
    Pass { // (0,+2)
	   	CGPROGRAM
		#pragma vertex vert	
		#pragma fragment frag				

		fixed4 _OuterColor;

		struct AppData {
			float4 vertex : POSITION;
		};
		
		void vert(inout AppData v) {
			float4x4 projectionMatrix = UNITY_MATRIX_P;
			float d = projectionMatrix[0][0];
 			float distanceFromCameraToVertex = mul( UNITY_MATRIX_MV, v.vertex ).z;
 			//The check here is for wether the camera is orthographic or perspective
 			float frustumWidth = projectionMatrix[3][3] == 1 ? 2/d : 2.0*-distanceFromCameraToVertex*(1/d);
 			float metersPerPixel = frustumWidth/_ScreenParams.x;
 			metersPerPixel /= _Object2World[0][0];
 			
 			v.vertex.y += metersPerPixel * 4;
			v.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			v.vertex.z-=0.001;		
		}
		
		fixed4 frag(AppData i) : COLOR {
			return _OuterColor;					
		}
		ENDCG
		
    }  
}
 
}
