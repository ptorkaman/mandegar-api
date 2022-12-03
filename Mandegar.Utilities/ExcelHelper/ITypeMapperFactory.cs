using System;

namespace Mandegar.Utilities.ExcelHelper
{
    public interface ITypeMapperFactory
    {
        TypeMapper Create(Type type);

        TypeMapper Create(object o);
    }
}