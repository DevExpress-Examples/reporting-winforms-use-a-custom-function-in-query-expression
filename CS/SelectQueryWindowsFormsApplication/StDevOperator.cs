using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;


namespace SelectQueryWindowsFormsApplication {
    public sealed class StDevOperator : ICustomFunctionOperatorBrowsable, ICustomFunctionOperatorFormattable {
        const string name = "StDev";

        public static void Register() {
            CriteriaOperator.RegisterCustomFunction(new StDevOperator());
        }

        public static void Unregister() {
            CriteriaOperator.UnregisterCustomFunction(name);
        }

        public static readonly HashSet<Type> ValidOperandTypes = new HashSet<Type> {
            typeof(sbyte),
            typeof(byte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(double),
            typeof(float)
        };

        #region Implementation of ICustomFunctionOperator

        public Type ResultType(params Type[] operands) {
            return typeof(double);
        }

        public object Evaluate(params object[] operands) {
            throw new NotSupportedException();
        }

        public string Name { get { return name; } }

        #endregion

        #region Implementation of ICustomFunctionOperatorBrowsable

        public FunctionCategory Category { get { return FunctionCategory.Math; } }

        public string Description { get { return "Standard deviation function"; } }

        public bool IsValidOperandCount(int count) {
            return count == 1;
        }

        public bool IsValidOperandType(int operandIndex, int operandCount, Type type) {
            return ValidOperandTypes.Contains(type);
        }

        public int MaxOperandCount { get { return 1; } }

        public int MinOperandCount { get { return 1; } }

        #endregion

        #region Implementation of ICustomFunctionOperatorFormattable

        public string Format(Type providerType, params string[] operands) {
            return string.Format("stdev({0})", operands[0]);
        }

        #endregion
    }
}
