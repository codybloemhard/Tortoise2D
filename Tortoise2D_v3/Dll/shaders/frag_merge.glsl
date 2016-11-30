#version 330

in vec4 color;
in vec2 texcoord;
in vec2 vp;

out vec4 fragColor;

uniform sampler2D tex;

void main()
{
	vec2 newtexcoord = texcoord;
	newtexcoord.y *= -1;
    fragColor = texture(tex, newtexcoord);
}