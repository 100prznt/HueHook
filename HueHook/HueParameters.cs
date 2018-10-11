using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.HueHook
{
    public enum HueParameters
    {
        [HueParameterAssignment(HueObjects.Group | HueObjects.Light | HueObjects.Scene)]
        [HueParameterType(typeof(int))]
        [HueParameterSpecification(0, 254)]
        Id,
        [HueParameterAssignment(HueObjects.Group | HueObjects.Light)]
        [HueParameterType(typeof(bool))]
        On,
        [HueParameterAssignment(HueObjects.Group | HueObjects.Light)]
        [HueParameterType(typeof(int))]
        [HueParameterSpecification(0, 65535)]
        Hue,
        [HueParameterAssignment(HueObjects.Group | HueObjects.Light)]
        [HueParameterType(typeof(int))]
        [HueParameterSpecification(0, 254)]
        Sat,
        [HueParameterAssignment(HueObjects.Group | HueObjects.Light)]
        [HueParameterType(typeof(byte))]
        [HueParameterSpecification(0, 254)]
        Bri,
        [HueParameterAssignment(HueObjects.Group | HueObjects.Light)]
        [HueParameterType(typeof(int))]
        [HueParameterSpecification(153, 500)]
        Ct
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class HueParameterAssignmentAttribute : Attribute
    {
        public HueObjects AssignTo { get; private set; }

        public HueParameterAssignmentAttribute(HueObjects assignTo)
        {
            AssignTo = assignTo;
        }
    }

    [Flags]
    public enum HueObjects
    {
        None = 0x0,
        Light = 0x1,
        Group = 0x2,
        Scene = 0x4
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class HueParameterTypeAttribute : Attribute
    {
        public Type DataType { get; private set; }

        public HueParameterTypeAttribute(Type type)
        {
            DataType = type;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class HueParameterSpecificationAttribute : Attribute
    {
        public double LowLimit { get; private set; }

        public double HighLimit { get; private set; }

        public HueParameterSpecificationAttribute(double lowLimit, double highLimit)
        {
            if (lowLimit > highLimit)
                throw new ArgumentException("Parameter lowlimit must be smaller than highlimit!");

            LowLimit = lowLimit;
            HighLimit = highLimit;
        }
    }
}
