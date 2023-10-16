using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace WeatherApp.UserContols
{
    /// <summary>
    /// Interaction logic for CardDay.xaml
    /// </summary>
    public partial class CardDay : UserControl
    {
        public CardDay()
        {
            InitializeComponent();
        }

        /*hwn 3m ye3mal control jdid, 3imilloh l xaml bas lma3lomet libadha ten7at 3ala hl control (ta2s(min,max) , lsora ...) hwdi
        hydi bnd yed5lo w2t 2e3mal instances min hal control fabyijo ka attributes(properties) mit l x:Name propert...
        hl2 la7atta we3mal hyk properties (attributes) bi3mal bil c# file tb3 hal control ljdid, variables nw3on public static readonly DependencyProperty
        wbista3mel hal method DependencyProperty.Register("2ism_lattribute(lproperty)_kif_baddi_ykon",nw3 lvalue tb3 hl property: typeof(..), nw3 lowner tb3 hl property: typeof(control_name) );
        *********************************************************
        be3mal getter w setter lal variable (lget bit3ayet la method GetValue 3ala lobject min nw3 DependencyProperty m3 cast sho nw3 lvalue, wil set bit3ayet la method SetValue 3ala lobject min nw3 DependencyProperty

        ye3ni l string Day (be3maloh nfs 2ism lattribute (property) hwn howi variable m3 getters wsetters 3m 7awelhom la yishti8li 3ala variable lproperty
        hl2 bil xaml tb3 hl control matra7 ma */
        public static readonly DependencyProperty DayProperty = DependencyProperty.Register("Day", typeof(string), typeof(CardDay)); //5l2t property 2ismha Day, lvalue nw3oh string, teb3a lal control CardDay

        public string Day //variable 2ismoh 2ism lproperty, wl getter wl setter bitraje3 value lproperty li wynha bil read only DependercyProperty object
        {
            get { return (String)GetValue(DayProperty); } //btista3mel l GetValue method lihiyyi
            set { SetValue(DayProperty, value); }

        }

        public static readonly DependencyProperty MaxNumProperty = DependencyProperty.Register("MaxNum", typeof(string), typeof(CardDay));
        public string MaxNum
        {
            get { return (String)GetValue(MaxNumProperty); }
            set { SetValue(MaxNumProperty, value); }

        }

        public static readonly DependencyProperty MinNumProperty = DependencyProperty.Register("MinNum", typeof(string), typeof(CardDay));
        public string MinNum
        {
            get { return (String)GetValue(MinNumProperty); }
            set { SetValue(MinNumProperty, value); }

        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(CardDay));
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }

        }
    }
}
