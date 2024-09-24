using AudioToolbox;
using AVFoundation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MonoCross.Utilities.Notification
{
    public static class Notify
    {
        static Notify()
        {
            // Setup your session
            AVAudioSession.SharedInstance().Init();
            var outError = AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.Playback);
            if (outError != null)
            {
      
                return;
            }
            AVAudioSession.Notifications.ObserveInterruption(ToneInterruptionListener);

            if (!AVAudioSession.SharedInstance().SetActive(true, out outError))
            { 

                return;
            }
            //AudioSession.Initialize();
            //AudioSession.Category = AudioSessionCategory.MediaPlayback;
            //AudioSession.SetActive(true);
        }

        static void ToneInterruptionListener(object sender, AVAudioSessionInterruptionEventArgs interruptArgs)
        {
            //
        }

        public static void PlaySound(string uri)
        {
            // Play the file
            var sound = SystemSound.FromFile(uri);
            sound.PlaySystemSound();
        }

        public static void Vibrate()
        {
            SystemSound.Vibrate.PlaySystemSound();
        }
    }
}