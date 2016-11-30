#version 330

in vec4 color;
in vec2 texcoord;
in vec2 vp;

out vec4 fragColor;

uniform sampler2D tex;

void main()
{
    fragColor = texture(tex, texcoord) * color;
}