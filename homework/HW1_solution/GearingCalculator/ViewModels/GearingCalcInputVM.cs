using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GearingCalculator.ViewModels
{
    public class GearingCalcInputVM
    {
        [Required]
        [Display(Name = "Wheel Circumference")]
        [Range(0,double.MaxValue)]
        public double? WheelCircumference { get; set; }

        [Required]
        [Display(Name = "Front chainring sizes")]
        [RegularExpression(@"\d+(,\d+)*",ErrorMessage = "Please enter a comma separated list of whole numbers")]
        public string FrontChainringSizes { get; set; } 

        [Required]
        [Display(Name = "Rear chainring sizes")]
        [RegularExpression(@"\d+(,\d+)*",ErrorMessage = "Please enter a comma separated list of whole numbers")]
        public string RearChainringSizes { get; set; }
        
        [Required]
        public double? Cadence { get; set; }

        public static string[] Units = new [] { "mph", "kph" };
        [Required]
        public string DisplayUnits { get; set; }
        
        public GearingCalcInputVM()
        {
            // Set some starting values
            WheelCircumference = 2111.5;
            FrontChainringSizes = "30,46";
            RearChainringSizes = "11,12,15,17,19,21,23,25,27,30,34";
            Cadence = 90;
            DisplayUnits = Units[1];
        }

        public IEnumerable<int> FrontChainringValues()
        {
            // Either the split or parse could throw an exception
            string[] arr = FrontChainringSizes.Split(',');
            return arr.Select(v => Int32.Parse(v)).OrderBy(v => v).ToList();
        }

        public IEnumerable<int> RearChainringValues()
        {
            // Either the split or parse could throw an exception
            string[] arr = RearChainringSizes.Split(',');
            return arr.Select(v => Int32.Parse(v)).OrderBy(v => v).ToList();
        }

        public double Speed(int frontCog, int rearCog)
        {
            double speed = Cadence.Value * ((double)frontCog / rearCog) * WheelCircumference.Value * 60 / 1e6;
            if(DisplayUnits.Equals("mph"))
            {
                speed = speed / 1.609; 
            }
            return speed;
        }

        public double MinSpeed()
        {
            return Speed(FrontChainringValues().First(),RearChainringValues().Last());
        }

        public double MaxSpeed()
        {
            return Speed(FrontChainringValues().Last(),RearChainringValues().First());
        }
    }
}