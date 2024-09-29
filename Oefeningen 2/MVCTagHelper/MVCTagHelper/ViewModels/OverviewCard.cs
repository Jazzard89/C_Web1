using MVCTagHelper.Models;

namespace MVCTagHelper.ViewModels
{
    public class OverviewCard
    {
        public List<Afdeling> Afdelingen { get; set; }
        public List<MedewerkerCard> MedewerkerCards { get; set; }

        public OverviewCard(List<Afdeling> afdelingen)
        {
            Afdelingen = afdelingen;
        }
    }
}
