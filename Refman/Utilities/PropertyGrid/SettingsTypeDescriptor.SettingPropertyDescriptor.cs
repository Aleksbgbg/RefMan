namespace Refman.Utilities.PropertyGrid
{
    using System;
    using System.ComponentModel;

    using Refman.Models.Settings;

    using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

    internal partial class SettingsTypeDescriptor
    {
        private sealed class SettingPropertyDescriptor : PropertyDescriptor
        {
            private readonly Setting _setting;

            public SettingPropertyDescriptor(Setting setting) : base(setting.Name, null)
            {
                if (setting.Editor != null)
                {
                    AttributeArray = new Attribute[] { new EditorAttribute(setting.Editor, typeof(ITypeEditor)) };
                }

                _setting = setting;
            }

            public override string DisplayName => _setting.Name;

            public override string Description => _setting.Description;

            public override Type ComponentType => null;

            public override bool IsReadOnly => false;

            public override Type PropertyType => _setting.Value.GetType();

            public override bool CanResetValue(object component)
            {
                return true;
            }

            public override object GetValue(object component)
            {
                return _setting.Value;
            }

            public override void ResetValue(object component)
            {
                _setting.ResetValue();
            }

            public override void SetValue(object component, object value)
            {
                _setting.Value = value;
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }
    }
}