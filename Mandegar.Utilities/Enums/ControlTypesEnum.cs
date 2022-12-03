using System.ComponentModel;

namespace Mandegar.Utilities.Enums
{
    public enum ControlTypesEnum
    {
        [Description("TextBox")]
        text,

        [Description("TextArea")]
        textarea,

        [Description("Number")]
        number,

        [Description("CheckBox")]
        checkbox,

        [Description("Radio")]
        radio,

        [Description("CheckBoxList")]
        checkboxlist,

        [Description("Datepicker")]
        datetime_local,

        [Description("TimePicker")]
        time,

        [Description("RangeDatePicker")]
        rangeDatePicker,

        [Description("Dropdown")]
        select,
    }
}
