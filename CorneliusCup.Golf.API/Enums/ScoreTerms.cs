namespace CorneliusCup.Golf.API.Enums
{
    public class ScoreTerms
    {
        public static readonly Tuple<string, short> NoReturn = new Tuple<string, short>("NR", 0);
        public static readonly Tuple<string, short> HoleInOne = new Tuple<string, short>("Hole In One", 1);
        public static readonly Tuple<string, short> Condor = new Tuple<string, short>("Condor", -4);
        public static readonly Tuple<string, short> Albatross = new Tuple<string, short>("Albatross", -3);
        public static readonly Tuple<string, short> Eagle = new Tuple<string, short>("Eagle", -2);
        public static readonly Tuple<string, short> Birdie = new Tuple<string, short>("Birdie", -1);
        public static readonly Tuple<string, short> Par = new Tuple<string, short>("Par", 0);
        public static readonly Tuple<string, short> Bogey = new Tuple<string, short>("Bogey", 1);
        public static readonly Tuple<string, short> DoubleBogey = new Tuple<string, short>("Double Bogey", 2);
        public static readonly Tuple<string, short> TripleBogy = new Tuple<string, short>("Triple Bogy", 3);
        public static readonly Tuple<string, short> QuadrupleBogey = new Tuple<string, short>("Quadruple Bogey", 4);

        //public static string getStringRep(short strokes, short par)
        //{
        //    // special case, player entered zero as a score, return NR
        //    if (strokes == 0)
        //    {
        //        return NoReturn;
        //    }

        //    // special case, player scored a Hole In One!
        //    if (strokes == 1)
        //    {
        //        return HoleInOne;
        //    }

        //    int nettScore = strokes - par;
        //    switch (nettScore)
        //    {
        //        case < -4: return $"{nettScore} Under {Par}";
        //        case -4: return Condor;
        //        case -3: return Albatross;
        //        case -2: return Eagle;
        //        case -1: return Birdie;
        //        case 0: return Par;
        //        case 1: return Bogey;
        //        case 2: return DoubleBogey;
        //        case 3: return TripleBogy;
        //        case 4: return QuadrupleBogey;
        //        default: return $"{nettScore} Over {Par}";
        //    }
        //}
    }
}
