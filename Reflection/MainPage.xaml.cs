using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using WinRTXamlToolkit.Input;
using WinRTXamlToolkit.Tools;
using static Reflection.MainPage;
using static System.Net.Mime.MediaTypeNames;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Reflection
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 





    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }
        public class SmartPhone
        {
            public string Model { get; set; }
            public int Price { get; set; }
            public int Memory { get; set; }

            public string Company { get; set; }
            public string Color { get; set; }


        }
        public class FilterOption
        {

            public bool IsSelected { get; set; }
        }
        public class FilterOptionSet
        {
            public string Heading { get; set; }
            public string FieldName { get; set; }
            public List<FilterOption> FilterOptions { get; set; }
        }
        public List<FilterField> FilterFields { get; set; }

        IList<SmartPhone> list = new List<SmartPhone>();
        private Type itemType;
        public List<FilterField> FieldNames { get; set; }
        public List<FilterOptionSet> AllFilters { get; private set; }
        public IList AllItems { get; set; }
        IList<TokenItemSelectedValues> objTokensList = new List<TokenItemSelectedValues>();

        public void showfilter()
        {
            new List<FilterField>
            {
                    new FilterField { InternalValue =nameof(SmartPhone.Color), DisplayValue="Color"},
 new FilterField { InternalValue =nameof(SmartPhone.Company) , DisplayValue="Company"},
 new FilterField { InternalValue = nameof(SmartPhone.Model), DisplayValue = "Model" },
            };

        }
        //public void LoadAsync()
        //
        //    if (FilterFields?.Count < 1) return;
        //    AllFilters = new List<FilterOptionSet>();

        //    foreach (var field in list)
        //    {
        //        var filters = GetFilterValues(field.InternalValue, AllItems);
        //        if (filters.Count > 0) //TODO: Review if this condition should be done for 1 item also
        //        {
        //            AllFilters.Add(new FilterOptionSet { Heading = field.DisplayValue, FieldName = field.InternalValue, FilterOptions = filters });
        //        });
        //    }
        //} 

        //private List<SmartPhone> GetFilterValues(string fieldName, IList list)
        //{


        //    list.Add(new SmartPhone() { Model = "IPhone 11", Memory = 40, Price = 80000, Company = "Apple", Color = "green" });
        //    list.Add(new SmartPhone() { Model = "IPhone 12", Memory = 40, Price = 80000, Company = "Apple", Color = "blue" });
        //    list.Add(new SmartPhone() { Model = "IPhone 13", Memory = 40, Price = 80000, Company = "Apple", Color = "green" });
        //    list.Add(new SmartPhone() { Model = "jio", Memory = 20, Price = 60000, Company = "Reliance", Color = "yellow" });
        //    list.Add(new SmartPhone() { Model = "Redme 11", Memory = 64, Price = 85000, Company = "Xiaomi", Color = "black" });
        //    list.Add(new SmartPhone() { Model = "Realme 1", Memory = 36, Price = 1000, Company = "Oppo", Color = "orange" });
        //    list.Add(new SmartPhone() { Model = "Realme 1", Memory = 36, Price = 5000, Company = "Oppo", Color = "BROWN" });
        //    list.Add(new SmartPhone() { Model = "Realme N", Memory = 36, Price = 3000, Company = "Oppo", Color = "violet" });
        //    list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung", Color = "pink" });
        //    list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black" });
        //    list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black" });
        //    list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black" });
        //    var filters = new List<SmartPhone>();
        //    if (list != null)
        //        return filters;
        //    foreach (var item in list)
        //    {
        //        if (itemType == null)
        //        {
        //            itemType = item.GetType();
        //        }
        //        PropertyInfo[] props = itemType.GetProperties();


        //        foreach (var propertyInfo in typeof(SmartPhone).GetProperties())
        //        {

        //            //Console.WriteLine(propertyInfo.Name);
        //            //propertyInfo = itemType.GetProperty(props);

        //            var val = propertyInfo.GetValue(item, null)?.ToString();
        //            if (string.IsNullOrEmpty(val)) continue;
        //            //if (!filters.Any(f => f.InternalValue == val))
        //            //{
        //            //    filters.Add(new SmartPhone
        //            //    {
        //            //        DisplayValue = val,
        //            //        InternalValue = val,
        //            //    });
        //            //}



        //        }

        //    }



        //}

        private void LoadChartContents()
        {

            //LinkedHashSet<SmartPhone> UniqueList = new LinkedHashSet<SmartPhone>();
            list.Add(new SmartPhone() { Model = "IPhone 11", Memory = 40, Price = 80000, Company = "Apple", Color = "green" });
            list.Add(new SmartPhone() { Model = "IPhone 12", Memory = 40, Price = 80000, Company = "Apple", Color = "blue" });
            list.Add(new SmartPhone() { Model = "IPhone 13", Memory = 40, Price = 80000, Company = "Apple", Color = "green" });
            list.Add(new SmartPhone() { Model = "jio", Memory = 20, Price = 60000, Company = "Reliance", Color = "yellow" });
            list.Add(new SmartPhone() { Model = "Redme 11", Memory = 64, Price = 85000, Company = "Xiaomi", Color = "black" });
            list.Add(new SmartPhone() { Model = "Realme 1", Memory = 36, Price = 1000, Company = "Oppo", Color = "orange" });
            list.Add(new SmartPhone() { Model = "Realme 1", Memory = 36, Price = 5000, Company = "Oppo", Color = "BROWN" });
            list.Add(new SmartPhone() { Model = "Realme N", Memory = 36, Price = 3000, Company = "Oppo", Color = "violet" });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung", Color = "pink" });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black" });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black" });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black" });
            var data = list.Select(p => p.Color).Distinct().ToList();


            IList<TokenItemSelectedValues> objTokensList = new List<TokenItemSelectedValues>();

            foreach (var item in data)
            {
                var prioritiesList = list.Where(x => x.Company == item).Distinct();

                TokenItemSelectedValues objToken = new TokenItemSelectedValues();
                objToken.DisplayItem = item + "(" + Convert.ToString(prioritiesList.Count()) + ")";


                objToken.ValueItem = Convert.ToString(prioritiesList.Count());
                //objToken.FilteredIDs = prioritiesList.Select(o => o.Company).ToList();
                objTokensList.Add(objToken);

                (PieChart.Series[0] as PieSeries).ItemsSource = objTokensList;


            }


        }

        private static Dictionary<string, Dictionary<object, int>>
    getDistinctValues<T>(List<T> list)
        {
            var properties = typeof(T).GetProperties();

            var result = properties
                //The key of the first dictionary is the property name
                .ToDictionary(prop => prop.Name,
                    //the value is another dictionary
                    prop => list.GroupBy(item => prop.GetValue(item, null))
                        //The key of the inner dictionary is the unique property value
                        //the value if the inner dictionary is the count of that group.
                        .ToDictionary(group => group.Key, group => group.Count()));

            return result;
        }
        private void Apply_Click(object sender, RoutedEventArgs e)
        {

            list.Add(new SmartPhone() { Model = "IPhone 11", Memory = 40, Price = 80000, Company = "Apple", Color = "green" });
            list.Add(new SmartPhone() { Model = "IPhone 12", Memory = 40, Price = 80000, Company = "Apple", Color = "blue" });
            list.Add(new SmartPhone() { Model = "IPhone 13", Memory = 40, Price = 80000, Company = "Apple", Color = "green" });
            list.Add(new SmartPhone() { Model = "jio", Memory = 20, Price = 60000, Company = "Reliance", Color = "yellow" });
            list.Add(new SmartPhone() { Model = "Redme 11", Memory = 64, Price = 85000, Company = "Xiaomi", Color = "black" });
            list.Add(new SmartPhone() { Model = "Realme 1", Memory = 36, Price = 1000, Company = "Oppo", Color = "orange" });
            list.Add(new SmartPhone() { Model = "Realme 1", Memory = 36, Price = 5000, Company = "Oppo", Color = "BROWN" });
            list.Add(new SmartPhone() { Model = "Realme N", Memory = 36, Price = 3000, Company = "Oppo", Color = "violet" });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung", Color = "pink" });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black" });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black" });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black" });

            Type type = typeof(SmartPhone);
            var comboBoxItemText = colorComboBox.SelectedItem.ToString();


            PropertyInfo[] props = type.GetProperties();

            var result = props
                .ToDictionary(prop => prop.Name,
                    prop => list.GroupBy(item => prop.GetValue(item, null))
                        .ToDictionary(group => group.Key, group => group.Count()));
            var meta = result.Select(pair => pair.Key).Distinct().ToList();
            //var met = meta.Where(p => p.Key == ).Select(pair => pair.Values).ToList();
            //var resul = result.SelectMany(item => item.Value.Select(s => (s, item.Value)));
            var resul = result.SelectMany(item => item.Value.Where(s =>item.Key.ToString()==comboBoxItemText).ToList());
           
            //.ToDictionary(k => k.s, v => v.Value);
            //var data = meta.Where(p => p.Key == comboBoxItemText).Select(pair => pair.va).ToList();
            foreach (var item in resul)
            {

               var mst = result.Select(m => m.Key ==comboBoxItemText).Distinct().ToList();

                TokenItemSelectedValues objToken = new TokenItemSelectedValues();
                objToken.DisplayItem = item.ToString();
                objToken.ValueItem = Convert.ToString(resul.Count());
                objTokensList.Add(objToken);
                (PieChart.Series[0] as PieSeries).ItemsSource = objTokensList;
                pie.IndependentValuePath = "DisplayItem";
                pie.DependentValuePath = "ValueItem";

            }






            

            }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            (PieChart.Series[0] as PieSeries).ItemsSource = null;

        }
    } 
    }






        //string name = "LoadChartContents";
        //MethodInfo info = itemType.GetMethod(name);

        //var prioritiesList = props.Where(x => x.GetType());



        //MethodInfo mInfo = field.GetType().GetMethod();


        //var val = PropertyInfo.GetValue(field)?.ToString();

        //var fks = from property in props
        //          where property.GetValue(typeof(SmartPhone),null).ToString();

        //var Result = val.Distinct().ToList();

        //if (string.IsNullOrEmpty(val)) continue;
        //if (!filters.Any(f => f.InternalValue == val))
        //{
        //    filters.Add(new SmartPhone
        //    {
        //        DisplayValue = val,
        //        InternalValue = val,
        //    });
        //}

        //if (filters.Count > 0)
        //{

        //}//TODO: Review if this condition should be done for 1 item also
        //AllFilters.Add(new FilterOptionSet { Heading = field.DisplayValue, FieldName = field.InternalValue, FilterOptions = filters });
    

    
            

        
    



    

    



