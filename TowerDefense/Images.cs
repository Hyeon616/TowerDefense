using TowerDefense.Map;

namespace TowerDefense
{
    internal class Images
    {
        public static Dictionary<Maps.MapState, char> mapImages = new Dictionary<Maps.MapState, char>()
        {
         {Maps.MapState.LINE,'□' },
         {Maps.MapState.BUILD,'■' },

         {Maps.MapState.NORMALCONSONANT,'㉠' },
         {Maps.MapState.NORMALWORD,'㉮' },
         {Maps.MapState.NORMALALPHA,'ⓐ' },
         {Maps.MapState.NORMALLASOR,'①' },

         {Maps.MapState.MAGICCONSONANT,'㉡' },
         {Maps.MapState.MAGICWORD,'㉯' },
         {Maps.MapState.MAGICALPHA,'ⓑ' },
         {Maps.MapState.MAGICLASOR,'②' },

         {Maps.MapState.RARECONSONANT,'㉢' },
         {Maps.MapState.RAREWORD,'㉰' },
         {Maps.MapState.RAREALPHA,'ⓒ' },
         {Maps.MapState.RARELASOR,'③' },

         {Maps.MapState.EPICCONSONANT,'㉣' },
         {Maps.MapState.EPICWORD,'㉱' },
         {Maps.MapState.EPICALPHA,'ⓓ' },
         {Maps.MapState.EPICLASOR,'④' },

         {Maps.MapState.LEGENDCONSONANT,'㉤' },
         {Maps.MapState.LEGENDWORD,'㉲' },
         {Maps.MapState.LEGENDALPHA,'ⓔ' },
         {Maps.MapState.LEGENDLASOR,'⑤' },

         {Maps.MapState.PLAYER,'▣' },
         {Maps.MapState.ENEMY,'●' },

        };

    }
}
