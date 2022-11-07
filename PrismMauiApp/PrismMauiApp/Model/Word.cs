using PrismMauiApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMauiApp.Model
{
    public class Word : Notifier
    {
        public int Id { get; }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    Notify();
                }

            }
        }
        private string? translate;
        public string? Translate
        {
            get => translate;
            set
            {
                if (value != translate)
                {
                    translate = value;
                    Notify();
                }

            }
        }

        private string? descriptions;
        public string? Descriptions
        {
            get => descriptions;
            set
            {
                if (value != descriptions)
                {
                    descriptions = value;
                    Notify();
                }

            }
        }
        private string? transcription;
        public string? Transcription
        {
            get => transcription;
            set
            {
                if (value != transcription)
                {
                    transcription = value;
                    Notify();
                }

            }
        }

        private bool isVisible = false;
        public bool IsVisible
        {
            get => isVisible;
            set
            {
                if (value != isVisible)
                {
                    isVisible = value;
                    Notify();
                }

            }
        }
    }
}
