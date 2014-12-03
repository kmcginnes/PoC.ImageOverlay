using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace PoC.ImageOverlay
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            RecordedEvents = new ReactiveList<RecordedEvent>();

            var thumbnails = Directory.EnumerateFiles(@"C:\WatchGuardVideo\Videos", "*.jpg", SearchOption.AllDirectories);

            foreach (var thumbnail in thumbnails)
            {
                var recordedEvent = new RecordedEvent
                {
                    Path = thumbnail,
                    FileName = Path.GetFileName(thumbnail),
                };
                RecordedEvents.Add(recordedEvent);
            }
        }

        public ReactiveList<RecordedEvent> RecordedEvents { get; }
    }

    public class RecordedEvent : ReactiveObject
    {
        string _path;
        public string Path
        {
            get { return _path; }
            set { this.RaiseAndSetIfChanged(ref _path, value); }
        }

        string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { this.RaiseAndSetIfChanged(ref _fileName, value); }
        }
    }
}
