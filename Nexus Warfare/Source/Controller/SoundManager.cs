using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Controller
{
    public class SoundManager
    {
        private Dictionary<string, SoundEffect> soundEffects;

        public SoundManager()
        { 
            soundEffects = new Dictionary<string, SoundEffect>();
        }

        public void LoadSound(ContentManager content, string assetName, string soundName)
        {
            SoundEffect soundEffect = content.Load<SoundEffect>(assetName);
            soundEffects[soundName] = soundEffect;
        }

        public void PlaySound(string soundName)
        {
            if (soundEffects.ContainsKey(soundName))
            {
                soundEffects[soundName].Play();
            }
        }
    }

}
