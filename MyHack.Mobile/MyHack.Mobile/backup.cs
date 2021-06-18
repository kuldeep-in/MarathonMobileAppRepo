using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHack.Mobile
{
    class backup
    {
    }
}

// Build the page.
//this.Content = new StackLayout
//{
//    Children =
//    {
//        createButton,
//        lbl1,
//        lbl2,
//        listView
//        //button,
//        //label
//    }
//};

//private Layout BuildView()
//{
//    StackLayout stackHeaderInv = new StackLayout()
//    {
//        Padding = new Thickness(0, 10),
//        HorizontalOptions = LayoutOptions.FillAndExpand,
//        BackgroundColor = Color.Gray,
//    };

//    Button btnComplete = new Button();

//    StackLayout stackAll = new StackLayout()
//    {
//        Padding = 0,
//        Spacing = 0,
//        Children =
//                { stackHeaderInv, btnComplete }
//    };

//    return stackAll;
//}


//MyScheduleInformation myScheduleInformation = new MyScheduleInformation();
//myScheduleInformation.TargetEvent = "TE1";
//myScheduleInformation.TrainingPlan = "TP1";
//myScheduleInformation.MyScheduleList = new List<PersonalSchedule>();
//myScheduleInformation.MyScheduleList.Add(new PersonalSchedule { Id = 1, Week = "W1", Date = "12-12-2016", Workout = "W1D1" });
//myScheduleInformation.MyScheduleList.Add(new PersonalSchedule { Id = 2, Week = "W1", Date = "13-12-2016", Workout = "W1D2" });

//BindingContext = myScheduleInformation;
//InitializeComponent();

//Label lbl1 = new Label
//{
//    Text = GlobalVariables.MyScheduleInformation.TargetEvent
//};

//Label lbl2 = new Label
//{
//    Text = GlobalVariables.MyScheduleInformation.TrainingPlan
//};

//DataTemplate datatemplate = new DataTemplate(() =>
//{
//    var button = new Button();
//    button.SetBinding(Button.TextProperty, new Binding("Name"));
//    return new ViewCell { View = button };
//});

//ListView listView = new ListView
//{
//    ItemsSource = GlobalVariables.MyScheduleInformation.MyScheduleList,
//    HasUnevenRows = true,
//    RowHeight = -1,
//    ItemTemplate = new DataTemplate(() =>
//    {
//        Label titleLabel = new Label();
//        titleLabel.SetBinding(Label.TextProperty, "Workout");
//        Label titleLabel1 = new Label();
//        titleLabel1.SetBinding(Label.TextProperty, "Week");
//        Label titleLabel2 = new Label();
//        titleLabel2.SetBinding(Label.TextProperty, "Date");

//        return new ViewCell
//        {
//            View = new StackLayout
//            {
//                Padding = new Thickness(5, 5, 0, 5),
//                Orientation = StackOrientation.Horizontal,
//                Spacing = 15,
//                Children = {
//                                titleLabel,
//                                new StackLayout {
//                                    Orientation = StackOrientation.Vertical,
//                                    Spacing = 5,
//                                    Children = {
//                                        titleLabel1,
//                                        titleLabel2
//                                    }
//                                }
//                            }
//            }
//        };
//    })
//};

//Button createButton = new Button
//{
//    Text = "Create Your Plan",
//    Font = Font.SystemFontOfSize(NamedSize.Large),
//    BorderWidth = 1,
//    HorizontalOptions = LayoutOptions.Center
//};
//createButton.Clicked += CreateButton_Clicked;


//ItemsSource="{Binding Monkeys}"
//ItemDisplayBinding="Binding Name}"
//SelectedItem="0"





//    using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xamarin.Forms;

//namespace MyHack.Mobile.Helper
//{
//    public class BindablePicker : Picker
//    {
//        #region Fields

//        //Bindable property for the items source
//        public static readonly BindableProperty ItemsSourceProperty =
//            BindableProperty.Create<BindablePicker, IEnumerable>(p => p.ItemsSource, null, propertyChanged: OnItemsSourcePropertyChanged);

//        //Bindable property for the selected item
//        public static readonly BindableProperty SelectedItemProperty =
//            BindableProperty.Create<BindablePicker, object>(p => p.SelectedItem, null, BindingMode.TwoWay, propertyChanged: OnSelectedItemPropertyChanged);

//        #endregion

//        #region Properties

//        /// <summary>
//        /// Gets or sets the items source.
//        /// </summary>
//        /// <value>
//        /// The items source.
//        /// </value>
//        public IEnumerable ItemsSource
//        {
//            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
//            set { SetValue(ItemsSourceProperty, value); }
//        }

//        /// <summary>
//        /// Gets or sets the selected item.
//        /// </summary>
//        /// <value>
//        /// The selected item.
//        /// </value>
//        public object SelectedItem
//        {
//            get { return GetValue(SelectedItemProperty); }
//            set { SetValue(SelectedItemProperty, value); }
//        }

//        #endregion

//        #region Methods

//        /// <summary>
//        /// Called when [items source property changed].
//        /// </summary>
//        /// <param name="bindable">The bindable.</param>
//        /// <param name="value">The value.</param>
//        /// <param name="newValue">The new value.</param>
//        private static void OnItemsSourcePropertyChanged(BindableObject bindable, IEnumerable value, IEnumerable newValue)
//        {
//            var picker = (BindablePicker)bindable;
//            var notifyCollection = newValue as INotifyCollectionChanged;
//            if (notifyCollection != null)
//            {
//                notifyCollection.CollectionChanged += (sender, args) =>
//                {
//                    if (args.NewItems != null)
//                    {
//                        foreach (var newItem in args.NewItems)
//                        {
//                            picker.Items.Add((newItem ?? "").ToString());
//                        }
//                    }
//                    if (args.OldItems != null)
//                    {
//                        foreach (var oldItem in args.OldItems)
//                        {
//                            picker.Items.Remove((oldItem ?? "").ToString());
//                        }
//                    }
//                };
//            }

//            if (newValue == null)
//                return;

//            picker.Items.Clear();

//            foreach (var item in newValue)
//                picker.Items.Add((item ?? "").ToString());
//        }

//        /// <summary>
//        /// Called when [selected item property changed].
//        /// </summary>
//        /// <param name="bindable">The bindable.</param>
//        /// <param name="value">The value.</param>
//        /// <param name="newValue">The new value.</param>
//        private static void OnSelectedItemPropertyChanged(BindableObject bindable, object value, object newValue)
//        {
//            var picker = (BindablePicker)bindable;
//            if (picker.ItemsSource != null)
//                picker.SelectedIndex = picker.ItemsSource.IndexOf(picker.SelectedItem);
//        }

//        #endregion
//    }

//    public static class EnumerableExtensions
//    {
//        /// <summary>
//        /// Returns the index of the specified object in the collection.
//        /// </summary>
//        /// <param name="self">The self.</param>
//        /// <param name="obj">The object.</param>
//        /// <returns>If found returns index otherwise -1</returns>
//        public static int IndexOf(this IEnumerable self, object obj)
//        {
//            int index = -1;

//            var enumerator = self.GetEnumerator();
//            enumerator.Reset();
//            int i = 0;
//            while (enumerator.MoveNext())
//            {
//                if (enumerator.Current == obj)
//                {
//                    index = i;
//                    break;
//                }

//                i++;
//            }

//            return index;
//        }
//    }

//}
