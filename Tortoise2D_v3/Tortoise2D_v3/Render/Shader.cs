using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;
using Tortoise2D_v3.Platform;

namespace Tortoise2D_v3.Render
{
    public class Shader : IDisposable
    {
        public enum TYPE
        {
            VERTEX = 0x1,
            FRAGMENT = 0x2
        }

        private int Program = 0;
        private Dictionary<string, int> Variables = new Dictionary<string, int>();

        public Shader() { }

        public Shader(string source, TYPE type)
        {
            if (!GetSupported())
            {
                Debug.PrintEngine("Failed to create Shader." +
                    Environment.NewLine + "Your system doesn't support Shader.");
                return;
            }

            if (type == TYPE.VERTEX)
                Compile(source, "");
            else
                Compile("", source);
        }
        public Shader(string vsource, string fsource)
        {
            if (!GetSupported())
            {
                Debug.PrintEngine("Failed to create Shader." +
                    Environment.NewLine + "Your system doesn't support the Shader.");
                return;
            }

            Compile(vsource, fsource);
        }

        private bool Compile(string vertexSource = "", string fragmentSource = "")
        {
            int status_code = -1;
            string info = "";

            if (vertexSource == "" && fragmentSource == "")
            {
                Debug.PrintEngine("Failed to compile Shader." +
                    Environment.NewLine + "Nothing to Compile.");
                return false;
            }

            if (Program > 0)
                GL.DeleteProgram(Program);

            Variables.Clear();

            Program = GL.CreateProgram();

            if (vertexSource != "")
            {
                int vertexShader = GL.CreateShader(ShaderType.VertexShader);
                GL.ShaderSource(vertexShader, vertexSource);
                GL.CompileShader(vertexShader);
                GL.GetShaderInfoLog(vertexShader, out info);
                GL.GetShader(vertexShader, ShaderParameter.CompileStatus, out status_code);

                if (status_code != 1)
                {
                    Debug.PrintEngine("Failed to Compile Vertex Shader Source." +
                        Environment.NewLine + info + Environment.NewLine + "Status Code: " + status_code.ToString());

                    GL.DeleteShader(vertexShader);
                    GL.DeleteProgram(Program);
                    Program = 0;

                    return false;
                }

                GL.AttachShader(Program, vertexShader);
                GL.DeleteShader(vertexShader);
            }

            if (fragmentSource != "")
            {
                int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
                GL.ShaderSource(fragmentShader, fragmentSource);
                GL.CompileShader(fragmentShader);
                GL.GetShaderInfoLog(fragmentShader, out info);
                GL.GetShader(fragmentShader, ShaderParameter.CompileStatus, out status_code);

                if (status_code != 1)
                {
                    Debug.PrintEngine("Failed to Compile Fragment Shader Source." +
                        Environment.NewLine + info + Environment.NewLine + "Status Code: " + status_code.ToString());

                    GL.DeleteShader(fragmentShader);
                    GL.DeleteProgram(Program);
                    Program = 0;

                    return false;
                }

                GL.AttachShader(Program, fragmentShader);
                GL.DeleteShader(fragmentShader);
            }

            GL.LinkProgram(Program);
            GL.GetProgramInfoLog(Program, out info);
            GL.GetProgram(Program, GetProgramParameterName.LinkStatus, out status_code);

            if (status_code != 1)
            {
                Debug.PrintEngine("Failed to Link Shader Program." +
                    Environment.NewLine + info + Environment.NewLine + "Status Code: " + status_code.ToString());

                GL.DeleteProgram(Program);
                Program = 0;

                return false;
            }

            return true;
        }
        public static void Bind(Shader shader)
        {
            if (shader != null && shader.Program > 0)
            {
                GL.UseProgram(shader.Program);
            }
            else
            {
                GL.UseProgram(0);
            }
        }
        public static void Bind(int id)
        {
            GL.UseProgram(id);
        }
        public static string RShaderFF(string file)
        {
            return System.IO.File.ReadAllText(file);
        }
        //
        public void SetVariable(string name, float x, float y, float z, float w)
        {
            if (Program > 0)
            {
                GL.UseProgram(Program);

                int location = GetVariableLocation(name);
                if (location != -1)
                    GL.Uniform4(location, x, y, z, w);

                GL.UseProgram(0);
            }
        }
        public void SetVariable(string name, Matrix4 matrix)
        {
            if (Program > 0)
            {
                GL.UseProgram(Program);

                int location = GetVariableLocation(name);
                if (location != -1)
                {
                    GL.UniformMatrix4(location, false, ref matrix);
                }

                GL.UseProgram(0);
            }
        }
        public void SetVariable(string name, Vector2 vector)
        {
            if (Program > 0)
            {
                GL.UseProgram(Program);

                int location = GetVariableLocation(name);
                if (location != -1)
                    GL.Uniform2(location, vector.X, vector.Y);

                GL.UseProgram(0);
            }
        }
        public void SetVariable(string name, float x, float y)
        {
            if (Program > 0)
            {
                GL.UseProgram(Program);

                int location = GetVariableLocation(name);
                if (location != -1)
                    GL.Uniform2(location, x, y);

                GL.UseProgram(0);
            }
        }
        public void SetVariable(string name, Vector3 vector)
        {
            if (Program > 0)
            {
                GL.UseProgram(Program);

                int location = GetVariableLocation(name);
                if (location != -1)
                    GL.Uniform3(location, vector.X, vector.Y, vector.Z);

                GL.UseProgram(0);
            }
        }
        public void SetVariable(string name, Color color)
        {
            SetVariable(name, color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);
        }

        public void SetVariable(string name, float n)
        {
            if (Program > 0)
            {
                GL.UseProgram(Program);

                int location = GetVariableLocation(name);
                if (location != -1)
                {
                    GL.Uniform1(location, n);
                }

                GL.UseProgram(0);
            }
        }
        public void SetInt(string name, int n)
        {
            if (Program > 0)
            {
                GL.UseProgram(Program);

                int location = GetVariableLocation(name);
                if (location != -1)
                {
                    GL.Uniform1(location, (int)n);
                }

                GL.UseProgram(0);
            }
        }
        //
        public static bool GetSupported()
        {
            return (new Version(GL.GetString(StringName.Version).Substring(0, 3)) >= new Version(2, 0) ? true : false);
        }
        public int GetHandle()
        {
            return Program;
        }

        private int GetVariableLocation(string name)
        {
            if (Variables.ContainsKey(name))
                return Variables[name];

            int location = GL.GetUniformLocation(Program, name);

            if (location != -1)
                Variables.Add(name, location);
            else
                Debug.PrintEngine("Failed to retrieve Variable Location." +
                    Environment.NewLine + "Variable Name not found.");

            return location;
        }

        public void Dispose()
        {
            if (Program != 0) GL.DeleteProgram(Program);
        }
    }
}
