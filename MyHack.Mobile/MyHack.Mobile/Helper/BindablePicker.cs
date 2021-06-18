using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using Xamarin.Forms;

namespace MyHack.Mobile.Helper
{
    public class BindablePicker : Picker
    {
        public BindablePicker()
        {
            this.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindablePicker, IList>(o => o.ItemsSource, default(IList), propertyChanged: OnItemsSourceChanged);

        public static BindableProperty SelectedItemProperty =
            BindableProperty.Create<BindablePicker, object>(o => o.SelectedItem, default(object));


        public string DisplayMember { get; set; }

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemProperty, value);
                UpdateSelected();
            }
        }

        public static void OnItemsSourceChanged(BindableObject bindable, IList oldvalue, IList newvalue)
        {
            var picker = bindable as BindablePicker;

            if (picker != null)
            {
                picker.Items.Clear();
                if (newvalue == null) return;

                foreach (var item in newvalue)
                {
                    if (string.IsNullOrEmpty(picker.DisplayMember))
                    {
                        picker.Items.Add(item.ToString());
                    }
                    else
                    {
                        var type = item.GetType();
                        var json = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(item));
                        picker.Items.Add(json[picker.DisplayMember].ToString());

                        //var propertyValue = type.GetRuntimeField(picker.DisplayMember).GetValue(item);
                        //picker.Items.Add(prop.GetValue(item).ToString());
                    }
                }
                picker.UpdateSelected();
            }
        }

        private void UpdateSelected()
        {
            if (ItemsSource != null)
            {
                if (ItemsSource.Contains(SelectedItem))
                {
                    SelectedIndex = ItemsSource.IndexOf(SelectedItem);
                }
                else
                {
                    SelectedIndex = -1;
                }
            }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = null;
            }
            else
            {
                SelectedItem = ItemsSource[SelectedIndex];
            }
        }
    }
}
