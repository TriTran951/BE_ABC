using BE_ABC.ConstValue;

namespace BE_ABC.Util
{
    public static class CheckEnumValue
    {
        public static bool checkGrade(int value)
        {
            return Enum.IsDefined(typeof(Grade), value);
        }
        public static bool checkStatusType(int value)
        {
            return Enum.IsDefined(typeof(StatusType), value);
        }
    }
}
