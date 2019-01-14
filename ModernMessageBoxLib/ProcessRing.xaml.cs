using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace ModernMessageBoxLib
{

    internal partial class ProcessRing
    {
        private Storyboard _trans;

        public ProcessRing()
        {
            InitializeComponent();
            _trans = Resources["Trans"] as Storyboard;
            Loaded += (sender, e) => Active();
        }

        private async void Active()
        {
            //e1.BeginStoryboard(_trans);
            //await Task.Delay(100);
            e2.BeginStoryboard(_trans);
            await Task.Delay(170);
            e3.BeginStoryboard(_trans);
            await Task.Delay(170);
            e4.BeginStoryboard(_trans);
            await Task.Delay(170);
            e5.BeginStoryboard(_trans);
            await Task.Delay(170);
            e6.BeginStoryboard(_trans);
        }
    }
}