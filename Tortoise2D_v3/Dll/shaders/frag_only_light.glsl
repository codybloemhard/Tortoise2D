#version 330
#define MAXL 1000

in vec4 color;
in vec2 texcoord;
in vec2 vp;

out vec4 fragColor;

struct ldata{
	vec4 lpowercolor;
	vec4 lposrangemax;
};

uniform light{
	ldata l[MAXL];
}lights;

uniform float Nl;
uniform sampler2D tex;
uniform vec4 ambient;

void main()
{
	vec4 finalLcolor, lc;
	float dis, att;
	
	finalLcolor += ambient;
	for(int i = 0; i < Nl; i++){
		dis = length(vp - lights.l[i].lposrangemax.xy);
		att = 1/(1+(1/lights.l[i].lposrangemax.z)*dis*dis); 
		
		lc = vec4(color.x * (att * lights.l[i].lpowercolor.x * lights.l[i].lpowercolor.y),
				  color.y * (att * lights.l[i].lpowercolor.x * lights.l[i].lpowercolor.z),
				  color.z * (att * lights.l[i].lpowercolor.x * lights.l[i].lpowercolor.w),
				  1f);
		finalLcolor += lc;
	}
    fragColor = texture(tex, texcoord) + finalLcolor;
}