using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf22.Views
{
    /// <summary>
    /// Логика взаимодействия для StudentEditorWindow.xaml
    /// </summary>
    public partial class StudentEditorWindow 
    {
        public static DependencyProperty FirstNameProperty = 
            DependencyProperty.Register(
                nameof(FirstName),
                typeof(string),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(string)));

        [Description("Имя")]
        public string FirstName 
        { 
            get => (string)GetValue(FirstNameProperty); 
            set => SetValue(FirstNameProperty, value); 
        }



        public static DependencyProperty LastNameProperty =
            DependencyProperty.Register(
                nameof(LastName),
                typeof(string),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(string)));

        [Description("Фамилия")]
        public string LastName { get => (string) GetValue(LastNameProperty); set => SetValue(LastNameProperty, value); }


        public static DependencyProperty PatronymicProperty =
            DependencyProperty.Register(
                nameof(Patronymic),
                typeof(string),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(string)));

        [Description("Отчество")]
        public string Patronymic { get => (string)GetValue(PatronymicProperty); set => SetValue(PatronymicProperty, value); }



        public static DependencyProperty RatingProperty = 
            DependencyProperty.Register(
                nameof(Rating),
                typeof(double),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(double)));

        [Description("Рейтинг")]
        public double Rating { get => (double)GetValue(RatingProperty); set => SetValue(RatingProperty, value); }



        public static DependencyProperty BirthDayProperty =
    DependencyProperty.Register(
        nameof(BirthDay),
        typeof(DateTime),
        typeof(StudentEditorWindow),
        new PropertyMetadata(default(DateTime)));

        [Description("Дата рождения")]
        public DateTime BirthDay { get => (DateTime)GetValue(BirthDayProperty); set => SetValue(BirthDayProperty, value); }
         


        public StudentEditorWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FirstName = "5555555555555";
        }
    }
}
