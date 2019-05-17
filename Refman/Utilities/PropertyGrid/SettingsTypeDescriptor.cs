namespace Refman.Utilities.PropertyGrid
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Refman.Models.Settings;

    internal partial class SettingsTypeDescriptor : CustomTypeDescriptor
    {
        private readonly Setting[] _settings;

        public SettingsTypeDescriptor(Setting[] settings)
        {
            _settings = settings;
        }

        public override PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptor[] properties = _settings.Select(setting => new SettingPropertyDescriptor(setting))
                                                       .Cast<PropertyDescriptor>()
                                                       .ToArray();

            return new PropertyDescriptorCollection(properties);
        }

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public override object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
}