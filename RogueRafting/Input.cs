using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;

namespace RogueRafting
{
    internal class Input
    {
        private const float ANALOG_SENSITIVITY = 0.2F;

        // main buttons
        public static bool A = false;
        public static bool X = false;
        public static bool Y= false;
        public static bool B = false;

        // bumpers
        public static bool LEFT_BUMPER = false;
        public static bool RIGHT_BUMPER = false;

        // triggers
        public static float LEFT_TRIGGER_FLOAT = 0F;
        public static float RIGHT_TRIGGER_FLOAT = 0F;

        // analog stick vector2s
        public static Vector2 LEFT_ANALOG_VECTOR2 = new Vector2(0,0);
        public static Vector2 RIGHT_ANALOG_VECTOR2 = new Vector2(0,0);

        // directional booleans for analog sticks
        public static bool LEFT_ANALOG_UP = false;
        public static bool LEFT_ANALOG_DOWN = false;
        public static bool LEFT_ANALOG_LEFT = false;
        public static bool LEFT_ANALOG_RIGHT = false;

        public static bool RIGHT_ANALOG_UP = false;
        public static bool RIGHT_ANALOG_DOWN = false;
        public static bool RIGHT_ANALOG_LEFT = false;
        public static bool RIGHT_ANALOG_RIGHT = false;

        public static void getInput()
        {
            captureControllerInput();
            captureKeyboardInput();
            captureMouseInput();
        }

        private static void captureKeyboardInput()
        {

        }

        private static void captureMouseInput()
        {

        }

        private static void captureControllerInput()
        {
            captureMainButtons();
            captureBumpers();
            captureTriggers();
            captureAnalogStickVectors();
            captureAnalogStickBooleans();
        }

        private static void captureMainButtons()
        {
            A = GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.T);
            X = GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.X);
            Y = GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Y);
            B = GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.R);
        }
        private static void captureBumpers()
        {
            LEFT_BUMPER = GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder == ButtonState.Pressed;
            RIGHT_BUMPER = GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed;
        }

        private static void captureTriggers()
        {
            LEFT_TRIGGER_FLOAT = GamePad.GetState(PlayerIndex.One).Triggers.Left;
            RIGHT_TRIGGER_FLOAT = GamePad.GetState(PlayerIndex.One).Triggers.Right;
        }

        private static void captureAnalogStickVectors()
        {
            LEFT_ANALOG_VECTOR2 = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            RIGHT_ANALOG_VECTOR2 = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right;
        }

        private static void captureAnalogStickBooleans()
        {
            LEFT_ANALOG_UP = LEFT_ANALOG_VECTOR2.Y > ANALOG_SENSITIVITY;
            LEFT_ANALOG_DOWN = LEFT_ANALOG_VECTOR2.Y < ANALOG_SENSITIVITY;
            LEFT_ANALOG_LEFT = LEFT_ANALOG_VECTOR2.X < ANALOG_SENSITIVITY;
            LEFT_ANALOG_RIGHT = LEFT_ANALOG_VECTOR2.X > ANALOG_SENSITIVITY;

            RIGHT_ANALOG_UP = RIGHT_ANALOG_VECTOR2.Y > ANALOG_SENSITIVITY; 
            RIGHT_ANALOG_DOWN = RIGHT_ANALOG_VECTOR2.Y < ANALOG_SENSITIVITY; 
            RIGHT_ANALOG_LEFT = RIGHT_ANALOG_VECTOR2.X < ANALOG_SENSITIVITY; 
            RIGHT_ANALOG_RIGHT = RIGHT_ANALOG_VECTOR2.X > ANALOG_SENSITIVITY; 
        }

        public static void log()
        {
            Debug.WriteLine("A : " + A);
            Debug.WriteLine("X : " + X);
            Debug.WriteLine("Y : " + Y);
            Debug.WriteLine("B : " + B);
            Debug.WriteLine("LEFT_BUMPER : " + LEFT_BUMPER);
            Debug.WriteLine("RIGHT_BUMPER : " +  RIGHT_BUMPER);
            Debug.WriteLine("LEFT_TRIGGER : " + LEFT_TRIGGER_FLOAT);
            Debug.WriteLine("RIGHT_TRIGGER : " + RIGHT_TRIGGER_FLOAT);
            Debug.WriteLine("LEFT_ANALOG : " + LEFT_ANALOG_VECTOR2);
            Debug.WriteLine("RIGHT_ANALOG : " + RIGHT_ANALOG_VECTOR2);
        }

    }
}
