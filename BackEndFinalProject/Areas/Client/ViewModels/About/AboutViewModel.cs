using BackEndFinalProject.Areas.Client.ViewModels.Home.Index;
using Org.BouncyCastle.Bcpg;

namespace BackEndFinalProject.Areas.Client.ViewModels.About
{
    public class AboutViewModel
    {
        public List<ListAboutViewModel> Abouts { get; set; }
        public List<PaymmentLIstItemViewModel> Payments { get; set; }
        public List<RewardLIstItemViewModel> Rewards { get; set; }
    }
}
