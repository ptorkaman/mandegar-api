using System;

namespace Mandegar.Utilities.ExcelHelper.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public sealed class ColumnAttribute : Attribute
    {
        readonly string name = null;
        int index = -1;
        readonly MappingDirections directions;

        public ColumnAttribute(string name, MappingDirections directions = MappingDirections.Both)
        {
            this.name = name;
            this.directions = directions;
        }

        public ColumnAttribute(int index, MappingDirections directions = MappingDirections.Both)
        {
            this.index = index;
            this.directions = directions;
        }

        public ColumnAttribute(MappingDirections directions = MappingDirections.Both)
        {
            this.directions = directions;
        }

        public MappingDirections Directions => directions;

        public string Name => name;

        public int Index => index;

        public string Letter
        {
            get => Map.IndexToLetter(Index);
            set => index = Map.LetterToIndex(value);
        }
    }
}
