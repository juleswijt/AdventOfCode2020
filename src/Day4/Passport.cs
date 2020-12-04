using System.Linq;

namespace Day4
{
    public class Passport
    {
        /// <summary> Birth Year </summary>
        public string byr { get; set; }

        /// <summary> Issue Year  </summary>
        public string iyr { get; set; }

        /// <summary> Expiration Year </summary>
        public string eyr { get; set; }

        /// <summary> Height </summary>
        public string hgt { get; set; }

        /// <summary> Hair Color </summary>
        public string hcl { get; set; }

        /// <summary> Eye Color </summary>
        public string ecl { get; set; }

        /// <summary> Passport ID </summary>
        public string pid { get; set; }

        /// <summary> Country ID </summary>
        public string cid { get; set; }
    }
}