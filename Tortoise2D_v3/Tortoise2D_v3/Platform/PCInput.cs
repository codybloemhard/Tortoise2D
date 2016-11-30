using System;
using OpenTK.Input;

namespace Tortoise2D_v3.Platform
{
    public class PCInput
    {
        private MouseState now, prev;
        private float[] deltamouse;
        private Tortoise2d game;
        private bool[] keysDown;
        private bool[] keysPrev;
        private float[] deltaMouse;
        private double lockx, locky;
        
        public PCInput(Tortoise2d game)
        {
            now = new MouseState();
            prev = new MouseState();
            deltamouse = new float[3] { 0, 0, 0 };
            this.game = game;
            keysDown = new bool[71];
            keysPrev = new bool[71];
            deltaMouse = new float[3];
        }

        public void Update()
        {
            for(int i = 0; i < 71; i++)
            {
                keysPrev[i] = keysDown[i];
            }
            GetOpenTKKeys();
            deltaMouse = GetDeltaMouseThisFrame();
            if(lockx != -1 && locky != -1)
                OpenTK.Input.Mouse.SetPosition(lockx, locky);

        }

        public bool GetKeyPressed(string k)
        {
            return GetKeyDown(k) && !GetKeyDownPrev(k);
        }
        public bool GetKeyReleased(string k)
        {
            return !GetKeyDown(k) && GetKeyDownPrev(k);
        }

        private bool GetOpenTKKeys()
        {
            var state = OpenTK.Input.Keyboard.GetState();
            //////////////////////////////////////////////////
            if (state[Key.Up]) { keysDown[0] = true; } else keysDown[0] = false;
            if (state[Key.Down]) { keysDown[1] = true; } else keysDown[1] = false;
            if (state[Key.Left]) { keysDown[2] = true; } else keysDown[2] = false;
            if (state[Key.Right]) { keysDown[3] = true; } else keysDown[3] = false;
            if (state[Key.W]) { keysDown[4] = true; } else keysDown[4] = false;
            if (state[Key.S]) { keysDown[5] = true; } else keysDown[5] = false;
            if (state[Key.A]) { keysDown[6] = true; } else keysDown[6] = false;
            if (state[Key.D]) { keysDown[7] = true; } else keysDown[7] = false;
            ///////////////////////////////////////////////
            if (state[Key.Q]) { keysDown[8] = true; } else keysDown[8] = false;
            if (state[Key.E]) { keysDown[9] = true; } else keysDown[9] = false;
            if (state[Key.R]) { keysDown[10] = true; } else keysDown[10] = false;
            if (state[Key.T]) { keysDown[11] = true; } else keysDown[11] = false;
            if (state[Key.Y]) { keysDown[12] = true; } else keysDown[12] = false;
            if (state[Key.U]) { keysDown[13] = true; } else keysDown[13] = false;
            if (state[Key.I]) { keysDown[14] = true; } else keysDown[14] = false;
            if (state[Key.O]) { keysDown[15] = true; } else keysDown[15] = false;
            if (state[Key.P]) { keysDown[16] = true; } else keysDown[16] = false;
            if (state[Key.F]) { keysDown[17] = true; } else keysDown[17] = false;
            if (state[Key.G]) { keysDown[18] = true; } else keysDown[18] = false;
            if (state[Key.H]) { keysDown[19] = true; } else keysDown[19] = false;
            if (state[Key.J]) { keysDown[20] = true; } else keysDown[20] = false;
            if (state[Key.K]) { keysDown[21] = true; } else keysDown[21] = false;
            if (state[Key.L]) { keysDown[22] = true; } else keysDown[22] = false;
            if (state[Key.Z]) { keysDown[23] = true; } else keysDown[23] = false;
            if (state[Key.X]) { keysDown[24] = true; } else keysDown[24] = false;
            if (state[Key.C]) { keysDown[25] = true; } else keysDown[25] = false;
            if (state[Key.V]) { keysDown[26] = true; } else keysDown[26] = false;
            if (state[Key.B]) { keysDown[27] = true; } else keysDown[27] = false;
            if (state[Key.N]) { keysDown[28] = true; } else keysDown[28] = false;
            if (state[Key.M]) { keysDown[29] = true; } else keysDown[29] = false;
            ///////////////////////////////////////////////
            if (state[Key.ControlLeft]) { keysDown[30] = true; } else keysDown[30] = false;
            if (state[Key.ControlRight]) { keysDown[31] = true; } else keysDown[31] = false;
            if (state[Key.ShiftLeft]) { keysDown[32] = true; } else keysDown[32] = false;
            if (state[Key.ShiftRight]) { keysDown[33] = true; } else keysDown[33] = false;
            if (state[Key.AltLeft]) { keysDown[34] = true; } else keysDown[34] = false;
            if (state[Key.AltRight]) { keysDown[35] = true; } else keysDown[35] = false;
            if (state[Key.Tab]) { keysDown[36] = true; } else keysDown[36] = false;
            if (state[Key.Space]) { keysDown[37] = true; } else keysDown[37] = false;
            if (state[Key.BackSpace]) { keysDown[38] = true; } else keysDown[38] = false;
            if (state[Key.Enter]) { keysDown[39] = true; } else keysDown[39] = false;
            if (state[Key.WinLeft]) { keysDown[40] = true; } else keysDown[40] = false;
            if (state[Key.WinRight]) { keysDown[41] = true; } else keysDown[41] = false;
            ///////////////////////////////////////////////////////
            if (state[Key.Number0]) { keysDown[42] = true; } else keysDown[42] = false;
            if (state[Key.Number1]) { keysDown[43] = true; } else keysDown[43] = false;
            if (state[Key.Number2]) { keysDown[44] = true; } else keysDown[44] = false;
            if (state[Key.Number3]) { keysDown[45] = true; } else keysDown[45] = false;
            if (state[Key.Number4]) { keysDown[46] = true; } else keysDown[46] = false;
            if (state[Key.Number5]) { keysDown[47] = true; } else keysDown[47] = false;
            if (state[Key.Number6]) { keysDown[48] = true; } else keysDown[48] = false;
            if (state[Key.Number7]) { keysDown[49] = true; } else keysDown[49] = false;
            if (state[Key.Number8]) { keysDown[50] = true; } else keysDown[50] = false;
            if (state[Key.Number9]) { keysDown[51] = true; } else keysDown[51] = false;
            ///////////////////////////////////////////////////
            if (state[Key.Keypad0]) { keysDown[52] = true; } else keysDown[52] = false;
            if (state[Key.Keypad1]) { keysDown[53] = true; } else keysDown[53] = false;
            if (state[Key.Keypad2]) { keysDown[54] = true; } else keysDown[54] = false;
            if (state[Key.Keypad3]) { keysDown[55] = true; } else keysDown[55] = false;
            if (state[Key.Keypad4]) { keysDown[56] = true; } else keysDown[56] = false;
            if (state[Key.Keypad5]) { keysDown[57] = true; } else keysDown[57] = false;
            if (state[Key.Keypad6]) { keysDown[58] = true; } else keysDown[58] = false;
            if (state[Key.Keypad7]) { keysDown[59] = true; } else keysDown[59] = false;
            if (state[Key.Keypad8]) { keysDown[60] = true; } else keysDown[60] = false;
            if (state[Key.Keypad9]) { keysDown[61] = true; } else keysDown[61] = false;
            if (state[Key.KeypadAdd]) { keysDown[62] = true; } else keysDown[62] = false;
            if (state[Key.KeypadDecimal]) { keysDown[63] = true; } else keysDown[63] = false;
            if (state[Key.KeypadDivide]) { keysDown[64] = true; } else keysDown[64] = false;
            if (state[Key.KeypadEnter]) { keysDown[65] = true; } else keysDown[65] = false;
            if (state[Key.KeypadMinus]) { keysDown[66] = true; } else keysDown[66] = false;
            if (state[Key.KeypadMultiply]) { keysDown[67] = true; } else keysDown[67] = false;
            if (state[Key.KeypadPeriod]) { keysDown[68] = true; } else keysDown[68] = false;
            if (state[Key.KeypadPlus]) { keysDown[69] = true; } else keysDown[69] = false;
            if (state[Key.KeypadSubtract]) { keysDown[70] = true; } else keysDown[70] = false;
            //////////////////////////////////////////////////////////
            return false;
        }
        public bool GetKeyDown(string k)
        {
            //////////////////////////////////////////////////
            if (k == "up") { return keysDown[0]; }
            if (k == "down") { return keysDown[1]; }
            if (k == "left") { return keysDown[2]; }
            if (k == "right") { return keysDown[3]; }
            if (k == "w") { return keysDown[4]; }
            if (k == "s") { return keysDown[5]; }
            if (k == "a") { return keysDown[6]; }
            if (k == "d") { return keysDown[7]; }
            ///////////////////////////////////////////////
            if (k == "q") { return keysDown[8]; }
            if (k == "e") { return keysDown[9]; }
            if (k == "r") { return keysDown[10]; }
            if (k == "t") { return keysDown[11]; }
            if (k == "y") { return keysDown[12]; }
            if (k == "u") { return keysDown[13]; }
            if (k == "i") { return keysDown[14]; }
            if (k == "o") { return keysDown[15]; }
            if (k == "p") { return keysDown[16]; }
            if (k == "f") { return keysDown[17]; }
            if (k == "g") { return keysDown[18]; }
            if (k == "h") { return keysDown[19]; }
            if (k == "j") { return keysDown[20]; }
            if (k == "k") { return keysDown[21]; }
            if (k == "l") { return keysDown[22]; }
            if (k == "z") { return keysDown[23]; }
            if (k == "x") { return keysDown[24]; }
            if (k == "c") { return keysDown[25]; }
            if (k == "v") { return keysDown[26]; }
            if (k == "b") { return keysDown[27]; }
            if (k == "n") { return keysDown[28]; }
            if (k == "m") { return keysDown[29]; }
            ///////////////////////////////////////////////
            if (k == "controlLeft") { return keysDown[30]; }
            if (k == "controlRight") { return keysDown[31]; }
            if (k == "shiftLeft") { return keysDown[32]; }
            if (k == "shiftRight") { return keysDown[33]; }
            if (k == "altLeft") { return keysDown[34]; }
            if (k == "altRight") { return keysDown[35]; }
            if (k == "tab") { return keysDown[36]; }
            if (k == "space") { return keysDown[37]; }
            if (k == "backspace") { return keysDown[38]; }
            if (k == "enter") { return keysDown[39]; }
            if (k == "windowsLeft") { return keysDown[40]; }
            if (k == "windowsRight") { return keysDown[41]; }
            ///////////////////////////////////////////////////////
            if (k == "0") { return keysDown[42]; }
            if (k == "1") { return keysDown[43]; }
            if (k == "2") { return keysDown[44]; }
            if (k == "3") { return keysDown[45]; }
            if (k == "4") { return keysDown[46]; }
            if (k == "5") { return keysDown[47]; }
            if (k == "6") { return keysDown[48]; }
            if (k == "7") { return keysDown[49]; }
            if (k == "8") { return keysDown[50]; }
            if (k == "9") { return keysDown[51]; }
            ///////////////////////////////////////////////////
            if (k == "keypad0") { return keysDown[52]; }
            if (k == "keypad1") { return keysDown[53]; }
            if (k == "keypad2") { return keysDown[54]; }
            if (k == "keypad3") { return keysDown[55]; }
            if (k == "keypad4") { return keysDown[56]; }
            if (k == "keypad5") { return keysDown[57]; }
            if (k == "keypad6") { return keysDown[58]; }
            if (k == "keypad7") { return keysDown[59]; }
            if (k == "keypad8") { return keysDown[60]; }
            if (k == "keypad9") { return keysDown[61]; }
            if (k == "keypadAdd") { return keysDown[62]; }
            if (k == "keypadDecimal") { return keysDown[63]; }
            if (k == "keypadDivide") { return keysDown[64]; }
            if (k == "keypadEnter") { return keysDown[65]; }
            if (k == "keypadMinus") { return keysDown[66]; }
            if (k == "keypadMultiply") { return keysDown[67]; }
            if (k == "keypadPeriod") { return keysDown[68]; }
            if (k == "keypadPlus") { return keysDown[69]; }
            if (k == "keypadSubtract") { return keysDown[70]; }
            //////////////////////////////////////////////////////////
            else { return false; }
        }
        private bool GetKeyDownPrev(string k)
        {
            //////////////////////////////////////////////////
            if (k == "up") { return keysPrev[0]; }
            if (k == "down") { return keysPrev[1]; }
            if (k == "left") { return keysPrev[2]; }
            if (k == "right") { return keysPrev[3]; }
            if (k == "w") { return keysPrev[4]; }
            if (k == "s") { return keysPrev[5]; }
            if (k == "a") { return keysPrev[6]; }
            if (k == "d") { return keysPrev[7]; }
            ///////////////////////////////////////////////
            if (k == "q") { return keysPrev[8]; }
            if (k == "e") { return keysPrev[9]; }
            if (k == "r") { return keysPrev[10]; }
            if (k == "t") { return keysPrev[11]; }
            if (k == "y") { return keysPrev[12]; }
            if (k == "u") { return keysPrev[13]; }
            if (k == "i") { return keysPrev[14]; }
            if (k == "o") { return keysPrev[15]; }
            if (k == "p") { return keysPrev[16]; }
            if (k == "f") { return keysPrev[17]; }
            if (k == "g") { return keysPrev[18]; }
            if (k == "h") { return keysPrev[19]; }
            if (k == "j") { return keysPrev[20]; }
            if (k == "k") { return keysPrev[21]; }
            if (k == "l") { return keysPrev[22]; }
            if (k == "z") { return keysPrev[23]; }
            if (k == "x") { return keysPrev[24]; }
            if (k == "c") { return keysPrev[25]; }
            if (k == "v") { return keysPrev[26]; }
            if (k == "b") { return keysPrev[27]; }
            if (k == "n") { return keysPrev[28]; }
            if (k == "m") { return keysPrev[29]; }
            ///////////////////////////////////////////////
            if (k == "controlLeft") { return keysPrev[30]; }
            if (k == "controlRight") { return keysPrev[31]; }
            if (k == "shiftLeft") { return keysPrev[32]; }
            if (k == "shiftRight") { return keysPrev[33]; }
            if (k == "altLeft") { return keysPrev[34]; }
            if (k == "altRight") { return keysPrev[35]; }
            if (k == "tab") { return keysPrev[36]; }
            if (k == "space") { return keysPrev[37]; }
            if (k == "backspace") { return keysPrev[38]; }
            if (k == "enter") { return keysPrev[39]; }
            if (k == "windowsLeft") { return keysPrev[40]; }
            if (k == "windowsRight") { return keysPrev[41]; }
            ///////////////////////////////////////////////////////
            if (k == "0") { return keysPrev[42]; }
            if (k == "1") { return keysPrev[43]; }
            if (k == "2") { return keysPrev[44]; }
            if (k == "3") { return keysPrev[45]; }
            if (k == "4") { return keysPrev[46]; }
            if (k == "5") { return keysPrev[47]; }
            if (k == "6") { return keysPrev[48]; }
            if (k == "7") { return keysPrev[49]; }
            if (k == "8") { return keysPrev[50]; }
            if (k == "9") { return keysPrev[51]; }
            ///////////////////////////////////////////////////
            if (k == "keypad0") { return keysPrev[52]; }
            if (k == "keypad1") { return keysPrev[53]; }
            if (k == "keypad2") { return keysPrev[54]; }
            if (k == "keypad3") { return keysPrev[55]; }
            if (k == "keypad4") { return keysPrev[56]; }
            if (k == "keypad5") { return keysPrev[57]; }
            if (k == "keypad6") { return keysPrev[58]; }
            if (k == "keypad7") { return keysPrev[59]; }
            if (k == "keypad8") { return keysPrev[60]; }
            if (k == "keypad9") { return keysPrev[61]; }
            if (k == "keypadAdd") { return keysPrev[62]; }
            if (k == "keypadDecimal") { return keysPrev[63]; }
            if (k == "keypadDivide") { return keysPrev[64]; }
            if (k == "keypadEnter") { return keysPrev[65]; }
            if (k == "keypadMinus") { return keysPrev[66]; }
            if (k == "keypadMultiply") { return keysPrev[67]; }
            if (k == "keypadPeriod") { return keysPrev[68]; }
            if (k == "keypadPlus") { return keysPrev[69]; }
            if (k == "keypadSubtract") { return keysPrev[70]; }
            //////////////////////////////////////////////////////////
            else { return false; }
        }

        public bool GetMouseButtonDown(string button)
        {
            var mouse = Mouse.GetState();

            if (mouse[MouseButton.Left] && button == "left")
            {
                return true;
            }
            if (mouse[MouseButton.Right] && button == "right")
            {
                return true;
            }
            if (mouse[MouseButton.Middle] && button == "middle")
            {
                return true;
            }
            if (mouse[MouseButton.LastButton] && button == "last")
            {
                return true;
            }
            if (mouse[MouseButton.Button1] && button == "button1")
            {
                return true;
            }
            if (mouse[MouseButton.Button2] && button == "button2")
            {
                return true;
            }
            if (mouse[MouseButton.Button3] && button == "button3")
            {
                return true;
            }
            if (mouse[MouseButton.Button4] && button == "button4")
            {
                return true;
            }
            if (mouse[MouseButton.Button5] && button == "button5")
            {
                return true;
            }
            if (mouse[MouseButton.Button6] && button == "button6")
            {
                return true;
            }
            if (mouse[MouseButton.Button7] && button == "button7")
            {
                return true;
            }
            if (mouse[MouseButton.Button8] && button == "button8")
            {
                return true;
            }
            if (mouse[MouseButton.Button9] && button == "button9")
            {
                return true;
            }

            return false;
        }

        private float[] GetDeltaMouseThisFrame()
        {
            now = Mouse.GetState();
            int xdelta, ydelta, zdelta;

            xdelta = now.X - prev.X;
            ydelta = now.Y - prev.Y;
            zdelta = now.Wheel - prev.Wheel;

            prev = now;
            deltamouse[0] = xdelta;
            deltamouse[1] = ydelta;
            deltamouse[2] = zdelta;

            return deltamouse;
        }
        public float[] GetDeltaMousePosition()
        {
            return deltaMouse;
        }

        public int GetMouseX()
        {
            return game.Mouse.X;
        }
        public int GetMouseY()
        {
            return game.Mouse.Y;
        }

        public float GetMouseXGrid()
        {
            return game.grid.TranslateScreenGridX(game.Mouse.X);
        }
        public float GetMouseYGrid()
        {
            return game.grid.TranslateScreenGridX(game.Mouse.Y);
        }

        public string GetMouseDevice()
        {
            return game.Mouse.Description + " , " +
                    game.Mouse.DeviceID + " , " +
                    game.Mouse.DeviceType;
        }
        public void lockMouse(bool locked, double x = 0, double y = 0)
        {
            if (locked)
            {
                lockx = x;
                locky = y;
            }
            else
            {
                lockx = -1;
                locky = -1;
            }
        }
    }
}
