
namespace Illuminum {
    public static class IlluUtils {
        /// <summary>
        /// Converts a float to seconds. Terraria's <see cref="Terraria.Main.DoUpdate(Microsoft.Xna.Framework.GameTime)"/> method runs 60 times a second under ideal conditions.
        /// These conditions also happen to be the logic in which most logic is meant to run.
        /// </summary>
        /// <param name="f">The value in seconds.</param>
        /// <returns>Seconds in ticks. See also: <see cref="ToSeconds(int)"/></returns>
        public static float ToSeconds(this float f) =>
            f * 60;
        /// <summary>
        /// Converts an int to seconds. Terraria's <see cref="Terraria.Main.DoUpdate(Microsoft.Xna.Framework.GameTime)"/> method runs 60 times a second under ideal conditions.
        /// These conditions also happen to be the logic in which most logic is meant to run.
        /// </summary>
        /// <param name="i">The value in seconds.</param>
        /// <returns>Seconds in ticks. See also: <see cref="ToSeconds(float)"/></returns>
        public static int ToSeconds(this int i) =>
            (int)((float)i).ToSeconds();
    }
}
