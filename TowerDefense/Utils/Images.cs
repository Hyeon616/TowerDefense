using TowerDefense.Map;

namespace TowerDefense.Utils
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
         {Maps.MapState.NORMALNUMBER,'①' },

         {Maps.MapState.MAGICCONSONANT,'㉡' },
         {Maps.MapState.MAGICWORD,'㉯' },
         {Maps.MapState.MAGICALPHA,'ⓑ' },
         {Maps.MapState.MAGICNUMBER,'②' },

         {Maps.MapState.RARECONSONANT,'㉢' },
         {Maps.MapState.RAREWORD,'㉰' },
         {Maps.MapState.RAREALPHA,'ⓒ' },
         {Maps.MapState.RARENUMBER,'③' },

         {Maps.MapState.EPICCONSONANT,'㉣' },
         {Maps.MapState.EPICWORD,'㉱' },
         {Maps.MapState.EPICALPHA,'ⓓ' },
         {Maps.MapState.EPICNUMBER,'④' },

         {Maps.MapState.LEGENDCONSONANT,'㉤' },
         {Maps.MapState.LEGENDWORD,'㉲' },
         {Maps.MapState.LEGENDALPHA,'ⓔ' },
         {Maps.MapState.LEGENDNUMBER,'⑤' },

         {Maps.MapState.PLAYER,'▣' },
         {Maps.MapState.ENEMY,'●' },

        {Maps.MapState.MISSION1,'★' },
        {Maps.MapState.MISSION2,'▩' },
        {Maps.MapState.MISSION3,'◈' },
        {Maps.MapState.MISSION4,'㉿' },

        };

    }
}
