using System.Numerics;
using Raylib_cs;
using GameFunctions;

public static class Program {

    public static void Main() {

        int screenWidth = 800;
        int screenHeight = 450;
        Raylib.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");
        Vector2 center  = new Vector2(screenWidth, screenHeight) / 2;

        Vector2 startPos = center;
        Vector2 endPos = center + new Vector2(100, 0);
        float time = 0.0f;
        float duration = 2f;

        while (!Raylib.WindowShouldClose()) {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            float dt = Raylib.GetFrameTime();
            time += dt;
            if (time > duration) {
                time = duration;
            }

            if (Raylib.IsKeyDown(KeyboardKey.Space)) {
                time = 0.0f;
            }

            // draw start line and end line, total two lines
            Raylib.DrawLineV(startPos - new Vector2(0, screenHeight / 2), startPos + new Vector2(0, screenHeight / 2), Color.Black);
            Raylib.DrawLineV(endPos - new Vector2(0, screenHeight / 2), endPos + new Vector2(0, screenHeight / 2), Color.Black);

            // ==== Easing ====
            // - Linear
            Vector2 tmpStart = startPos;
            Vector2 tmpEnd = endPos;
            Vector2 pos1 = GFEasing.Ease2D(GFEasingEnum.Linear, time, duration, tmpStart, tmpEnd);
            Raylib.DrawCircleV(pos1, 20, Color.Blue);

            // - Sine
            tmpStart = startPos - new Vector2(0, 100);
            tmpEnd = endPos - new Vector2(0, 100);
            Vector2 pos2 = GFEasing.Ease2D(GFEasingEnum.OutSine, time, duration, tmpStart, tmpEnd);
            Raylib.DrawCircleV(pos2, 20, Color.Red);

            // - Elastic
            tmpStart = startPos - new Vector2(0, 200);
            tmpEnd = endPos - new Vector2(0, 200);
            Vector2 pos3 = GFEasing.Ease2D(GFEasingEnum.OutElastic, time, duration, tmpStart, tmpEnd);
            Raylib.DrawCircleV(pos3, 20, Color.Green);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();

    }

}