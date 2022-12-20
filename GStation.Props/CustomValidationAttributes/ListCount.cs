using System.ComponentModel.DataAnnotations;

namespace GStation.Core.Props.CustomValidationAttributes
{
    public class ListCount : ValidationAttribute
    {
        private int Minimum { get; set; }
        private int Maximum { get; set; }

        public ListCount(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        public override bool IsValid(object? value)
        {
            // TODO: Resolve this custom data annotation
            var list = value as List<object>;

            if (list == null || !list.Any())
            {
                return false;
            }

            return true;
        }

    }
}
