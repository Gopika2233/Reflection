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
using Windows.Globalization.DateTimeFormatting;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using WinRTXamlToolkit.Input;
using WinRTXamlToolkit.IO.Serialization;
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
            public DateTime Manufacturedate { get; set; }
            public string Color { get; set; }
        }
        IList<SmartPhone> list = new List<SmartPhone>();
        IList<TokenItemSelectedValues> objTokensList = new List<TokenItemSelectedValues>();
        private void Apply_Click(object sender, RoutedEventArgs e)
        {

            list.Add(new SmartPhone() { Model = "IPhone 11", Memory = 40, Price = 80000, Company = "Apple", Color = "green",Manufacturedate= new DateTime(2010, 3, 1) });
            list.Add(new SmartPhone() { Model = "IPhone 12", Memory = 40, Price = 80000, Company = "Apple", Color = "blue",Manufacturedate=new DateTime(1999,5,10) });
            list.Add(new SmartPhone() { Model = "IPhone 13", Memory = 40, Price = 80000, Company = "Apple", Color = "green", Manufacturedate=new DateTime(2005,03,18) });
            list.Add(new SmartPhone() { Model = "jio", Memory = 20, Price = 60000, Company = "Reliance", Color = "yellow", Manufacturedate = new DateTime(2010, 3, 31)
            });
    ;
            list.Add(new SmartPhone() { Model = "Redme 11", Memory = 64, Price = 85000, Company = "Xiaomi", Color = "black", Manufacturedate=new DateTime(1998,01,24) });
            list.Add(new SmartPhone() { Model = "Realme 1", Memory = 36, Price = 1000, Company = "Oppo", Color = "orange", Manufacturedate= new DateTime(2010, 3, 31) });
            list.Add(new SmartPhone() { Model = "Realme 1", Memory = 36, Price = 5000, Company = "Oppo", Color = "BROWN",Manufacturedate= new DateTime(1999, 5, 10) });
            list.Add(new SmartPhone() { Model = "Realme N", Memory = 36, Price = 3000, Company = "Oppo", Color = "violet",Manufacturedate = new DateTime(2010, 3, 31) });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung", Color = "pink",Manufacturedate= new DateTime(2010, 7, 31) });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black",Manufacturedate = new DateTime(2010, 3, 31) });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black",Manufacturedate=new DateTime(1998,01,24) });
            list.Add(new SmartPhone() { Model = "Samsung 2", Memory = 36, Price = 3000, Company = "Samsung1", Color = "black",Manufacturedate = new DateTime(2010, 8, 31) });

            Type type = typeof(SmartPhone);
            string comboBoxItemText = colorComboBox.SelectedItem.ToString();
            

            PropertyInfo[] props = type.GetProperties();

            var result = props
                .ToDictionary(prop => prop.Name,
                    prop => list.GroupBy(item => prop.GetValue(item, null))
                        .ToDictionary(group => group.Key, group => group.Count()));
            var meta = result.Select(pair => pair.Key).Distinct().ToList();


            var resul = result.SelectMany(item => item.Value.Where(s =>item.Key.ToString()==comboBoxItemText).ToList());
            //var uniqueMonthYears = resul
            //                         .Select(my => new DateTime(my.Value.Year, my.Key.Month, 1));
            //var res = resul.Select(item => item.Key.Containskey(DateTime.Now.ToString()).ToList());
            var results = resul.GroupBy(x => x.Key).Select(g => g.First()).ToList();

            foreach (var item in resul)
            {
                var re = resul.Select(s => item.Key).Distinct().ToList();
                //var msr=res.Select(s=>item.Key=DateTime.DaysInMonth)

                TokenItemSelectedValues objToken = new TokenItemSelectedValues();
                objToken.DisplayItem = item.ToString();
                objToken.ValueItem = Convert.ToString(item.Value);
                objTokensList.Add(objToken);
                (PieChart.Series[0] as PieSeries).ItemsSource = objTokensList;
                pie.IndependentValuePath = "DisplayItem";
                pie.DependentValuePath = "ValueItem";

            }

            }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {

                     objTokensList.Clear();
            (PieChart.Series[0] as PieSeries).ItemsSource = null;

        }
    } 
    }










































//.ToDictionary(k => k.s, v => v.Value);




















