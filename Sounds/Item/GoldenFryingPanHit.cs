using Microsoft.Xna.Framework.Audio;
using Terraria.ModLoader;

namespace Illuminum.Sounds.Item
{
	public class GoldenFryingPanHit : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		{
			// By creating a new instance, this ModSound allows for overlapping sounds. Non-ModSound behavior is to restart the sound, only permitting 1 instance.
			soundInstance = sound.CreateInstance();
			soundInstance.Volume = volume * 0.2f;
			soundInstance.Pan = pan;
			//soundInstance.Pitch = 1.0f;
			return soundInstance;
		}
	}
}